using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MYZJ.Finance.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.RentActivity;
using Myzj.OPC.UI.ServiceClient;


namespace Myzj.OPC.UI.Portal.Controllers
{
    public class RentManagerController : BaseController
    {
        //
        // GET: /RentManager/

        public ActionResult ActivityIndex(BaseRefer<BaseRentActivityInfo> refer)
        {
            var result = RentActivityClient.Instance.QueryRentActivityList(refer);
            return View(result);
        }

        public ActionResult RentGoodsIndex(BaseRefer<BaseRentGoodsInfo> refer)
        {
            var activityKey = Request.QueryString["ActivityKey"];
            refer.SearchDetail = refer.SearchDetail ?? new BaseRentGoodsInfo();
            if (!string.IsNullOrEmpty(activityKey))
            {
                refer.SearchDetail.ActivityKey = activityKey;
            }

            var result = RentActivityClient.Instance.QueryRentGoodsList(refer);
            return View(result);
        }

        public ActionResult CartSplitIndex(BaseRefer<BaseCartSplitInfo> refer)
        {
            var result = RentActivityClient.Instance.QueryCartSplitList(refer);
            return View(result);
        }

        public ActionResult AgreementIndex(BaseRefer<BaseRentAgreementInfo> refer)
        {
            var result = RentActivityClient.Instance.QueryRentAgreementList(refer);
            return View(result);
        }

        public ActionResult StatisticsIndex(BaseRefer<BaseRentStatisticsInfo> refer)
        {
            var result = RentActivityClient.Instance.QueryStatisticsInfo(refer);
            return View(result);
        }
        public ActionResult StatisticsDetailIndex(BaseRefer<BaseRentStatisticsInfo> refer)
        {
            var goodsId = Request.QueryString["goodsId"];
            var date= Request.QueryString["date"];
            refer.SearchDetail = refer.SearchDetail ?? new BaseRentStatisticsInfo();
            if (!string.IsNullOrEmpty(goodsId))
            {
                refer.SearchDetail.GoodsId =int.Parse(goodsId);
            }
            if (!string.IsNullOrEmpty(date))
            {
                refer.SearchDetail.Date = date;
            }
            var result = RentActivityClient.Instance.QueryStatisticsDetailInfo(refer);
            return View(result);
        }

        public ActionResult ActivityDetail(int? sysNo)
        {
            var refer = new BaseRefer<BaseRentActivityInfo>();
            var res = new BaseRentActivityInfo();
            res.Extend = new ActivityExtend();
            if (sysNo > 0)
            {
                ViewBag.Title = "修改租赁活动信息";
                refer.SearchDetail = new BaseRentActivityInfo();
                refer.SearchDetail.SysNo = sysNo;
                var result = RentActivityClient.Instance.QueryRentActivityList(refer);
                return View(result.List2.FirstOrDefault());
            }
            ViewBag.Title = "新增租赁活动信息";
            return View(res);
        }

        public ActionResult GoodsDetail(int? sysNo)
        {
            var refer = new BaseRefer<BaseRentGoodsInfo>();
            var res = new BaseRentGoodsInfo();
            if (sysNo > 0)
            {
                ViewBag.Title = "修改租赁商品信息";
                refer.SearchDetail = new BaseRentGoodsInfo();
                refer.SearchDetail.SysNo = sysNo;
                var result = RentActivityClient.Instance.QueryRentGoodsList(refer);
                return View(result.List2.FirstOrDefault());
            }
            ViewBag.Title = "新增租赁商品信息";
            return View(res);
        }

        public ActionResult AgreementDetail(int? sysNo)
        {
            var refer = new BaseRefer<BaseRentAgreementInfo>();
            var res = new BaseRentAgreementInfo();
            if (sysNo > 0)
            {
                ViewBag.Title = "修改协议信息";
                refer.SearchDetail = new BaseRentAgreementInfo();
                refer.SearchDetail.SysNo = sysNo;
                var result = RentActivityClient.Instance.QueryRentAgreementList(refer);
                return View(result.List2.FirstOrDefault());
            }
            ViewBag.Title = "新增租赁协议信息";
            return View(res);
        }

