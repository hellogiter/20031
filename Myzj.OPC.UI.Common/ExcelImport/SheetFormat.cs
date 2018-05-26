// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:40:58
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:40:58
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Myzj.OPC.UI.Common
{
	[Serializable]
	public class SheetFormat
	{
		[XmlAttribute("name")]
		public string Name
		{
			get;
			set;
		}

		[XmlAttribute("index")]
		public int Index
		{
			get;
			set;
		}

		[XmlAttribute("headerRowIndex")]
		public int HeaderRowIndex
		{
			get;
			set;
		}

		[XmlAttribute("dataRowStart")]
		public int DataRowStart
		{
			get;
			set;
		}

		[XmlAttribute("dataColumnStart")]
		public int DataColumnStart
		{
			get;
			set;
		}

		[XmlAttribute("dataColumnEnd")]
		public int? DataColumnEnd
		{
			get;
			set;
		}

		public bool AllEmptyIsEnd
		{
			get;
			set;
		}

		public SheetFormat()
		{
			this.AllEmptyIsEnd = true;
			this.Index = 0;
			this.HeaderRowIndex = 0;
			this.DataRowStart = this.HeaderRowIndex + 1;
			this.DataColumnStart = 0;
		}
	}
}
