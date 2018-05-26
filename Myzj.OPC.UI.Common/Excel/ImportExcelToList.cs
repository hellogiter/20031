// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:36:11
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:36:11
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class ImportExcelToList
	{
		public ImportFileFormat Format
		{
			get;
			set;
		}

		public List<List<object>> ImportedData
		{
			get;
			private set;
		}

		public List<string> ImportedHeader
		{
			get;
			private set;
		}

		public ImportExcelToList()
			: this(ImportFileFormat.CreateDefault())
		{
		}

		public ImportExcelToList(ImportFileFormat format)
		{
			this.Format = format;
		}

		/// <summary>
		/// 根据完整路径的文件名获取导入的表头与表体列表
		/// </summary>
		/// <param name="fileName">文件的完整路径名字</param>
		/// <returns></returns>
		public ImportToListResult DoImport(string fileName)
		{
			ImportFromExcel import = new ImportFromExcel(this.Format);
			import.OnDataRowImporting += new EventHandler<ImportRowEventArg>(this.import_OnDataRowImported);
			ImportResult result = import.DoImport(fileName);
			return new ImportToListResult(result, new ImportedData(this.ImportedHeader, this.ImportedData));
		}

		public ImportToListResult DoImport(Stream stream)
		{
			ImportFromExcel import = new ImportFromExcel(this.Format);
			import.OnDataRowImporting += new EventHandler<ImportRowEventArg>(this.import_OnDataRowImported);
			ImportResult result = import.DoImport(stream);
			return new ImportToListResult(result, new ImportedData(this.ImportedHeader, this.ImportedData));
		}

		private void import_OnDataRowImported(object sender, ImportRowEventArg e)
		{
			if (this.ImportedHeader == null)
			{
				this.ImportedHeader = e.HeaderData;
			}
			if (this.ImportedData == null)
			{
				this.ImportedData = new List<List<object>>();
			}
			this.ImportedData.Add(e.RowData);
			e.IsSuccess = true;
		}
	}
}
