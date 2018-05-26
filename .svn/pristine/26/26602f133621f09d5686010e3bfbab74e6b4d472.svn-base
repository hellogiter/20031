using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.UDP.ServiceModel;
using Myzj.BS.ServiceModel.Logistics;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.ExpressModel;
//using Myzj.TM.OUT.ServiceModel;
using tmdll=Myzj.TM.OUT.ServiceModel;
using upsdll= Ups.myzj.com.ServiceModel.ForUi;
using BaseResponse = Myzj.BS.ServiceModel.BaseResponse;
namespace Myzj.OPC.UI.ServiceClient
{
    public class ExpressClient : BaseService
    {
        #region 单例
        private ExpressClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static ExpressClient _instance;
        public static ExpressClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ExpressClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region 物流信息管理
        //查询列表
        public ExpressInfoRefer QueryExpressInfoPageList(ExpressInfoRefer refer)
        {
            var ret = new ExpressInfoRefer();
            var search = ret.Search = refer.Search;

            try
            {
                var req = Mapper.Map<ExpressInfoSearchModel, EC_QueryExpressInfoList>(search);
                req.PageIndex = refer.PageIndex;
                req.PageSize = refer.PageSize;
                var response = BSClient.Send<EC_QueryExpressInfoListResponse>(req);
                if (response.DoFlag && response.Dtos != null && response.Dtos.Any())
                {
                    var expressOrderTypeArr = typeof(AppEnum.ExpressOrderTypeEnum).GetEnumList();
                    var expressCallTypeArr = typeof(AppEnum.ExpressCallTypeModeEnum).GetEnumList();
                    var expressLastStatusArr = typeof(AppEnum.ExpressLastStatusEnum).GetEnumList();
                    var subscribeStatusArr = typeof(AppEnum.ExpressSubscribeStatusEnum).GetEnumList();
                    ret.List = Mapper.MappGereric<EC_QueryExpressInfoListDto, ExpressInfoModelExt>(response.Dtos);

                    for (var i = 0; i < ret.List.Count(); i++)
                    {
                        var item = ret.List[i];
                        var logisContent = item.LogiscticContent;
                        var orderStatus = item.OrderStatusContent;
                        var orderStatusShow = item.OrderStatusContent;
                        var outerContent = item.LogisticOuterContent;
                        var outerContentShow = item.LogisticOuterContent;
                        if (!string.IsNullOrEmpty(orderStatus) && orderStatus.Length > 40)
                        {
                            orderStatus = orderStatus.Substring(0, 40) + "...";
                            orderStatusShow = item.OrderStatusContent;
                        }
                        if (!string.IsNullOrEmpty(logisContent) && logisContent.Length > 40)
                        {
                            logisContent = item.LogiscticContent.Substring(0, 40) + "...";
                        }
                        if (!string.IsNullOrEmpty(outerContent) && outerContent.Length > 40)
                        {
                            outerContent = item.LogisticOuterContent.Substring(0, 40) + "...";
                            outerContentShow = item.LogisticOuterContent;
                        }
                        ret.List[i].OrderStatusContentShow = orderStatus;
                        ret.List[i].OrderStatusContentTitle = orderStatusShow;
                        ret.List[i].LogiscticContentShow = logisContent;
                        ret.List[i].LogiscticContentTitle = Converter.ConvertExpressContent(item.LogiscticContent);
                        ret.List[i].LogisticOuterContentShow = outerContent;
                        ret.List[i].LogisticOuterContentTitle = outerContentShow;

                        if (expressLastStatusArr.Any(c => c.Key == item.LastStatus))
                        {
                            ret.List[i].LastStatusDesc = expressLastStatusArr.First(c => c.Key == item.LastStatus).Value;
                        }
                        else
                        {
                            ret.List[i].LastStatusDesc = "空";
                        }
                        ret.List[i].OrderTypeDesc = expressOrderTypeArr.First(c => c.Key == item.OrderType).Value;
                        ret.List[i].PushRequestMessage = "";
                        if (!string.IsNullOrEmpty(item.PushRequestMessage))
                        {
                            ret.List[i].PushRequestMessage = item.PushRequestMessage;
                        }
                        ret.List[i].CallTypeDesc = expressCallTypeArr.First(c => c.Key == item.CallType).Value;
                        ret.List[i].SubscribeStatusDesc = subscribeStatusArr.First(c => c.Key == item.SubscribeStatus).Value;
                    }

                    ret.PageIndex = response.PageIndex;
                    ret.PageSize = response.PageSize;
                    ret.Total = response.Total;
                }
            }
            catch (Exception e)
            {
                ret.DoResult = "导出异常或数据量太大，请筛选条件后再导出0.0：" + e.Message;
            }
            return ret;
        }

