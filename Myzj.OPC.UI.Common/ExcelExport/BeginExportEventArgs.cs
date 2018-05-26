// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 14:36:57
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 14:36:57
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class BeginExportEventArgs : EventArgs
	{
		private Dictionary<int, int> ColumnWidth;
		private Dictionary<string, int> DefineLocation;
		private List<string> SheetNames;

		public BeginExportEventArgs(List<string> sheetName, Dictionary<string, int> defineLocation, Dictionary<int, int> columnWidth)
		{
			this.SheetNames = sheetName;
			this.DefineLocation = defineLocation;
			this.ColumnWidth = columnWidth;
		}

		public void AddSheet(string sheetName)
		{
			this.SheetNames.Add(sheetName);
		}

		public void SetColumnWidth(string headName, int width)
		{
			if (this.DefineLocation.ContainsKey(headName))
			{
				int key = this.DefineLocation[headName];
				if (this.ColumnWidth.ContainsKey(key))
				{
					this.ColumnWidth[key] = width;
				}
				else
				{
					this.ColumnWidth.Add(key, width);
				}
			}
		}
	}
}
