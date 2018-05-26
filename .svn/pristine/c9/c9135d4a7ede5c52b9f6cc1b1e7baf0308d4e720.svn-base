using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.Project;
using Myzj.OPC.UI.ServiceClient;

//专题页
namespace Myzj.OPC.UI.Portal.Controllers
{
    public class ProjectController : Controller
    {
        #region 专题管理
        /// <summary>
        /// 专题管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 专题列表
        /// <summary>
        /// 专题列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Item(GetProjectList model)
        {
            try
            {
                model = ProjectClient.Instance.GetList(model);
            }
            catch (Exception ex)
            {

            }

            ViewBag.GetProjectList = model;

            return View();
        }
        #endregion

        #region 修改状态
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id">专题ID</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpState(int id, int state)
        {
            var result = new BaseResponse();

            try
            {
                result = ProjectClient.Instance.UpState(id, state);
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改排序
        /// <summary>
        /// 修改排序
        /// </summary>
        /// <param name="id">专题ID</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpSort(int id, int sort)
        {
            var result = new BaseResponse();

            try
            {
                result = ProjectClient.Instance.UpSort(id, sort);
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 专题详细页
        /// <summary>
        /// 专题详细页
        /// </summary>
        /// <param name="projectId">专题ID</param>
        /// <returns></returns>
        public ActionResult Detail(int projectId = 0)
        {
            var model = new ProjectDetail();

            try
            {
                if (projectId > 0)
                {
                    var result = ProjectClient.Instance.GetProjectModel(projectId);
                    if (result.DoFlag)
                    {
                        model = result.Info;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            ViewBag.ProjectDetail = model;
            return View();
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Save(ProjectOperation model)
        {
            var result = new BaseResponse();

            try
            {
                result = ProjectClient.Instance.Save(model);
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet); 
        }
        #endregion
    }
}
