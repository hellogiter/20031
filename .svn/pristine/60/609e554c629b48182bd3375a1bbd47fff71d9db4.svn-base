using System;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.WordMsg;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class WebForbidWordMsgController : Controller
    {
        // GET: /WebForbidWordMsg/

        #region 禁词列表
        public ActionResult Index(WordMsgRefer wordMsg)
        {
            var result = new WordMsgRefer();

            result = ForbidWordMsgClient.Instance.QueryGetWordMsg(wordMsg);
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 根据Id查询单条信息
        public ActionResult Detail(int? id)
        {
            var viewModel = new WordMsgDetail();
            try
            {
                if (id > 0)
                {
                    viewModel = ForbidWordMsgClient.Instance.QueryById(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(viewModel);
        }

        #endregion

        #region 保存
        public JsonResult Save(WordMsgDetail wordMsg)
        {
            var jsonResult = new BaseResponse() { };

            try
            {
                if (wordMsg.IntForbidID > 0)
                {
                    //修改
                    var result = ForbidWordMsgClient.Instance.UpdateWordMsg(wordMsg);
                    if (result)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "修改失败，请重试！";
                    }
                }
                else
                {
                    //新增
                    var result = ForbidWordMsgClient.Instance.AddWordMsg(wordMsg);
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
                jsonResult.DoResult = "保存异常... ...";
            }
            return Json(jsonResult);
        }
        #endregion

        #region 删除

        public JsonResult Del(int id)
        {
            var jsonResult = new BaseResponse() { };
            try
            {
                var res = ForbidWordMsgClient.Instance.DelWordMsg(id);
                if (res)
                {
                    jsonResult.DoFlag = true;
                }
                else
                {
                    jsonResult.DoResult = "删除失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                jsonResult.DoResult = "删除异常... ...";
            }
            return Json(jsonResult);
        }
        #endregion
    }
}
