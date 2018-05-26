using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.HotStyle
{
    public class HotStyleModel
    {
        /// <summary>
        /// 返回的总数
        /// </summary>
        public int? cnt { get; set; }

        public int? Id { get; set; }

        public int? ProductId { get; set; }

        public string ProductName { get; set; }

        public string ApplyPlace { get; set; }

        public string ApplyLabel { get; set; }

        public System.DateTime? StartTime { get; set; }

        public System.DateTime? EndTime { get; set; }

        public string PictureUrl { get; set; }
        public string PictureUrlTrans { get; set; }    //app过渡商品图片

        public string HotDescription { get; set; }

        public bool? IsEnable { get; set; }
        public int? QueryIsEnable { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CreateBy { get; set; }

        public System.DateTime CreateDate { get; set; }

        public System.Nullable<int> UpdateBy { get; set; }

        public System.Nullable<System.DateTime> UpdateDate { get; set; }

        public string HotTag { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string CountryName { get; set; }
        public Nullable<int> Sort { get; set; }
        public System.Nullable<System.DateTime> TopBeginTime { get; set; }
        public System.Nullable<System.DateTime> TopEndTime { get; set; }
        public short? IsTop { get; set; }

        public string ExpireDesc { get; set; }
        public int? IsExpire { get; set; }
    }
}
