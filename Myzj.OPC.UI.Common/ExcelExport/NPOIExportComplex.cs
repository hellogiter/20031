// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 17:25:56
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 17:25:56
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace Myzj.OPC.UI.Common
{
	internal class NPOIExportComplex : NPOIExportBase, IExportComplexEvent, IExport, IWriteFileSet
	{
		public event EventHandler<OnRowExportEventArgs> RowExport;

		public NPOIExportComplex(IList<object> dataSource, IList<string> heads)
		{
			this.DataSource = dataSource;
			base.Head = heads;
		}

		public void Export(string fileUrl, MyFileType fileType)
		{
			fileUrl = ExportHelper.GetMatchUrl(fileUrl, fileType);
			byte[] buffer = base.Export<object>(this.DataSource, fileType);
			using (FileStream stream = new FileStream(fileUrl, FileMode.Create, FileAccess.Write))
			{
				stream.Write(buffer, 0, buffer.Length);
				Console.WriteLine("文件导出成功！" + fileUrl);
			}
		}

		public byte[] GetFile(MyFileType fileType)
		{
			return base.Export<object>(this.DataSource, fileType);
		}

		protected virtual void OnRowExport(OnRowExportEventArgs e)
		{
			e.Raise<OnRowExportEventArgs>(this, ref this.RowExport);
		}

		protected override void SetListData(ISheet sheet)
		{
			if (base.defineLocation == null)
			{
				throw new NoExportHeadException("请先设置表头");
			}
			int rowStartIndex = base.RowStartIndex;
			foreach (object obj2 in this.DataSource)
			{
				IRow row = sheet.CreateRow(rowStartIndex);
				ExportHelper helper = new ExportHelper(base.CurWorkBook, row, base.defineLocation);
				OnRowExportEventArgs e = new OnRowExportEventArgs(rowStartIndex, obj2)
				{
					helper = helper
				};
				this.OnRowExport(e);
				rowStartIndex++;
			}
		}

		public IList<object> DataSource { get; private set; }
	}
}
