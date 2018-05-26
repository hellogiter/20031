using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebUserBe
{
    public class UserBehaviorRefer : Pager
    {
        private List<UserBehaviorDetail> _list;
        public List<UserBehaviorDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<UserBehaviorDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private UserBehaviorDetail _searchDetail;
        public UserBehaviorDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new UserBehaviorDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
