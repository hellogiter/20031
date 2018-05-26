using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.SaleHotStyleSpecialSubject
{
    public class SaleHotStyleSpecialSubjectDetail
    {
        public Nullable<int> Id { get; set; }
        public string SubjectName { get; set; }
        public string SujectDesc { get; set; }
        public string ApplyPlace { get; set; }
        public string PictureUrl { get; set; }
        public string ClickUrl { get; set; }
        public string SetDiscount { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> Sort { get; set; }
        public string AppClickUrl { get; set; }
        public Nullable<System.DateTime> TopBeginTime { get; set; }
        public Nullable<System.DateTime> TopEndTime { get; set; }
        public Nullable<short> IsTop { get; set; }
        public Nullable<short> isExpire { get; set; }  //活动是否过期
    }
}
