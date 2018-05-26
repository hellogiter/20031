using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.SearchManagement
{
    //修改/批量修改(新增/批量新增)商品搜索词
    public class SearchManagementListBody
    {
        public List<SearchManagementBody> SearchList { get; set; }
    }

    public class SearchManagementBody
    {
        public string ProductId { get; set; }
        public string SearchWord { get; set; }
        public string ExcludeWord { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> State { get; set; }
    }

    // 批量审核商品搜索词
    public class ExamineSearch
    {
        public List<TempWebSearchManagementItem> SearchManagement { get; set; }
    }

    #region 批量审核商品搜索词审核
    public class TempWebSearchManagementItem
    {
        public Nullable<int> SItemId { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> UpdateBy { get; set; }//审核人
        public Nullable<System.DateTime> UpdateDate { get; set; }//审核时间
        public Nullable<int> CreateBy { get; set; }//创建人
        public Nullable<System.DateTime> CreateDate { get; set; }//创建时间
        public string SearchWord { get; set; }
        public string ExcludeWord { get; set; }
        public Nullable<int> ProductId { get; set; }

    }
    #endregion

    #region 修改/批量修改(新增/批量新增)
    public class TempSearchDetail
    {
        public Nullable<int> SId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string SearchWord { get; set; }
        public string ExcludeWord { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> State { get; set; }
        public string UpdateSearchWord { get; set; }
        public string UpdateExcludeWord { get; set; }
    }
    #endregion
}
