using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.Model.CouponActivity;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class AppCouponActivityController : Controller
    {
        #region app新人抢券活动管理
        //1展示查询列表
        public ActionResult Index(CouponActivityRefer refer)
        {
            var result = CouponActivityClient.Instance.QueryCouponActivityPageList(refer);
            return View(result);
        }
        //2进入编辑页面
        public ActionResult ActivityEdit(int? SysNo)
        {
            var result = new CouponActivityDetail();
            if (SysNo > 0)
            {
                result = CouponActivityClient.Instance.QueryCouponActivityEntity(SysNo ?? 0);
            }
            return View(result);
        }
        //新增、修改
        public JsonResult Save(CouponActivityDetail model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "保存失败，请稍后重试... ..." };
            try
            {
                if (model.SysNo > 0)
                {
                    //修改
                    var res = CouponActivityClient.Instance.UpdateCouponActivity(model);
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
                    model.CreateTime = DateTime.Now;
                    model.ReceiveLimitCount = 0;
                    model.IsDelete = false;
                    model.ActivityKey = Utils.MD5Encrypt(Guid.NewGuid().ToString(), 16);
                    var res = CouponActivityClient.Instance.AddCouponActivity(model);
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


        #region app新人抢券活动优惠券管理
        //1展示查询列表
        public ActionResult QueryCouponActivityConfigurePageList(CouponActivityConfigureRefer refer)
        {
            var id = Request.QueryString["GroupActivitySysNo"];
            if (id != null)
            {
                refer.SearchDetail.ActivitySysNo = int.Parse(id);
                ViewBag.GroupActivitySysNo = id;
            }
            var result = CouponActivityConfigureClient.Instance.QueryCouponActivityConfigurePageList(refer);
            return View(result);
        }
        //2进入编辑页面
        public ActionResult ActivityCouponEdit(int? SysNo)
        {
            var result = new CouponActivityConfigureDetail();
            if (SysNo > 0)
            {
                result = CouponActivityConfigureClient.Instance.QueryCouponActivityConfigureEntity(SysNo ?? 0);
            }
            else
            {
                //新增，根据GroupActivitySysNo 提取活动sysno和activitykey
                var id = Request.QueryString["GroupActivitySysNo"];
                if (id != null)
                {
                    var actEnt = CouponActivityClient.Instance.QueryCouponActivityEntity(Convert.ToInt16(id));
                    result.ActivitySysNo = actEnt.SysNo;
                    result.ActivityKey = actEnt.ActivityKey;
                }
            }
           
            return View(result);
        }
        //新增、修改
        public JsonResult Save2(CouponActivityConfigureDetail model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "保存失败，请稍后重试... ..." };
            try
            {
                if (model.SysNo > 0)
                {
                    //修改
                    var res = CouponActivityConfigureClient.Instance.UpdateCouponActivityConfigure(model);
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
                    model.CreateTime = DateTime.Now;
                    model.ReceiveLimitCount = 0;
                    model.IsDelete = false;
                    var res = CouponActivityConfigureClient.Instance.AddCouponActivityConfigure(model);
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

        //删除活动下优惠券
        public JsonResult DeleteCouponActivityConfigure(int? SysNo)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "删除失败，请稍后重试... ..." };
            if (SysNo > 0)
            {
                var res = CouponActivityClient.Instance.DeleteCouponActivityConfigure(SysNo ?? 0);
                if (res)
                {
                    result.DoFlag = true;
                }
            }
            return Json(result);
        }
        #endregion
    }
}
