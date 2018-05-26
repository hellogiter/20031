// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 16:56:41
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 16:56:41
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NPOI.SS.UserModel;

namespace Myzj.OPC.UI.Common
{
	internal class ExportSupport
	{
		private int EndIndex = 0;

		public void SetMainHead(IRow row, Type classType, Dictionary<string, string> Head, int columnStartIndex = 0)
		{
			if (Head == null)
			{
				Head = new Dictionary<string, string>();
			}
			this.HeadSupport = new Dictionary<string, PropertyInfo>();
			PropertyInfo[] properties = classType.GetProperties();
			this.PropertyNames = new string[properties.Count<PropertyInfo>()];
			this.EndIndex = columnStartIndex;
			foreach (string str in Head.Keys)
			{
				row.CreateCell(this.EndIndex).SetCellValue(Head[str]);
				this.HeadSupport.Add(str, null);
				this.EndIndex++;
			}
			int index = 0;
			foreach (PropertyInfo info in properties)
			{
				this.PropertyNames[index] = info.Name;
				if (Head.ContainsKey(info.Name))
				{
					this.HeadSupport[info.Name] = info;
				}
				index++;
			}
		}

		public Dictionary<string, PropertyInfo> HeadSupport { get; private set; }
		private string[] PropertyNames { get; set; }

	}
}
