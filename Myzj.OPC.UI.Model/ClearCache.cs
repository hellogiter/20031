using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model
{
    public class ClearCacheSiteEntity
    {
        public int SysNo { get; set; }
        public string SiteName { get; set; }
        public string SitePort { get; set; }
        public string IsEnable { get; set; }
    }

    public class ClearCacheSites
    {
        public List<ClearCacheSiteEntity> ClearCacheSiteList { get; set; }
    }

    public class ClearCacheServerEntity
    {
        public int SysNo { get; set; }
        public string ServerIp { get; set; }
        public string IsEnable { get; set; }
    }

    public class ClearCacheServers
    {
        public List<ClearCacheServerEntity> ClearCacheServerList { get; set; }
    }

    public class ClearCacheServerSiteEntity
    {
        public int ServerSysNo { get; set; }
        public int SiteSysNo { get; set; }
    }

    public class ClearCacheServerSites
    {
        public List<ClearCacheServerSiteEntity> ClearCacheServerSiteList { get; set; }
    }
}
