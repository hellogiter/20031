using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Myzj.OPC.UI.Common
{
    public class ServiceData
    {
        /// <summary>
        /// 获取服务器IP
        /// </summary>
        /// <returns></returns>
        public static string GetServiceIP()
        {
            string ip = "";
            try
            {
                System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;

                if (addressList.Length >= 1)
                {
                    return Converter.ParseString(addressList[0], "");
                }
                else
                {
                    return Converter.ParseString(addressList.Length, "0");
                }
            }
            catch (Exception)
            {
                ip = "获取服务器IP异常";
            }

            return ip;
        }

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {

            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }
    }
}
