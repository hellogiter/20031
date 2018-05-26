// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:43:59
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:43:59
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class ImportResult
	{
		public List<SheetImportResult> Sheets
		{
			get;
			set;
		}

		public bool IsSuccess
		{
			get;
			set;
		}

		public string Error
		{
			get;
			private set;
		}

		public ImportResult()
		{
			this.Sheets = new List<SheetImportResult>();
			this.IsSuccess = true;
		}

		public ImportResult AddSheetResult(SheetImportResult sheet)
		{
			this.Sheets.Add(sheet);
			return this;
		}

		public void SetError(string error)
		{
			this.Error = error;
			this.IsSuccess = false;
		}
	}
}
