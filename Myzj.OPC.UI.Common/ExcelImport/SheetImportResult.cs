// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:44:50
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:44:50
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Myzj.OPC.UI.Common
{
	public class SheetImportResult
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

		public int Success
		{
			get;
			private set;
		}

		public List<string> Errors
		{
			get;
			set;
		}

		public int Skiped
		{
			get;
			private set;
		}

		public SheetImportResult()
		{
			this.Errors = new List<string>();
		}

		public void IncreaseSkiped()
		{
			this.Skiped++;
		}

		public void AddError(string p)
		{
			this.Errors.Add(p);
		}

		public void IncreaseSuccess()
		{
			this.Success++;
		}
	}
}
