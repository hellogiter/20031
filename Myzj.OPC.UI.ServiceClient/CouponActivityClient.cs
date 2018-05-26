using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.MKMS.ServiceModel.Coupon;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.Model.CouponActivity;

namespace Myzj.OPC.UI.ServiceClient
{
    public class CouponActivityClient : BaseService
    {
        #region 单例
        private CouponActivityClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static CouponActivityClient _instance;
        public static CouponActivityClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new CouponActivityClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 新增活动
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AddCouponActivity(CouponActivityDetail request)
        {
            var param = Mapper.Map<CouponActivityDetail, AddCouponActivity>(request);
            param.UserId = 555;
            var response = MKMSClient.Send<AddCouponActivityResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 查询活动列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public CouponActivityRefer QueryCouponActivityPageList(CouponActivityRefer refer)
        {
            var obj = refer.SearchDetail;
            var where = "";
            if (!string.IsNullOrEmpty(obj.ActivityKey))
            {
                where += " and ActivityKey='" + obj.ActivityKey + "'";
            }

            if (!string.IsNullOrEmpty(obj.ActivityName))
            {
                where += " and ActivityName like '%" + obj.ActivityName + "%'";
            }
            var result = new CouponActivityRefer();
            var param = new QueryCouponActivityPageList
            {
                PageIndex = 1,
                PageSize = 30,
                where = where,
                UserId = 555
            };
            var response = MKMSClient.Send<QueryCouponActivityPageListResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List = Mapper.MappGereric<CouponActivityDto, CouponActivityDetail>(response.CouponActivityPageListDtos);
            }
            return result;
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public CouponActivityDetail QueryCouponActivityEntity(int sysNo)
        {
            var groupGooodsInfo = new CouponActivityDetail();
            var param = new QueryCouponActivityEntity() { SysNo = sysNo };
            var response = MKMSClient.Send<QueryCouponActivityEntityResponse>(param);

            if (response.DoFlag)
            {
                groupGooodsInfo = Mapper.Map<CouponActivityDto, CouponActivityDetail>(response.CouponActivityEntity);
            }
            return groupGooodsInfo;
        }

        /// <summary>
        /// 更新活动
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool UpdateCouponActivity(CouponActivityDetail request)
        {
            var upd = new UpdateCouponActivity();
            upd.SysNo = request.SysNo;
            upd.ActivityKey = request.ActivityKey;
            upd.UpdateTo = Mapper.Map<CouponActivityDetail, CouponActivityDto>(request);
            upd.UserId = 555;
            var response = MKMSClient.Send<UpdateCouponActivityResponse>(upd);
            return response.DoFlag;
        }
        /// <summary>
        /// 删除活动下优惠券
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool DeleteCouponActivityConfigure(int SysNo)
        {
            var response = MKMSClient.Send<DeleteCouponActivityConfigureResponse>(new DeleteCouponActivityConfigure
                {
                    SysNo = SysNo,
                    IsDelete = true,
                    UserId = 555
                }
                );
            return response.DoFlag;
        }

        public string GetUse168CouponOrder(int userId)
        {
            var couponKey = Configurator.JsonServiceUrl("NewMemberCouponKey");

            var response = MKMSClient.Send<QueryUserCouponOrderCodeResponse>(new QueryUserCouponOrderCodeRequest
            {
                UserId = userId,
                CouponKey = couponKey
            });

            if (response.DoFlag)
            {
                return response.OrderCode ?? "";
            }

            return "系统繁忙，稍后再试。";
        }
    }
}
