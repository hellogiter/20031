using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MYZJ.Finance.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class CouponAuditRoleController : Controller
    {
        //
        // GET: /CouponAuditRole/

        public ActionResult Index()
        {
            var result = BaseCouponConfigClient.Instance.QueryRole();
            return View(result);
        }

        public ActionResult EditRole(int? sysNo)
        {
            ViewBag.Title = "添加角色信息";
            var detail = new AuditRoleDetail();
            if (sysNo.HasValue)
            {
                var result = BaseCouponConfigClient.Instance.QueryRole(sysNo);
                if (result != null && result.Any())
                {
                    detail = result.First();
                    ViewBag.Title = "编辑角色信息";
                }
            }
            return View(detail);
        }

        public JsonResult SaveRole(AuditRoleDetail detail)
        {
            var result = new BaseResponse()
            {
                DoFlag = false
            };
            var flag = false;
            string message = "";
            if (detail.SysNo.HasValue)
            {
                //修改
                flag = BaseCouponConfigClient.Instance.UpdateRole(detail, out message);

            }
            else
            {
                //添加
                flag = BaseCouponConfigClient.Instance.AddRole(detail, out message);
            }
            if (flag)
            {
                result.DoResult = "操作成功";
                result.DoFlag = true;
            }
            else
            {
                result.DoResult = message;
            }
            return Json(result);
        }

        public JsonResult DeleteRole(int sysNo)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "删除失败 ，请稍后重试……"
            };
            var detail = BaseCouponConfigClient.Instance.QueryRole(sysNo).First();
            detail.IsDelete = true;
            var message = "";
            var flag = BaseCouponConfigClient.Instance.UpdateRole(detail, out message);
            if (flag)
            {
                result.DoResult = "删除成功";
                result.DoFlag = true;
            }
            return Json(result);
        }

        //用户角色列表
        public ActionResult UserRoleIndex(BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt> refer)
        {
            var result = BaseCouponConfigClient.Instance.QueryUserRole(refer);
            return View(result);
        }
        //根据部门Id 查询部门用户
        public JsonResult GetDeptUser(string deptId)
        {
            var user = BaseCouponConfigClient.Instance.GetAllUser(int.Parse(deptId));
            // var strJson = Serializer.SerializeToString(user);
            var str = new StringBuilder();
            str.Append("<option value='-1' selected=\"selected\">--请选择用户--</option>");
            if (user.Any())
            {
                foreach (var item in user)
                {
                    str.Append("<option value='");
                    str.Append(item.Key);
                    str.Append("'>");
                    str.Append(item.Value);
                    str.Append("</option>");
                }
            }

            return Json(str.ToString());
        }

        public JsonResult DeleteUserRole(int sysNo)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "删除失败 ，请稍后重试……"
            };
            var refer = new BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt>();
            refer.SearchDetail = new AuditRoleConfigDetail();
            refer.SearchDetail.SysNo = sysNo;
            var detail = BaseCouponConfigClient.Instance.QueryUserRole(refer).List2.First();
            detail.IsDelete = true;
            var message = "";
            var flag = BaseCouponConfigClient.Instance.UpdateUserRole(detail, out message);
            if (flag)
            {
                result.DoResult = "删除成功";
                result.DoFlag = true;
            }
            return Json(result);
        }

        public ActionResult EditUserRole(int? sysNo)
        {
            ViewBag.Title = "添加用户角色信息";
            var detail = new AuditRoleConfigDetailExt();
            var refer = new BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt>();
            refer.SearchDetail = new AuditRoleConfigDetail();
            if (sysNo.HasValue)
            {
                refer.SearchDetail.SysNo = sysNo;
                var result = BaseCouponConfigClient.Instance.QueryUserRole(refer).List2;
                if (result != null && result.Any())
                {
                    detail = result.First();
                    ViewBag.Title = "编辑用户角色信息";
                }
            }
            return View(detail);
        }



        public JsonResult SaveUserRole(AuditRoleConfigDetailExt detail)
        {
            var result = new BaseResponse()
            {
                DoFlag = false
            };
            var flag = false;
            string message = "";
            if (string.IsNullOrEmpty(detail.RoleStr))
            {
                return Json(result);
            }

            //修改  删除所有的会员数据，重新添加
            if (detail.SysNo.HasValue)
            {
                var delete = BaseCouponConfigClient.Instance.DeleteUserRole(detail.MemberId);
            }

            var list = detail.RoleStr.Split(',');
            foreach (var s in list)
            {
                detail.MemberRole = int.Parse(s);
                //if (detail.SysNo.HasValue)
                //{
                //    //修改
                //    flag = BaseCouponConfigClient.Instance.UpdateUserRole(detail, out message);
                //}
                //else
                //{
                //添加
                flag = BaseCouponConfigClient.Instance.AddUserRole(detail, out message);
                //}
                if (flag)
                {
                    result.DoResult = "操作成功";
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = message;
                }
            }
            return Json(result);
        }


        //审核规则
        public ActionResult RuleIndex()
        {
            var result = BaseCouponConfigClient.Instance.QueryRule();
            return View(result);
        }

        public ActionResult EditRule(int? sysNo)
        {
            ViewBag.Title = "添加规则信息";
            var detail = new AuditRuleDetail();
            if (sysNo.HasValue)
            {
                var result = BaseCouponConfigClient.Instance.QueryRule(sysNo);
                if (result != null && result.Any())
                {
                    detail = result.First();
                    ViewBag.Title = "编辑规则信息";
                }
            }
            return View(detail);
        }

        public JsonResult SaveRule(AuditRuleDetail detail)
        {
            var result = new BaseResponse()
            {
                DoFlag = false
            };
            var flag = false;
            string message = "";
            if (detail.SysNo.HasValue)
            {
                //修改
                flag = BaseCouponConfigClient.Instance.UpdateRule(detail, out message);

            }
            //else
            //{
            //    //添加
            //    flag = BaseCouponConfigClient.Instance.AddRule(detail, out message);
            //}
            if (flag)
            {
                result.DoResult = "操作成功";
                result.DoFlag = true;
            }
            else
            {
                result.DoResult = message;
            }
            return Json(result);
        }

        public JsonResult DeleteRule(int sysNo, int isDelete)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "操作失败 ，请稍后重试……"
            };
            var detail = BaseCouponConfigClient.Instance.QueryRule(sysNo).First();
            if (isDelete == 1)
                detail.IsDelete = true;
            else
            {
                detail.IsDelete = false;
            }
            var message = "";
            var flag = BaseCouponConfigClient.Instance.UpdateRule(detail, out message);
            if (flag)
            {
                result.DoResult = "操作成功";
                result.DoFlag = true;
            }
            return Json(result);
        }
    }
}
