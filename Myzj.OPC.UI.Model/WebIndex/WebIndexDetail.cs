using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebIndex
{
    public class WebIndexDetail
    {
        public Nullable<int> IntRapidInID { get; set; }
        public string VchName { get; set; }
        public string VchLink { get; set; }
        public Nullable<int> IntSort { get; set; }
        public Nullable<byte> IntIsVisibleIndex { get; set; }
        public string VchMemo { get; set; }
        public Nullable<int> IntAddUserID { get; set; }
        public Nullable<System.DateTime> DtAddDate { get; set; }
        public Nullable<int> IntModUserID { get; set; }
        public Nullable<System.DateTime> DtModDate { get; set; }
        public Nullable<byte> IntNewUserVerify { get; set; }
        public Nullable<int> IntActivityId { get; set; }
        public string VchActivityName { get; set; }
        public Nullable<int> IntSystemType { get; set; }
        public Nullable<System.DateTime> DtStratDate { get; set; }
        public Nullable<System.DateTime> DtEndDate { get; set; }
    }
}
