﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.CommentsManage
{
	public class CommentsManageRefer : Pager
    {
	    public string SuccessMsg;
	    public string ErrorMsg;
		private List<VipCommentProductDetail> _list;

		public List<VipCommentProductDetail> List
        {
            get
            {
                if (_list == null)
                {
					_list = new List<VipCommentProductDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

		private VipCommentProductDetail _commnetDetail;
		public VipCommentProductDetail CommentDetail
        {
            get
            {
				if (_commnetDetail == null)
                {
					_commnetDetail = new VipCommentProductDetail();
                }
				return _commnetDetail;
            }
			set { _commnetDetail = value; }
        }

		//private SearchManCheckDetail _searchManCheckDetail;
		//public SearchManCheckDetail SearchManCheckDetail
		//{
		//	get
		//	{
		//		if (_searchManCheckDetail == null)
		//		{
		//			_searchManCheckDetail = new SearchManCheckDetail();
		//		}
		//		return _searchManCheckDetail;
		//	}
		//	set { _searchManCheckDetail = value; }
		//}


		//private List<SearchManCheckDetail> _smcdlist;
		//public List<SearchManCheckDetail> SearchList
		//{
		//	get
		//	{
		//		if (_smcdlist == null)
		//		{
		//			_smcdlist = new List<SearchManCheckDetail>();
		//		}
		//		return _smcdlist;
		//	}
		//	set { _smcdlist = value; }
		//}
		//private List<SearchManagementItemDetail> _searchItemlist;
		//public List<SearchManagementItemDetail> SearchItemList
		//{
		//	get
		//	{
		//		if (_searchItemlist == null)
		//		{
		//			_searchItemlist = new List<SearchManagementItemDetail>();
		//		}

		//		return _searchItemlist;
		//	}
		//	set { _searchItemlist = value; }
		//}

		//private SearchManagementItemDetail _searchItemDetail;
		//public SearchManagementItemDetail SearchItemDetail
		//{
		//	get
		//	{
		//		if (_searchItemDetail == null)
		//		{
		//			_searchItemDetail = new SearchManagementItemDetail();
		//		}
		//		return _searchItemDetail;
		//	}
		//	set { _searchItemDetail = value; }
		//}

    }
}
