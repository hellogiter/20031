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
    public class CouponBabyCoinManagerController : BaseController
    {
        //
        // GET: /CouponBabyManager/

        public ActionResult Index(CouponBabyCoinRefer refer)
        {
            var result = new CouponBabyCoinRefer();
            result = CouponBabyCoinConfigClient.Instance.QueryCoponBabyCoinRelationPageList(refer);

            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            var result = new CouponBabyCoinDetail();
            if (id > 0)
            {
                var userId = UserInfo.UserSysNo;
                result = CouponBabyCoinConfigClient.Instance.QueryCoponBabyCoinRelationById(userId, id ?? 0);
            }
            return View(result);
        }

        //新增、修改
        public JsonResult Save(CouponBabyCoinDetail model)
        {
            var result = new BaseResponse() { };
            try
            {
                if (model.Id > 0)
                {
                    //修改
                    model.UpdateBy = UserInfo.UserSysNo;
                    model.UpdateDate = DateTime.Now;
                    model.IsDeleted = false;
                    var res = CouponBabyCoinConfigClient.Instance.UpdateCoponBabyCoinRelation(model);
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
                    model.CreateBy = UserInfo.UserSysNo;
                    model.CreateDate = DateTime.Now;
                    model.IsDeleted = false;
                    var res = CouponBabyCoinConfigClient.Instance.AddCoponBabyCoinRelation(model);
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


        //删除
        public JsonResult SetsetIsDely(int? Id)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "删除失败，请稍后重试... ..." };
            try
            {
                var userId = UserInfo.UserSysNo;
                var request = CouponBabyCoinConfigClient.Instance.QueryCoponBabyCoinRelationById(userId, Id ?? 0);
                request.UpdateBy = userId;
                request.IsDeleted = true;
                result.DoFlag = CouponBabyCoinConfigClient.Instance.UpdateCoponBabyCoinRelation(request);
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
