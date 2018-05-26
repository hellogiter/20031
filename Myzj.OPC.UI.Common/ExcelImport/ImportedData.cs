// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.Excel
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/14 13:46:04
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/14 13:46:04
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class ImportedData
	{
		public List<List<object>> ImportedBody
		{
			get;
			private set;
		}

		public List<string> ImportedHeader
		{
			get;
			private set;
		}

		public ImportedData(List<string> headerData, List<List<object>> bodyData)
		{
			this.ImportedHeader = headerData;
			this.ImportedBody = bodyData;
		}

		public List<object> GetDataByIndex(int column)
		{
			if (this.ImportedHeader == null)
			{
				throw new ApplicationException("请先调用DoImport方法执行导入.");
			}
			if (column >= this.ImportedHeader.Count || column < 0)
			{
				throw new ArgumentException("colmun的值不在指定的范围之内");
			}
			List<object> data = new List<object>();
			foreach (List<object> one in this.ImportedBody)
			{
				if (one.Count <= column)
				{
					data.Add(null);
				}
				else
				{
					data.Add(one[column]);
				}
			}
			return data;
		}

		public int FindHeaderIndexContains(string key)
		{
			if (this.ImportedHeader == null)
			{
				throw new ApplicationException("请先调用DoImport方法执行导入.");
			}
			for (int i = 0; i < this.ImportedHeader.Count; i++)
			{
				string one = this.ImportedHeader[i];
				if (one != null && one.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return i;
				}
			}
			return -1;
		}

	}
}
