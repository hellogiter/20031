using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.FloorConfig
{
    public class FloorConfigDetail
    {
        public Nullable<int> SysNo { get; set; }
        public string FloorType { get; set; }
        public string FloorTypeName { get; set; }
        public int TempFloorType { get; set; }
        public string FloorName { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string FloorKeyName { get; set; }
        public string FloorKeyValue { get; set; }
        public string FloorDiscription { get; set; }
        public string FloorLink { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> ExpirationFrom { get; set; }
        public Nullable<System.DateTime> ExpirationEnd { get; set; }
        public Nullable<int> Createby { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
