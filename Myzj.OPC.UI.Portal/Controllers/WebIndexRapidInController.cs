using System;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.WebIndex;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class WebIndexRapidInController : BaseController
    {
        // GET: /WebIndexRapidIn/

        #region 快速入口管理列表
        public ActionResult Index(WebIndexRefer webIndex)
        {
            var result = new WebIndexRefer();
            result = WebIndexRapidInClien.Instance.QueryWordMsgRefer(webIndex);
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 详细信息
        public ActionResult Detail(int? id)
        {
            var req = new WebActivityRefer();

            var res = WebIndexRapidInClien.Instance.QueryWebActivity(req);

            ViewBag.WebActivity = res;//活动类型

            var viewModel = new WebIndexDetail();
            try
            {
                if (id > 0)
                {
                    viewModel = WebIndexRapidInClien.Instance.QueryById(id.Value);
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
        public JsonResult Save(WebIndexDetail webIndex)
        {
            var result = new BaseResponse() { };
            try
            {
                if (webIndex.IntRapidInID > 0)
                {
                    //修改
                    var res = WebIndexRapidInClien.Instance.UpdateWordMsgRefer(webIndex);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ...";
                    }
                }
                else
                {
                    //新增
                    webIndex.IntAddUserID = UserInfo.UserSysNo;
                    webIndex.IntModUserID = UserInfo.UserSysNo;
                    webIndex.DtAddDate = DateTime.Now;
                    webIndex.DtModDate = DateTime.Now;
                    var res = WebIndexRapidInClien.Instance.AddWordMsgRefer(webIndex);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常,稍后重试... ...";
            }
            return Json(result);
        }

        #endregion

        #region 修改排序
        public JsonResult UpdateSort(int id, int sort)
        {
            var result = new BaseResponse();

            try
            {
                if (id > 0)
                {
                    var res = WebIndexRapidInClien.Instance.UpdateSort(id, sort);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败,请稍后重试... ...";
                    }
                }
                else
                {
                    result.DoResult = "参数错误... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常,请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改状态
        public JsonResult Updatevisible(int id, byte isvisible)
        {
            var result = new BaseResponse();

            try
            {
                if (id > 0)
                {
                    var res = WebIndexRapidInClien.Instance.UpdateVisible(id, isvisible);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败,请稍后重试... ...";
                    }
                }
                else
                {
                    result.DoResult = "参数错误... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常,请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  删除
        public JsonResult Del(int? id)
        {
            var result = new BaseResponse() { };
            try
            {
                var res = WebIndexRapidInClien.Instance.DelWordMsgRefer(id.Value);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "删除失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常,请稍后重试... ...";
            }
            return Json(result);
        }
        #endregion
    }
}
