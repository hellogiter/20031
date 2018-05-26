using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Myzj.MKMS.ServiceModel.SortProduct;
using Myzj.OPC.UI.Model.KeyWord;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    /// <summary>
    /// Description:对搜索推荐商品进行维护
    /// </summary>
    public class SortProductController : BaseController
    {

        //1展示查询列表
        public ActionResult Index(SortProductRefer search)
        {
            var result = new SortProductRefer();
            if (search.SortProductDetail.KeyWord != null)
            {
                search.SortProductDetail.KeyWord = search.SortProductDetail.KeyWord.Trim();
            }
            if (search.SortProductDetail.ProductJson != null)
            {
                search.SortProductDetail.ProductJson = search.SortProductDetail.ProductJson.Trim();
            } 
            result = SortProductConfigClient.Instance.QuerySortProductPageList(search);
            return View(result);
        }
        //2进入编辑页面
        public ActionResult EditDetail(int? id)
        {
            SortProductDetail result = new SortProductDetail(); 
            if (id > 0)
            {
                result = SortProductConfigClient.Instance.QuerySortProductEntity(id ?? 0);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                if (result.ProductJson!=null && result.ProductJson.Any())
                {
                    ViewBag.ProductJson = jss.Deserialize<List<ProductJson>>(result.ProductJson);  
                }
                
                
            } 
            return View(result);
        }

        //新增或修改指定商品的排序列表
        public JsonResult EditSortProdutDetail(SortProductDetail model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "保存失败，请稍后重试... ..." };
            try
            { 
                if (model.Id > 0)
                {
                    //修改 
                    model.LastUpdateTime = DateTime.Now; 
                    model.LastOperator = UserInfo.UserSysNo; 
                    var res = SortProductConfigClient.Instance.UpdateSortProduct(model);
                    if (res.DoFlag)
                    {
                        result.DoFlag = true;
                        result.DoResult = res.DoResult;
                    }
                    else
                    {
                        result.DoResult = res.DoResult;
                    }
                }
                else
                {
                   //新增
                    model.CreateTime = DateTime.Now;
                    model.LastUpdateTime = DateTime.Now;
                    model.CreateOperator =UserInfo.UserSysNo;
                    model.LastOperator= UserInfo.UserSysNo;  
                    var res = SortProductConfigClient.Instance.AddSortProduct(model);
                    if (res.DoFlag)
                    {
                        result.DoFlag = true;
                        result.DoResult = res.DoResult;
                    }
                    else
                    {
                        result.DoResult = res.DoResult;
                    }
                }

            }
            catch (Exception ex)
            { 
                result.DoResult = "保存异常，请稍后重试... ...";
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult DelSortProduct(string ids)
        {
            var result = new BaseResponse() {DoFlag = false, DoResult = "删除失败"};
            if (string.IsNullOrEmpty(ids))
            {
                result.DoResult = "请选择要删除的选项";
                return Json(result);
            }
            var listId = ids.Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(int.Parse).ToList();
            result.DoResult = SortProductConfigClient.Instance.DelSortProduct(listId);
            if (!string.IsNullOrEmpty(result.DoResult))
                result.DoFlag = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
