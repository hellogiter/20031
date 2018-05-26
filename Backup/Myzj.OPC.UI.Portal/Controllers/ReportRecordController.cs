using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.ReportRecord;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class ReportRecordController : Controller
    {
        #region 投诉列表
        /// <summary>
        /// 投诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(GetReportRecord model)
        {
            ViewBag.ReportRecord = model;
            return View(model);
        }
        #endregion


        #region 投诉列表
        /// <summary>
        /// 投诉列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Item(GetReportRecord model)
        {
            try
            {
                model = ReportRecordClient.Instance.GetReportRecordList(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.ReportRecord = model;
            return View();
        }
        #endregion

        #region 修改投诉状态

        public JsonResult UpRecordState(int id, int state)
        {
            BaseResponse jsonResult = new BaseResponse();
            try
            {
                if (id > 0)
                {

                    var result = ReportRecordClient.Instance.UpRecordState(id, state);
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

        #region 删除投诉

        public JsonResult DelRecord(int id)
        {
            BaseResponse jsonResult = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var result = ReportRecordClient.Instance.DelRecord(id);
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
