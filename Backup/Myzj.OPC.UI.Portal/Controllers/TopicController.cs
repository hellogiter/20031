using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.MotherShow;
using Myzj.OPC.UI.Model.Topic;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class TopicController : Controller
    {

        public ActionResult Index(Topics topics)
        {
            var viewMode = new Topics();

            viewMode = TopicClient.Instance.GetTopicList(topics);

            return View(viewMode);
        }

        public ActionResult Item()
        {
            return View();
        }

        #region 获取话题题详细信息
        /// <summary>
        /// #region 获取话题题详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int? id)
        {
            var viewModel = new TopicDetail();
            if (id > 0)
            {
                viewModel = TopicClient.Instance.GetTopicDetail(id.Value);

                viewModel.Images = TopicClient.Instance.GetTopicImages(id.Value);
            }
            return View(viewModel);
        }
        #endregion

        #region 修改话题题图片
        /// <summary>
        /// 修改话题题图片
        /// </summary>
        /// <param name="topicBody"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateImages(TopicBody topicBody)
        {
            var result = new BaseResponse();
            if (topicBody.Topic != null)
            {
                var topicId = topicBody.Topic.TopicId.GetValueOrDefault();

                if (topicId > 0)
                {
                    result.DoFlag = TopicClient.Instance.UpdateTopic(topicBody.Topic);
                }
                else
                {
                    topicId = TopicClient.Instance.AddTopic(topicBody.Topic);
                    if (topicId <= 0)
                    {
                        result.DoResult = "插入话题出错！";
                    }
                    else
                    {
                        result.DoFlag = true;
                    }
                }

                if (topicBody.TopicImages != null)
                {
                    result.DoFlag = TopicClient.Instance.UpdateTopicImage(topicId, topicBody.TopicImages);
                }
                else
                {
                    result.DoResult = "请添加图文！";
                }
            }

            result.DoFlag = true;

            return Json(result);
        }
        #endregion

        #region 添加话题
        /// <summary>
        /// 添加话题
        /// </summary>
        /// <param name="topicDetail"></param>
        /// <returns></returns>
        public JsonResult Add(TopicDetail topicDetail)
        {
            var jsonResult = new BaseResponse() { };

            if (topicDetail != null)
            {
                var result = TopicClient.Instance.AddTopic(topicDetail);

                if (result > 0)
                {
                    jsonResult.DoFlag = true;
                }
                else
                {
                    jsonResult.DoResult = "插入失败，请重试！";
                }
            }
            else
            {
                jsonResult.DoResult = "参数错误！";
            }

            return Json(jsonResult);
        }
        #endregion

        #region 修改话题
        /// <summary>
        /// 修改话题
        /// </summary>
        /// <param name="topicDetail"></param>
        /// <returns></returns>
        public JsonResult Update(TopicDetail topicDetail)
        {
            var jsonResult = new BaseResponse() { };

            if (topicDetail != null)
            {
                var result = TopicClient.Instance.UpdateTopic(topicDetail);

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
                jsonResult.DoResult = "参数错误！";
            }

            return Json(jsonResult);
        }
         #endregion

        #region 修改话题排序
        /// <summary>
        /// 修改话题排序
        /// </summary>
        /// <param name="topicId">话题ID</param>
        /// <param name="sort">排序ID</param>
        /// <returns></returns>
        public JsonResult UpTopicSort(int topicId, int sort)
        {
            var result = new BaseResponse();
            try
            {
                result = TopicClient.Instance.UpdateTopicSort(topicId, sort);
            }
            catch (Exception ex)
            {
               
            }
            return Json(result, JsonRequestBehavior.AllowGet); 
        }
         #endregion


    }
}
