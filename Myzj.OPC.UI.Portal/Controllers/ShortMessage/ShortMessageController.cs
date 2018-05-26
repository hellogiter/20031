using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.ShortMessage;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers.ShortMessage
{
    public class ShortMessageController : BaseController
    {
        //
        // GET: /ShortMessage/

        public ActionResult TemplateIndex(TemplateListRefer refer)
        {
            var result = ShortMessageClient.Instance.QueryTemplatePageList(refer);
            return View(result);
        }

        public ActionResult TemplateAdd()
        {
            return View();
        }
        public ActionResult TemplateUpdate(int sysNo)
        {

            var gad = new TemplateModel();
            var result = ShortMessageClient.Instance.QueryTemplateEntity(sysNo);
            if (result.SysNo != null)
            {
                gad = result;
            }
            return View(gad);
        }


        public ActionResult SendRecorsIndex(SendRecorsRefer refer)
        {
            var result = ShortMessageClient.Instance.QuerySendRecordsPageList(refer);
            return View(result);
        }



        public ActionResult BlackListIndex(BlackListRefer refer)
        {
            var result = ShortMessageClient.Instance.QueryBackPageList(refer);
            return View(result);
        }

        public ActionResult BlackListAdd()
        {
            return View();
        }
        public ActionResult BlackListUpdate(int sysNo)
        {

            var gad = new BlackListModel();
            var result = ShortMessageClient.Instance.QueryBackListEntity(sysNo);
            if (result.SysNo != null)
            {
                gad = result;
            }
            return View(gad);
        }



        public ActionResult WhiteListIndex(WhiteListRefer refer)
        {
            var result = ShortMessageClient.Instance.QueryWhitePageList(refer);
            return View(result);
        }

        public ActionResult WhiteListAdd()
        {
            return View();
        }
        public ActionResult WhiteListUpdate(int sysNo)
        {

            var gad = new WhiteListModel();
            var result = ShortMessageClient.Instance.QueryWhiteListEntity(sysNo);
            if (result.SysNo != null)
            {
                gad = result;
            }
            return View(gad);
        }

        public ActionResult SmsTemplatePlaceHolder()
        {
            ViewBag.PlaceHolderList = ShortMessageClient.Instance.QuerySmsPlaceHolderPageList(new SmsPlaceHolderRefer()).List;
            return View("SmsPlaceHolder/PlaceHolderList");
        }

        [OutputCache(Duration = 3600)]
        public ActionResult SmsBanlanceIndex(SmsBalanceRefer refer)
        {
            var result = ShortMessageClient.Instance.QuerySmsBalanceList(refer);
            return View(result);
        }

    }
}
