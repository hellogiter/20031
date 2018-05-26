using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.SaleHotStyle
{
    public class SaleHotStyleDetail
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string vchProductName { get; set; }
        public string ApplyPlace { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string HotDescription { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string PictureUrl { get; set; }
        public string HotTag { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<System.DateTime> TopBeginTime { get; set; }
        public Nullable<System.DateTime> TopEndTime { get; set; }
        public Nullable<short> IsTop { get; set; }

        public Nullable<int> isExpire { get; set; }
    }
}
