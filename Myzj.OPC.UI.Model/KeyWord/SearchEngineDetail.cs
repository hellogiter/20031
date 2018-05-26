using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.KeyWord
{
    public class SortProductDetail
    {
        public Nullable<int> Id { get; set; }
        public string KeyWord { get; set; }
        public bool? Enable { get; set; }
        public Nullable<int> CreateOperator { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public Nullable<int> LastOperator { get; set; }
        public Nullable<short> KeyWordType { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string ProductJson { get; set; } 
        public int? Usablestatus { get; set; }
        public bool? IsDelete { get; set; }
    }


    public class ProductJson
    {
        public int productid { get; set; }
        public int sortindex { get; set; }
    }


}
