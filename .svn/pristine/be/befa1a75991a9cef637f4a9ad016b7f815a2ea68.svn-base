using Myzj.OPC.UI.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class ClearCacheController : Controller
    {
        //
        // GET: /ClearCache/

        public ActionResult Index()
        {
            var list = ClearCacheClient.Instance.QuerySite().ClearCacheSiteList;
            ViewBag.SiteList = new SelectList(list, "SysNo", "SiteName").AsEnumerable();

            if (list != null && list.Count > 0)
            {
                ViewBag.DefaultSiteId = list[0].SysNo;
            }
            else
            {
                ViewBag.DefaultSiteId = 0;
            }

            var serverlist = ClearCacheClient.Instance.QueryServer().ClearCacheServerList;

            var servers = new List<SelectListItem>();

            foreach (var s in serverlist)
            {
                servers.Add(new SelectListItem { Value = s.SysNo.ToString(), Text = s.ServerIp });
            }

            ViewBag.ServerList = servers;
            return View();
        }


        public ActionResult ServerSiteConfig()
        {
            return View();
        }

        public bool AddSite(string SiteName, string SitePort)
        {
            return ClearCacheClient.Instance.AddSite(SiteName, SitePort);
        }

        public ActionResult SiteShow()
        {
            var ret = ClearCacheClient.Instance.QuerySite();
            return View(ret);
        }

        public bool UpdateSite(int sysno,bool isenable)
        {
            return ClearCacheClient.Instance.UpdateSite(sysno, isenable);
        }

        public ActionResult ServerShow()
        {
            var ret = ClearCacheClient.Instance.QueryServer();
            return View(ret);
        }

        public bool AddServer(string ServerName)
        {
            return ClearCacheClient.Instance.AddServer(ServerName);
        }

        public bool UpdateServer(int sysno, bool isenable)
        {
            return ClearCacheClient.Instance.UpdateServer(sysno, isenable);
        }


        public ActionResult ServerSiteRelate()
        {
            var list = ClearCacheClient.Instance.QuerySite().ClearCacheSiteList;
            ViewBag.SiteList = new SelectList(list, "SysNo", "SiteName").AsEnumerable();

            if (list != null && list.Count > 0)
            {
                ViewBag.DefaultSiteId = list[0].SysNo;
            }
            else
            {
                ViewBag.DefaultSiteId = 0;
            }
           
            var serverlist = ClearCacheClient.Instance.QueryServer().ClearCacheServerList;

            var servers = new List<SelectListItem>();

            foreach (var s in serverlist)
            {
                servers.Add(new SelectListItem { Value = s.SysNo.ToString(), Text = s.ServerIp });
            }

            ViewBag.ServerList = servers;

            return View();
        }

        public ActionResult ServerContent(string siteId)
        {
            var serverlist = ClearCacheClient.Instance.QueryServer().ClearCacheServerList;

            var serverSiteList = ClearCacheClient.Instance.QueryServerSite(Convert.ToInt32( siteId)).ClearCacheServerSiteList;

            var servers = new List<SelectListItem>();

            foreach (var s in serverlist)
            {
                var check = false;

                if (serverSiteList != null && serverSiteList.Count > 0)
                {
                    if (serverSiteList.Exists(x => x.ServerSysNo == s.SysNo))
                    {
                        check = true;
                    }

                }

                servers.Add(new SelectListItem { Value = s.SysNo.ToString(), Text = s.ServerIp, Selected = check });
            }

            ViewBag.ServerList = servers;

            return View();
        }

        public bool AddServerSite(string ServerSysNo, int SiteSysNo)
        {
            string[] arr = ServerSysNo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 1)
            {
                return false;
            }
            return ClearCacheClient.Instance.AddServerSite(arr.ToList().Select(x => Convert.ToInt32(x)).ToList(), SiteSysNo);
        }
    }
}
