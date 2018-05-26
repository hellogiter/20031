using System;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.OrderProductState;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class OrderProductStateController : Controller
    {
        // GET: /OrderProductState/

        #region 查询订单扭转物流信息配置
        public ActionResult Index(OrderProductStateRefer orderProduct)
        {
            var result = new OrderProductStateRefer();
            result = OrderProductStateClient.Instance.QueryOrderProductStatusConfig(orderProduct);
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 详细信息
        public ActionResult Detail(int? id)
        {
            var result = new OrderProductStateDetail();
            if (id > 0)
            {
                result = OrderProductStateClient.Instance.QueryOrderProductStatusConfigById(id.Value);
            }

            //仓位标识列表  QueryBaseWarehouse
            var ResultWarehouse = OrderProductStateClient.Instance.QueryBaseWarehouse();

            //生成下拉列表并绑定值
            //  List<SelectListItem> ddClass = new List<SelectListItem>();
            //foreach (var cls in ResultWarehouse)
            //{
            //    ddClass.Add(new SelectListItem() { Value = cls.Id.ToString(), Text = cls.WarehouseName });
            //}
            //ViewData.Add("WareHouse", ddClass);
            ViewBag.ResultWarehouse = ResultWarehouse;

            return View(result);
        }
        #endregion

        #region 修改/新增订单扭转物流信息
        public JsonResult Save(OrderProductStateDetail detail)
        {
            var result = new BaseResponse();
            try
            {
                if (detail.ID > 0)
                {
                    detail.UpdateDate = DateTime.Now;
                    var res = OrderProductStateClient.Instance.UpdateOrderProductStatusConfig(detail);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "修改成功!";
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ...";
                    }
                }
                else
                {
                    detail.CreateDate = DateTime.Now;
                    var res = OrderProductStateClient.Instance.AddOrderProductStatusConfig(detail);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "新增成功!";
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改订单扭转排序
        public JsonResult UpdateSort(int id, int sort)
        {
            var result = new BaseResponse();
            try
            {
                var res = OrderProductStateClient.Instance.UpdateOrderProductStatusConfigSort(id, sort);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改排序成功!";
                }
                else
                {
                    result.DoResult = "修改排序失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改排序失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改订单扭转状态
        public JsonResult UpdateState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = OrderProductStateClient.Instance.UpdateOrderProductStatusConfigState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改状态成功!";
                }
                else
                {
                    result.DoResult = "修改状态失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改状态失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
