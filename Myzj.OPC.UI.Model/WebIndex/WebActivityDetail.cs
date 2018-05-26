using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebIndex
{
    public class WebActivityDetail
    {
        public Nullable<int> IntActivityId { get; set; }
        public string VchActivityName { get; set; }
        public Nullable<System.DateTime> DtStartTime { get; set; }
        public Nullable<System.DateTime> DtEndTime { get; set; }
        public Nullable<int> IntAddUserIt { get; set; }
        public Nullable<System.DateTime> DtCreateTime { get; set; }
        public Nullable<int> IntStatus { get; set; }
    }
}
