using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.Finance.UI.Common;
using Myzj.MKMS.ServiceModel.RentActivity;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.RentActivity;

namespace Myzj.OPC.UI.ServiceClient
{
    public class RentActivityClient : BaseService
    {
        #region 单例

        private RentActivityClient()
        {
        }

        private static readonly object Lockobj = new object();
        private static RentActivityClient _instance;
        public static RentActivityClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new RentActivityClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 活动管理
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool ActivityManager(BaseRentActivityInfo request, int userId, out string message)
        {
            var param = new RentAcitivyInfo()
                {
                    SysNo = request.SysNo,
                    ActivityName = request.ActivityName,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    PreStartTime = request.PreStartTime,
                    PreEndTime = request.PreEndTime,
                    ActivityDes = request.ActivityDes,
                    PromotionId = request.PromotionId,
                    GoodsTotalCount = request.GoodsTotalCount,
                    Remarks = request.Remarks,
                    IsEnable = request.IsEnable,
                    IsDelete = request.IsDelete,
                    ActivityJsonContent = request.ActivityJsonContent
                };
            var response = MKMSClient.Send<ActivityManagerResponse>(new ActivityManagerRequest()
                {
                    UserId = userId,
                    AcitivyInfo = param
                });
            message = response.DoResult;
            return response.DoFlag;
        }

        /// <summary>
        /// 查询活动信息
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<BaseRentActivityInfo> QueryRentActivityList(BaseRefer<BaseRentActivityInfo> refer)
        {
            var obj = refer.SearchDetail ?? new BaseRentActivityInfo();
            var param = new QueryRentActivityRequest()
            {
                SysNo = obj.SysNo ?? 0,
                ActivityKey = obj.ActivityKey,
                ActivityName = obj.ActivityName,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize
            };
            var result = new BaseRefer<BaseRentActivityInfo>();
            var response = MKMSClient.Send<QueryRentActivityResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = new List<BaseRentActivityInfo>();
                var list = Mapper.MappGereric<RentAcitivyInfo, BaseRentActivityInfo>(response.ActivityList);

                foreach (var item in list)
                {
                    item.Extend = new Myzj.OPC.UI.Model.RentActivity.ActivityExtend();
                    if (!string.IsNullOrEmpty(item.ActivityJsonContent))
                    {
                        item.Extend = Serializer.DeserializeFromString<Myzj.OPC.UI.Model.RentActivity.ActivityExtend>(item.ActivityJsonContent);
                    }
                    result.List2.Add(item);
                }

            }
            return result;
        }

        /// <summary>
        /// 商品管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool RentGoodsManager(BaseRentGoodsInfo request, int userId, out string message)
        {
            var param = new RentGoodsInfo()
            {
                SysNo = request.SysNo,
                ActivityKey = request.ActivityKey,
                GoodsId = request.GoodsId,
                GoodsDeCash = request.GoodsDeCash,
                RentTimeYear = request.RentTimeYear,
                Sort = request.Sort,
                IsEnable = request.IsEnable,
                IsDelete = request.IsDelete,
                PromotionId = request.PromotionId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Remark = request.Remark,
                GoodsPicUrlList = request.GoodsPicUrlList,
                GoodsShare = request.GoodsShare,
                GoodsHireSet = request.GoodsHireSet,
                GoodsFeeSet = request.GoodsFeeSet,
                RentAgreementId = request.RentAgreementId,
                GoodsType = request.GoodsType
            };
            var response = MKMSClient.Send<GoodsManagerResponse>(new GoodsManagerRequest()
            {
                UserId = userId,
                RentGoodsInfo = param
            });
            message = response.DoResult;
            return response.DoFlag;
        }
        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<BaseRentGoodsInfo> QueryRentGoodsList(BaseRefer<BaseRentGoodsInfo> refer)
        {
            var obj = refer.SearchDetail ?? new BaseRentGoodsInfo();
            var param = new QueryRentGoodsInfoRequest()
            {
                SysNo = obj.SysNo ?? 0,
                ActivityKey = obj.ActivityKey,
                GoodsId = obj.GoodsId ?? 0,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize
            };
            var result = new BaseRefer<BaseRentGoodsInfo>();
            var response = MKMSClient.Send<QueryRentGoodsInfoResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = new List<BaseRentGoodsInfo>();
                var list = Mapper.MappGereric<RentGoodsInfo, BaseRentGoodsInfo>(response.GoodsList);
                foreach (var item in list)
                {
                    item.HireSet = new List<Myzj.OPC.UI.Model.RentActivity.LevelSet>();
                    if (!string.IsNullOrEmpty(item.GoodsHireSet))
                    {
                        item.HireSet = Serializer.DeserializeFromString<List<Myzj.OPC.UI.Model.RentActivity.LevelSet>>(item.GoodsHireSet);
                    }
                    result.List2.Add(item);
                }
                result.SearchDetail = new BaseRentGoodsInfo();
                result.SearchDetail.ActivityKey = obj.ActivityKey;
                result.SearchDetail.GoodsId = obj.GoodsId;
            }

