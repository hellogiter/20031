using System;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.ProductLabel;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class ProductLabelController : Controller
    {
        // GET: /ProductLabel/
        #region 商品标签列表
        public ActionResult Index(ProductLabelRefer productLabel)
        {
            var result = new ProductLabelRefer();
            result = ProductLabelClient.Instance.QueryBasetLabels(productLabel);
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
            var res = new ProductLabelDetail();
            if (id > 0)
            {
                res = ProductLabelClient.Instance.QueryBasetLabelsById(id.Value);
            }
            return View(res);
        }
        #endregion

        #region 修改/新增商品标签
        public JsonResult Save(ProductLabelDetail productLabel)
        {
            var result = new BaseResponse();
            try
            {
                if (productLabel.ID > 0)
                {
                    //修改
                    var res = ProductLabelClient.Instance.UpdateBasetLabels(productLabel);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "修改成功!";
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试";
                    }
                }
                else
                {
                    //新增
                    productLabel.CreateDate = DateTime.Now;
                    productLabel.IsDeleted = false;
                    var res = ProductLabelClient.Instance.AddBasetLabels(productLabel);
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
                result.DoResult = "保存异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除商品标签
        public JsonResult Del(int id)
        {
            var result = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var res = ProductLabelClient.Instance.DelBasetLabels(id);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "删除成功";
                    }
                    else
                    {
                        result.DoResult = "删除失败，请稍后重试... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
