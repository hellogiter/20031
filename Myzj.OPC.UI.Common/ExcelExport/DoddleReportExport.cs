// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 17:08:04
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 17:08:04
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DoddleReport;
using DoddleReport.Writers;

namespace Myzj.OPC.UI.Common
{
	internal class DoddleReportExport<T> : ExportBase<T>,  IExport, IWriteFileSet
	{
		public event EventHandler<BeginExportEventArgs> BgExport;

		public DoddleReportExport(IList<T> dataSource, Dictionary<string, string> head)
		{
			base.DataSource = dataSource;
			base.Head = head;
		}

		public void BeforeExport(ExportSupport exportSupport = null)
		{
			if (exportSupport != null)
			{
			}
		}

		public void Export(string FileUrl, MyFileType FileType)
		{
			FileUrl = ExportHelper.GetMatchUrl(FileUrl, FileType);
			Report report = new Report(base.DataSource.ToList<T>().ToReportSource())
			{
				TextFields = { Title = "产品报表", SubTitle = "这是一个测试DoddleReport的导出文件", Footer = "测试于2014-1-10", Header = string.Format(" 产品报表表头", new object[0]) },
				RenderHints = { BooleanCheckboxes = true }
			};
			using (FileStream stream = File.Create(FileUrl))
			{
				this.GetWriter(FileType).WriteReport(report, stream);
				Console.WriteLine("文件导出成功！" + FileUrl);
			}
		}

		public byte[] GetFile(MyFileType fileType)
		{
			return new byte[0];
		}

		private IReportWriter GetWriter(MyFileType fileType)
		{
			switch (fileType)
			{
				case MyFileType.CSV:
					return new DelimitedTextReportWriter();

				case MyFileType.HTML:
					return new HtmlReportWriter();

				case MyFileType.TXT:
					return new DelimitedTextReportWriter();

				case MyFileType.EXCEL2003:
					return new ExcelReportWriter();
			}
			return new ExcelReportWriter();
		}

		public int ColumnStartIndex { get; set; }

		public int HeadRowIndex { get; set; }

		public int RowStartIndex { get; set; }
	}
}
