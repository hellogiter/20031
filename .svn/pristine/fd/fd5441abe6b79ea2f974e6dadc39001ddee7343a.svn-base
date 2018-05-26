using System;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.WebBulletin;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class WebBulletinController : BaseController
    {
        // GET: /WebBulletin/

        #region 公告列表
        public ActionResult Index(WebBulletinRefer bulletin)
        {
            var result = new WebBulletinRefer();
            result = WebBulletinClient.Instance.QueryWebBulletin(bulletin);
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
            var result = new WebBulletinDetail();
            if (id > 0)
            {
                result = WebBulletinClient.Instance.QueryWebBulletinById(id.Value);
            }
            return View(result);
        }
        #endregion

        #region 保存
        public JsonResult Save(WebBulletinDetail bulletin)
        {
            var result = new BaseResponse() { };
            try
            {
                if (bulletin.IntBulletinID > 0)
                {
                    //修改
                    var res = WebBulletinClient.Instance.UpdateWebBulletin(bulletin);
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
                    bulletin.IntAddUserID = UserInfo.UserSysNo;
                    bulletin.IntModUserID = UserInfo.UserSysNo;
                    bulletin.DtModDate = bulletin.DtAddDate;

                    var res = WebBulletinClient.Instance.AddWebBulletin(bulletin);
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
                result.DoResult = "保存异常，请稍后重试... ...";
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
                var res = WebBulletinClient.Instance.UpdateWebBulletinSort(id, sort);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改错误，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改状态
        public JsonResult UpdateState(int id, byte state)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebBulletinClient.Instance.UpdateWebBulletinState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改错误，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除公告
        public JsonResult Del(int id)
        {
            var result = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var res = WebBulletinClient.Instance.DelWebBulletin(id);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "删除失败，请稍后重试... ...";
                    }
                }
                else
                {
                    result.DoResult = "参数错误... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
