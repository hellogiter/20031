using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.SpreadInfo;
using Myzj.OPC.UI.Portal.Models.DomainModels;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class SpreadInfoController : BaseController
    {

        // GET: /SpreadInfo/

        #region 推广列表
        /// <summary>
        /// 推广列表
        /// </summary>
        /// <param name="spreadInfo"></param>
        /// <returns></returns>
        public ActionResult Index(SpreadInfoRefer spreadInfo)
        {

            #region 通过第三方标识查找用户信息
            var res = new ResultUserByUnionIdentity();
            var req = new GetUserByUnionIdentity();
            res = QueryUserByUnionIdentity(req);

            Session["S_RoleInfo"] = res.RoleInfo;
            Session["S_UserInfo"] = res.UserInfo;
            #endregion

            var result = new SpreadInfoRefer();
            spreadInfo.SearchDetail.UserId = UserInfo.UserSysNo;
            result = SpreadInfoClient.Instance.QuertSpreadInfo(spreadInfo);
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }

        #endregion

        #region 推广点详情
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int? id)
        {
            //获取归属地列表
            var list = new List<SpreadUserDetail>();
            list = SpreadInfoClient.Instance.QueryRegionList();
            ViewBag.Region = list;

            //获取活动列表
            var listActivity = new Activity();
            listActivity = SpreadInfoClient.Instance.QueryAllActivity();
            ViewBag.AllActivity = listActivity;


            //查询推广点详情


            return View();
        }
        #endregion

        #region 创建推广点/推广人员信息
        /// <summary>
        /// 创建推广用户信息
        /// </summary>
        /// <param name="spreadUser"></param>
        /// <returns></returns>
        public JsonResult Save(CreateSpreadUser spreadUser)
        {
            var result = new BaseResponse();
            try
            {

                if (spreadUser.SpreadId > 0)
                {
                    //修改
                    var res = SpreadInfoClient.Instance.UpdateSpreadInfo(spreadUser);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "修改推广信息成功";
                    }
                    else
                    {
                        result.DoResult = "修改推广信息失败";
                    }
                }
                else
                {
                    if (spreadUser.Type == 1)
                    {
                        spreadUser.SpreadType = AppEnum.SpreadType.Online;
                    }
                    else
                    {
                        spreadUser.SpreadType = AppEnum.SpreadType.GroundSpread;
                    }

                    spreadUser.CreateUserId = UserInfo.UserSysNo;
                    var res = SpreadInfoClient.Instance.CreateSpreadUser(spreadUser);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "创建成功... ...";
                    }
                    else
                    {
                        result.DoResult = "创建失败... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存推广点异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 创建归属地
        /// <summary>
        /// 创建归属地
        /// </summary>
        /// <param name="spreadUser"></param>
        /// <returns></returns>
        public ActionResult AddAttribution()
        {
            //获取归属地列表
            var list = new List<SpreadUserDetail>();
            list = SpreadInfoClient.Instance.QueryRegionList();
            ViewBag.Region = list;

            //获取活动列表
            var listActivity = new Activity();
            listActivity = SpreadInfoClient.Instance.QueryAllActivity();
            ViewBag.AllActivity = listActivity;

            return View();
        }

        public JsonResult CreateAttribution(CreateSpreadUser spreadUser)
        {
            var result = new BaseResponse();
            try
            {
                spreadUser.ParentUserId = UserInfo.UserSysNo;
                spreadUser.SpreadType = AppEnum.SpreadType.Online;
                spreadUser.CreateUserId = UserInfo.UserSysNo;
                var res = SpreadInfoClient.Instance.CreateRegionUser(spreadUser);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "创建归属地成功... ...";
                }
                else
                {
                    result.DoResult = "创建归属地失败... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "创建归属地异常,请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 修改推广信息状态
        public JsonResult UpdateSpreadInfoState(int id, string state)
        {
            var result = new BaseResponse();
            try
            {
                var res = SpreadInfoClient.Instance.UpdateSpreadInfoState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改状态成功";
                }
                else
                {
                    result.DoResult = "修改状态失败";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改状态异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //***************************************************************************

        #region 推广活动列表
        /// <summary>
        /// 推广活动列表
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public ActionResult ActivityIndex(SpreadActivityRefer activity)
        {
            #region 通过第三方标识查找用户信息
            var res = new ResultUserByUnionIdentity();
            var req = new GetUserByUnionIdentity();
            res = QueryUserByUnionIdentity(req);

            Session["S_RoleInfo"] = res.RoleInfo;
            Session["S_UserInfo"] = res.UserInfo;
            #endregion


            var result = new SpreadActivityRefer();
            result = SpreadInfoClient.Instance.QueryActivityListByPage(activity);
            return View(result);
        }

        public ActionResult ActivityItem()
        {
            return View();
        }
        #endregion

        #region 活动详情
        /// <summary>
        /// 创建活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ActivityDetail(int? id)
        {
            var result = new AddSpreadActivity();
            //查询活动详情
            if (id > 0)
            {
                result = SpreadInfoClient.Instance.QuerySpreadActivityById(id.Value);

                ViewBag.SpreadActivity = result;
            }
            return View(result);
        }
        #endregion

        #region 创建/修改活动
        /// <summary>
        /// 创建活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public JsonResult SaveActivity(AddSpreadActivity activity)
        {
            var result = new BaseResponse();
            try
            {
                if (activity.ActivityId > 0)
                {
                    //修改
                    var res = SpreadInfoClient.Instance.UpdateActivity(activity);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "修改活动成功... ...";
                    }
                    else
                    {
                        result.DoResult = "修改活动失败... ...";
                    }
                }
                else
                {
                    activity.CreateByUserId = UserInfo.UserSysNo;
                    activity.CreatedTime = DateTime.Now;
                    activity.IsDelete = false;

                    var res = SpreadInfoClient.Instance.AddSpreadActivity(activity);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "创建活动成功... ...";
                    }
                    else
                    {
                        result.DoResult = "创建活动失败... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存活动异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改活动状态
        /// <summary>
        /// 修改活动状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public JsonResult UpdateState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = SpreadInfoClient.Instance.UpdateState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改状态成功";
                }
                else
                {
                    result.DoResult = "修改状态失败";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改状态异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 删除活动
        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelActivity(int id)
        {
            var result = new BaseResponse();
            try
            {
                var res = SpreadInfoClient.Instance.DelActivity(id);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "删除活动成功";
                }
                else
                {
                    result.DoResult = "删除活动失败";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除活动异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //***************************************************************************

        #region 推广统计列表
        /// <summary>
        /// 推广统计列表
        /// </summary>
        /// <param name="spreadBase"></param>
        /// <returns></returns>
        public ActionResult SpreadDataReport(SpreadBaseRefer spreadBase)
        {
            //获取归属地列表
            var list = new List<SpreadUserDetail>();
            list = SpreadInfoClient.Instance.QueryRegionList();

            //生成下拉列表并绑定值
            List<SelectListItem> ddClass = new List<SelectListItem>();
            foreach (var cls in list)
            {
                ddClass.Add(new SelectListItem() { Value = cls.UserId.ToString(), Text = cls.UserName });
            }
            ViewData.Add("SearchDetail.RegionId", ddClass);

            ViewBag.SpreadBaseInfo = spreadBase;


            #region 通过第三方标识查找用户信息
            var res = new ResultUserByUnionIdentity();
            var req = new GetUserByUnionIdentity();
            res = QueryUserByUnionIdentity(req);

            Session["S_RoleInfo"] = res.RoleInfo;
            Session["S_UserInfo"] = res.UserInfo;
            #endregion

            return View(spreadBase);
        }

        public ActionResult SpreadDataReportItem(SpreadBaseRefer spreadBase)
        {
            try
            {
                spreadBase = SpreadInfoClient.Instance.QueryAllSpreadDataReport(spreadBase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.SpreadBaseInfo = spreadBase;

            return View();
        }
        #endregion

        #region 获取所有未注册用户数据统计列表

        //public ActionResult UnRegisterUserItem()
        //{
        //    return View();
        //}
        #endregion

        #region 导出获取所有未注册用户数据统计列表

        public JsonResult DrowldUnRegisterUser()
        {
            var result = new BaseResponse();
            try
            {
                var req = new UnRegisterUserRefer();

                var list = SpreadInfoClient.Instance.QueryUnRegisterUser(req);
                try
                {
                    string strFile = "地推未注册的用户-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv"; //生成的Excel名称
                    StringBuilder sb = new StringBuilder();
                    sb.Append("手机号,宝宝生日/预产期,参加的活动,推广点名称,提交日期");
                    sb.AppendLine();
                    if (list != null && list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            sb.Append(list[i].Phone + "," + list[i].BirthDay + "," + list[i].ActivityName + "," +
                                      list[i].SpreadUserName + "," + list[i].SubmitTime);
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
                    result.DoResult = "导出数据成功！";
                }
                catch (Exception ex)
                {
                    result.DoResult = "导出数据失败，请稍后重试！";
                }
            }
            catch (Exception)
            {
                result.DoResult = "导出数据失败，请稍后重试！";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 通过第三方标识查找用户信息
        /// <summary>
        /// 通过第三方标识查找用户信息
        /// </summary>
        /// <param name="userByUnion"></param>
        public ResultUserByUnionIdentity QueryUserByUnionIdentity(GetUserByUnionIdentity userByUnion)
        {
            var result = new ResultUserByUnionIdentity();
            userByUnion.Identity = UserInfo.UserSysNo.ToString();
            userByUnion.IdentityType = AppEnum.SpreadUnionIdentityType.MyzkBackStageUser;
            var res = SpreadInfoClient.Instance.QueryUserByUnionIdentity(userByUnion);
            if (result != null)
            {
                result.RoleInfo = res.RoleInfo;
                result.UserInfo = res.UserInfo;
            }
            return result;
        }
        #endregion



        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveTest(TestDetail model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Test");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View("Test");
        }
    }
}
