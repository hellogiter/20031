using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.UserRefer;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class UserReferController : BaseController
    {
        //  /UserRefer/

        #region 咨询列表
        public ActionResult Index(GetUserRefer userRefer)
        {
            ViewBag.UserRefer = userRefer;
            return View(userRefer);
        }

        public ActionResult Item(GetUserRefer userRefer)
        {
            try
            {
                userRefer = UserReferClient.Instance.GetUserReferList(userRefer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.UserRefer = userRefer;

            return View();
        }
        #endregion

        #region 根据id查询单条信息
        public ActionResult Detail(int? id)
        {
            var viewModel = new UserReferDetail();
            try
            {
                if (id > 0)
                {
                    viewModel = UserReferClient.Instance.GetUserRegerDetail(id.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(viewModel);
        }
        #endregion

        #region 保存咨询
        public JsonResult UpdateUserRefer(UserReferDetail userRefer)
        {
            var jsonResult = new BaseResponse() { };
            try
            {
                if (userRefer.IntReferID > 0)
                {
                    //回复咨询
                    userRefer.VchReplyPerson = UserInfo.UserSysNo;//用户Id
                    var result = UserReferClient.Instance.UpdateUserRefer(userRefer);
                    if (result)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "回复失败，请重试！";
                    }
                }
                else
                {
                    //新增咨询
                    userRefer.IntUserID = UserInfo.UserSysNo;//用户Id
                    userRefer.VchUserNick = UserInfo.UserName;//用户昵称
                    userRefer.VchMemLevel = UserInfo.DepartmentSysNo;//会员等级
                    userRefer.DtDatetime = DateTime.Now;//咨询时间

                    var res = UserReferClient.Instance.AddUserRefer(userRefer);
                    if (res)
                    {
                        jsonResult.DoFlag = true;
                    }
                    else
                    {
                        jsonResult.DoResult = "新增失败，请重试！";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(jsonResult);
        }
        #endregion

        #region 根据商品Id查询关联的咨询列表 回复列表

        public ActionResult DateilUserRefer(int? id, int? type, int pageIndex, int PageSize)
        {
            var viewModel = new UserReferByProduct();
            try
            {
                viewModel = UserReferClient.Instance.QueryUserReferByPId(id.Value, type.Value, pageIndex, PageSize);

                ViewBag.viewUserRef = viewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(viewModel);
        }
        #endregion

        #region 检测商品编号是否存在商品表
        public JsonResult CheckPdtInfoById(int id)
        {
            var result = new BaseResponse();
            string str;
            var res = UserReferClient.Instance.CheckPdtInfoById(id, out str);
            if (res)
            {
                result.DoFlag = true;
                result.DoResult = str;
            }
            else
            {
                result.DoResult = str;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改状态
        public JsonResult UpdateState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = UserReferClient.Instance.UpdateState(id, state);
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
                result.DoResult = "修改失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 导出execl
        /// <summary>
        /// 导出execl
        /// </summary>
        /// <param name="execlModel"></param>
        /// <returns></returns>
        public JsonResult ExportExecl(ExportExeclModel execlModel)
        {
            var result = new BaseResponse();
            List<UserReferDetail> list = null;
            //查询数据
            list = UserReferClient.Instance.ExportExeclss(execlModel);
            try
            {
                string strFile = "咨询管理-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv"; //生成的Excel名称
                StringBuilder sb = new StringBuilder();
                sb.Append("编号,用户编号,商品编号,商品名称,咨询内容.,咨询类型,咨询日期,回复内容,回复人,回复日期,是否可见");
                sb.AppendLine();
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        sb.Append(list[i].IntReferID + "," + list[i].IntUserID + "," + list[i].IntProductID + "," +
                                  list[i].VchProductName + "," + list[i].VchContent + "," + list[i].IntReferType +
                                  "," +
                                  list[i].DtDatetime + "," + list[i].VchReplyContent + "," + list[i].VchReplyPerson +
                                  "," + list[i].DtReplyDatetime + "," + list[i].IntOtherIsVisible);
                        sb.AppendLine();
                    }
                }
                StringWriter sw = new StringWriter(sb);
             
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "e:\\" + strFile));
                Response.ContentType = "text/xml";
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.Write(sw);
                Response.Flush();
                Response.End();
                sw.Close();
                result.DoFlag = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
