using MYZJ.UDP.ServiceModel.ForHolyca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.ServiceClient
{
    public class UdpClient : BaseService
    {
        private UdpClient() {}

        private static readonly object Lockobj = new object();
        private static UdpClient _instance;
        public static UdpClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new UdpClient();
                        }
                    }
                }
                return _instance;
            }
        }

        public string GetFirstOrder(int userId)
        {
            var response = UdpClient.Send<QueryOrderForSendCouponRespones>(new QueryOrderForSendCouponRequest
            {
                CustomerSysNo = userId
            });

            if (response.DoFlag)
            {
                if (response.orderInfo != null)
                {
                    var status = "";

                    if (response.orderInfo.OrderStatus == -1)
                    {
                        status = "已取消";
                    }
                    else if (response.orderInfo.OrderStatus == 0)
                    {
                        status = "待确认";
                    }
                    else if (response.orderInfo.OrderStatus == 1)
                    {
                        status = "待手动审核";
                    }
                    else if (response.orderInfo.OrderStatus == 2)
                    {
                        status = "已手动审核";
                    }
                    else if (response.orderInfo.OrderStatus == 4)
                    {
                        status = "已自动审核";
                    }
                    else if (response.orderInfo.OrderStatus == 8)
                    {
                        status = "已分单";
                    }
                    else if (response.orderInfo.OrderStatus == 16)
                    {
                        status = "生产中";
                    }
                    else if (response.orderInfo.OrderStatus == 32)
                    {
                        status = "已打包";
                    }
                    else if (response.orderInfo.OrderStatus == 64)
                    {
                        status = "已出库";
                    }
                    else if (response.orderInfo.OrderStatus == 128)
                    {
                        status = "已完成";
                    }

                    var paytype = "";

                    if (response.orderInfo.PayTypeSysNo == 1)
                    {
                        paytype = "货到付款（现金）";
                    }
                    else if(response.orderInfo.PayTypeSysNo ==2)
                    {
                        paytype = "货到付款（刷卡）";
                    }
                    else if (response.orderInfo.PayTypeSysNo == 4)
                    {
                        paytype = "在线支付";
                    }
                    else if (response.orderInfo.PayTypeSysNo == 8)
                    {
                        paytype = "混合支付";
                    }
                    else if (response.orderInfo.PayTypeSysNo == 16)
                    {
                        paytype = "即时支付(现金)";
                    }
                    else if (response.orderInfo.PayTypeSysNo == 17)
                    {
                        paytype = "即时支付(银行卡)";
                    }

                    return string.Format("首单订单号：{0}；金额：{1}；订单状态：{2}；支付方式：{3}；",
                        response.orderInfo.OrderNo, response.orderInfo.ReceiveAmount * 0.01, status, paytype);
                }

                return "未查到有效首单。";
            }

            return "系统繁忙，请稍后再试。 ";
        }

    }
}
