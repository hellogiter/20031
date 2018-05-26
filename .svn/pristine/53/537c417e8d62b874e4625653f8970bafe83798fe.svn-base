using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.SaleHotStyle;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class SaleHotStyleController : BaseController
    {
        // GET: /SaleHotStyle/

        #region 爆品列表
        public ActionResult Index(SaleHotStyleRefer saleHotStyle)
        {
            var result = new SaleHotStyleRefer();
            string name = "";
            result = SaleHotStyleClient.Instance.QuerySaleHotStyle(saleHotStyle);


            List<SaleHotStyleDetail> list = result.List;

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    //根据商品Id返回商品名称
                    string productName = SaleHotStyleClient.Instance.QueryPdtBaseInfoById(list[i].ProductId.Value);
                    list[i].vchProductName = productName;
                }
            }
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

        #region 根据Id查询单条信息
        public ActionResult Detail(int? id, string name)
        {
            var result = new SaleHotStyleDetail();
            result.Id = id;
            if (id > 0)
            {
                result = SaleHotStyleClient.Instance.QuerySaleHotStyleById(result);
            }
            //应用位置列表
            var hotStyleApply = SaleHotStyleClient.Instance.QuerySaleHotStyleApplyPlace();
            ViewBag.HotStyleApply = hotStyleApply;
            ViewBag.ProductName = name;
            return View(result);
        }
        #endregion

        #region 修改/新增爆品商品
        public JsonResult SaveSaleHotStyle(SaleHotStyleDetail saleHotStyle)
        {
            var result = new BaseResponse();
            string str = "";
            try
            {
                if (saleHotStyle.Id > 0)
                {
                    //修改
                    saleHotStyle.UpdateBy = UserInfo.UserSysNo;
                    saleHotStyle.UpdateDate = DateTime.Now;
                    var res = SaleHotStyleClient.Instance.UpdateSaleHotStyle(saleHotStyle, out str);

                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改异常，请稍后重试... ...";
                    }
                }
                else
                {
                    //新增
                    saleHotStyle.CreateBy = 1111;
                    saleHotStyle.CreateDate = DateTime.Now;
                    var res = SaleHotStyleClient.Instance.AddSaleHotStyle(saleHotStyle, out str);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "新增异常，请稍后重试... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 取消爆品商品置顶信息
        public JsonResult CancelSaleHotStyleIsTop(int id)
        {
            var result = new BaseResponse();

            try
            {
                var res = SaleHotStyleClient.Instance.CancelSaleHotStyleIsTop(id);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "取消爆品置顶失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "取消爆品置顶异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 保存置顶信息
        public JsonResult SaveIsTop(int id, DateTime startDate, DateTime endDate)
        {
            var result = new BaseResponse();
            short isTop = 1;
            try
            {
                var res = SaleHotStyleClient.Instance.UpdateSaleHotStyleIsTop(id, isTop, startDate, endDate);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "置顶失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "置顶异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改爆品商品状态
        public JsonResult UpdateSaleHotStyleState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleClient.Instance.UpdateSaleHotStyleState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改失败，请稍后重试... ...";
                }
            }
            catch (Exception)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改爆品商品排序
        public JsonResult UpdateSaleHotStyleSort(int id, int sort)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleClient.Instance.UpdateSaleHotStyleSort(id, sort);
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

        #region 删除爆品商品
        public JsonResult DelSaleHotStyle(int id)
        {
            var result = new BaseResponse();
            try
            {
                var res = SaleHotStyleClient.Instance.DelSaleHotStyle(id);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "删除失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 检测商品编号是否存在商品表中
        public JsonResult CheckPdtInfoById(int productId)
        {
            var result = new BaseResponse();
            string str = "";
            try
            {
                var res = SaleHotStyleClient.Instance.CheckPdtInfoById(productId, out str);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = str;
                }
                else
                {
                    result.DoResult = "<font style='color:red'>错误：系统未在商品表中找到商品Id，请检查</font>";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "<font style='color:red'>检测异常，请稍后重试... ..</font>.";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
