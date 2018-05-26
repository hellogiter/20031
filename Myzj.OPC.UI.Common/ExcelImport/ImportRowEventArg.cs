// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:53:06
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:53:06
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class ImportRowEventArg : EventArgs
	{
		public int RowIndex
		{
			get;
			set;
		}

		public List<string> HeaderData
		{
			get;
			set;
		}

		public List<object> RowData
		{
			get;
			set;
		}

		public SheetFormat Format
		{
			get;
			set;
		}

		public bool IsSuccess
		{
			get;
			set;
		}

		public bool IsSkip
		{
			get;
			set;
		}

		public bool IsEnd
		{
			get;
			set;
		}

		public string Error
		{
			get;
			set;
		}

		public ImportRowEventArg()
		{
			this.IsSuccess = true;
		}
	}
}
