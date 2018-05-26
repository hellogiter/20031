using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebPrizeDetail
    {
        public Nullable<int> IntPrizeId { get; set; }
        public Nullable<int> IntAwardId { get; set; }
        public string vchAwardName { get; set; }
        public Nullable<int> IntPrizeNo { get; set; }
        public string VchPrizeName { get; set; }
        public Nullable<int> IntPrizeWeight { get; set; }
        public Nullable<int> IntPrizeCount { get; set; }
        public Nullable<System.DateTime> DtCreateTime { get; set; }
        public Nullable<int> DtCreateUser { get; set; }
        public Nullable<System.DateTime> DtUpdateTime { get; set; }
        public Nullable<int> DtUpdateUser { get; set; }
        public Nullable<int> IntStatus { get; set; }
        public string VchRemark { get; set; }
        public Nullable<int> IntPrizeType { get; set; }
        public string vchModelName { get; set; }
        public Nullable<int> IntNumId { get; set; }
        public string VchPrizeNo { get; set; }
    }
}
