// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:42:59
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:42:59
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class ImportToListResult
	{
		public ImportResult Result
		{
			get;
			private set;
		}

		public ImportedData Data
		{
			get;
			private set;
		}

		public ImportToListResult(ImportResult result, ImportedData data)
		{
			this.Result = result;
			this.Data = data;
		}
	}
}
