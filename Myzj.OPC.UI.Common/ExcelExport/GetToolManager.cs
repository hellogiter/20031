// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 16:17:12
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 16:17:12
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
    public class GetToolManager
    {
        private IExport GetExporter<TEntity>(MyFileType fileType, IExportSimplePage<TEntity> userPage)
        {
            switch (fileType)
            {
                case MyFileType.EXCEL:
                case MyFileType.EXCEL2003:
                    return new NPOIExport<TEntity>(userPage.GetDataSource(), userPage.GetHead());

                case MyFileType.PDF:
                case MyFileType.CSV:
                case MyFileType.HTML:
                case MyFileType.TXT:
                    return new DoddleReportExport<TEntity>(userPage.GetDataSource(), userPage.GetHead());
            }
            return new NPOIExport<TEntity>(userPage.GetDataSource(), userPage.GetHead());
        }

        public IExport InitExport<TEntity>(IExportComplexPage<TEntity> userPage)
        {
            IExport import = new NPOIExportComplex<TEntity>(userPage.GetDataSource(), userPage.GetHead());
            import.BgExport += new EventHandler<BeginExportEventArgs>(userPage.BeginExport);
            this.SetWrite(import);
            IExportComplexEvent<TEntity> event2 = import as IExportComplexEvent<TEntity>;
            event2.RowExport += new EventHandler<OnRowExportEventArgs<TEntity>>(userPage.OnRowExport);
            return import;
        }

        public IExport InitExport<TEntity>(IExportSimplePage<TEntity> userPage, MyFileType fileType)
        {
            IExport exporter = this.GetExporter<TEntity>(fileType, userPage);
            exporter.BgExport += new EventHandler<BeginExportEventArgs>(userPage.BeginExport);
            this.SetWrite(exporter);
            return exporter;
        }

        public IExport InitExport<TEntity>(IExportComplexPage userPage, IList<TEntity> dataSource, EventHandler<OnRowExportEventArgs<TEntity>> onRow)
        {
            IExport import = new NPOIExportComplex<TEntity>(dataSource, userPage.GetHead());
            import.BgExport += new EventHandler<BeginExportEventArgs>(userPage.BeginExport);
            this.SetWrite(import);
            IExportComplexEvent<TEntity> event2 = import as IExportComplexEvent<TEntity>;
            event2.RowExport += onRow;
            return import;
        }

        private void SetWrite(IWriteFileSet import)
        {
            import.HeadRowIndex = this.HeadRowIndex;
            import.ColumnStartIndex = this.ColumnStartIndex;
            import.RowStartIndex = this.RowStartIndex;
        }

        public int ColumnStartIndex { get; set; }

        public int HeadRowIndex { get; set; }

        public int RowStartIndex { get; set; }
    }
}
