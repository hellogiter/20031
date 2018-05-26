using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.ServiceClient
{
    public class ClearCacheClient : BaseService
    {
        private ClearCacheClient() { }
        private static readonly object Lockobj = new object();
        private static ClearCacheClient _instance;
        public static ClearCacheClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ClearCacheClient();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool AddSite(string SiteName, string SitePort)
        {
            return BSClient.Send<AddClearCache_SiteConfigResponse>(new AddClearCache_SiteConfigRequest
            {
                SiteName = SiteName,
                SitePort = SitePort
            }).DoFlag;
        }

        public ClearCacheSites QuerySite()
        {
            var ret = new ClearCacheSites();
            ret.ClearCacheSiteList = new List<ClearCacheSiteEntity>();

            var response = BSClient.Send<QueryClearCache_SiteConfigResponse>(new QueryClearCache_SiteConfigRequest { });

            if (response.DoFlag && response.ClearCache_SiteList != null && response.ClearCache_SiteList.Count > 0)
            {
                ret.ClearCacheSiteList = Mapper.MappGereric<ClearCache_SiteEntity, ClearCacheSiteEntity>(response.ClearCache_SiteList).ToList();
            }

            return ret;
        }

        public bool UpdateSite(int SysNo, bool IsEnable)
        {
            return BSClient.Send<UpdateClearCache_SiteConfigResponse>(new UpdateClearCache_SiteConfigRequest
            {
                SysNo = SysNo,
                IsEnable = IsEnable
            }).DoFlag;
        }

        public bool AddServer(string ServerName)
        {
            return BSClient.Send<AddClearCache_ServerConfigResponse>(new AddClearCache_ServerConfigRequest
            {
                ServerIp = ServerName
            }).DoFlag;
        }

        public ClearCacheServers QueryServer()
        {
            var ret = new ClearCacheServers();
            ret.ClearCacheServerList = new List<ClearCacheServerEntity>();

            var response = BSClient.Send<QueryClearCache_ServerConfigResponse>(new QueryClearCache_ServerConfigRequest { });

            if (response.DoFlag && response.ClearCache_ServerList != null && response.ClearCache_ServerList.Count > 0)
            {
                ret.ClearCacheServerList = Mapper.MappGereric<ClearCache_ServerEntity, ClearCacheServerEntity>(response.ClearCache_ServerList).ToList();
            }

            return ret;
        }

        public bool UpdateServer(int SysNo, bool IsEnable)
        {
            return BSClient.Send<UpdateClearCache_ServerConfigResponse>(new UpdateClearCache_ServerConfigRequest
            {
                SysNo = SysNo,
                IsEnable = IsEnable
            }).DoFlag;
        }

        public bool AddServerSite(List<int> ServerSysNo,int SiteSysNo)
        {

            

            return BSClient.Send<AddClearCache_ServerSiteResponse>(new AddClearCache_ServerSiteRequest
            {
                ServerNoList = ServerSysNo,
                SiteSysNo = SiteSysNo
            }).DoFlag;
        }

        public ClearCacheServerSites QueryServerSite(int siteSysNo)
        {
            var ret = new ClearCacheServerSites();
            ret.ClearCacheServerSiteList = new List<ClearCacheServerSiteEntity>();

            var response = BSClient.Send<QueryClearCache_ServerSiteResponse>(new QueryClearCache_ServerSiteRequest { SiteSysNo = siteSysNo });

            if (response.DoFlag && response.ServerSiteList != null && response.ServerSiteList.Count > 0)
            {
                ret.ClearCacheServerSiteList = Mapper.MappGereric<ClearCache_ServerSiteEntity, ClearCacheServerSiteEntity>(response.ServerSiteList).ToList();
            }

            return ret;
        }
    }
}
