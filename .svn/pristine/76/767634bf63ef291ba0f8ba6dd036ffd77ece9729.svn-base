using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.UserPdtComment
{
    public class UserPdtCommentCusReplyRefer:Pager
    {
        //UserPdtCommentCusReplyDetail
        private List<UserPdtCommentCusReplyDetail> _list;

        public List<UserPdtCommentCusReplyDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<UserPdtCommentCusReplyDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private UserPdtCommentCusReplyDetail _searchDetail;
        public UserPdtCommentCusReplyDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new UserPdtCommentCusReplyDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
