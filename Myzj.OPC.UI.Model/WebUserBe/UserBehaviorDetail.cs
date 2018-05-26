using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebUserBe
{
    public class UserBehaviorDetail
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> ObjectType { get; set; }
        public Nullable<long> BegionIp { get; set; }
        public Nullable<long> EndIp { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string ShowMesage { get; set; }
        public Nullable<System.DateTime> LimitBegionTime { get; set; }
        public Nullable<System.DateTime> LimitEndTime { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public string CreateByName { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> IsEnable { get; set; }
        public string TempUserId { get; set; }
    }
}
