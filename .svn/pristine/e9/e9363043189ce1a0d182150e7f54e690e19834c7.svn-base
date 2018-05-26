using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.Goods.ServiceModel.HotProduct;
using Myzj.Goods.ServiceModel.HotSubject;
using Myzj.Goods.ServiceModel.UnifyGoods;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.HotStyle;

namespace Myzj.OPC.UI.ServiceClient
{
    public class HotStyleClient : BaseService
    {
        private HotStyleClient() { }
        private static readonly object Lockobj = new object();
        private static HotStyleClient _instance;
        public static HotStyleClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new HotStyleClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 爆款

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public HotStyleRefer QueryHotStylePageList(HotStyleRefer refer)
        {
            var req = refer.Search;
            var ret = new HotStyleRefer();
            var isEnable = !(req.QueryIsEnable == 2);

            var response = GoodsClient.Send<GetHotProductListResponse>(new GetHotProductList
            {
                ProductId = req.ProductId,
                ProductName = req.ProductName,
                ApplyPlace = req.ApplyPlace,
                IsEnable = isEnable,
                IsExpire = req.IsExpire,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
            });
            ret.List = Mapper.MappGereric<GetHotProductDto, HotStyleModel>(response.Dtos);

            var list = ret.List;
            var goodsList = list.Select(c => c.ProductId ?? 0).ToList();

            //商品名称接入统一商品
            if (goodsList.Any())
            {
                var dictory = QueryUnionGoodsNameList(goodsList);
                foreach (var item in list)
                {
                    if (string.IsNullOrEmpty(item.ProductName))
                    {
                        item.ProductName = dictory.First(c => c.Key == item.ProductId).Value;
                    }
                }
            }
            var coutryKv = typeof(AppEnum.HotCountryEnum).GetEnumList();
            foreach (var item in list)
            {
                if (item.CountryId == 0)
                {
                    item.CountryName = "";
                }
                else
                {
                    item.CountryName = coutryKv.First(c => c.Key == (item.CountryId ?? 0)).Value;
                }
            }

            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public HotStyleModel QueryHotStyleModel(int SysNo)
        {
            var model = new HotStyleModel();
            var response = GoodsClient.Send<GetHotProductModelResponse>(new GetHotProductModel
            {
                Id = SysNo
            });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<GetHotProductDto, HotStyleModel>(response.Dto);
            }
            return model;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHotStyle(HotStyleModel model)
        {
            return GoodsClient.Send<UpdHotProductModelResponse>(new UpdHotProductModel
            {
                UpdDto = Mapper.Map<HotStyleModel, GetHotProductDto>(model)
            }).DoFlag;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddHotStyle(HotStyleModel model)
        {
            return GoodsClient.Send<AddHotProductModelResponse>(new AddHotProductModel
                {
                    AddDto = Mapper.Map<HotStyleModel, GetHotProductDto>(model)
                }
             ).DoFlag;
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public bool SetTop(int SysNo)
        {
            return GoodsClient.Send<SetTopHotProductModelResponse>(new SetTopHotProductModel
                {
                    Id = SysNo
                }).DoFlag;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="oldStr"></param>
        /// <param name="newStr"></param>
        /// <returns></returns>
        public bool SortableHotStyle(string oldStr, string newStr)
        {
            return GoodsClient.Send<SortableHotProductResponse>(new SortableHotProduct
            {
                OldIds = oldStr,
                NewIds = newStr
            }).DoFlag;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <param name="ApplyPlace"></param>
        /// <returns></returns>
        public bool RefreshHotStyleCache(string ApplyPlace)
        {
            return GoodsClient.Send<RefreshHotStyleCacheResponse>(new
                                                                      RefreshHotStyleCache
                {
                    ApplyPlace = ApplyPlace
                }).DoFlag;
        }



        /// <summary>
        /// 查询统一商品,返回 商品名；简介
        /// 爆品用
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public UnifyGoodsRes QueryUnionGoods(int productId)
        {
            var disable = new List<int?>();
            disable.Add(1);
            var res = GoodsClient.Send<UnifyGoodsRes>(new UnifyGoodsReq
            {
                SourceTypeSysNo = 2,
                GoodsID = productId,
                ClientIp = "111",
                DisplayLabel = disable
            });

            return res;
        }
        /// <summary>
        /// 查询统一商品，返回goodsId,goodsName集合
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public Dictionary<int, string> QueryUnionGoodsNameList(List<int> goodsId)
        {
            var keyValuePair = new Dictionary<int, string>();
            var obj = "";
            var disable = new List<int?>();
            disable.Add(1);
            var res = GoodsClient.Send<UnifyBaseGoodsListRes>(new UnifyBaseGoodsListReq
            {
                SourceTypeSysNo = 2,
                GoodsID = goodsId,
                ClientIp = "111",
                DisplayLabel = disable
            });
            if (res != null && res.DoFlag && res.UnifyGoodsList.Any())
            {
                foreach (var item in res.UnifyGoodsList)
                {
                    keyValuePair.Add(item.GoodsId, item.Title);
                }
            }
            return keyValuePair;
        }

        #endregion

        #region 专题
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public HotSubjectRefer QueryHotSubjectPageList(HotSubjectRefer refer)
        {
            var req = refer.Search;
            var ret = new HotSubjectRefer();
            var isEnable = !(req.QueryIsEnable == 2);
            var response = GoodsClient.Send<GetHotSubjectListResponse>(new GetHotSubjectList
            {
                ApplyPlace = req.ApplyPlace,
                IsEnable = isEnable,
                IsExpire = req.IsExpire,
                SubjectName = req.SubjectName,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
            });
            ret.List = Mapper.MappGereric<GetHotSubjectDto, HotSubjectModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public HotSubjectModel QueryHotSubjectModel(int SysNo)
        {
            var model = new HotSubjectModel();
            var response = GoodsClient.Send<GetHotSubjectModelResponse>(new GetHotSubjectModel
            {
                Id = SysNo
            });
            if (response.DoFlag && response.HotSubjectDto != null)
            {
                model = Mapper.Map<GetHotSubjectDto, HotSubjectModel>(response.HotSubjectDto);
            }
            return model;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHotSubject(HotSubjectModel model)
        {
            return GoodsClient.Send<UpdHotSubjectModelResponse>(new UpdHotSubjectModel
                {
                    UpdDto = Mapper.Map<HotSubjectModel, GetHotSubjectDto>(model)
                }).DoFlag;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddHotSubject(HotSubjectModel model)
        {
            return GoodsClient.Send<AddHotSubjectModelResponse>(new AddHotSubjectModel
            {
                AddDto = Mapper.Map<HotSubjectModel, GetHotSubjectDto>(model)
            }).DoFlag;
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public bool SetSubjectTop(int SysNo)
        {
            return GoodsClient.Send<SetTopHotSubjectModelResponse>(new SetTopHotSubjectModel
            {
                Id = SysNo
            }).DoFlag;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <param name="ApplyPlace"></param>
        /// <returns></returns>
        public bool RefreshHotSujectCache(string ApplyPlace)
        {
            return GoodsClient.Send<RefreshHotSujectCacheResponse>(new
                                                                      RefreshHotSujectCache
            {
                ApplyPlace = ApplyPlace
            }).DoFlag;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="oldStr"></param>
        /// <param name="newStr"></param>
        /// <returns></returns>
        public bool SortableHotSubject(string oldStr, string newStr)
        {
            return GoodsClient.Send<SortableHotSubjectResponse>(new SortableHotSubject
            {
                OldIds = oldStr,
                NewIds = newStr
            }).DoFlag;
        }
        #endregion

        public List<ApplyPlaceModel> GetApplyPlace(ApplyPlaceModel req)
        {
            var list = new List<ApplyPlaceModel>();
            var ptcp = GoodsClient.Send<GetApplyPlaceResponse>(Mapper.Map<ApplyPlaceModel, GetApplyPlace>(req));
            if (ptcp.DoFlag && ptcp.Dtos.Any())
            {
                list = Mapper.MappGereric<GetApplyPlaceDto, ApplyPlaceModel>(ptcp.Dtos);
            }
            return list;
        }

    }
}
