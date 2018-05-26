using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Myzj.OPC.UI.Portal.Models
{
    public static class GroupUrlFactory
    {
        public static string ConvertPromotionUrl(string promosysno)
        {
            var url = Configurator.JsonServiceUrl("kc_Searchurl");
            return url.Replace("{0}", promosysno);
        }


        public static string ConvertActivityUrl(int actId)
        {
            var url = Configurator.JsonServiceUrl("kj_ActivityUrl");
            return url.Replace("{0}", actId.ToString(CultureInfo.InvariantCulture));
        }
        public static string ConvertActivityUrl2(int actId)
        {
            var url = Configurator.JsonServiceUrl("kj_ActivityUrl2");
            return url.Replace("{0}", actId.ToString(CultureInfo.InvariantCulture));
        }

        public static string GetMkmsDomainUrl()
        {
            return Configurator.JsonServiceUrl("MYZJmkmsDomainGroupJsonServiceUrl");
        }
    }
}