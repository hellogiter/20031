// ***********************************************************************
// Copyright (c) 2016 Administrator,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.ServiceClient
// Author:ysx2012@muyingzhijia.com
// Created:2016/8/6 17:03:33
// Description:
// ***********************************************************************
// Last Modified By:WIN-F4KN29N0GFG
// Last Modified On:2016/8/6 17:03:33
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model.CommentsManage;
using Ups.myzj.com.ServiceModel.ForDaemon;


namespace Myzj.OPC.UI.ServiceClient
{
	public class CommentManageClient : BaseService
	{
		        #region 单例
		private CommentManageClient()
        {

        }
        private static readonly object Lockobj = new object();
        private static CommentManageClient _instance;
		public static CommentManageClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
							_instance = new CommentManageClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

		/// <summary>
		/// 查询评论列表
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public CommentsManageRefer QueryCommentsPageList(CommentsManageRefer request)
		{
			var result = new CommentsManageRefer();
			var req = new QueryCommentsPageListReq()
			{
				QueryCommentsReqParam=Mapper.Map<VipCommentProductDetail, QueryCommentsReqParam>(request.CommentDetail),
				PageIndex = (int)request.PageIndex,
				PageSize = (int)request.PageSize
			};
			var res = UpsServiceClient.Send<QueryCommentsPageListRes>(req);
			if (res.DoFlag)
			{
				result.List = Mapper.MappGereric<VipCommentProduct, VipCommentProductDetail>(res.VipCommnetsList);
				result.Total = res.TotalCount;
			}
			result.CommentDetail = request.CommentDetail;
			result.PageIndex = request.PageIndex;
			result.PageSize = request.PageSize;
			return result;
		}

		/// <summary>
		/// 批量审核
		/// </summary>
		/// <param name="checkStr">审核内容</param>
		/// <param name="checkInfo">拒绝原因</param>
		/// <param name="checkUserId">审核人</param>
		/// <returns></returns>
		public AuditCommentManageRes AuditCommentManage(string checkStr, string checkInfo, int checkUserId)
		{
			var result = new AuditCommentManageRes();
			var req = new AuditCommentManageReq()
			{
				CheckStr = checkStr,
				CheckInfo = checkInfo,
				CheckUserId = checkUserId
			};
			result = UpsServiceClient.Send<AuditCommentManageRes>(req);
			return result;
		}

		/// <summary>
		/// 评论加精
		/// </summary>
		/// <param name="cids">要加精的id</param>
		/// <param name="uncids">要去掉加精的id</param>
		/// <returns></returns>
		public SetEssenceRes SetEssence(string cids, string uncids)
		{
			var result = new SetEssenceRes();
			var req = new SetEssenceReq()
			{
				Cids = cids,
				Uncids = uncids
			};
			result = UpsServiceClient.Send<SetEssenceRes>(req);
			return result;
		}

		/// <summary>
		/// 回复评论
		/// </summary>
		/// <param name="rid">评论id</param>
		/// <param name="replyinfo">回复内容</param>
		/// <param name="replyUserId">回复人</param>
		/// <returns></returns>
		public ReplyCommentRes ReplyComment(int rid, string replyinfo, int replyUserId)
		{
			var result = new ReplyCommentRes();
			var req = new ReplyCommentReq()
			{
				Rid = rid,
				ReplyContent = replyinfo,
				ReplyUserId = replyUserId
			};
			result = UpsServiceClient.Send<ReplyCommentRes>(req);
			return result;
		}

		///// <summary>
		///// 刷新商品缓存
		///// </summary>
		///// <param name="refreshIds">商品Id</param>
		///// <returns></returns>
		//public ReplyCommentRes RefreshProducts(string refreshIds)
		//{
		//	var result = new ReplyCommentRes();
		//	var req = new ReplyCommentReq()
		//	{
		//		ReplyContent = refreshIds
		//	};
		//	result = UpsServiceClient.Send<ReplyCommentRes>(req);
		//	return result;
		//}

		/// <summary>
		/// 批量导入Excel数据
		/// </summary>
		/// <param name="importList"></param>
		/// <returns></returns>
		public ImportCommentsRes ImportComments(List<VipCommentProductDetail> importList)
		{
			var result = new ImportCommentsRes();
			var req = new ImportCommentsReq()
			{
				ImprotList = Mapper.MappGereric<VipCommentProductDetail, VipCommentProduct>(importList)
			};
			result = UpsServiceClient.Send<ImportCommentsRes>(req);
			return result;
		}


	}
}
