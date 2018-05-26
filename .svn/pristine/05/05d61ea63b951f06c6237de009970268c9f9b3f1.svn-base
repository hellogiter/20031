using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class NewMemberDiscountController :BaseController 
    {
        //
        // GET: /NewMemberDiscount/

        public ActionResult Index()
        {
            return View();
        }

        public string GetReseaon(int userId)
        {
            var ret = VIPClient.Instance.GetNewMemberFirstOrderCouponInfo(userId);

            ret = ret.Replace(";", "<br/>");
            return ret.Replace("；", "<br/>");
        }

        public string SendCouponManually(int userId)
        {
            return "";

            var success = "";
            var error = "";
            var doResult = "";
            var list = new List<M_SendInfo>();
            list.Add(new M_SendInfo
            {
                CouponKey = Configurator.JsonServiceUrl("NewMemberCouponKey"),
                UserId = userId,
                SendDescription = "系统发送"
            });
            var request = new CouponSendDetail
                   {
                       Operator = UserInfo.UserSysNo,
                       ClientIp = ServiceData.GetClientIP(),
                       Sends = list
                   };
            bool DoFlag = BaseCouponConfigClient.Instance.SendCopuonFunction(request, out doResult, out success, out error);

            if (string.IsNullOrEmpty(doResult))
            {
                if (DoFlag)
                {
                    doResult = "发券成功。";

                    VIPClient.Instance.Add168CouponLog(userId.ToString());
                }
                else
                {
                    doResult = "发券失败。";
                }
            }

            if (error == null||error =="null")
            {
                error = "";
            }

            if (success == null || success == "null")
            {
                success = "";
            }

            return doResult + ";" + success + ";" + error;
        }

        public string GetFirstOrder(int userId)
        {
            var ret= UdpClient.Instance.GetFirstOrder(userId);

            ret = ret.Replace(";", "<br/>");
            ret= ret.Replace("；", "<br/>");
            ret += "<br/><br/>";

            var ret2 = CouponActivityClient.Instance.GetUse168CouponOrder(userId);

            if (string.IsNullOrWhiteSpace(ret2))
            {
                ret += "没有使用168现金直减券的订单";
            }
            else
            {
                ret += string.Format("使用168现金直减券的订单号：{0}", ret2);
            }

            return ret;
        }
    }
}
