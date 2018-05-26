// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:50:20
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:50:20
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace Myzj.OPC.UI.Common
{
	public class ImportFromExcel
	{
		private IWorkbook workbook;

		public event EventHandler<ImportRowEventArg> OnDataRowImporting;

		public ImportFileFormat Format
		{
			get;
			set;
		}

		public ImportFromExcel()
			: this(ImportFileFormat.CreateDefault())
		{
		}

		public ImportFromExcel(ImportFileFormat format)
		{
			this.Format = format;
		}

		/// <summary>
		/// 根据文件完整路径获取ImportResult
		/// </summary>
		/// <param name="fileName">完整路径的文件名字</param>
		/// <returns></returns>
		public ImportResult DoImport(string fileName)
		{
			ImportResult result;
			using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				result = this.DoImport(file);
			}
			return result;
		}

		/// <summary>
		/// 根据文件流得到 ImportResult
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public ImportResult DoImport(Stream stream)
		{
			ImportResult result = new ImportResult();
			try
			{
				this.workbook = WorkbookFactory.Create(stream, ImportOption.All);
				foreach (SheetFormat one in this.Format.Sheets)
				{
					if (one != null)
					{
						ISheet sheet = null;
						if (!string.IsNullOrEmpty(one.Name))
						{
							sheet = this.workbook.GetSheet(one.Name);
						}
						if (sheet == null)
						{
							sheet = this.workbook.GetSheetAt(one.Index);
						}
						if (sheet == null)
						{
							throw new ApplicationException("无法找到指定的sheet,请检查格式定义是否正确.");
						}
						SheetImportResult oneResult = this.ImportSheet(sheet, one);
						result.AddSheetResult(oneResult);
					}
				}
			}
			catch (Exception ep)
			{
				result.SetError(string.Format("导入失败:{0}", ep.Message));
				result.IsSuccess = false;
			}
			return result;
		}

		protected virtual SheetImportResult ImportSheet(ISheet sheet, SheetFormat format)
		{
			SheetImportResult result = new SheetImportResult();
			result.Name = format.Name;
			result.Index = format.Index;
			int dataColumnEnd;
			List<string> headerData = this.GetHeaderData(sheet, format, out dataColumnEnd);
			int rowIndex = format.DataRowStart;
			bool isEnd = false;
			IRow dataRow = sheet.GetRow(rowIndex);
			while (!isEnd && dataRow != null)
			{
				List<object> rowData = this.GetRowData(dataRow, format, rowIndex, dataColumnEnd);
				ImportRowEventArg arg = new ImportRowEventArg();
				arg.RowData = rowData;
				arg.HeaderData = headerData;
				arg.Format = format;
				arg.RowIndex = rowIndex;
				if (this.OnDataRowImporting != null)
				{
					this.OnDataRowImporting(this, arg);
				}
				if (arg.IsSkip)
				{
					result.IncreaseSkiped();
				}
				else if (!string.IsNullOrEmpty(arg.Error))
				{
					result.AddError(string.Format("第{0}处理失败:{1}", rowIndex, arg.Error));
				}
				else if (arg.IsSuccess)
				{
					result.IncreaseSuccess();
				}
				isEnd = arg.IsEnd;
				if (!isEnd && format.AllEmptyIsEnd && rowData == null)
				{
					isEnd = true;
				}
				if (!isEnd)
				{
					rowIndex++;
				}
				dataRow = sheet.GetRow(rowIndex);
			}
			return result;
		}

		protected virtual List<string> GetHeaderData(ISheet sheet, SheetFormat format, out int dataColumnEnd)
		{
			dataColumnEnd = 0;
			List<string> rtn = new List<string>();
			IRow row = sheet.GetRow(format.HeaderRowIndex);
			if (row == null)
			{
				throw new ApplicationException("无法找到header行");
			}
			bool hasEnd = format.DataColumnEnd.HasValue;
			if (hasEnd)
			{
				dataColumnEnd = format.DataColumnEnd.Value;
				for (int cellNum = format.DataColumnStart; cellNum <= format.DataColumnEnd; cellNum++)
				{
					ICell cell = row.GetCell(cellNum);
					string data = this.GetStringFromCell(cell);
					rtn.Add(data);
				}
			}
			else
			{
				int cellNum2 = format.DataColumnStart;
				ICell cell2 = row.GetCell(cellNum2);
				string data2 = this.GetStringFromCell(cell2);
				while (cell2 != null && !string.IsNullOrEmpty(data2))
				{
					rtn.Add(data2);
					dataColumnEnd = cellNum2;
					cellNum2++;
					cell2 = row.GetCell(cellNum2);
					data2 = this.GetStringFromCell(cell2);
				}
			}
			return rtn;
		}

		protected virtual List<object> GetRowData(IRow row, SheetFormat format, int rowIndex, int dataColumnEnd)
		{
			List<object> data = new List<object>();
			bool allNull = true;
			for (int i = format.DataColumnStart; i <= dataColumnEnd; i++)
			{
				ICell cell = row.GetCell(i);
				object one = this.GetCellValue(cell);
				if (one != null)
				{
					allNull = false;
				}
				data.Add(one);
			}
			if (!allNull)
			{
				return data;
			}
			return null;
		}

		private string GetStringFromCell(ICell cell)
		{
			if (cell == null)
			{
				return string.Empty;
			}
			if (cell == null)
			{
				return null;
			}
			switch (cell.CellType)
			{
				case CellType.Unknown:
				case CellType.String:
				case CellType.Formula:
				case CellType.Blank:
					if (cell.StringCellValue != null)
					{
						return cell.StringCellValue.Trim();
					}
					return null;
				case CellType.Numeric:
					if (DateUtil.IsCellDateFormatted(cell))
					{
						return cell.DateCellValue.ToString("yyyy-MM-dd");
					}
					return cell.NumericCellValue.ToString();
				case CellType.Boolean:
					return cell.BooleanCellValue.ToString();
				default:
					if (cell.StringCellValue != null)
					{
						return cell.StringCellValue.Trim();
					}
					return null;
			}
		}

		private object GetCellValue(ICell cell)
		{
			if (cell == null)
			{
				return null;
			}
			switch (cell.CellType)
			{
				case CellType.Unknown:
				case CellType.String:
				case CellType.Formula:
				case CellType.Blank:
					if (cell.StringCellValue != null)
					{
						return cell.StringCellValue.Trim();
					}
					return null;
				case CellType.Numeric:
					if (DateUtil.IsCellDateFormatted(cell))
					{
						return cell.DateCellValue;
					}
					return cell.NumericCellValue;
				case CellType.Boolean:
					return cell.BooleanCellValue;
				default:
					if (cell.StringCellValue != null)
					{
						return cell.StringCellValue.Trim();
					}
					return null;
			}
		}
	}
}
