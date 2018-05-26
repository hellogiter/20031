using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.UserPdtComment
{
    public class UserPdtCommentRefer : Pager
    {
        private List<UserPdtCommentDetail> _list;

        public List<UserPdtCommentDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<UserPdtCommentDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private UserPdtCommentDetail _searchDetail;
        public UserPdtCommentDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new UserPdtCommentDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
