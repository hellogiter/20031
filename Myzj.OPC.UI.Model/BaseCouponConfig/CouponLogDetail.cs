using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class CouponLogDetail
    {
        public int SysNo { get; set; }
        public string CouponKey { get; set; }
    }

    public class CouponLogDetailExt
    {
        public int SysNo { get; set; }
        public string CouponKey { get; set; }
        public string OperationTable { get; set; }
        public int OperationType { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public int Operator { get; set; }
        public DateTime RowCreateDate { get; set; }
    }


    public class CouponInfoData
    {
        public Nullable<int> SysNo { get; set; }
        public string CouponKey { get; set; }
        public string Belonging { get; set; }
        public string CouponName { get; set; }
        public string CouponDescription { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<decimal> FillMoney { get; set; }
        public Nullable<decimal> SubtractMoney { get; set; }
        public decimal? Discount { get; set; } //折扣
        public decimal? DiscountUpperLimit { get; set; }//折扣上限金额
        public int? IsCodeToCoupon { get; set; }//优惠券是否是码转券
        public string BasicsExt { get; set; }
        public string CouponRule { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreatePeople { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdatePeople { get; set; }
        public Nullable<int> AuditLevel { get; set; }
        public Nullable<int> AuditState { get; set; }
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public int? CouponCategorySource { get; set; } //抵扣券分类来源 0  代表普通【普通券】 1、新妈【新客券】  2、推广类【线下活动券】 3、固定活动类【幸运星期一】  4、会员权益【会员券】

        public int? SendLimitUserCount { get; set; }
        public int? SendLimitCount { get; set; }
        public int? WillReachWarning { get; set; }
        public int? UseSetDays { get; set; }
        public List<M_BatchUse> BatchUses { get; set; }
        public int DeptId { get; set; }
        public int? CouponType { get; set; }
        public bool IsGetCoupon { get; set; }
        public bool IsShowOnDetail { get; set; }
      

        public List<int?> Platform { get; set; }
        public List<int?> ApplicableFirstCategory { get; set; }
        public List<int?> ApplicableSecondCategory { get; set; }
        public List<int?> ApplicableThreeCategory { get; set; }
        public List<int?> ExcludeFirstCategory { get; set; }
        public List<int?> ExcludeSecondCategory { get; set; }
        public List<int?> ExcludeThreeCategory { get; set; }
        public string C_ApplicableFirstCategory { get; set; }//匹配分类的中文名
        public string C_ApplicableSecondCategory { get; set; }//匹配中文
        public string C_ApplicableThreeCategory { get; set; }//匹配中文
        public string C_ExcludeFirstCategory { get; set; }//匹配中文
        public string C_ExcludeSecondCategory { get; set; }//匹配中文
        public string C_ExcludeThreeCategory { get; set; }//匹配中文
        public List<int?> ApplicableGoodsId { get; set; }
        public List<int?> ExcludeGoodsId { get; set; }
        public List<int?> ApplicablePromotion { get; set; }
        public List<int?> ExcludePromotion { get; set; }
        public List<int?> ApplicableMemberLevel { get; set; }
        public List<int?> ApplicablePosition { get; set; }
        public List<int?> MallType { get; set; }
        public List<int?> PromType { get; set; }
        public List<int?> Supplier { get; set; }
        public List<int?> Special { get; set; }
        public List<int?> ApplicableBrand { get; set; }
        public List<int?> ExcludeBrand { get; set; }
    }

    public class BasicsExt
    {
        public int? SendLimitUserCount { get; set; }
        public int? SendLimitCount { get; set; }
        public int? WillReachWarning { get; set; }
        public int? UseSetDays { get; set; }
        public int? BatchUses { get; set; }
        public int? CouponType { get; set; }
        public decimal? Discount { get; set; } //折扣
        public decimal? DiscountUpperLimit { get; set; }//折扣上限金额
        public int? IsCodeToCoupon { get; set; }//优惠券是否是码转券
    }
}
