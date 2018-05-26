using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebAwardDetail
    {
        public Nullable<int> IntAwardId { get; set; }
        public string VchAwardName { get; set; }
        public Nullable<int> IntAwardRate { get; set; }
        public Nullable<System.DateTime> DtStartTime { get; set; }
        public Nullable<System.DateTime> DtEndTime { get; set; }
        public Nullable<int> IntCreateUser { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> DtCreateTime { get; set; }
        public Nullable<int> IntStatus { get; set; }
        public Nullable<int> IntAwarcCount { get; set; }
        public Nullable<int> IntWinCount { get; set; }
        public string VchTemplateCode { get; set; }
        public string VchDisplayLabels { get; set; }
        public Nullable<int> IntFalseData { get; set; }
        public Nullable<int> IntCouponCodeId { get; set; }
    }
}
