using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.MotherShow;
using Myzj.OPC.UI.ServiceClient;
using System;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class MotherShowController : BaseController
    {
        #region 妈妈秀关联列表
        /// <summary>
        /// 妈妈秀管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(GetMotherShow model)
        {
            ViewBag.GetMotherShow = model;
            return View();
        }
        #endregion

        #region 妈妈秀关联列表
        /// <summary>
        /// 妈妈秀列表
        /// </summary>
        /// <param name="motherShow">参数</param>
        /// <returns></returns>
        public ActionResult Item(GetMotherShow motherShow)
        {
            try
            {
                motherShow = MotherShowClient.Instance.GetMotherShowList(motherShow);
            }
            catch (Exception ex)
            {

                throw;
            }
            ViewBag.GetMotherShow = motherShow;
            return View();
        }
        #endregion

        #region 妈妈秀关联列表
        /// <summary>
        /// 妈妈秀关联列表
        /// </summary>
        /// <param name="topicId">话题ID</param>
        /// <returns></returns>
        public ActionResult Relevance(int topicId)
        {
            var list = new List<MotherShowTopic>();
            try
            {
                list = MotherShowClient.Instance.GetMotherShowTopicList(topicId, 0);
            }
            catch (Exception ex)
            {

                throw;
            }
            ViewBag.List = list;
            return View();
        }
        #endregion

        #region 妈妈秀详细页
        /// <summary>
        /// 妈妈秀详细页
        /// </summary>
        /// <param name="id">妈妈秀ID</param>
        /// <returns></returns>
        public ActionResult Detail(int? id)
        {
            var viewModel = new MotherShowDetail();
            if (id > 0)
            {
                viewModel = MotherShowClient.Instance.GetMotherShowDetail(id.Value);
            }
            return View(viewModel);
        }
        #endregion

        #region 妈妈秀保存
        /// <summary>
        /// 妈妈秀保存
        /// </summary>
        /// <param name="fromData"></param>
        /// <returns></returns>
        public JsonResult SaveMotherShow(MotherShowDetail fromData)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherShowClient.Instance.SaveMotherShow(fromData);
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 更新妈妈秀状态审核
        /// <summary>
        /// 更新妈妈秀状态审核
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="showId">麻麻秀ID</param>
        /// <param name="state">状态</param>
        /// <param name="originalState">原始状态</param>
        /// <returns></returns>
        public JsonpResult UpdateCheck(int userId, int showId, int state, int originalState)
        {
            var result = new JsonpResult();

            try
            {
                result.Data = MotherShowClient.Instance.UpdateCheck(userId, showId, state, originalState);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public JsonResult BatchUpdateCheck(List<BatchUpShowSate> list)
        {
            var count = 0;
            var result = new BaseResponse();

            try
            {
                foreach (var item in list)
                {
                    var res = MotherShowClient.Instance.UpdateCheck(item.UserId, item.ShowId, item.State, item.OriginalState);
                    if (res.DoFlag)
                    {
                        count += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if (count == list.Count)
            {
                result.DoFlag = true;
            }
            else if (count < list.Count)
            {
                result.DoResult = "更新部分成功";
            }
            else
            {
                result.DoResult = "更新失败";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加妈妈秀话题关联
        /// <summary>
        /// 添加妈妈秀话题关联
        /// </summary>
        /// <param name="topicId">话题ID</param>
        /// <param name="mShowId">妈妈秀ID</param>
        /// <param name="isTopic">是否话题关联</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddMotherShowTopic(int topicId, int mShowId, int isTopic, int state)
        {
            var result = new BaseResponse();
            try
            {
                var topicFlag = false;
                if (isTopic == 1)
                {
                    topicFlag = true;
                }

                result = MotherShowClient.Instance.AddMotherShowTopic(topicId, mShowId, topicFlag, state);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除妈妈秀话题关联
        /// <summary>
        /// 删除妈妈秀话题关联
        /// </summary>
        /// <param name="mTopicId">关联ID</param>
        /// <returns></returns>
        public JsonResult DelMotherShowTopic(int mTopicId)
        {
            var result = new BaseResponse();
            try
            {
                result = MotherShowClient.Instance.DelMotherShowTopic(mTopicId);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改妈妈秀话题关联排序
        /// <summary>
        /// 修改妈妈秀话题关联排序
        /// </summary>
        /// <param name="mTopicId">关联ID</param>
        ///  <param name="sort">排序ID</param>
        /// <returns></returns>
        public JsonResult UpMotherShowTopicSort(int mTopicId, int sort)
        {
            var result = new BaseResponse();
            try
            {
                result = MotherShowClient.Instance.UpMotherShowTopicSort(mTopicId, sort);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }

    /// <summary>
    /// 批量更新
    /// </summary>
    public class BatchUpShowSate
    {
        public int UserId { get; set; }
        public int ShowId { get; set; }
        public int State { get; set; }
        public int OriginalState { get; set; }
    }
}
