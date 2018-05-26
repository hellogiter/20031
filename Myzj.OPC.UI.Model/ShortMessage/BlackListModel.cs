using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.ShortMessage
{
   public class BlackListModel
    {
        public Nullable<int> SysNo { get; set; }
        public string Mobile { get; set; }
        public string UserGuid { get; set; }
        public string ClientIp { get; set; }
        public string LimitReason { get; set; }
        public Nullable<System.DateTime> LimitEndTime { get; set; }
        public string Operator { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<System.DateTime> RowModifyDate { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsDel { get; set; }
    }
}
