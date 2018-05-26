using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.OrderProductState
{
    public class BaseWarehouseDetail
    {
        public Nullable<int> Id { get; set; }
        public string WarehouseName { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Createby { get; set; }
    }
}
