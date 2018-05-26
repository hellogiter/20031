using System;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.WebUserBe;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class WebLimitUserBehaviorController : BaseController
    {
        // GET: /WebLimitUserBehavior/

        #region 用户行为管理列表
        public ActionResult Index(UserBehaviorRefer userBehavior)
        {
            var result = new UserBehaviorRefer();
            result = WebUserBehaviorClient.Instance.GetUserBehavior(userBehavior);

            //根据用户Id查询用户名称
            if (result != null && result.List.Count > 0)
            {
                for (int i = 0; i < result.List.Count; i++)
                {
                    var UserDetail = WebAwardClient.Instance.GetUserName(result.List[i].CreateBy);
                    result.List[i].UserName = UserDetail.UserName;
                }
            }

            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }

        #endregion

        #region 根据Id查询详细信息
        public ActionResult Detail(int? id)
        {
            var result = new UserBehaviorDetail();

            if (id > 0)
            {
                result = WebUserBehaviorClient.Instance.GetuserBehaviorById(id.Value);
            }
            return View(result);
        }
        #endregion

        #region 保存
        public JsonResult Save(UserBehaviorDetail userBehavior)
        {
            var result = new BaseResponse() { };
            try
            {
                if (userBehavior.SysNo > 0)
                {
                    //修改
                    var res = WebUserBehaviorClient.Instance.UpdateuserBehavior(userBehavior);
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
                    userBehavior.UserId = UserInfo.UserSysNo;
                    userBehavior.CreateBy = UserInfo.UserSysNo;
                    userBehavior.CreateTime = DateTime.Now;
                    var res = WebUserBehaviorClient.Instance.AdduserBehavior(userBehavior);
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

        #region 修改状态

        public JsonResult UpdateSate(int id, int state)
        {
            var result = new BaseResponse();

            try
            {
                var res = WebUserBehaviorClient.Instance.UpdateuserBehaviorState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 删除

        public JsonResult Del(int id)
        {
            var result = new BaseResponse();

            try
            {
                if (id > 0)
                {
                    var res = WebUserBehaviorClient.Instance.DeluserBehavior(id);
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
                result.DoResult = "删除异常,请稍后重试... ...";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
