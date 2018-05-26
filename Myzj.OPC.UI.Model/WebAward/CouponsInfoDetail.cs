using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class CouponsInfoDetail
    {
        public Nullable<int> CouponId { get; set; }
        public string CouponName { get; set; }
        public string CouponDescription { get; set; }
        public Nullable<System.DateTime> Effectivetime { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<decimal> FillMoney { get; set; }
        public Nullable<decimal> SubtractMoney { get; set; }
        public Nullable<int> CouponType { get; set; }
        public Nullable<bool> Is_enable { get; set; }
        public string FirstCategory { get; set; }
        public string SecondCategory { get; set; }
        public string ThreeCategory { get; set; }
        public string ProductsId { get; set; }
        public string ExcludePromId { get; set; }
        public Nullable<int> Status { get; set; }
        public string OpUser { get; set; }
        public Nullable<System.DateTime> OpDateTime { get; set; }
        public Nullable<int> Type { get; set; }
        public string FirstWebCategory { get; set; }
        public string SecondWebCategory { get; set; }
        public string ThreeWebCategory { get; set; }
        public Nullable<bool> IsCanRepeat { get; set; }
        public Nullable<int> ValidDays { get; set; }
        public string SystemType { get; set; }
        public Nullable<bool> IsSetDays { get; set; }
        public string BatchNo { get; set; }
        public string MallType { get; set; }
        public string Supplier { get; set; }
        public string Special { get; set; }
        public string MemberLevel { get; set; }
        public string WareHouse { get; set; }
        public string UseBrand { get; set; }
        public string ExcludeBrand { get; set; }
        public string Condition { get; set; }
        public Nullable<int> LimitNum { get; set; }
    }
}
