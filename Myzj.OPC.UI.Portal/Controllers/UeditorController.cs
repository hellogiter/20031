using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using OpenProxy;
using MC.Core.Config;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class UeditorController : BaseController
    {
        // GET: /Ueditor/

        static object _lock = new object();

        public ActionResult Index(string target, string action)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(target))
                {
                    string method = Request.HttpMethod.ToLower();
                    //if (!string.IsNullOrEmpty(action))
                    //{
                    //    method = action.ToLower().Trim();
                    //}

                    StringBuilder urlBuilder = new StringBuilder();
                    urlBuilder.Append(MConfig.Get<String>("remoteRoot"));
                    urlBuilder.Append(MConfig.Get<string>(target.Trim().ToLower()));
                    urlBuilder.AppendFormat("userId={0}", UserInfo.UserSysNo);
                    switch (method)
                    {
                        case "get":
                            {
                                NameValueCollection keyValuePair = Request.QueryString;
                                foreach (string key in keyValuePair.Keys)
                                {
                                    urlBuilder.AppendFormat("&{0}={1}", key, keyValuePair[key]);
                                }
                                break; ;
                            }
                        case "post":
                            {
                                NameValueCollection keyValuePair = Request.Form;
                                foreach (string key in keyValuePair.Keys)
                                {
                                    urlBuilder.AppendFormat("&{0}={1}", key, keyValuePair[key]);
                                }
                                break;
                            }
                    }

                    var proxy = OpenRequest.Create(urlBuilder.ToString(), method);
                    var resp = proxy.GetResponse();
                    return Content(resp.ResponseText);
                }
                return new EmptyResult();
            }
        }


        ///// <summary>
        ///// 获取请求的Url
        ///// </summary>
        ///// <returns></returns>
        //private string GetRequestUrl(string type, int userId)
        //{
        //    StringBuilder urlBuilder = new StringBuilder(MConfig.Get<String>("remoteRoot"));
        //    urlBuilder.Append(MConfig.Get<string>(type.Trim().ToLower()));
        //    urlBuilder.AppendFormat("userId={0}", userId);

        //    string method = this.GetHttpMethod();
        //    if (method == "get")
        //    {
        //        NameValueCollection keyValuePair = this.GetRequestParameters();
        //        foreach (string key in keyValuePair.Keys)
        //        {
        //            urlBuilder.AppendFormat("&{0}={1}", key, keyValuePair[key]);
        //        }
        //    }
        //    return urlBuilder.ToString();
        //}

        ///// <summary>
        ///// 获取当前HTTP请求包含的参数(包括GET和POST两种方式)
        ///// </summary>
        ///// <returns></returns>
        //private NameValueCollection GetRequestParameters()
        //{
        //    NameValueCollection keyValuePair = null;
        //    string httpMethod = request.HttpMethod.ToLower();
        //    switch (httpMethod)
        //    {
        //        case "get":
        //            keyValuePair = request.QueryString;
        //            break;
        //        case "post":
        //            keyValuePair = request.Form;
        //            break;
        //    }
        //    return keyValuePair;
        //}

        ///// <summary>
        ///// 获取原始请求的类型字符串
        ///// </summary>
        ///// <returns></returns>
        //private string GetHttpMethod()
        //{
        //    if (!string.IsNullOrEmpty(request["action"]))
        //    {
        //        return request["action"].ToLower();
        //    }

        //    return request.HttpMethod.ToLower();
        //}
    }
}
