using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.MKMS.ServiceModel.Coupon;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.Model.CouponActivity;

namespace Myzj.OPC.UI.ServiceClient
{
    public class CouponActivityConfigureClient : BaseService
    {
        #region 单例
        private CouponActivityConfigureClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static CouponActivityConfigureClient _instance;
        public static CouponActivityConfigureClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new CouponActivityConfigureClient();
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
        public bool AddCouponActivityConfigure(CouponActivityConfigureDetail request)
        {
            var param = Mapper.Map<CouponActivityConfigureDetail, AddCouponActivityConfigure>(request);
            param.UserId = 555;
            var response = MKMSClient.Send<AddCouponActivityConfigureResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 查询活动列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public CouponActivityConfigureRefer QueryCouponActivityConfigurePageList(CouponActivityConfigureRefer refer)
        {
            var obj = refer.SearchDetail;
            var where = "";
            if ((obj.ActivitySysNo??0) >0)
            {
                where += " and ActivitySysNo=" + obj.ActivitySysNo;
            }

            if (!string.IsNullOrEmpty(obj.CouponKey))
            {
                where += " and CouponKey='" + obj.CouponKey + "'";
            }
            var result = new CouponActivityConfigureRefer();
            var param = new QueryCouponActivityConfigurePageList
            {
                PageIndex = 1,
                PageSize = 30,
                where = where
            };
            var response = MKMSClient.Send<QueryCouponActivityConfigurePageListResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List = Mapper.MappGereric<CouponActivityConfigureDto, CouponActivityConfigureDetail>(response.CouponActivityConfigurePageListDtos);
            }
            return result;
        }

        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public CouponActivityConfigureDetail QueryCouponActivityConfigureEntity(int sysNo)
        {
            var groupGooodsInfo = new CouponActivityConfigureDetail();
            var param = new QueryCouponActivityConfigureEntity() { SysNo = sysNo };
            var response = MKMSClient.Send<QueryCouponActivityConfigureEntityResponse>(param);

            if (response.DoFlag)
            {
                groupGooodsInfo = Mapper.Map<CouponActivityConfigureDto, CouponActivityConfigureDetail>(response.QueryCouponActivityConfigureEntity);
            }
            return groupGooodsInfo;
        }

        /// <summary>
        /// 更新活动
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool UpdateCouponActivityConfigure(CouponActivityConfigureDetail request)
        {
            var upd = new UpdateCouponActivityConfigure();
            upd.SysNo = request.SysNo;
            upd.UpdateTo = Mapper.Map<CouponActivityConfigureDetail, CouponActivityConfigureDto>(request);
            upd.UserId = 555;
            var response = MKMSClient.Send<UpdateCouponActivityConfigureResponse>(upd);
            return response.DoFlag;
        }

    }
}
