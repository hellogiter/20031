using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.CouponActivity
{
   public class CouponActivityConfigureDetail
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> ActivitySysNo { get; set; }
        public string ActivityKey { get; set; }
        public string CouponKey { get; set; }
        public string CouponPicUrl { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> SetLimitCount { get; set; }
        public Nullable<int> ReceiveLimitCount { get; set; }
        public Nullable<int> SetLimitUserCount { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
