using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.HotStyle;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers.HotStyle
{
    public class HotStyleController : Controller
    {
        //
        // GET: /HotStyle/

        public ActionResult Index(HotStyleRefer refer)
        {
            if (refer.Search.ApplyPlace == null) refer.Search.ApplyPlace = "1";
            if (refer.Search.IsExpire == null)
            {
                refer.Search.IsExpire = 1;
            }
            if (refer.Search.IsEnable == null)
            {
                refer.Search.IsEnable = true;
            }
            var result = HotStyleClient.Instance.QueryHotStylePageList(refer);
            return View(result);
        }

        public ActionResult HotStyleAdd()
        {
            return View();
        }
        public ActionResult HotStyleUpdate(int sysNo)
        {
            var result = HotStyleClient.Instance.QueryHotStyleModel(sysNo);
            return View(result);
        }
    }
}
