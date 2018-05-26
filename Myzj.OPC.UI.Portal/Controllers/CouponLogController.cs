using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class CouponLogController : Controller
    {
        //
        // GET: /CouponLog/

        public ActionResult Index(BaseRefer<CouponLogDetail,CouponLogDetailExt> refer)
        {
            var result = new BaseRefer<CouponLogDetail, CouponLogDetailExt>();
            result = BaseCouponConfigClient.Instance.QueryCouponLog(refer);
            return View(result);
        }

        public ActionResult CouponLogDetail(int sysNo, int operatorId, DateTime rowCreateDate, int operationType)
        {
            var result = new Dictionary<CouponInfoData, CouponInfoData>();
            result = BaseCouponConfigClient.Instance.QueryCouponLogDetail(sysNo);

            //获取发货仓库
            var resultItem = BaseCouponConfigClient.Instance.QueryWareHouseList();
            ViewBag.ItemModel = resultItem;

            //操作类型 1 新增 2 修改 3 删除 4 禁用/启用
            //string type = "";
            //switch (operationType)
            //{
            //    case 1:
            //        type = "新增";
            //        break;
            //    case 2:
            //        type = "修改";
            //        break;
            //    case 3:
            //        type = "删除";
            //        break;
            //    case 4:
            //        type = "禁用/启用";
            //        break;
            //    case 5:
            //        type = "审核通过";
            //        break;
            //    case 6:
            //        type = "驳回";
            //        break;
            //    case 7:
            //        type = "作废";
            //        break;
            //    case 8:
            //        type = "提交审核";
            //        break;
            //}
            ViewBag.operationType = operationType;
            ViewBag.operatorId = operatorId;
            ViewBag.rowCreateDate = rowCreateDate;
            return View(result);
        }

    }
}
