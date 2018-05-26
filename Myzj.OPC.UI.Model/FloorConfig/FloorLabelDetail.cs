using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.FloorConfig
{
    public class FloorLabelDetail
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> FloorType { get; set; }
        public string FloorTypeName { get; set; }
        public string ConfigItemName { get; set; }
        public Nullable<int> FloorDetailID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductLink { get; set; }
        public string ProductPicture { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string ProductDiscription { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> ExpirationFrom { get; set; }
        public Nullable<System.DateTime> ExpirationEnd { get; set; }
    }
}