            return result;
        }

        public BaseRefer<BaseCartSplitInfo> QueryCartSplitList(BaseRefer<BaseCartSplitInfo> refer)
        {
            var obj = refer.SearchDetail ?? new BaseCartSplitInfo();
            var param = new QueryCartSplitReq()
            {
                SplitType = obj.SplitType,
                SplitValue = obj.SplitValue,
                IsValid = obj.IsValid
            };
            int pageIndex = refer.PageIndex ?? 1;
            int pageSize = refer.PageSize ?? 20;
            var result = new BaseRefer<BaseCartSplitInfo>();
            var response = MKMSClient.Send<QueryCartSplitRes>(param);
            if (response.DoFlag)
            {
                var list = Mapper.MappGereric<CartSplit, BaseCartSplitInfo>(response.CartSplitList);
                if (list != null)
                {
                    var count = list.Count;
                    result.List2 = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                    result.SearchDetail = new BaseCartSplitInfo();
                    result.SearchDetail.SplitType = obj.SplitType;
                    result.SearchDetail.SplitValue = obj.SplitValue;
                    result.SearchDetail.IsValid = obj.IsValid;
                    result.PageIndex = pageIndex;
                    result.PageSize = pageSize;
                    result.Total = count;
                }
              
            }
            return result;
        }


        public bool CartSplitIsEnable(int? SplitNo, int? IsValid)
        {
            var response = MKMSClient.Send<SplitIsEnableRes>(new SplitIsEnableReq() { SplitNo = SplitNo, IsValid = IsValid });
            return response.DoFlag;
        }

        /// <summary>
        /// 协议管理
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool AgreementManager(BaseRentAgreementInfo request, int userId, out string message)
        {
            var param = new Agreement()
            {
                SysNo = request.SysNo,
                AgreementName = request.AgreementName,
                AgreementContent = request.AgreementContent,
                Remark = request.Remark,
                IsEnable = request.IsEnable
            };
            var response = MKMSClient.Send<ActivityManagerResponse>(new AgreementManagerReq()
            {
                UserId = userId,
                Agreement = param
            });
            message = response.DoResult;
            return response.DoFlag;
        }

        /// <summary>
        /// 查询协议信息
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<BaseRentAgreementInfo> QueryRentAgreementList(BaseRefer<BaseRentAgreementInfo> refer)
        {
            var obj = refer.SearchDetail ?? new BaseRentAgreementInfo();
            var param = new QueryAgreementReq()
            {
                SysNo = obj.SysNo ?? 0,
                AgreementName = obj.AgreementName,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize
            };
            var result = new BaseRefer<BaseRentAgreementInfo>();
            var response = MKMSClient.Send<QueryAgreementRes>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<Agreement, BaseRentAgreementInfo>(response.AgreementList);
            }
            return result;
        }

        /// <summary>
        /// 统计租赁数据
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public BaseRefer<BaseRentStatisticsInfo> QueryStatisticsInfo(BaseRefer<BaseRentStatisticsInfo> refer)
        {
            var obj = refer.SearchDetail ?? new BaseRentStatisticsInfo();
            var result = new BaseRefer<BaseRentStatisticsInfo>();
            var response = MKMSClient.Send<StatisticsRes>(new StatisticsReq() { Type = obj.Type, PageIndex = refer.PageIndex, PageSize = refer.PageSize });
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<Statistics, BaseRentStatisticsInfo>(response.StatisticsInfo);
                result.SearchDetail = new BaseRentStatisticsInfo();
                result.SearchDetail.Type = obj.Type;
            }
            return result;
        }
        /// <summary>
        /// 统计明细
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<BaseRentStatisticsInfo> QueryStatisticsDetailInfo(BaseRefer<BaseRentStatisticsInfo> refer)
        {
            int pageIndex = refer.PageIndex ?? 1;
            int pageSize = refer.PageSize ?? 20;
            var obj = refer.SearchDetail ?? new BaseRentStatisticsInfo();
            var result = new BaseRefer<BaseRentStatisticsInfo>();
            var response = MKMSClient.Send<StatisticsDetailRes>(new StatisticsDetailReq() { GoodsId = obj.GoodsId, Date = obj.Date, PageIndex = refer.PageIndex, PageSize = refer.PageSize });
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<StatisticsDetail, BaseRentStatisticsInfo>(response.StatisticsInfo);
                IEnumerable<BaseRentStatisticsInfo> list = null;
                if (obj.StartTime.HasValue && !obj.EndTime.HasValue)
                {
                    list = result.List2.Where(m => m.DtTime >= obj.StartTime.Value);
                }
                else if (obj.EndTime.HasValue && !obj.StartTime.HasValue)
                {
                    list = result.List2.Where(m => m.DtTime <= obj.EndTime.Value);
                }
                else if (obj.StartTime.HasValue && obj.EndTime.HasValue)
                {
                    list = result.List2.Where(m => m.DtTime <= obj.EndTime.Value && m.DtTime >= obj.StartTime);
                }
                if (list != null)
                    result.List2 = list.ToList();
                if (result.List2 != null)
                    result.List2 = result.List2.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                result.SearchDetail = new BaseRentStatisticsInfo();
                result.SearchDetail.GoodsId = obj.GoodsId;
                result.SearchDetail.Date = obj.Date;
                result.SearchDetail.StartTime = obj.StartTime;
                result.SearchDetail.EndTime = obj.EndTime;

            }
            return result;
        }

        //会员等级处理
        public string GetLevelName(int v)
        {
            var result = "";
            switch (v)
            {
                case 1:
                    result = "普通会员";
                    break;
                case 2:
                    result = "银卡会员";
                    break;
                case 3:
                    result = "金卡会员";
                    break;
                case 4:
                    result = "白金卡会员";
                    break;
                case 5:
                    result = "至尊会员";
                    break;
                case 6:
                    result = "租期未满";
                    break;
            }
            return result;
        }


    }
}
