
using MYZJ.VIP.ServiceModel.ForMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vip.myzj.com.ServiceModel.MemberCenter;

namespace Myzj.OPC.UI.ServiceClient
{
    public class VIPClient : BaseService
    {
        private VIPClient() { }


        private static readonly object Lockobj = new object();
        private static VIPClient _instance;
        public static VIPClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new VIPClient();
                        }
                    }
                }
                return _instance;
            }
        }


        public string GetNewMemberFirstOrderCouponInfo(int userId)
        {
            var resposne = VIPClient.Send<NewMemberCouponResultResponse>(new NewMemberCouponResultRequest
            {
                UserId = userId
            });

            if (resposne.DoFlag)
            {
                if (resposne.IsSendCoupon !=1)
                {
                    return "未发券，"+ resposne.Result;
                }

                return resposne.Result;
            }

            return "";
        }


        public void Add168CouponLog(string userId)
        {
            var request = new AddFirstOrderCouponLogRequest();
            request.UserId=userId ;
            request.OrderCode = "";
            request.FullAddress = "";
            request.IsSendCoupon = 1;
            request.Province = "";
            request.City = "";
            request.District = "";
            request.AddressMobile = "";
            request.RegistMobile = "";
            request.SendDate = DateTime.Now;
            request.SendDetail = "手动补发券成功";
            MYZJVIPClient.Send<AddFirstOrderCouponLogResponse>(request);
        }

        public void AddCouponLog(string userId)
        {
            var request = new AddFirstOrderCouponLogRequest();
            request.UserId = userId;
            request.OrderCode = "";
            request.FullAddress = "";
            request.IsSendCoupon = 1;
            request.Province = "";
            request.City = "";
            request.District = "";
            request.AddressMobile = "";
            request.RegistMobile = "";
            request.SendDate = DateTime.Now;
            request.SendDetail = "手动补发券成功";
            MYZJVIPClient.Send<AddFirstOrderCouponLogResponse>(request);
        }
    }
}
