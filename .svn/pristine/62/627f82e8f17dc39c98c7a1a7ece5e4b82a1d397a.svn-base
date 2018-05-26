// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 17:29:25
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 17:29:25
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Common
{
	public class StringHelper
	{
		public static string cutTrueLength(string strOriginal, int maxTrueLength, char chrPad, bool blnCutTail)
		{
			int num2;
			string str = strOriginal;
			if ((strOriginal == null) || (maxTrueLength <= 0))
			{
				return "";
			}
			int num = trueLength(strOriginal);
			if (num > maxTrueLength)
			{
				if (blnCutTail)
				{
					for (num2 = strOriginal.Length - 1; num2 > 0; num2--)
					{
						str = str.Substring(0, num2);
						if (trueLength(str) == maxTrueLength)
						{
							return str;
						}
						if (trueLength(str) < maxTrueLength)
						{
							return (str + chrPad.ToString());
						}
					}
				}
				return str;
			}
			for (num2 = 0; num2 < (maxTrueLength - num); num2++)
			{
				str = str + chrPad.ToString();
			}
			return str;
		}

		public static int trueLength(string str)
		{
			int num = 0;
			int length = str.Length;
			for (int i = 0; i < length; i++)
			{
				int num3 = Convert.ToChar(str.Substring(i, 1));
				if ((num3 < 0) || (num3 > 0x7f))
				{
					num += 2;
				}
				else
				{
					num++;
				}
			}
			return num;
		}
	}
}
