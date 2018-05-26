using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.SaleHotStyle
{
    public class SaleHotStyleApplyPlaceDetail
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> ApplyPlaceId { get; set; }
        public string ApplyPlaceName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
