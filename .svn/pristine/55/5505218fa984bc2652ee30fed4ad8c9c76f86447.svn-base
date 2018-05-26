using System;
using System.Collections.Generic;
using MYZJ.VIP.ServiceModel;
using Myzj.CMS.ServiceModel;
using Myzj.OPC.UI.Model.SaleHotStyle;

namespace Myzj.OPC.UI.ServiceClient
{
    public class SaleHotStyleClient : BaseService
    {

        private SaleHotStyleClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static SaleHotStyleClient _instance;
        public static SaleHotStyleClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SaleHotStyleClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 爆品列表
        /// <summary>
        /// 爆品列表
        /// </summary>
        /// <param name="saleHotStyle"></param>
        /// <returns></returns>
        public SaleHotStyleRefer QuerySaleHotStyle(SaleHotStyleRefer saleHotStyle)
        {
            var result = new SaleHotStyleRefer();
            var req = new QuerySaleHotStyleRequest();
            if (saleHotStyle.SearchDetail != null)
            {
                req.ProductId = saleHotStyle.SearchDetail.ProductId;
                req.ProductName = saleHotStyle.SearchDetail.vchProductName;
                req.ApplyPlace = saleHotStyle.SearchDetail.ApplyPlace;

                req.IsEnable = saleHotStyle.SearchDetail.IsEnable;

                req.IsTop = saleHotStyle.SearchDetail.IsTop;
                req.isExpire = saleHotStyle.SearchDetail.isExpire ?? 0;
            }
            req.PageIndex = saleHotStyle.PageIndex;
            req.PageSize = saleHotStyle.PageSize;
            var res = CMSClient.Send<QuerySaleHotStyleResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Sale_HotStyleExt, SaleHotStyleDetail>(res.PdtbaseInfoDos);
                result.Total = res.Total;
            }
            result.SearchDetail = saleHotStyle.SearchDetail;
            result.PageIndex = saleHotStyle.PageIndex;
            result.PageSize = saleHotStyle.PageSize;
            return result;
        }
        #endregion

        #region 应用位置列表
        /// <summary>
        /// 应用位置列表
        /// </summary>
        /// <returns></returns>
        public List<SaleHotStyleApplyPlaceDetail> QuerySaleHotStyleApplyPlace()
        {
            var result = new List<SaleHotStyleApplyPlaceDetail>();
            var req = new QuerySaleHotStyleApplyPlaceRequest();
            var res = CMSClient.Send<QuerySaleHotStyleApplyPlaceResponse>(req);
            if (res.DoFlag)
            {
                result =
                    Mapper.MappGereric<Sale_HotStyle_ApplyPlaceExt, SaleHotStyleApplyPlaceDetail>(
                        res.SaleHotStyleApplyDos);
            }
            return result;
        }
        #endregion

