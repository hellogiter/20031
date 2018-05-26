using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.MotherUser;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class MotherUserController : BaseController
    {
        #region 用户管理
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(GetMotherUserRequest model)
        {


            ViewBag.MotherUser = model;

            var total = 0;
            try
            {
                var list = MotherUserClient.Instance.GetMotherUserList(model, out total);
            }
            catch (Exception ex)
            {

                throw;
            }
            model.Total = total;
            ViewBag.ByReportProjectId = model.UserId;
            return View();
        }
        #endregion

        #region 用户列表
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Item(GetMotherUserRequest model)
        {
            var total = 0;

            var list = new List<MotherUserDetail>();
            try
            {
                list = MotherUserClient.Instance.GetMotherUserList(model, out total);
            }
            catch (Exception ex)
            {

                throw;
            }
            model.Total = total;
            ViewBag.List = list;
            return View();
        }
        #endregion

        #region 修改用户状态
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpMotherUserState(int userId, int state)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.UpMotherUserState(userId, state);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加系统账号
        /// <summary>
        /// 添加系统账号
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult AddSysMotherUser(int userId)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.AddSysMotherUser(userId);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除系统账号
        /// <summary>
        /// 删除系统账号
        /// </summary>
        /// <param name="sysUserId">系统ID</param>
        /// <returns></returns>
        public JsonResult DelSysMotherUser(int sysUserId)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.DelSysMotherUser(sysUserId);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改系统关注
        /// <summary>
        /// 修改系统关注
        /// </summary>
        /// <returns></returns>
        public JsonResult UpSysMotherUserFocus(int sysUserId, int isDefaultFocus)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.UpSysMotherUserFocus(sysUserId, isDefaultFocus);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加推荐妈妈
        /// <summary>
        /// 添加推荐妈妈
        /// </summary>
        /// <param name="mUserId">用户ID</param>
        /// <returns></returns>
        public JsonResult AddRecommendedMother(int mUserId)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.AddRecommendedMother(mUserId);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除推荐妈妈
        /// <summary>
        /// 删除推荐妈妈
        /// </summary>
        /// <param name="recommendedMId">推荐用户ID</param>
        /// <returns></returns>
        public JsonResult DelRecommendedMother(int recommendedMId)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.DelRecommendedMother(recommendedMId);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改推荐妈妈排序
        /// <summary>
        /// 修改推荐用户排序
        /// </summary>
        /// <param name="recommendedMId">Id</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public JsonResult UpRecommendedMotherSort(int recommendedMId, int sort)
        {
            var result = new BaseResponse();

            try
            {
                result = MotherUserClient.Instance.UpRecommendedMotherSort(recommendedMId, sort);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}