        //查询单个
        public ExpressInfoModel QueryExpressInfoEntity(int SysNo, string OrderCode)
        {
            var model = new ExpressInfoModel();
            var response = BSClient.Send<EC_QueryExpressInfoEntityResponse>(new EC_QueryExpressInfoEntity
                {
                    SysNo = SysNo,
                    OrderCode = OrderCode
                });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<EC_QueryExpressInfoListDto, ExpressInfoModel>(response.Dto);
            }
            return model;
        }

        //修改基本信息(已归档数据无法修改)-可以改为已签收
        public EC_ExpressInfoUpdateResponse UpdateExpressInfo(ExpressInfoModel model)
        {
            return BSClient.Send<EC_ExpressInfoUpdateResponse>(Mapper.Map<ExpressInfoModel, EC_ExpressInfoUpdate>(model));
        }

        ////新增-运单手动导入
        //public bool AddExpressInfo(ExpressInfoModel model)
        //{
        //    return BSClient.Send<EC_ExpressInfoAddResponse>(Mapper.Map<ExpressInfoModel, EC_ExpressInfoAdd>(model)).DoFlag;
        //}

        //查询数据订阅记录
        public List<ExpressSubscribeRecordModel> QuerySubScribeRecord(string orderCode)
        {
            var ret = new List<ExpressSubscribeRecordModel>();
            var response = BSClient.Send<EC_QueryExpressSubscribeRecordResponse>(new EC_QueryExpressSubscribeRecord
                {
                    OrderCode = orderCode
                });
            if (response.DoFlag && response.Dtos != null && response.Dtos.Any())
            {
                ret = Mapper.MappGereric<EC_QueryExpressSubscribeRecordDto, ExpressSubscribeRecordModel>(response.Dtos);
            }
            return ret;
        }

        //查询自接记录
        public ExpressSelfAccessRefer QuerySelfAccessPageList(ExpressSelfAccessRefer refer)
        {
            var req = refer.Search;
            var ret = new ExpressSelfAccessRefer();
            var response = BSClient.Send<EC_QueryExpressSelfAccessListResponse>(new EC_QueryExpressSelfAccessList
                {
                    OrderCode = req.OrderCode,
                    StartTime = req.StartTime,
                    EndTime = req.EndTime,
                    PageIndex = refer.PageIndex,
                    PageSize = refer.PageSize
                });
            ret.List = Mapper.MappGereric<EC_QueryExpressSelfAccessListDto, ExpressSelfAccessModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }

        ////批量重新订阅(重推-重开)(修改物流中间表实现)
        //public bool SetSubscribeRetry(int OrderCode)
        //{
        //    return BSClient.Send<EC_SetSubscribeRetryResponse>(new EC_SetSubscribeRetry
        //        {
        //            OrderCode = OrderCode
        //        }).DoFlag;
        //}

        //刷新查询缓存
        public bool RefreshExpressCache(string ordercode)
        {
            return BSClient.Send<EC_RefreshExpressCacheResponse>(new EC_RefreshExpressCache
                {
                    OrderCode = ordercode
                }).DoFlag;
        }

        #endregion

        #region 配送商管理

        /// <summary>
        /// 查询配送商列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ExpressCompanyRefer QueryCompanPageList(ExpressCompanyRefer refer)
        {
            var req = refer.Search;
            var ret = new ExpressCompanyRefer();
            var response = BSClient.Send<EC_QueryCompanyListResponse>(new EC_QueryCompanyList
                 {
                     LogiscticId = req.LogiscticId,
                     LogiscticCompany = req.LogiscticCompany,
                     LogiscticCompanyName = req.LogiscticCompanyName,
                     OfenFlag = req.OfenFlag,
                     SetAccessMode = req.SetAccessMode,
                     PageIndex = refer.PageIndex,
                     PageSize = refer.PageSize,
                     IsDel = req.IsDel
                 });
            ret.List = Mapper.MappGereric<EC_QueryCompanyDto, CompanyModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }

