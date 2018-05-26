using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class CountGoodsDetailInfo
    {
        /// <summary>
        /// 建团总数
        /// </summary>
        public int JianGroupCount { get; set; }
        /// <summary>
        /// 参团人数
        /// </summary>
        public int CanGroupCount { get; set; }
        /// <summary>
        /// 成团人数
        /// </summary>
        public int GroupCount { get; set; }
        /// <summary>
        /// 差价
        /// </summary>
        public int DiscountPrice { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 商品SysNo
        /// </summary>
        public int? SysNo { get; set; }
        /// <summary>
        /// 商品GoodsId
        /// </summary>
        public int? GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品团购价格
        /// </summary>
        public decimal GroupPrice { get; set; }

      
        public int? GroupActivitySysNo { get; set; }

    }

    public class CountGoodsDetailInfoExt
    {
        /// <summary>
        /// 建团总数
        /// </summary>
        public int JianGroupCount { get; set; }
        /// <summary>
        /// 参团人数
        /// </summary>
        public int CanGroupCount { get; set; }
        /// <summary>
        /// 成团人数
        /// </summary>
        public int GroupCount { get; set; }
        /// <summary>
        /// 差价
        /// </summary>
        public int DiscountPrice { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 商品SysNo
        /// </summary>
        public int? SysNo { get; set; }
        /// <summary>
        /// 商品GoodsId
        /// </summary>
        public int GoodsId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品团购价格
        /// </summary>
        public decimal GroupPrice { get; set; }
        /// <summary>
        /// 促销Id
        /// </summary>
        public string PromSysNos { get; set; }
        /// <summary>
        /// 免单促销Id
        /// </summary>
        public string PromSysNos2 { get; set; }

    }
}