        /// <summary>
        /// 活动管理
        /// </summary>
        /// <returns></returns>
        public JsonResult SaveActivityInfo(BaseRentActivityInfo req)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };
            if (!req.IsDelete.HasValue)
            {
                #region  验证

                if (string.IsNullOrEmpty(req.ActivityName))
                {
                    result.DoResult = "请输入活动名称";
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

                #endregion
            }
            req.ActivityJsonContent = Serializer.SerializeToString(req.Extend);
            req.Remarks = "操作人：" + UserInfo.UserSysNo;
            string message = "";
            if (req.SysNo > 0)
            {
                //修改
                var refer = new BaseRefer<BaseRentActivityInfo>();
                refer.SearchDetail = new BaseRentActivityInfo();
                refer.SearchDetail.SysNo = req.SysNo;
                var res = RentActivityClient.Instance.QueryRentActivityList(refer);
                if (res != null && res.List2 != null && res.List2.Any())
                {
                    var act = new BaseRentActivityInfo();
                    act = res.List2.FirstOrDefault();
                    if (req.IsDelete == true)
                    {
                        act.IsDelete = req.IsDelete;
                    }
                    else
                    {
                        act.ActivityName = req.ActivityName;
                        act.ActivityDes = req.ActivityDes;
                        act.StartTime = req.StartTime;
                        act.EndTime = req.EndTime;
                        act.ActivityJsonContent = req.ActivityJsonContent;
                        act.Remarks = req.Remarks;
                        act.IsEnable = req.IsEnable;
                    }
                    var flag = RentActivityClient.Instance.ActivityManager(act, UserInfo.UserSysNo, out message);
                    if (flag)
                    {
                        result.DoFlag = true;
                        result.DoResult = "操作成功";
                    }
                    else
                    {
                        result.DoResult = message;
                    }
                }
            }
            else
            {
                var flag = RentActivityClient.Instance.ActivityManager(req, UserInfo.UserSysNo, out message);
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "添加成功";
                }
                else
                {
                    result.DoResult = message;
                }
            }
            return Json(result);
        }

        /// <summary>
        /// 商品管理
        /// </summary>
        /// <returns></returns>
        public JsonResult SaveGoodsInfo(BaseRentGoodsInfo req)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };
            if (!req.IsDelete.HasValue)
            {
                #region  验证

                if (string.IsNullOrEmpty(req.ActivityKey))
                {
                    result.DoResult = "请输入活动Key";
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

                #endregion
            }
            req.GoodsHireSet = Serializer.SerializeToString(req.HireSet);
            
            // req.Remark = "操作人：" + UserInfo.UserSysNo;
            string message = "";
            if (req.SysNo > 0)
            {
                //修改
                var refer = new BaseRefer<BaseRentGoodsInfo>();
                refer.SearchDetail = new BaseRentGoodsInfo();
                refer.SearchDetail.SysNo = req.SysNo;
                var res = RentActivityClient.Instance.QueryRentGoodsList(refer);
                if (res != null && res.List2 != null && res.List2.Any())
                {
                    var goods = new BaseRentGoodsInfo();
                    goods = res.List2.FirstOrDefault();
                    if (req.IsDelete == true)
                    {
                        goods.IsDelete = req.IsDelete;
                    }
                    else
                    {
                        goods.GoodsId = req.GoodsId;
                        goods.ActivityKey = req.ActivityKey;
                        goods.GoodsDeCash = req.GoodsDeCash;
                        goods.StartTime = req.StartTime;
                        goods.EndTime = req.EndTime;
                        goods.RentTimeYear = req.RentTimeYear;
                        goods.Sort = req.Sort;
                        goods.GoodsShare = req.GoodsShare;
                        goods.GoodsPicUrlList = req.GoodsPicUrlList;
                        goods.PromotionId = req.PromotionId;
                        goods.GoodsHireSet = req.GoodsHireSet;
                        goods.GoodsFeeSet = req.GoodsFeeSet;
                        goods.PromotionId = req.PromotionId;
                        goods.RentAgreementId = req.RentAgreementId;
                        goods.Remark = req.Remark;
                        goods.IsEnable = req.IsEnable;
                        goods.GoodsType = req.GoodsType;
                    }
                    
                    var flag = RentActivityClient.Instance.RentGoodsManager(goods, UserInfo.UserSysNo, out message);
                    if (flag)
                    {
                        result.DoFlag = true;
                        result.DoResult = "操作成功";
                    }
                    else
                    {
                        result.DoResult = message;
                    }
                }

            }
            else
            {
                var flag = RentActivityClient.Instance.RentGoodsManager(req, UserInfo.UserSysNo, out message);
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "添加成功";
                }
                else
                {
                    result.DoResult = message;
                }
            }
            return Json(result);
        }

        public JsonResult IsEnableCartSplit(int? splitNo, int? isValid)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };
            var flag = RentActivityClient.Instance.CartSplitIsEnable(splitNo, isValid);
            if (flag)
            {
                result.DoFlag = true;
                result.DoResult = "操作成功";
            }
            return Json(result);
        }

        /// <summary>
        /// 协议管理
        /// </summary>
        /// <returns></returns>
        public JsonResult SaveAgreementInfo(BaseRentAgreementInfo req)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败"
            };

            req.Remark = "操作人：" + UserInfo.UserSysNo;
            string message = "";
            if (req.SysNo > 0)
            {
                //修改
                var refer = new BaseRefer<BaseRentAgreementInfo>();
                refer.SearchDetail = new BaseRentAgreementInfo();
                refer.SearchDetail.SysNo = req.SysNo;
                var res = RentActivityClient.Instance.QueryRentAgreementList(refer);
                if (res != null && res.List2 != null && res.List2.Any())
                {
                    var agreement = new BaseRentAgreementInfo();
                    agreement = res.List2.FirstOrDefault();
                    agreement.AgreementName = req.AgreementName;
                    agreement.AgreementContent = req.AgreementContent;
                    agreement.Remark = req.Remark;
                    agreement.IsEnable = req.IsEnable;
                    var flag = RentActivityClient.Instance.AgreementManager(agreement, UserInfo.UserSysNo, out message);
                    if (flag)
                    {
                        result.DoFlag = true;
                        result.DoResult = "操作成功";
                    }
                    else
                    {
                        result.DoResult = message;
                    }
                }

            }
            else
            {
                var flag = RentActivityClient.Instance.AgreementManager(req, UserInfo.UserSysNo, out message);
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "添加成功";
                }
                else
                {
                    result.DoResult = message;
                }
            }
            return Json(result);
        }



    }
}
