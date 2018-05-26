// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 15:42:10
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 15:42:10
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class ExportException : Exception
	{
		public ExportException(string message)
			: base(message)
		{
			message = "导出错误: " + message;
		}
	}
}
