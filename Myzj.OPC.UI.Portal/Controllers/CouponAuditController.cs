using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class CouponAuditController : BaseController
    {
        //查询列表
        public ActionResult Index(CouponAuditRefer refer)
        {
            var result = new CouponAuditRefer();
            //根据当前用户ID 查询用户等级、
            BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt> user =
                new BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt>();
            user.SearchDetail = new AuditRoleConfigDetail();
            user.SearchDetail.MemberId = UserInfo.UserSysNo;
            var userinfo = BaseCouponConfigClient.Instance.QueryUserRole(user);
            var auditLevel = new List<int?>();
            if (userinfo != null && userinfo.List2 != null && userinfo.List2.Any())
            {
                auditLevel = userinfo.List2.Select(m => m.MemberRole-1).ToList();
                //auditLevel.Add(userinfo.List2.Max(m=>m.MemberRole));

            }
            result = BaseCouponConfigClient.Instance.QueryCouponAuditPageList(refer, auditLevel);
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        //查询单条
        public ActionResult Audit(int? Id, string sysNos)
        {
            var result = new CouponInfoDetailExt();

            if (Id > 0)
            {
                result = BaseCouponConfigClient.Instance.QueryCouponInfoEntity(Id);
            }
            ViewBag.sysNos = sysNos;
            return View(result);
        }
 
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="type">(审核状态 0 待审核 1 驳回 2 审核通过)</param>
        /// <param name="sysNos">优惠券Id</param>
        /// <param name="reason">驳回原因</param>
        /// <returns></returns>
        public JsonResult Save(int? type, string sysNos, string reason)
        {
            var result = new BaseResponse() { };
            var couponAuditList = new List<CouponAuditDetail>();
            var arr= sysNos.Split(',');
            foreach (var s in arr)
            {
                var model = new CouponAuditDetail()
                    {
                        SysNo = Convert.ToInt32(s),
                        AuditState = type,
                        RejectReason = reason.Trim()
                    };
                couponAuditList.Add(model);
            }
            var userid = UserInfo.UserSysNo;
            var flag = BaseCouponConfigClient.Instance.CouponBatchAudit(couponAuditList, userid);
            result.DoFlag = flag;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
