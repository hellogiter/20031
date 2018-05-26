using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.Comments;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class MLTCommentsRecordController : Controller
    {

        #region 评论列表
        /// <summary>
        /// 评论列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(CommentsRecord commentModel, int? id)
        {
            var commentResult = new CommentsRecord();
            if (id > 0)
            {
                commentModel.SearchDetail.CommentsRecordId = id ?? 0;
            }

            try
            {
                commentResult = MLTCommentsRecordClient.Instance.GetCommentRecoedList(commentModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.ByReportProjectId = id;

            return View(commentResult);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 修改/新增评论
        /// <summary>
        /// 详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int? id)
        {
            CommentsDetail commentModel = new CommentsDetail();

            try
            {
                if (id > 0)
                {
                    //根据编号查询评论信息
                    commentModel = MLTCommentsRecordClient.Instance.GetCommentRecordById(id.Value);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(commentModel);
        }

        /// <summary>
        /// 修改or新增评论
        /// </summary>
        /// <returns></returns>
        public JsonResult OperationComment(CommentBody commentModel)
        {
            var model = new CommentBody();
            model.CommentDetail = new CommentsDetail();
            model.CommentDetail.ReplyUserId = commentModel.CommentDetail.ReplyUserId;
            model.CommentDetail.ProjectId = commentModel.CommentDetail.ProjectId;
            model.CommentDetail.CommentsRecordId = commentModel.CommentDetail.CommentsRecordId;
            model.CommentDetail.ReplyContent = commentModel.CommentDetail.ReplyContent;
            model.CommentDetail.ByReplyUserId = commentModel.CommentDetail.ByReplyUserId;
            model.CommentDetail.ByCommentsRecordId = commentModel.CommentDetail.ByCommentsRecordId;
            model.CommentDetail.ReplyDepth = commentModel.CommentDetail.ReplyDepth;
            model.CommentDetail.CommentsRecordType = commentModel.CommentDetail.CommentsRecordType;
            model.CommentDetail.CommentsRecordState = commentModel.CommentDetail.CommentsRecordState;
            model.CommentDetail.ReplyTime = commentModel.CommentDetail.ReplyTime;
            model.CommentDetail.ChannelId = UserContext.ChannelId;
            model.CommentDetail.RecordIp = " ";

            BaseResponse jsonResult = new BaseResponse();
            try
            {
                if (commentModel.CommentDetail.CommentsRecordId > 0)
                {
                    //修改
                    var result = MLTCommentsRecordClient.Instance.UpdateCommentRecord(model);
                    if (result)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "更新失败，请重试！";
                    }
                }
                else
                {
                    //新增
                    var result = MLTCommentsRecordClient.Instance.AddCommentRecord(model.CommentDetail);
                    if (result)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "新增失败，请重试！";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(jsonResult);
        }
        #endregion

        #region 删除评论
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <param name="recordType">类型</param>
        /// <param name="projectId">主ID</param>
        /// <returns></returns>
        public JsonResult Delete(int id, int recordType, int projectId)
        {
            BaseResponse jsonResult = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var result = MLTCommentsRecordClient.Instance.DeletCommentRecord(id, recordType,projectId);
                    if (result)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "删除失败，请重试！";
                    }
                }
                else
                {
                    jsonResult.DoResult = "参数错误！";
                    jsonResult.DoFlag = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonResult);
        }
        #endregion

        #region 修改评论状态
        /// <summary>
        /// 修改评论状态
        /// </summary>
        /// <param name="id">评论ID</param>
        /// <param name="state">状态</param>
        /// <param name="recordType">评论类型</param>
        /// <param name="projectId">评论主ID</param>
        /// <returns></returns>
        public JsonResult UpdateCommentState(int id, int state, int recordType, int projectId)
        {
            BaseResponse jsonResult = new BaseResponse();

            try
            {
                if (id > 0)
                {

                    var result = MLTCommentsRecordClient.Instance.UpdateCommentState(id, state, recordType, projectId);
                    if (result)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "更新失败，请重试！";
                    }
                }
                else
                {
                    jsonResult.DoFlag = false;
                    jsonResult.DoResult = "参数错误！";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonResult);
        }

        #endregion

    }
}
