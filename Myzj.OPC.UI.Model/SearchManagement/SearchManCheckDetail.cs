// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Model.SearchManagement
// Author:ysx2012@muyingzhijia.com
// Created:2016/7/30 17:43:53
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/7/30 17:43:53
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.SearchManagement
{
	/// <summary>
	/// 页面新增词记录的实体类
	/// </summary>
	public class SearchManCheckDetail
	{
		public int? Id { get; set; }
		public string ProductIds { get; set; }
		public string KeyWords { get; set; }
		public int? OperateType { get; set; }
		public int? CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public int? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public int? AuditState { get; set; }
		public string RefusedReason { get; set; }
	}
}
