using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.SaleHotStyleSpecialSubject;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class SaleHotStyleSpecialSubjectController : BaseController
    {
        // GET: /SaleHotStyleSpecialSubject/

        #region  活动专题列表
        /// <summary>
        /// 活动专题列表
        /// </summary>
        /// <param name="specialSubject"></param>
        /// <returns></returns>
        public ActionResult Index(SaleHotStyleSpecialSubjectRefer specialSubject)
        {
            var result = new SaleHotStyleSpecialSubjectRefer();
            result = SaleHotStyleSpecialSubjectClient.Instance.QuertSaleHotStyleSpeciaSubject(specialSubject);

            //应用位置列表
            var hotStyleApply = SaleHotStyleClient.Instance.QuerySaleHotStyleApplyPlace();
            ViewBag.StyleApply = hotStyleApply;

            //生成下拉列表并绑定值
            List<SelectListItem> ddClass = new List<SelectListItem>();
            foreach (var cls in hotStyleApply)
            {
                ddClass.Add(new SelectListItem() { Value = cls.ApplyPlaceId.ToString(), Text = cls.ApplyPlaceName });
            }
            ViewData.Add("SearchDetail.ApplyPlace", ddClass);

            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 专题活动详情
        /// <summary>
        /// 专题活动详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int? id)
        {
            var result = new SaleHotStyleSpecialSubjectDetail();
            if (id > 0)
            {
                result = SaleHotStyleSpecialSubjectClient.Instance.QuertSaleHotStyleSpeciaSubjectById(id.Value);
            }

            //应用位置列表
            var hotStyleApply = SaleHotStyleClient.Instance.QuerySaleHotStyleApplyPlace();
            ViewBag.HotStyleApply = hotStyleApply;
            return View(result);
        }

        #endregion

        #region 新增/修改专题活动
        /// <summary>
        ///  新增/修改专题活动
        /// </summary>
        /// <param name="specialSubject"></param>
        /// <returns></returns>
        public JsonResult Save(SaleHotStyleSpecialSubjectDetail specialSubject)
        {
            var result = new BaseResponse();
            try
            {
                if (specialSubject.Id > 0)
                {
                    //修改
                    specialSubject.UpdateBy = UserInfo.UserSysNo;
                    specialSubject.UpdateDate = DateTime.Now;
                    var res = SaleHotStyleSpecialSubjectClient.Instance.Update(specialSubject);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "修改成功... ...";
                    }
                    else
                    {
                        result.DoResult = "修改失败... ...";
                    }
                }
                else
                {
                    //新增
                    specialSubject.CreateBy = UserInfo.UserSysNo;
                    specialSubject.CreateDate = DateTime.Now;
                    specialSubject.IsDeleted = false;
                    specialSubject.IsEnable = true;
                    specialSubject.IsTop = 0;
                    var res = SaleHotStyleSpecialSubjectClient.Instance.Add(specialSubject);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "新增成功... ...";
                    }
                    else
                    {
                        result.DoResult = "新增失败... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后再试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 修改专题活动状态
        /// <summary>
        /// 修改专题活动状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public JsonResult UpdateState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleSpecialSubjectClient.Instance.UpdateState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改状态成功... ...";
                }
                else
                {
                    result.DoResult = "修改状态失败... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改状态异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 修改专题活动排序
        /// <summary>
        /// 修改专题活动排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public JsonResult UpdateSort(int id, int sort)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleSpecialSubjectClient.Instance.UpdateSort(id, sort);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改成功... ...";
                }
                else
                {
                    result.DoResult = "修改失败... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 设置活动专题置顶/取消置顶
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="top">0 取消置顶  1置顶</param>
        /// <param name="startDate">置顶开始时间</param>
        /// <param name="endDate">置顶结束时间</param>
        /// <returns></returns>
        public JsonResult UpdateTop(int id, int top, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleSpecialSubjectClient.Instance.UpdateIsTop(id, top, startDate, endDate);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "置顶成功... ...";
                }
                else
                {
                    result.DoResult = "置顶失败... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "置顶异常... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除专题活动
        /// <summary>
        /// 删除专题活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Del(int id)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleSpecialSubjectClient.Instance.DelSaleHotStyleSpeciaSubject(id);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "删除专题成功... ...";
                }
                else
                {
                    result.DoResult = "删除专题失败... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除专题异常... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
