using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.UserRefer
{
    public class UserReferDetail
    {
        public int Count { get; set; }  // 总数
        public Nullable<int> IntReferID { get; set; }
        public Nullable<int> IntProductID { get; set; }
        public string VchEmail { get; set; }
        public Nullable<int> IntUserID { get; set; }
        public string VchProductName { get; set; }
        public string VchUserNick { get; set; }
        public string VchContent { get; set; }
        public Nullable<System.DateTime> DtDatetime { get; set; }
        public Nullable<System.DateTime> DtReplyDatetime { get; set; }
        public string VchReplyContent { get; set; }
        public Nullable<int> VchReplyPerson { get; set; }
        public Nullable<byte> IntIsPleased { get; set; }
        public Nullable<int> IntReferType { get; set; }
        public Nullable<byte> IntOtherIsVisible { get; set; }
        public Nullable<int> VchMemLevel { get; set; }
        public Nullable<int> IntCateID { get; set; }
    }
}