        #region 根据Id查询单条信息
        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <param name="saleHotStyle"></param>
        /// <returns></returns>
        public SaleHotStyleDetail QuerySaleHotStyleById(SaleHotStyleDetail saleHotStyle)
        {
            var result = new SaleHotStyleDetail();
            var req = new QuerySaleHotStyleByIdRequest();
            req.ID = saleHotStyle.Id ?? 0;
            var res = CMSClient.Send<QuerySaleHotStyleByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Sale_HotStyleExt, SaleHotStyleDetail>(res.Item);
            }
            return result;
        }
        #endregion

        #region 根据应用位置ID查询对应的应用位置名称
        /// <summary>
        /// 根据应用位置ID查询对应的应用位置名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetApplaceName(string id)
        {
            string result = "";
            var req = new QuerySaleHotStyleApplyPlaceByIdRequest();
            req.ApplyPlaceId = id;
            var res = CMSClient.Send<QuerySaleHotStyleApplyPlaceByIdResponse>(req);
            if (res.DoFlag)
            {
                foreach (var item in res.SaleHotStyleApplyDos)
                {
                    result = item.ApplyPlaceName;
                }
            }
            return result;
        }
        #endregion

        #region 设置爆品商品置顶信息
        /// <summary>
        /// 设置爆品商品置顶信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="istop"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool UpdateSaleHotStyleIsTop(int id, short istop, DateTime startDate, DateTime endDate)
        {
            var req = new UpdateSaleHotStyleIsTopRequest();
            req.Id = id;
            req.IsTop = istop;
            req.TopBeginTime = startDate;
            req.TopEndTime = endDate;

            var res = CMSClient.Send<UpdateSaleHotStyleIsTopResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 取消爆品商品置顶信息
        /// <summary>
        ///  取消爆品商品置顶信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="istop"></param>
        /// <returns></returns>
        public bool CancelSaleHotStyleIsTop(int id)
        {
            var req = new CancelSaleHotStyleIsTopRequest();
            req.Id = id;
            req.IsTop = 0;
            var res = CMSClient.Send<CancelSaleHotStyleIsTopResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 新增爆品商品
        /// <summary>
        /// 新增爆品商品
        /// </summary>
        /// <returns></returns>
        public bool AddSaleHotStyle(SaleHotStyleDetail saleHotStyle, out string str)
        {
            var req = Mapper.Map<SaleHotStyleDetail, AddSaleHotStyleRequest>(saleHotStyle);
            var res = CMSClient.Send<AddSaleHotStyleResponse>(req);
            str = res.DoResult;
            return res.DoFlag;
        }
        #endregion

        #region 修改爆品商品
        /// <summary>
        /// 修改爆品商品
        /// </summary>
        /// <param name="saleHotStyle"></param>
        /// <returns></returns>
        public bool UpdateSaleHotStyle(SaleHotStyleDetail saleHotStyle, out string str)
        {
            var req = Mapper.Map<SaleHotStyleDetail, UpdateSaleHotStyleRequest>(saleHotStyle);
            var res = CMSClient.Send<UpdateSaleHotStyleResponse>(req);
            str = res.DoResult;
            return res.DoFlag;
        }
        #endregion

        #region 修改爆品状态
        /// <summary>
        /// 修改爆品状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateSaleHotStyleState(int id, int state)
        {
            var req = new UpdateSaleHotStyleStateRequest();
            req.Id = id;
            req.IsEnable = Convert.ToBoolean(state);

            var res = CMSClient.Send<UpdateSaleHotStyleStateResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改爆品商品排序
        /// <summary>
        /// 修改爆品商品排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool UpdateSaleHotStyleSort(int id, int sort)
        {
            var req = new UpdateSaleHotStyleSortRequest();
            req.Id = id;
            req.Sort = sort;
            var res = CMSClient.Send<UpdateSaleHotStyleSortResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除爆品商品
        /// <summary>
        /// 删除爆品商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelSaleHotStyle(int id)
        {
            var req = new DelSaleHotStyleRequest();
            req.Id = id;
            req.IsDeleted = Convert.ToBoolean(0);
            var res = CMSClient.Send<DelSaleHotStyleResponse>(req);
            return res.DoFlag;

        }
        #endregion

        #region 根据商品Id返回商品名称
        /// <summary>
        /// 根据商品Id返回商品名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string QueryPdtBaseInfoById(int id)
        {
            string result = "";
            var req = new QueryPdtBaseInfoByIdRequest();
            req.IntProductID = id;
            var res = OpcClient.Send<QueryPdtBaseInfoByIdResponse>(req);
            if (res.DoFlag)
            {
                result = res.PdtBaseInfoDos.VchProductName;
            }
            return result;
        }
        #endregion

        #region 检测商品Id是否存在商品表中
        /// <summary>
        /// 检测商品Id是否存在商品表中
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool CheckPdtInfoById(int productId, out string str)
        {
            var req = new QueryPdtBaseInfoByIdRequest();
            req.IntProductID = productId;
            var res = OpcClient.Send<QueryPdtBaseInfoByIdResponse>(req);
            if (res.PdtBaseInfoDos != null)
            {
                str = res.PdtBaseInfoDos.VchProductName;
            }
            else
            {
                str = "";
            }
            return res.DoFlag;
        }
        #endregion

    }
}
