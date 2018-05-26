// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 17:26:55
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 17:26:55
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace Myzj.OPC.UI.Common
{
	internal class NPOIExportComplex<TEntity> : NPOIExportBase, IExportComplexEvent<TEntity>, IExport, IWriteFileSet
	{
		public event EventHandler<OnRowExportEventArgs<TEntity>> RowExport;

		public NPOIExportComplex(IList<TEntity> dataSource, IList<string> heads)
		{
			this.DataSource = dataSource;
			base.Head = heads;
		}

		public void Export(string fileUrl, MyFileType fileType)
		{
			fileUrl = ExportHelper.GetMatchUrl(fileUrl, fileType);
			byte[] buffer = base.Export<TEntity>(this.DataSource, fileType);
			using (FileStream stream = new FileStream(fileUrl, FileMode.Create, FileAccess.Write))
			{
				stream.Write(buffer, 0, buffer.Length);
				Console.WriteLine("文件导出成功！" + fileUrl);
			}
		}

		public byte[] GetFile(MyFileType fileType)
		{
			return base.Export<TEntity>(this.DataSource, fileType);
		}

		protected virtual void OnRowExport(OnRowExportEventArgs<TEntity> e)
		{
			e.Raise<OnRowExportEventArgs<TEntity>>(this, ref this.RowExport);
		}

		protected override void SetListData(ISheet sheet)
		{
			if (base.defineLocation == null)
			{
				throw new NoExportHeadException("请先设置表头");
			}
			int rowStartIndex = base.RowStartIndex;
			foreach (TEntity local in this.DataSource)
			{
				IRow row = sheet.CreateRow(rowStartIndex);
				ExportHelper helper = new ExportHelper(base.CurWorkBook, row, base.defineLocation);
				OnRowExportEventArgs<TEntity> e = new OnRowExportEventArgs<TEntity>(rowStartIndex, local)
				{
					helper = helper
				};
				this.OnRowExport(e);
				rowStartIndex++;
			}
		}

		public IList<TEntity> DataSource { get; private set; }
	}
}
