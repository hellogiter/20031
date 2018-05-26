using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Business.PanGu;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.SearchManagement;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class SearchManagementController : BaseController
    {
		// GET: /SearchManagement/

		#region  商品搜索词查询列表
		public ActionResult Index(SearchManagementRefer search)
		{
			var result = new SearchManagementRefer();
			if (search.SearchDetail.TempProductId != null)
			{
				string[] productidarray=search.SearchDetail.TempProductId.Split(new string[] { "，", ",", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
				if (productidarray.Count() > 200)
				{
					ViewData["ErrorMsg"] = "搜索的数量不能超过200个";
				}
				else
				{
					search.SearchDetail.TempProductId = string.Join(",", productidarray).Trim().TrimEnd(',');
					result = SearchManagementClient.Instance.QueryWebSearchManagement(search);
				}
			}
			return View(result);
		}

		#endregion 

		#region 商品搜索词管理查询添加记录列表
		public ActionResult ExamineIndex(SearchManagementRefer search)
		{
			var result = new SearchManagementRefer();
			if (search.SearchManCheckDetail.KeyWords != null)
			{
				search.SearchManCheckDetail.KeyWords = string.Join(",", search.SearchManCheckDetail.KeyWords.Split(new string[] { "，", "," }, StringSplitOptions.RemoveEmptyEntries)).Trim().TrimEnd(',');
			}
			result = SearchManagementClient.Instance.QueryWebSearchAddRecords(search);
			ViewData["ErrorMsg"] = result.ErrorMsg;
			return View(result);
		}

		#endregion

		#region 跳转到新增页面
		public ActionResult PlDetail(string pid, string key)
		{
			SearchManCheckDetail result = new SearchManCheckDetail();
			if(!string.IsNullOrEmpty(pid))
			{
				result = SearchManagementClient.Instance.QueryWebSearchManagementToAdd(pid);
			}
			if (!string.IsNullOrEmpty(key))
			{
				result.KeyWords = key;
			}
			return View(result);
		}
		#endregion

		#region 新增商品搜索词
		public JsonResult AddSearchManCheckEntity(SearchManCheckDetail model)
		{
			var result = new BaseResponse() { DoFlag = false, DoResult = "新增失败" };

			model.ProductIds = string.Join(",", model.ProductIds.Split(new string[] { "，", ",", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)).TrimEnd(',');
			model.KeyWords = string.Join(",", model.KeyWords.Split(new string[] { "，", ",", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)).TrimEnd(',');
			model.CreateBy = model.CreateBy > 0 ? model.CreateBy : UserInfo.UserSysNo;
			//model.UpdateBy = model.UpdateBy > 0 ? model.UpdateBy : UserInfo.UserSysNo;
			model.CreateDate=DateTime.Now;
			//model.UpdateDate = DateTime.Now;
			model.AuditState = 0;  // 新增记录时状态为待审核
			var res = SearchManagementClient.Instance.AddSearchManCheck(model);
			result.DoFlag = res.DoFlag;
			result.DoResult = res.DoResult;
			return Json(result, JsonRequestBehavior.AllowGet);
		}
		#endregion

		#region 商品搜索词审核列表
		public ActionResult AuditProducts(string cid)
		{
			var result = new SearchManagementRefer();
			ViewBag.NoAudit = SearchManagementClient.Instance.IsSearchItem(cid);
			ViewBag.CheckId = cid;
			ViewBag.Productlink = Configurator.JsonServiceUrl("ProductLinkUrl");
			result = SearchManagementClient.Instance.QueryWebSearchManagementItem(cid);
			return View(result);
		}
		#endregion

		#region 批量审核商品搜索词
		public JsonResult AuditWebSearchManagementItem(AuditParam auditparam)
		{
			var result = new BaseResponse();
			string checkId = auditparam.CheckId;
			string productIds = auditparam.ProductIds;
			string refusedReason = auditparam.RefusedReason;
			int lastoperator = UserInfo.UserSysNo;
			DateTime lastupdatetime = DateTime.Now;
			var res = SearchManagementClient.Instance.AuditWebSearchManagement(checkId, productIds, refusedReason,lastoperator,lastupdatetime);
			result.DoFlag = res.DoFlag;
			result.DoResult = res.DoResult;
			return Json(result, JsonRequestBehavior.AllowGet);
		}
		#endregion




		
    }
}
