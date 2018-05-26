using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class GoodsInfo
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public Nullable<int> intProductID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string vchProductName { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string vchProductStunt { get; set; }
        /// <summary>
        ///  市场价
        /// </summary>
        public Nullable<decimal> numMarketPrice { get; set; }
        /// <summary>
        /// 会员价
        /// </summary>
        public Nullable<decimal> numVipPrice { get; set; }
    }
}
