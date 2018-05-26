using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model.OrderProductState;

namespace Myzj.OPC.UI.ServiceClient
{
    public class OrderProductStateClient : BaseService
    {
        private OrderProductStateClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static OrderProductStateClient _instance;
        public static OrderProductStateClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new OrderProductStateClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 查询订单扭转物流信息配置
        /// <summary>
        /// 查询订单扭转物流信息配置
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <returns></returns>
        public OrderProductStateRefer QueryOrderProductStatusConfig(OrderProductStateRefer orderProduct)
        {
            var result = new OrderProductStateRefer();
            var req = new QueryOrderProductStatusConfigRequest();
            if (orderProduct.SearchDetail != null)
            {
                req.MallType = orderProduct.SearchDetail.MallType;
                req.OrderStatusName = orderProduct.SearchDetail.OrderStatusName;
                req.IsDeleted = orderProduct.SearchDetail.IsDeleted;
                req.FlowStatus = orderProduct.SearchDetail.FlowStatus;
            }
            req.PageIndex = orderProduct.PageIndex;
            req.PageSize = orderProduct.PageSize;

            var res = BSClient.Send<QueryOrderProductStatusConfigResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<order_ProductStatus_ConfigExt, OrderProductStateDetail>(
                        res.ProductStatusConfigDos);
                result.Total = res.Total;
            }
            result.SearchDetail = orderProduct.SearchDetail;
            result.PageIndex = orderProduct.PageIndex;
            result.PageSize = orderProduct.PageSize;
            return result;
        }
        #endregion

        #region 查询单条订单扭转物流信息配置
        /// <summary>
        /// 查询单条订单扭转物流信息配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderProductStateDetail QueryOrderProductStatusConfigById(int id)
        {
            var result = new OrderProductStateDetail();
            var req = new QueryOrderProductStatusConfigByIdRequest();
            req.ID = id;
            var res = BSClient.Send<QueryOrderProductStatusConfigByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<order_ProductStatus_ConfigExt, OrderProductStateDetail>(res.ProductStatusConfigDos);
            }
            return result;
        }

        #endregion

        #region 仓位标识列表
        /// <summary>
        /// 仓位标识列表
        /// </summary>
        /// <returns></returns>
        public List<BaseWarehouseDetail> QueryBaseWarehouse()
        {
            var result = new List<BaseWarehouseDetail>();

            var req = new QueryBaseWarehouseRequest();
            var res = BSClient.Send<QueryBaseWarehouseResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.MappGereric<base_t_WarehouseExt, BaseWarehouseDetail>(res.WarehouseDos);
            }
            return result;
        }
        #endregion

        #region 新增订单扭转
        /// <summary>
        ///  新增订单扭转
        /// </summary>
        /// <returns></returns>
        public bool AddOrderProductStatusConfig(OrderProductStateDetail orderDetail)
        {
            var req = Mapper.Map<OrderProductStateDetail, AddOrderProductStatusConfigRequest>(orderDetail);
            var res = BSClient.Send<AddOrderProductStatusConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改订单扭转
        /// <summary>
        ///  修改订单扭转
        /// </summary>
        /// <returns></returns>
        public bool UpdateOrderProductStatusConfig(OrderProductStateDetail orderDetail)
        {
            var req = Mapper.Map<OrderProductStateDetail, UpdateOrderProductStatusConfigRequest>(orderDetail);
            var res = BSClient.Send<UpdateOrderProductStatusConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改订单扭转排序
        /// <summary>
        ///  修改订单扭转排序
        /// </summary>
        /// <returns></returns>
        public bool UpdateOrderProductStatusConfigSort(int id, int sort)
        {
            var req = new UpdateOrderProductStatusConfigSortRequest();
            req.ID = id;
            req.Sort = sort;
            var res = BSClient.Send<UpdateOrderProductStatusConfigSortResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改订单扭转状态
        /// <summary>
        ///  修改订单扭转状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateOrderProductStatusConfigState(int id, int state)
        {
            var req = new UpdateOrderProductStatusConfigStateRequest();
            req.ID = id;
            req.IsDeleted = state;
            var res = BSClient.Send<UpdateOrderProductStatusConfigStateResponse>(req);
            return res.DoFlag;
        }
        #endregion
    }
}
