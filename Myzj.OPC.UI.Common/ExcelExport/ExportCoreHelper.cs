﻿// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Common.ExcelExport
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/17 15:43:19
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/17 15:43:19
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Myzj.OPC.UI.Common
{
	internal static class ExportCoreHelper
	{
		public static short DateFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy");

		public static ICellStyle Getcellstyle(IWorkbook wb, StyleXls str)
		{
			ICellStyle style = wb.CreateCellStyle();
			//设置单元格上下左右边框线
			style.BorderTop = BorderStyle.Thin;
			style.BorderBottom = BorderStyle.Thin;
			style.BorderLeft = BorderStyle.Thin;
			style.BorderRight = BorderStyle.Thin;
			
			style.BottomBorderColor = 12;
			style.TopBorderColor = 12;
			//文字水平和垂直对齐方式  
			style.Alignment = HorizontalAlignment.Center;
			style.VerticalAlignment = VerticalAlignment.Center;

			//是否换行 (不换行)
			style.WrapText = false;

			style.Indention = 0;
			switch (str)
			{
				case StyleXls.默认:
					return style;

				case StyleXls.url:
					style.SetFont(GetFont(wb, 2));
					return style;

				case StyleXls.时间:
					style.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy");
					style.SetFont(GetFont(wb, 1));
					return style;

				case StyleXls.数字:
					style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
					style.SetFont(GetFont(wb, 1));
					return style;

				case StyleXls.钱:
					style.DataFormat = wb.CreateDataFormat().GetFormat("￥#,##0");
					style.SetFont(GetFont(wb, 1));
					return style;

				case StyleXls.百分比:
					style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
					style.SetFont(GetFont(wb, 1));
					return style;

				case StyleXls.中文大写:
					style.DataFormat = wb.CreateDataFormat().GetFormat("[DbNum2][$-804]0");
					style.SetFont(GetFont(wb, 1));
					return style;

				case StyleXls.科学计数法:
					style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
					style.SetFont(GetFont(wb, 1));
					return style;

				case StyleXls.头:
					style.FillBackgroundColor = 0x17;
					style.FillForegroundColor = 0x17;
					style.FillPattern = FillPattern.AltBars;
					style.SetFont(GetFont(wb, 0));
					return style;
			}
			return style;
		}

		public static short GetColor(MyColor color)
		{
			switch (color)
			{
				case MyColor.Black:
					return 8;

				case MyColor.Gray:
					return 0x17;

				case MyColor.white:
					return 9;

				case MyColor.Red:
					return 10;

				case MyColor.Blue:
					return 12;

				case MyColor.Orange:
					return 0x35;

				case MyColor.Green:
					return 0x11;
			}
			return 8;
		}

		public static ICellStyle GetDateTimeCellStyle(IWorkbook workbook)
		{
			ICellStyle style = workbook.CreateCellStyle();
			style.DataFormat = DateFormat;
			return style;
		}

		public static IFont GetFont(IWorkbook wb, int type)
		{
			if (type == 0)
			{
				IFont font = wb.CreateFont();
				font.FontHeightInPoints = 13;
				font.Boldweight = 13;
				font.FontName = "微软雅黑";
				return font;
			}
			if (type == 1)
			{
				IFont font2 = wb.CreateFont();
				font2.FontName = "微软雅黑";
				return font2;
			}
			if (type == 2)
			{
				IFont font3 = wb.CreateFont();
				font3.Color = 12;
				font3.IsItalic = true;
				font3.Underline = FontUnderlineType.Single;
				font3.FontName = "微软雅黑";
				return font3;
			}
			IFont font4 = wb.CreateFont();
			font4.FontName = "微软雅黑";
			return font4;
		}

		public static IRichTextString GetVersionString(string text, MyFileType fileType = 0)
		{
			if (fileType == MyFileType.EXCEL)
			{
				return new XSSFRichTextString(text);
			}
			return new HSSFRichTextString(text);
		}

		public static IWorkbook GetVersionWorkbook(MyFileType fileType)
		{
			switch (fileType)
			{
				case MyFileType.EXCEL:
					return new XSSFWorkbook();

				case MyFileType.EXCEL2003:
					return new HSSFWorkbook();
			}
			return new XSSFWorkbook();
		}
	}
}