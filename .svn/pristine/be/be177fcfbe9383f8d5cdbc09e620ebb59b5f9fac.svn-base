// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Model.CommentsManage
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/5 9:44:13
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/5 9:44:13
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.CommentsManage
{
	public class VipCommentProductDetail
	{
		public int? Id { get; set; }   //评论Id
		public int? UserId { get; set; }   //用户Id
		public int? OrderId { get; set; }   //订单Id
		public int? ParentId { get; set; }		//父Id,用于回复评论
		public string ContentInfo { get; set; }		//评论内容
		public int? Score { get; set; }				//评分
		public string UserImgObj { get; set; }		//评论图片
		public int? VoteTotal { get; set; }		//投票总数
		public int? IsHighLight { get; set; }		//精华,1:精华
		public DateTime? AddTime { get; set; }			//评论时间
		public int? SystemType { get; set; }		//来源平台
		public string Ip { get; set; }			//Ip地址
		public int? ProductId { get; set; }			//商品Id
		public string ProductName { get; set; }			//商品名称
		public string Mobile { get; set; }			//手机
		public string Email { get; set; }			//邮箱
		public string ShowNickName { get; set; }			//用户昵称
		public int? CheckState { get; set; }			//审核状态：1:未审核,2:审核通过,3:审核未通过
		public string CheckUser { get; set; }			//审核人
		public string CheckInfo { get; set; }		//审核信息：用于审核不通过原因
		public DateTime? CheckTime { get; set; }			//审核时间
		public string ReplyUser { get; set; }		//回复人
		public string ReplyContent { get; set; }			//回复内容
		public DateTime? ReplyTime { get; set; }			//回复时间

		public string ProductCondition { get; set; }	//商品查询条件（商品名或商品Id）
		public int? HasPic { get; set; }     //是否有图
		public int? HasReComment { get; set; }  //是否追评
		public int? HasReply { get; set; }   //是否回复
		public int? PeriodTimeType { get; set; }  //时间段查询
		public DateTime? StartTime { get; set; }   //时间段开始时间
		public DateTime? EndTime { get; set; }   //时间段结束时间
		public string CommentIds { get; set; }	//多个评论id
	}

	public class CommentImg
	{
		public string ImgUrl { get; set; }    //图片路径
		public int ImgSort { get; set; }	//图片排序
	}

	public class CommonAuditParam
	{
		//审核数组
		public string CheJsonStr { get; set; }
		//拒绝原因
		public string RefusedReason { get; set; }
	}

}
