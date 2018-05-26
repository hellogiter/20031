using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace System
{
    public class Configurator
    {
        static string GetAppSetting(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(appSetting))
            {
                return string.Format("未配置节点" + key);
            }
            return appSetting;
        }

        public static string JsonServiceUrl(string key)
        {
            return GetAppSetting(key);
        }
    }
}
