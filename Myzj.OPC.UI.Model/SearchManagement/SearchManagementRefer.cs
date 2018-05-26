using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.SearchManagement
{
    public class SearchManagementRefer : Pager
    {
	    public string SuccessMsg;
	    public string ErrorMsg;
        private List<SearchManagementDetail> _list;

        public List<SearchManagementDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SearchManagementDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private SearchManagementDetail _searchDetail;
        public SearchManagementDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new SearchManagementDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

	    private SearchManCheckDetail _searchManCheckDetail;
	    public SearchManCheckDetail SearchManCheckDetail
	    {
		    get
		    {
				if (_searchManCheckDetail == null)
                {
					_searchManCheckDetail = new SearchManCheckDetail();
                }
				return _searchManCheckDetail;
		    }
			set { _searchManCheckDetail = value; }
	    }


		private List<SearchManCheckDetail> _smcdlist;
		public List<SearchManCheckDetail> SearchList
		{
			get
			{
				if (_smcdlist == null)
				{
					_smcdlist = new List<SearchManCheckDetail>();
				}
				return _smcdlist;
			}
			set { _smcdlist = value; }
		}
		private List<SearchManagementItemDetail> _searchItemlist;
		public List<SearchManagementItemDetail> SearchItemList
		{
			get
			{
				if (_searchItemlist == null)
				{
					_searchItemlist = new List<SearchManagementItemDetail>();
				}

				return _searchItemlist;
			}
			set { _searchItemlist = value; }
		}

		private SearchManagementItemDetail _searchItemDetail;
		public SearchManagementItemDetail SearchItemDetail
		{
			get
			{
				if (_searchItemDetail == null)
				{
					_searchItemDetail = new SearchManagementItemDetail();
				}
				return _searchItemDetail;
			}
			set { _searchItemDetail = value; }
		}

    }
}
