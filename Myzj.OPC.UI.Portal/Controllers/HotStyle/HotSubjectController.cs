using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.HotStyle;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers.HotStyle
{
    public class HotSubjectController : Controller
    {
        //
        // GET: /HotSubject/

        public ActionResult Index(HotSubjectRefer refer)
        {
            if (refer.Search.ApplyPlace == null) refer.Search.ApplyPlace = "1";
            if (refer.Search.IsExpire == 0) refer.Search.IsExpire = 1;
            if (refer.Search.IsEnable == null) refer.Search.IsEnable = true;
            var result = HotStyleClient.Instance.QueryHotSubjectPageList(refer);
            return View(result);
        }
        public ActionResult HotSubjectAdd()
        {
            return View();
        }
        public ActionResult HotSubjectUpdate(int sysNo)
        {
            var result = HotStyleClient.Instance.QueryHotSubjectModel(sysNo);
            return View(result);
        }
    }
}
