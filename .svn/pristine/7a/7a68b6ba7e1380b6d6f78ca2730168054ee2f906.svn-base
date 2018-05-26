// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 14:49:08
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 14:49:08
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NPOI.SS.UserModel;

namespace Myzj.OPC.UI.Common
{
	public class ExportHelper
	{
		private IWorkbook WorkBook;
		private uint _PropertyName;
		private Dictionary<string, int> defineLocation;
		private IRow row;
		private int defaultHeight = 20;
		public static Dictionary<string, ICellStyle> headStyles;


		public string CurSheetName
		{
			get;
			private set;
		}
	
		public static Dictionary<StyleXls, ICellStyle> CellStyles { get; set; }

		public ExportHelper(IWorkbook workBook, IRow _row, Dictionary<string, int> _defineLocation)
		{
			this.defineLocation = _defineLocation;
			this.CurSheetName = _row.Sheet.SheetName;
			if (this.defineLocation == null)
			{
				throw new NoExportHeadException("请先设置表头");
			}
			this.row = _row;
			this.row.HeightInPoints = this.defaultHeight;
			this.WorkBook = workBook;
		}
		public void SetRowHeight(float height)
		{
			this.row.HeightInPoints = height;
		}
		private void SetHeadStyles(string headName, MyColor color, StyleXls style)
		{
			if (!headStyles.ContainsKey(headName + color.ToString()))
			{
				IFont font;
				ICellStyle cellstyle = ExportCoreHelper.Getcellstyle(this.WorkBook, style);
				if (style == StyleXls.url)
				{
					font = ExportCoreHelper.GetFont(this.WorkBook, 2);
				}
				else if (style == StyleXls.头)
				{
					font = ExportCoreHelper.GetFont(this.WorkBook, 0);
				}
				else
				{
					font = ExportCoreHelper.GetFont(this.WorkBook, 1);
				}
				font.Color = ExportCoreHelper.GetColor(color);
				cellstyle.SetFont(font);
				headStyles.Add(headName + color.ToString(), cellstyle);
			}
		}

		public void SetCellValue(string headName, int value, MyColor color = MyColor.Black, StyleXls style = StyleXls.数字)
		{
			double num = value;
			this.SetCellValue(headName, num, color, style);
		}
		public void SetCellValue(string headName, decimal value, MyColor color = MyColor.Black, StyleXls style = StyleXls.数字)
		{
			double num = (double)value;
			this.SetCellValue(headName, num, color, style);
		}
		public void SetCellValue(string headName, Guid value, MyColor color = MyColor.Black, StyleXls style = StyleXls.默认)
		{
			string str = value.ToString();
			this.SetCellValue(headName, str, color, style);
		}
		public void SetCellValue(string headName, string value, MyColor color = MyColor.Black, StyleXls style = StyleXls.默认)
		{
			this.validate(headName);
			this.SetHeadStyles(headName, color, style);
			ICell cell = this.row.CreateCell(this.defineLocation[headName]);
			if (string.IsNullOrWhiteSpace(value))
			{
				value = "";
			}
			cell.SetCellValue(value);
			cell.CellStyle = headStyles[headName + color.ToString()];
		}
		public void SetCellValue(string headName, DateTime value, MyColor color = MyColor.Black, StyleXls style = StyleXls.时间)
		{
			this.validate(headName);
			this.SetHeadStyles(headName, color, style);
			ICell cell = this.row.CreateCell(this.defineLocation[headName]);
			cell.SetCellValue(value);
			cell.CellStyle = headStyles[headName + color.ToString()];
		}
		public void SetCellValue(string headName, double value, MyColor color = MyColor.Black, StyleXls style = StyleXls.数字)
		{
			this.validate(headName);
			this.SetHeadStyles(headName, color, style);
			ICell cell = this.row.CreateCell(this.defineLocation[headName]);
			cell.SetCellValue(value);
			cell.CellStyle = headStyles[headName + color.ToString()];
		}
		public void SetCellValue(string headName, bool value, MyColor color = MyColor.Black, StyleXls style = StyleXls.默认)
		{
			this.validate(headName);
			this.SetHeadStyles(headName, color, style);
			ICell cell = this.row.CreateCell(this.defineLocation[headName]);
			cell.SetCellValue(value);
			cell.CellStyle = headStyles[headName + color.ToString()];
		}
		private void validate(string headName)
		{
			if (!this.defineLocation.ContainsKey(headName))
			{
				throw new NoExportHeadException(headName);
			}
		}
		private ICell GetCell(string headName)
		{
			this.validate(headName);
			return this.row.CreateCell(this.defineLocation[headName]);
		}
		public void SetCellValue(string headName, object value, string _typeName = "")
		{
			SetCellValue(this.GetCell(headName), value, _typeName);
			
		}
		public static void SetCellValue(ICell exCell, object value, string _typeName = "")
		{
			if (value == null)
			{
				exCell.SetCellValue("");
			}
			else
			{
				string str = "";
				if (_typeName != "")
					str = value.GetType().Name;
				switch (str)
				{
						
					case "Int32":
						exCell.SetCellValue((double)(int)value);
						exCell.CellStyle = CellStyles[StyleXls.数字];
						break;
					case "Float":
						exCell.SetCellValue((double)(float)value);
						exCell.CellStyle = CellStyles[StyleXls.数字];
						break;
					case "Decimal":
					case "Double":
						exCell.SetCellValue((double)value);
						exCell.CellStyle = CellStyles[StyleXls.数字];
						break;
					case "String":
					case "Guid":
						exCell.SetCellValue(value.ToString());
						exCell.CellStyle = CellStyles[StyleXls.默认];
						break;
					case "TimeSpan":
						TimeSpan timeSpan = (TimeSpan)value;
						DateTime dateTime = !(timeSpan < new TimeSpan(1, 0, 0, 0)) ? new DateTime(1900, 1, 1).AddTicks(timeSpan.Ticks) : new DateTime(timeSpan.Ticks);
						exCell.SetCellValue(dateTime);
						exCell.CellStyle = CellStyles[StyleXls.时间];
						break;
					case "DateTime":
						exCell.SetCellValue((DateTime)value);
						exCell.CellStyle = CellStyles[StyleXls.时间];
						break;
					default:
						exCell.SetCellValue(str);
						exCell.CellStyle = CellStyles[StyleXls.默认];
						break;
				}
			}
		}

		public static string GetMatchUrl(string fileUrl, MyFileType fileType)
		{
			switch (fileType)
			{
				case MyFileType.EXCEL:
					return SetMatchUrl(fileUrl, "xlsx");

				case MyFileType.PDF:
					return SetMatchUrl(fileUrl, "pdf");

				case MyFileType.CSV:
					return SetMatchUrl(fileUrl, "csv");

				case MyFileType.HTML:
					return SetMatchUrl(fileUrl, "html");

				case MyFileType.TXT:
					return SetMatchUrl(fileUrl, "txt");

				case MyFileType.EXCEL2003:
					return SetMatchUrl(fileUrl, "xls");
			}
			return SetMatchUrl(fileUrl, "xlsx");
		}
		public static string SetMatchUrl(string fileUrl, string matchUrl)
		{
			if (Path.GetExtension(fileUrl).ToUpper() != matchUrl.ToUpper())
			{
				fileUrl = Path.ChangeExtension(fileUrl, matchUrl);
			}
			return fileUrl;
		}
		
	}
}
