using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.RentActivity
{
    public class BaseRentStatisticsInfo
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public DateTime DtTime { get; set; }
        public int TotalCount { get; set; }
        public int Type { get; set; }
        /// <summary>
        /// 加入购物车统计
        /// </summary>
        public int AddCartCount { get; set; }
        /// <summary>
        /// 新建订单统计
        /// </summary>
        public int BuilderOrderCount { get; set; }
        /// <summary>
        /// 已支付订单统计
        /// </summary>
        public int OrderBuyCount { get; set; }
        /// <summary>
        /// 取消订单统计
        /// </summary>
        public int CancelOrderCount { get; set; }

        public string Date { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
