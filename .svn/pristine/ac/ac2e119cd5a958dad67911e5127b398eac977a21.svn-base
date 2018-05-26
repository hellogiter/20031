using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.Model.BaseDiscountCodeConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class DiscountCodeManagerController : BaseController
    {
        //
        // GET: /DiscountCodeManager/

        public ActionResult Index(BaseRefer<DiscountActivityReq, DiscountActivityRes> refer)
        {
            var obj = refer.SearchDetail ?? new DiscountActivityReq();
            var result = BaseDiscountCodeConfigClient.Instance.QueryDiscountActivityList(refer);
            result.SearchDetail = new DiscountActivityReq();
            result.SearchDetail.StartTime = obj.StartTime;
            result.SearchDetail.EndTime = obj.EndTime;
            return View(result);
        }


        public ActionResult EditDiscountActivity(int? SysNo)
        {
            var refer = new BaseRefer<DiscountActivityReq, DiscountActivityRes>();
            var res = new DiscountActivityRes();
            res.LimitCount = 1;
            if (SysNo.HasValue)
            {
                ViewBag.Title = "修改优惠码活动";
                refer.SearchDetail = new DiscountActivityReq();
                refer.SearchDetail.SysNo = SysNo;
                var result = BaseDiscountCodeConfigClient.Instance.QueryDiscountActivityList(refer);
                if (result != null && result.List2 != null && result.List2.Any())
                    return View(result.List2.First());
            }
            ViewBag.Title = "新增优惠码活动";
            return View(res);
        }


        public ActionResult QueryCouponList(string id,string CouponName)
        {
            ViewBag.ID = id;
            ViewBag.CouponName = CouponName;
            CouponInfoDtailRefer refer=new CouponInfoDtailRefer();
            refer.SearchDetail=new CouponInfoDetail();
            refer.SearchDetail.CouponName = CouponName;
            refer.SearchDetail.IsCodeToCoupon = 1;
            refer.PageIndex = 1;
            refer.PageSize = 100;
            refer.SearchDetail.AuditState = 2;
            refer.SearchDetail.IsDelete = false;
            refer.SearchDetail.IsEnable = true;
            refer = BaseCouponConfigClient.Instance.QueryCouponInfoPageList(refer);
            return View(refer.List2);
        }

        /// <summary>
        /// 新增、修改 优惠码活动
        /// </summary>
        /// <returns></returns>
        public JsonResult SaveDiscountActivity(DiscountActivityRes req)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };
            if (!req.IsDelete.HasValue && !req.IsEnable.HasValue)
            {
                #region  验证

                if (string.IsNullOrEmpty(req.ActivityName))
                {
                    result.DoResult = "请输入活动名称";
                    return Json(result);
                }

                if (string.IsNullOrEmpty(req.CouponKeys))
                {
                    result.DoResult = "请输入关联优惠券Key";
                    return Json(result);
                }

                if (!req.StartTime.HasValue)
                {
                    result.DoResult = "请输入开始时间";
                    return Json(result);
                }

                if (!req.EndTime.HasValue)
                {
                    result.DoResult = "请输入结束时间";
                    return Json(result);
                }

                if (req.StartTime >= req.EndTime)
                {
                    result.DoResult = "请输入正确的时间段";
                    return Json(result);
                }

                if (!req.SetCodeCount.HasValue)
                {
                    result.DoResult = "请输入码数量";
                    return Json(result);
                }

                if (!req.LimitCount.HasValue)
                {
                    result.DoResult = "请输入码限制";
                    return Json(result);
                }

                #endregion
            }

            var message = "";
            req.Remark = "操作人：" + UserInfo.UserSysNo;
            
            if (req.SysNo.HasValue)
            {
                //修改
                var refer = new BaseRefer<DiscountActivityReq, DiscountActivityRes>();
                refer.SearchDetail = new DiscountActivityReq();
                refer.SearchDetail.SysNo = req.SysNo;
                var res = BaseDiscountCodeConfigClient.Instance.QueryDiscountActivityList(refer);
                if (res != null && res.List2 != null && res.List2.Any())
                {
                    var activity = new DiscountActivityRes();
                    activity = res.List2.First();
                    if (!string.IsNullOrEmpty(req.ActivityName))
                        activity.ActivityName = req.ActivityName;
                    if (!string.IsNullOrEmpty(req.CouponKeys))
                        activity.CouponKeys = req.CouponKeys;
                    if (req.StartTime.HasValue)
                        activity.StartTime = req.StartTime;
                    if (req.EndTime.HasValue)
                        activity.EndTime = req.EndTime;
                    if (req.SetCodeCount.HasValue)
                        activity.SetCodeCount = req.SetCodeCount;
                    if (req.LimitCount.HasValue)
                        activity.LimitCount = req.LimitCount;
                    if (req.IsEnable.HasValue)
                        activity.IsEnable = req.IsEnable;
                    if (req.IsDelete.HasValue)
                        activity.IsDelete = req.IsDelete;
                    activity.CodeType = req.CodeType;
                    activity.Remark = req.Remark;
                    result.DoFlag = BaseDiscountCodeConfigClient.Instance.UpdateActivity(activity,out message);
                    if (result.DoFlag)
                    {
                        if (req.IsEnable.HasValue || req.IsDelete.HasValue)
                            message = "操作成功";
                    }
                }

            }
            else
            {
               

                //添加
                result.DoFlag = BaseDiscountCodeConfigClient.Instance.AddActivity(req,out message);
            }
            result.DoResult = message;
            //if (result.DoFlag)
            //{
            //    result.DoResult = "操作成功";
            //}
            //else
            //{
            //    result.DoResult = "操作失败";
            //}
            return Json(result);
        }

        /// <summary>
        /// 码管理
        /// </summary>
        /// <param name="activitySysNo"></param>
        /// <returns></returns>
        public ActionResult DiscountCodeDetail(BaseRefer<DiscountCodeBatchReq, DiscountCodeBatchRes> refer)
        {
            var act = new BaseRefer<DiscountActivityReq, DiscountActivityRes>();
            int? activitySysNo = null;
            if (!string.IsNullOrEmpty(Request.QueryString["activitySysNo"]))
            {
                activitySysNo = int.Parse(Request.QueryString["activitySysNo"]);
            }
             act.SearchDetail = new DiscountActivityReq();
             act.SearchDetail.SysNo = activitySysNo;
            var activity = BaseDiscountCodeConfigClient.Instance.QueryDiscountActivityList(act);
            var result = new BaseRefer<DiscountCodeBatchReq, DiscountCodeBatchRes>();
            if (activity != null && activity.List2 != null && activity.List2.Any())
            {
                ViewBag.SysNo = activitySysNo;
                ViewBag.ActivityName = activity.List2.First().ActivityName;
                ViewBag.CreateCodeCount = activity.List2.First().CreateCodeCount;
                ViewBag.SetCodeCount = activity.List2.First().SetCodeCount;
                refer.SearchDetail = refer.SearchDetail ??new DiscountCodeBatchReq();
                refer.SearchDetail.ActivityKey = activity.List2.First().ActivityKey;
                result = BaseDiscountCodeConfigClient.Instance.QueryDiscountCodeBatchList(refer);
            }
            return View(result);
        }

        public JsonResult AddDiscountCodeBatch(DiscountCodeBatchRes res)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };
            if (!res.SetCodeLength.HasValue || res.SetCodeLength <= 0 || res.SetCodeLength>100)
            {
                result.DoResult = "码长度输入错误";
                return Json(result);
            }
            if (!res.CreateCodeNum.HasValue || res.CreateCodeNum <= 0)
            {
                result.DoResult = "输入正确的生成数量";
                return Json(result);
            }
            var message = "";
            res.ApplyUserId = UserInfo.UserSysNo;
            res.ApplyUserName = UserInfo.UserName;
            result.DoFlag = BaseDiscountCodeConfigClient.Instance.AddDiscountBatch(res,out message);
            if (result.DoFlag)
            {
                result.DoResult = "操作成功";
            }
            else
            {
                result.DoResult = "操作失败,"+message;
            }
            return Json(result);
        }

        public ActionResult QueryDiscountCodeBatch(BaseRefer<DiscountCodeBatchReq, DiscountCodeBatchRes> refer)
        {
            var activityKey = Request.QueryString["activityKey"];
            refer.SearchDetail = refer.SearchDetail ?? new DiscountCodeBatchReq();
            if (!string.IsNullOrEmpty(activityKey))
            {
                refer.SearchDetail.ActivityKey = activityKey;
                ViewBag.activityKey = activityKey;
            }
            var result = BaseDiscountCodeConfigClient.Instance.QueryDiscountCodeBatchList(refer);
            return View(result);
        }

        //取消执行批次
        public JsonResult CancelExecute(int? sysNo)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };

            result.DoFlag = BaseDiscountCodeConfigClient.Instance.CancelExecuteBatch(sysNo,UserInfo.UserName);
            if (result.DoFlag)
            {
                result.DoResult = "操作成功";
            }
            return Json(result);
        }


        //查看优惠码
        public ActionResult QueryDiscountCode(BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes> refer)
        {
            var batchSysNo = Request.QueryString["BatchSysNo"];
            refer.SearchDetail = refer.SearchDetail ?? new DiscountCodeDetailRes();
            if (!string.IsNullOrEmpty(batchSysNo))
            {
                refer.SearchDetail.BatchSysNo = int.Parse(batchSysNo);
                ViewBag.BatchSysNo = int.Parse(batchSysNo);
            }
            ViewBag.ActivityKey = refer.SearchDetail.ActivityKey;
            ViewBag.DiscountCode = refer.SearchDetail.DiscountCode;
            ViewBag.STime = refer.SearchDetail.STime;
            ViewBag.ETime = refer.SearchDetail.ETime;
            refer.PageSize = 30;
            var result = BaseDiscountCodeConfigClient.Instance.QueryDiscountCodeDetailList(refer);
          
            return View(result);
        }


        //删除优惠码
        public JsonResult DeleteDiscountCode(string DiscountCode)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "删除失败" };
            var message = "";
            result.DoFlag = BaseDiscountCodeConfigClient.Instance.DeleteDiscountCode(DiscountCode, out message);
            result.DoResult = message;
            return Json(result);
        }

        /// <summary>
        /// 用户优惠码
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ActionResult QueryDiscountCodeUser(BaseRefer<DiscountCodeUserReq, DiscountCodeUserRes> refer)
        {
            var result = BaseDiscountCodeConfigClient.Instance.QueryDiscountCodeUserList(refer);

            return View(result);
        }

        /// <summary>
        /// 作废、批量作废
        /// </summary>
        /// <returns></returns>
        public JsonResult CancelDiscountCode(string sysNos, string remarks)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "作废失败" };
            if (string.IsNullOrEmpty(sysNos))
            {
                result.DoResult = "请选择作废项";
                return Json(result);
            }
            if (string.IsNullOrEmpty(remarks))
            {
                result.DoResult = "请填写作废原因";
                return Json(result);
            }
            remarks += ",操作类型：作废 ,操作人：" + UserInfo.UserName + ",  操作时间：" + DateTime.Now;

            var listSysNos = sysNos.Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(int.Parse).ToList();
            result.DoResult = BaseDiscountCodeConfigClient.Instance.CancelCoupon(listSysNos, remarks);
            if (!string.IsNullOrEmpty(result.DoResult))
                result.DoFlag = true;
            return Json(result);
        }


        //导出生成的优惠码
        public ActionResult DiscountCodeExport(DiscountCodeDetailRes detail)
        {
            var refer = new BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes>();
            refer.SearchDetail = refer.SearchDetail ?? new DiscountCodeDetailRes();
            refer.SearchDetail = detail;
            var result = BaseDiscountCodeConfigClient.Instance.QueryDiscountCodeDetailList(refer,null);
            var dicProperties = new Dictionary<string, string>();
            dicProperties.Add("SysNo","SysNo");
            dicProperties.Add("DiscountCode", "优惠码");

            ExcelHelper.GetInstance().WriteListToExcel(result.List2, dicProperties, "生成的优惠码");
            return null;
        }
    }
}
