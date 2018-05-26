using System;
using System.Collections.Generic;
using MYZJ.VIP.ServiceModel;
using Myzj.OPC.UI.Model.UserPdtComment;

namespace Myzj.OPC.UI.ServiceClient
{
    public class UserPdtCommentClient : BaseService
    {
        private UserPdtCommentClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static UserPdtCommentClient _instance;
        public static UserPdtCommentClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserPdtCommentClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 评论列表
        /// <summary>
        /// 评论列表
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public UserPdtCommentRefer QueryUserPdtComment(UserPdtCommentRefer comment)
        {
            var result = new UserPdtCommentRefer();
            var req = new QueryUserPdtCommentRequest();
            if (comment.SearchDetail != null)
            {
                req.IntUserID = comment.SearchDetail.IntUserID;
                req.IntOrderNO = comment.SearchDetail.IntOrderNO;
                req.IntProductID = comment.SearchDetail.IntProductID;
                req.IntAuditState = comment.SearchDetail.IntAuditState;
                req.IntStart = comment.SearchDetail.IntStart;
                req.IntXingXing = comment.SearchDetail.IntXingXing;
                req.IntIsHighLight = comment.SearchDetail.IntIsHighLight;
                req.IntIsOnTop = comment.SearchDetail.IntIsOnTop;
                req.IntAppHighLight = comment.SearchDetail.IntAppHighLight;
                req.IntIndexVisible = comment.SearchDetail.IntIndexVisible;
                req.IntIsMask = comment.SearchDetail.IntIsMask;
                req.IntAuditUserID = comment.SearchDetail.IntAuditUserID;
                req.IntReplyUserId = comment.SearchDetail.IntReplyUserId;
                req.StartDtCommentDate = comment.SearchDetail.StartDtCommentDate;
                req.EndDtCommentDate = comment.SearchDetail.EndDtCommentDate;
                req.StartDtAuditDate = comment.SearchDetail.StartDtAuditDate;
                req.EndDtAuditDate = comment.SearchDetail.EndDtAuditDate;
                req.StartDtReplyDateTime = comment.SearchDetail.StartDtReplyDateTime;
                req.EndDtReplyDateTime = comment.SearchDetail.EndDtReplyDateTime;
            }
            req.PageIndex = comment.PageIndex;
            req.PageSize = comment.PageSize;

            var res = OpcClient.Send<QueryUserPdtCommentResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<User_Pdt_CommentExt, UserPdtCommentDetail>(res.PdtCommentDos);
                result.Total = res.Total;
            }
            result.SearchDetail = comment.SearchDetail;
            result.PageIndex = comment.PageIndex;
            result.PageSize = comment.PageSize;
            return result;
        }
        #endregion

        #region 根据Id查询单条评论信息
        /// <summary>
        ///  根据Id查询单条评论信息
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public UserPdtCommentDetail QueryUserPdtCommentById(UserPdtCommentDetail comment)
        {
            var result = new UserPdtCommentDetail();
            var req = Mapper.Map<UserPdtCommentDetail, QueryUserPdtCommentByIdRequest>(comment);

            var res = OpcClient.Send<QueryUserPdtCommentByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<User_Pdt_CommentExt, UserPdtCommentDetail>(res.PdtCommentDos);
            }
            return result;
        }
        #endregion

        #region 根据多个Id批量查询多条数据详细信息
        /// <summary>
        /// 根据多个Id批量查询多条数据详细信息
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public List<UserPdtCommentDetail> QueryUserPdtCommentPLById(string commentId)
        {
            var result = new List<UserPdtCommentDetail>();
            var req = new QueryUserPdtCommentPLByIdRequest();
            req.IntCommentID = commentId;

            var res = OpcClient.Send<QueryUserPdtCommentPLByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.MappGereric<User_Pdt_CommentExt, UserPdtCommentDetail>(res.PdtCommentDos);
            }
            return result;
        }
        #endregion

        #region 批量修改评论
        /// <summary>
        /// 批量修改评论
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdatePLUserPdtComment(UserPdtCommentBody search)
        {
            var req = Mapper.Map<UserPdtCommentBody, UpdatePLUserPdtCommentRequest>(search);
            var res = OpcClient.Send<UpdatePLUserPdtCommentResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region  获取评论信息下面的所有回复信息
        /// <summary>
        /// 获取评论信息下面的所有回复信息
        /// </summary>
        /// <param name="commentDetail"></param>
        /// <returns></returns>
        public UserPdtCommentCusReplyRefer QueryUserPdtCommentCusReply(UserPdtCommentCusReplyRefer CommentReply)
        {
            var result = new UserPdtCommentCusReplyRefer();
            var req = new QueryUserPdtCommentCusReplyRequest();
            if (CommentReply.SearchDetail != null)
            {
                req.CommentId = CommentReply.SearchDetail.CommentId;
            }
            req.PageIndex = CommentReply.PageIndex ?? 0;
            req.PageSize = CommentReply.PageSize ?? 0;

            var res = OpcClient.Send<QueryUserPdtCommentCusReplyResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<User_Pdt_Comment_CusReplyExt, UserPdtCommentCusReplyDetail>(res.CommentCusReplyDos);
                result.Total = res.Total;
            }
            result.SearchDetail = CommentReply.SearchDetail;
            result.PageIndex = CommentReply.PageIndex;
            result.PageSize = CommentReply.PageSize;
            return result;
        }
        #endregion

        #region 批量更新回复内容
        /// <summary>
        /// 批量更新回复内容
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool QueryUserPdtCommentCusReply(UserPdtCommentCusReplyBody comment)
        {
            var req = Mapper.Map<UserPdtCommentCusReplyBody, UpdateCommentCusReplyPLIdRequest>(comment);
            var res = OpcClient.Send<UpdateCommentCusReplyPLIdResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 导入评价
        /// <summary>
        /// 导入评价
        /// </summary>
        /// <param name="pdtComment"></param>
        /// <returns></returns>
        public bool AddPdtComment(AddPLPLUserPdtComment pdtComment)
        {
            var req = Mapper.Map<AddPLPLUserPdtComment, AddPLPLUserPdtCommentRequest>(pdtComment);
            var res = OpcClient.Send<AddPLPLUserPdtCommentResponse>(req);
            return res.DoFlag;
        }
        #endregion
    }
}
