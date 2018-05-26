using System.Web.Mvc;
using MYZJ.Authorization.ClientHelper;
using MYZJ.Authorization.Dto;
using MYZJ.Framework.Service;
using MYZJ.Framework.ServiceClient.Web;
using Myzj.OPC.UI.ServiceClient.Base;
using Myzj.OPC.UI.ServiceClient.External;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        private static ServiceCollection _serviceCollection;
        public ServiceCollection ServiceCollection
        {
            get
            {
                if (null == _serviceCollection)
                {
                    _serviceCollection = ServiceCollectionFactory.ServiceCollection;
                }
                return _serviceCollection;
            }
        }

        private static SessionResponse _sessionResponse;
        public SessionResponse UserInfo
        {
            get
            {
                //if (null == _sessionResponse)
                //{                //if (null == _sessionResponse)
                //{
                    IRestClient _client = new JsonServiceClient(Config.AuthorizationServiceUri);
                    var httpCookie = HttpContext.Request.Cookies["session"];
                    string url = string.Format("/Session?SessionId={0}&ApplicationSysNo={1}&Includes={2}", httpCookie.Value,
                    Config.ApplicationSysNo,
                    ((int)(IncludeFlag.Page | IncludeFlag.Permission | IncludeFlag.Menu))
                    .ToString());
                    _sessionResponse = _client.Get<SessionResponse>(url);
                //}
                return _sessionResponse;
            }
            set { _sessionResponse = null; }
        }
    }
}