using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class OrderBillController : BaseController, IBaseController
    {
        //
        // GET: /OrderBill/
        [HttpGet]
        public ActionResult Index()
        {
            //Pager
            return View();
        }
        [ActionLocator("Query", "Pager")]
        public ActionResult Query(QueryOrderBySearchReq queryOrderBySearchReq)
        {
            var orderResponse = ServiceCollection.QueryOrderByClient.QueryOrderBy("10002608,10002607,10002606");
            ViewData["Detail"] = orderResponse;
            return View("Index");
        }

        public void Action_Load()
        {
            //action 结束~~~
        }
    }
}
