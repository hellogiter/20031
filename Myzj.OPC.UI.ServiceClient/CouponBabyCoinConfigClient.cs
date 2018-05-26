using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.DataCenter.ServiceModel.BabyCoin;
using Myzj.OPC.UI.Model.BaseCouponConfig;

namespace Myzj.OPC.UI.ServiceClient
{
    public class CouponBabyCoinConfigClient : BaseService
    {
        #region 单例
        private CouponBabyCoinConfigClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static CouponBabyCoinConfigClient _instance;
        public static CouponBabyCoinConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new CouponBabyCoinConfigClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public CouponBabyCoinRefer QueryCoponBabyCoinRelationPageList(CouponBabyCoinRefer param)
        {
            var result = new CouponBabyCoinRefer();
            var req = new QueryBabyCoinCouponRelationPageList();

            if (param.SearchDetail != null)
            {
                req.UserId = 555;
                if (!string.IsNullOrEmpty(param.SearchDetail.CouponId))
                {
                    req.where = " and CouponId='" + param.SearchDetail.CouponId + "'";//0查询所有，>0查询单条
                }
                if (param.SearchDetail.Id != 0)
                {
                    req.where = " and Id=" + param.SearchDetail.Id;//0查询所有，>0查询单条
                }
            }

            var res = DataCenterJsonServiceClient.Send<QueryBabyCoinCouponRelationPageListResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<CouponUserOrderRelationDto, CouponBabyCoinDetail>(res.QueryBabyCoinCouponRelationPageListDtos);
            }
            result.SearchDetail = param.SearchDetail;

            return result;
        }

        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public CouponBabyCoinDetail QueryCoponBabyCoinRelationById(int userid, int id)
        {
            var result = new CouponBabyCoinDetail();
            var req = new QueryBabyCoinCouponRelationPageList();

            req.UserId = userid;
            if (id != 0)
            {
                req.where = " and Id=" + id;//0查询所有，>0查询单条
            }

            var res = DataCenterJsonServiceClient.Send<QueryBabyCoinCouponRelationPageListResponse>(req);
            if (res.DoFlag)
            {
                return Mapper.MappGereric<CouponUserOrderRelationDto, CouponBabyCoinDetail>(res.QueryBabyCoinCouponRelationPageListDtos).First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public bool AddCoponBabyCoinRelation(CouponBabyCoinDetail floorConfig)
        {
            var req = Mapper.Map<CouponBabyCoinDetail, CouponUserOrderRelationDto>(floorConfig);
            var res = DataCenterJsonServiceClient.Send<AddBabyCoinCouponRelationResponse>(new AddBabyCoinCouponRelation
                {
                    AddBabyCoinCouponRelationEnt = req
                });
            return res.DoFlag;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public bool UpdateCoponBabyCoinRelation(CouponBabyCoinDetail floorConfig)
        {
            var req = Mapper.Map<CouponBabyCoinDetail, CouponUserOrderRelationDto>(floorConfig);
            var res = DataCenterJsonServiceClient.Send<UpdateBabyCoinCouponRelationResponse>(new UpdateBabyCoinCouponRelation
                {
                    UpdBabyCoinCouponRelationEnt = req
                });
            return res.DoFlag;
        }
    }
}
