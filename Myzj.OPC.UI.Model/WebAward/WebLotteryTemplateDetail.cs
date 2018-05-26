using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebLotteryTemplateDetail
    {
        public Nullable<int> LtSysNos { get; set; }
        public string TempName { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> IsEnable { get; set; }
        public Nullable<int> TempType { get; set; }
    }
}
