using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.OrderProductState
{
    public class OrderProductStateDetail
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> MallType { get; set; }
        public Nullable<int> FlowStatus { get; set; }
        public string OrderStatusName { get; set; }
        public string OrderStatusDesc { get; set; }
        public Nullable<System.DateTime> OrderStatusTime { get; set; }
        public Nullable<int> WareHouse { get; set; }
        public string WarehouseName { get; set; }
        public Nullable<int> DisplayTime { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Remark { get; set; }
    }
}