        /// <summary>
        /// 查询单个配送商
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public CompanyModel QueryCompanyEntity(int SysNo)
        {
            var model = new CompanyModel();
            var response = BSClient.Send<EC_QueryCompanyEntityResponse>(new EC_QueryCompanyEntity
                {
                    SysNo = SysNo
                });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<EC_QueryCompanyDto, CompanyModel>(response.Dto);
            }
            return model;
        }

        /// <summary>
        /// 修改配送商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCompany(CompanyModel model)
        {
            return BSClient.Send<EC_CompanyUpdateResponse>(Mapper.Map<CompanyModel, EC_CompanyUpdate>(model)).DoFlag;
        }

        /// <summary>
        /// 新增配送商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCompany(CompanyModel model)
        {
            return BSClient.Send<EC_CompanyAddResponse>(Mapper.Map<CompanyModel, EC_CompanyAdd>(model)).DoFlag;
        }

        /// <summary>
        /// 查询配送商
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ExpressAcessConfigRefer QueryExpressAccessConfigPageList(ExpressAcessConfigRefer refer)
        {
            var req = refer.Search;
            var ret = new ExpressAcessConfigRefer();
            var response = BSClient.Send<EC_SelfAccessConfigListResponse>(new EC_SelfAccessConfigList { });
            ret.List = Mapper.MappGereric<EC_SelfAccessConfigListDto, SelfAccessConfigModel>(response.Dtos);
            return ret;
        }

        /// <summary>
        /// 修改配送商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateExpressAccessConfig(SelfAccessConfigModel model)
        {
            return BSClient.Send<EC_SelfAccessConfigUpdateResponse>(Mapper.Map<SelfAccessConfigModel, EC_SelfAccessConfigUpdate>(model)).DoFlag;
        }

        /// <summary>
        /// 新增配送商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public EC_SelfAccessConfigAddResponse AddExpressAccessConfig(SelfAccessConfigModel model)
        {
            return BSClient.Send<EC_SelfAccessConfigAddResponse>(Mapper.Map<SelfAccessConfigModel, EC_SelfAccessConfigAdd>(model));
        }
        //自接频率列表查询
        public List<SelfAccessConfigModel> QuerySelfAccessConfigList(string LogiscticId)
        {
            var model = new List<SelfAccessConfigModel>();
            var response = BSClient.Send<EC_SelfAccessConfigListResponse>(new EC_SelfAccessConfigList
            {
                LogiscticId = LogiscticId
            });
            if (response != null && response.DoFlag && response.Dtos.Any())
            {
                model = Mapper.MappGereric<EC_SelfAccessConfigListDto, SelfAccessConfigModel>(response.Dtos);
            }
            return model;
        }

        //自接频率修改
        public bool UpdateSelfAccessConfig(SelfAccessConfigModel model)
        {
            return BSClient.Send<EC_SelfAccessConfigUpdateResponse>(Mapper.Map<SelfAccessConfigModel, EC_SelfAccessConfigUpdate>(model)).DoFlag;
        }
        #endregion

        #region 国际物流管理
        /// <summary>
        /// 查询国际物流
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ExpressGuojiRefer QueryGuojiPageList(ExpressGuojiRefer refer)
        {
            var req = refer.Search;
            var ret = new ExpressGuojiRefer();
            var response = BSClient.Send<EC_QueryGuojiListReponse>(new EC_QueryGuojiList
            {
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
                OrderCode = req.OrderCode
            });
            ret.List = Mapper.MappGereric<EC_QueryGuojiListDto, InterNationalModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }

        #endregion

        #region 查询对账单
        /// <summary>
        /// 对账单查询
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public int QueryAccountStateMent(DateTime StartTime, DateTime EndTime)
        {
            return BSClient.Send<EC_QueryAccountStateMentResponse>(new
                EC_QueryAccountStateMent
                {
                    StartTime = StartTime,
                    EndTime = EndTime
                }).Sum;
        }

        #endregion

        #region 查询日志
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ExpressLogRefer QueryLogPageList(ExpressLogRefer refer)
        {
            var req = refer.Search;
            var ret = new ExpressLogRefer();
            var response = BSClient.Send<EC_QueryLogPageListResponse>(new EC_QueryLogPageList
            {
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
                OrderCode = req.OrderCode
            });
            ret.List = Mapper.MappGereric<EC_LogModelDto, ExpressLogModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }
        #endregion

        #region 订单状态管理

        /// <summary>
        /// 查询订单状态扭转
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ExpressOrderStatusRefer QueryOrderStatusPageList(ExpressOrderStatusRefer refer)
        {
            var req = refer.Search;
            var ret = new ExpressOrderStatusRefer();
            var response = BSClient.Send<EC_QueryOrderStatusPageListResponse>(new EC_QueryOrderStatusPageList
            {
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
                OrderCode = req.OrderCode
            });
            ret.List = Mapper.MappGereric<EC_QueryOrderStatusPageListDto, OrderStatusModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }


        //查询订单状态配置列表
        public ExpressOrderStatusConfigRefer QueryOrderStatusConfigList(ExpressOrderStatusConfigRefer refer)
        {
            var ret = new ExpressOrderStatusConfigRefer();
            var response = BSClient.Send<EC_QueryOrderStatusConfigListResponse>(new EC_QueryOrderStatusConfigList
            {
                OrderType = refer.Search.OrderType,
                OrderStatus = refer.Search.OrderStatus
            });
            if (response.DoFlag && response.Dtos.Any())
            {
                ret.List = Mapper.MappGereric<EC_QueryOrderStatusConfigListDto, OrderStatusConfigModel>(response.Dtos);
            }
            return ret;
        }

        //查询单个订单状态配置
        public OrderStatusConfigModel QueryOrderStatusConfigEntity(int SysNo)
        {
            var model = new OrderStatusConfigModel();
            var response = BSClient.Send<EC_QueryOrderStatusConfigEntityResponse>(new EC_QueryOrderStatusConfigEntity
            {
                SysNo = SysNo
            });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<EC_QueryOrderStatusConfigListDto, OrderStatusConfigModel>(response.Dto);
            }
            return model;
        }

        //修改订单状态配置
        public bool UpdateOrderStatusConfig(OrderStatusConfigModel model)
        {
            return BSClient.Send<EC_OrderStatusConfigUpdateResponse>(Mapper.Map<OrderStatusConfigModel, EC_OrderStatusConfigUpdate>(model)).DoFlag;
        }

        //新增订单状态配置
        public EC_OrderStatusConfigAddResponse AddOrderStatusConfig(OrderStatusConfigModel model)
        {
            return BSClient.Send<EC_OrderStatusConfigAddResponse>(Mapper.Map<OrderStatusConfigModel, EC_OrderStatusConfigAdd>(model));
        }

        #endregion


        #region 删除运单
        /// <summary>
        /// 删除运单
        /// </summary>
        /// <param name="SysNo"></param>
        /// <param name="orderCode"></param>
        /// <param name="Reason"></param>
        /// <returns></returns>
        public BaseResponse DelExpressInfo(int SysNo, string orderCode, string Reason)
        {
            var ptcp = new BaseResponse();
            var response = BSClient.Send<EC_ExpressInfoDelResponse>(new EC_ExpressInfoDel
            {
                SysNo = SysNo,
                OrderCode = orderCode,
                Reason = Reason
            });
            ptcp.DoFlag = response.DoFlag;
            ptcp.DoResult = response.DoResult;
            return ptcp;
        }

        #endregion

        #region 导入处理意见
        /// <summary>
        /// 导入处理意见
        /// </summary>
        /// <param name="dList"></param>
        /// <returns></returns>
        public EC_ImportHandleInfoResponse ImportHandleInfo(List<ExpressImportModel> dList)
        {
            return BSClient.Send<EC_ImportHandleInfoResponse>(new EC_ImportHandleInfo
             {
                 Dtos = Mapper.MappGereric<ExpressImportModel, EC_ImportHandleInfoDto>(dList).ToList()
             });
        }

        #endregion

        /// <summary>
        /// 查询特卖供应商
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string QueryTemaiProvider(string orderCode, int type)
        {
            //根据订单号查询商品sku
            var orderInfo = UdpClient.Send<QueryOrderInfoForHolycaRes>(new QueryOrderInfoForHolycaReq
                 {
                     OrderNoCsv = orderCode
                 });
            int? skuId = 0;
            var providerName = "";
            if (orderInfo.DoFlag && orderInfo.OrderInfoForHolycaDtos!=null && orderInfo.OrderInfoForHolycaDtos.Any())
            {
               skuId= orderInfo.OrderInfoForHolycaDtos.First().ProductNo;
            }

            if (skuId == 0)
                return "";

            if (type == 2)
            {
                //特卖:通过SkuID查询对应供应商
                var tmInfo = TmOutServiceClient.Send<tmdll.GeSkuVendorBySkuRes>(new tmdll.GeSkuVendorBySkuReq
                    {
                        SkuIds = skuId.ToString()
                    });
                providerName = tmInfo.SkuVendorList.First().CompanyName;
            }
            if (type == 69)
            {
                //代发货:通过SkuID查询对应供应商
                var upsInfo = UpsServiceClient.Send<upsdll.GeSkuVendorBySkuRes>(new upsdll.GeSkuVendorBySkuReq
                {
                    SkuIdList = new List<int>()
                        {
                            skuId??0
                        }
                });
                if (upsInfo.DoFlag)
                {
                    providerName = upsInfo.SkuVendorList.First().CompanyName;
                }
            }

            return providerName;
        }
    }
}
