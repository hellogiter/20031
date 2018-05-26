using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebAwardUserTagsDetail
    {
        public Nullable<int> IntTagsId { get; set; }
        public Nullable<int> IntAwardId { get; set; }
        public string vchAwardName { get; set; }
        public string VchTagsName { get; set; }
        public string VchTagsLabels { get; set; }
        public Nullable<int> IntPriority { get; set; }
        public Nullable<bool> BitIsDefault { get; set; }
        public Nullable<System.DateTime> DtCreateTime { get; set; }
        public Nullable<int> IntCreateUserId { get; set; }
        public Nullable<System.DateTime> DtUpdateTime { get; set; }
        public Nullable<int> IntUpdateUserId { get; set; }
        public Nullable<int> IntStatus { get; set; }
    }
}
