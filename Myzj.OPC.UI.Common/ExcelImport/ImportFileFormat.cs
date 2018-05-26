// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:39:58
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:39:58
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Myzj.OPC.UI.Common
{
	[Serializable]
	public class ImportFileFormat
	{
		[XmlArray("sheets"), XmlArrayItem("one")]
		public List<SheetFormat> Sheets
		{
			get;
			set;
		}

		public ImportFileFormat()
		{
			this.Sheets = new List<SheetFormat>();
		}

		public static ImportFileFormat CreateDefault()
		{
			ImportFileFormat format = new ImportFileFormat();
			format.AddSheet(new SheetFormat
			{
				DataColumnStart = 0,
				HeaderRowIndex = 0,
				DataRowStart = 1,
				DataColumnEnd = null
			});
			return format;
		}

		public ImportFileFormat AddSheet(SheetFormat sheet)
		{
			if (sheet == null)
			{
				throw new ArgumentNullException("sheet格式定义对象不能为空");
			}
			this.Sheets.Add(sheet);
			return this;
		}
	}
}
