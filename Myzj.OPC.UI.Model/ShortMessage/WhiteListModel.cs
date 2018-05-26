using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.ShortMessage
{
   public class WhiteListModel
    {
       public Nullable<int> SysNo { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> RowCreateTime { get; set; }
        public string Remark { get; set; }
        public Nullable<int> IsEnable { get; set; }
    }
}
