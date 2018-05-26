using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class CouponManageController : BaseController
    {
        //查询列表
        public ActionResult Index(CouponInfoDtailRefer refer)
        {
            var result = new CouponInfoDtailRefer();


            result = BaseCouponConfigClient.Instance.QueryCouponInfoPageList(refer);
            ViewBag.StartTime = refer.SearchDetail.StartTime;
            ViewBag.EndTime = refer.SearchDetail.EndTime;
          
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }

        public ActionResult Cate(string ct, string ct2, int? id)
        {
            ViewData.Add("Id", id);
            ViewData.Add("Ct", ct);
            ViewData.Add("Ct2", ct2);
            return View();
        }
        //新增修改页面
        public ActionResult Detail(int? id)
        {
            var copyId = Request.QueryString["copyId"];
            if (!string.IsNullOrEmpty(copyId))
            {
                var a = 0;
                int.TryParse(copyId, out a);
                id = a;
            }
            var result = new CouponInfoDetailExt();
            if (id > 0)
            {
                result = BaseCouponConfigClient.Instance.QueryCouponInfoEntity(id.Value);
            }
            else
            {
                //model默认值
                result.SendLimitUserCount = 1;
                result.SendLimitCount = 1;
                result.UseSetDays = 0;
                result.Belonging = "1";
                result.WillReachWarning = 0;
                result.DeptId = 1;
            }

            //获取发货仓库
            var resultItem = BaseCouponConfigClient.Instance.QueryWareHouseList();
            ViewBag.ItemModel = resultItem;
            return View(result);
        }

        //查询详细页
        public ActionResult Detail2(int? id)
        {
            var result = new CouponInfoDetailExt();
            if (id > 0)
            {
                result = BaseCouponConfigClient.Instance.QueryCouponInfoEntity(id.Value);
            }
            else
            {
                //model默认值
                result.SendLimitUserCount = 1;
                result.SendLimitCount = 1;
                result.UseSetDays = 0;
                result.Belonging = "1";
            }
            //获取发货仓库
            var resultItem = BaseCouponConfigClient.Instance.QueryWareHouseList();
            ViewBag.ItemModel = resultItem;
            return View(result);
        }
        //新增、修改
        public JsonResult Save(CouponInfoDetailExt model)
        {
            var result = new BaseResponse() { };
            if (model.StartTime >= model.EndTime)
            {
                result.DoResult = "结束时间不能小于开始时间";
                goto ovr;
            }
            try
            {
                if (model.SysNo > 0)
                {
                    //修改
                    model.UpdatePeople = UserInfo.UserSysNo;
                    model.UpdateTime = DateTime.Now;
                    model.IsDelete = false;




                    //判断已修改待审核
                    var isAuditStatus = BaseCouponConfigClient.Instance.QueryCouponInfoEntity(model.SysNo);
                    if (isAuditStatus.AuditState == 0)
                    {
                        result.DoResult = "待审核中，无法修改... ...";
                        goto ovr;
                    }
                    //获取  最高审核等级
                    string auditLevel = BaseCouponConfigClient.Instance.GetAuditLevel(isAuditStatus.CouponKey);
                    if (isAuditStatus.AuditLevel <=int.Parse(auditLevel))
                        model.AuditLevel = int.Parse(auditLevel);

                    model.AuditState = -1;
                    var res = BaseCouponConfigClient.Instance.UpdateCouponInfo(model);
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
                    model.CreatePeople = UserInfo.UserSysNo;
                    model.IsDelete = false;
                    model.CouponKey = Utils.MD5Encrypt(Guid.NewGuid().ToString(), 16);
                    var res = BaseCouponConfigClient.Instance.AddCouponInfo(model);
                    if (res)
                    {
                        result.DoFlag = true;
                        //新增成功后  获取 审核等级
                        string auditLevel = BaseCouponConfigClient.Instance.GetAuditLevel(model.CouponKey);
                        //根据couponkey 查询
                        CouponInfoDtailRefer refer = new CouponInfoDtailRefer();
                        refer.SearchDetail.CouponKey = model.CouponKey;
                        var couponInfo = BaseCouponConfigClient.Instance.QueryCouponInfoPageList(refer).List2.First();
                        couponInfo.AuditLevel = int.Parse(auditLevel);
                        //更新
                       // var up = BaseCouponConfigClient.Instance.UpdateCouponInfo(couponInfo);
                        var up = BaseCouponConfigClient.Instance.UpdateAuditLevel(couponInfo.SysNo,couponInfo.AuditLevel);
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
        ovr: return Json(result);
        }

        //启用,1启用 2禁用
        public JsonResult SetIsEnabey(int? SysNo, int? Type)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "保存失败，请稍后重试... ..." };
            try
            {
                var userid = UserInfo.UserSysNo;
                var flag = Type == 1 ? true : false;
                result.DoFlag = BaseCouponConfigClient.Instance.DeleteCouponInfo(userid, SysNo, 1, flag);
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后重试... ..." + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //删除
        public JsonResult SetsetIsDely(int? SysNo)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "删除失败，请稍后重试... ..." };
            try
            {
                var useid = UserInfo.UserSysNo;
                result.DoFlag = BaseCouponConfigClient.Instance.DeleteCouponInfo(useid, SysNo, 0, true);
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //复制
        public JsonResult SetIsCopy(int? SysNo)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "复制失败，请稍后重试... ..." };
            try
            {
                var useid = UserInfo.UserSysNo;
                result.DoFlag = BaseCouponConfigClient.Instance.CopyCouponInfo(useid, SysNo);
            }
            catch (Exception ex)
            {
                result.DoResult = "复制异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //提交审核
        public JsonResult SumbitAudit(int? SysNo)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "提交失败，请稍后重试... ..." };
            try
            {
                var useid = UserInfo.UserSysNo;
                result.DoFlag = BaseCouponConfigClient.Instance.UpdateAuditState(SysNo, useid, 0, 8);
            }
            catch (Exception ex)
            {
                result.DoResult = "提交审核异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //查询品牌列表
        public ActionResult BrandList(string id, string BrandName)
        {
            ViewBag.ID = id;
            ViewBag.BrandName = BrandName;
            var dic = BaseCouponConfigClient.Instance.QueryBrandList(BrandName);
            return View(dic);
        }
    }
}
