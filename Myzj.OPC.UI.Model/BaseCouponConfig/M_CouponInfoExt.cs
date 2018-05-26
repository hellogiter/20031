using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    #region 优惠券基础信息扩展类

    /// <summary>
    /// 基础扩展类
    /// </summary>
    public class BasicsExtInfo
    {
        //发送的张数 默认为 1
        public int SendLimitCount { get; set; }

        //优惠劵设置相对过期天数 0不设置
        public int UseSetDays { get; set; }

        //批次使用条件
        public List<BatchUse> BatchUses { get; set; }
    }

    /// <summary>
    /// 批次使用条件
    /// </summary>
    public class BatchUse
    {
        //当前批次使用开始时间
        public DateTime BatchStartTime { get; set; }
        //当前批次使用结束时间
        public DateTime BatchEndTime { get; set; }
        //当前批次单个会员领取数量
        public int BatchSendUserCount { get; set; }
        //当前批量总共数量
        public int BatchSendCount { get; set; }
        //当前批次分组 唯一
        public string BatchGroup { get; set; }
    }

    /// <summary>
    /// 优惠劵使用规则扩展类
    /// </summary>
    public class CouponRuleInfo
    {
        //适用平台 默认为全部
        public ApplicablePlatform PlatformEntity { get; set; }
        //商品
        public M_Goods GoodsEntity { get; set; }
        //促销
        public M_Promotion PromotionEntity { get; set; }
        //会员等级
        public M_MemberLevel MemberLevelEntity { get; set; }
        //仓位
        public M_Position PositionEntity { get; set; }
        //商城
        public M_MallType MallTypeEntity { get; set; }
        //供应商
        public M_Supplier SupplierEntity { get; set; }
        //专场
        public M_Special SpecialEntity { get; set; }
        //品牌
        public M_Brand BrandEntity { get; set; }
    }

    /// <summary>
    /// 适用平台
    /// </summary>
    public class ApplicablePlatform
    {
        //平台Id [1] PC网站 [2]wap网站 [3]安卓app [4]Ios [8]ipad
        public int Platform { get; set; }
    }

    /// <summary>
    /// 商品分类
    /// </summary>
    public class M_Goods
    {
        //可使用分类
        public string ApplicableCategory { get; set; }
        //排除分类
        public string ExcludeCategory { get; set; }

        //可使用商品Id
        public string ApplicableGoodsId { get; set; }
        //排除商品Id
        public string ExcludeGoodsId { get; set; }
    }

    /// <summary>
    /// 促销
    /// </summary>
    public class M_Promotion
    {
        //可使用促销
        public string ApplicablePromotion { get; set; }
        //排除促销
        public string ExcludePromotion { get; set; }
    }

    /// <summary>
    /// 会员级别
    /// </summary>
    public class M_MemberLevel
    {
        //适用会员等级
        public string ApplicableMemberLevel { get; set; }
    }

    /// <summary>
    /// 仓位
    /// </summary>
    public class M_Position
    {
        //适用仓位
        public string ApplicablePosition { get; set; }
    }

    /// <summary>
    /// 商城
    /// </summary>
    public class M_MallType
    {
        //商城类型Id
        public string MallType { get; set; }
    }

    /// <summary>
    /// 供应商
    /// </summary>
    public class M_Supplier
    {
        //供应商Id
        public string Supplier { get; set; }
    }

    /// <summary>
    /// 专场
    /// </summary>
    public class M_Special
    {
        //专场Id
        public string Special { get; set; }
    }

    /// <summary>
    /// 品牌
    /// </summary>
    public class M_Brand
    {
        //可使用品牌
        public string ApplicableBrand { get; set; }
        //排除品牌
        public string ExcludeBrand { get; set; }
    }

    #endregion
}
