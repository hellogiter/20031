using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.SearchManagement
{
    public class SearchManagementItemDetail
    {
		//public Nullable<int> SItemId { get; set; }
		//public Nullable<int> ProductId { get; set; }
		//public string vchProductName { get; set; }
		//public string SearchWord { get; set; }//修改后
		//public string ExcludeWord { get; set; }//修改后
		//public Nullable<int> UpdateBy { get; set; }//审核人
		//public Nullable<System.DateTime> UpdateDate { get; set; }//审核时间
		//public Nullable<int> SId { get; set; }
		//public Nullable<int> State { get; set; }//状态
		//public Nullable<System.DateTime> UpdateStartDate { get; set; }//开始时间
		//public Nullable<System.DateTime> UpdateEndDate { get; set; }//结束时间
		//public string UpSearchWord { get; set; }//修改后
		//public string UpExcludeWord { get; set; }//修改后
		//public string UpUpdate { get; set; }//审核人
		//public string UpUpDateBy { get; set; }//审核时间
		//public string TempProductId { get; set; }
		//public string beforeSearchwoes { get; set; }//修改前
		//public string beforeExcludeWord { get; set; }//修改前
		public int? ProductId { get; set; }
		public string SearchWord { get; set; }  //待审核词
		public string AuidtSearchWord { get; set; }  //原搜索词
		public string MixedToAuditSearchWord { get; set; }//现搜索词
		public int? State { get; set; }  
		public int? CheckId { get; set; }
		public string ProductName { get; set; }

    }

	public class AuditParam
	{
		public string CheckId { get; set; }
		public string ProductIds { get; set; }
		public string RefusedReason { get; set; }
	}
}
