using MYZJ.OPC.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class GroupActivityRefer:Pager
    {
        private List<GroupActivityDetail> _list;

        public List<GroupActivityDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<GroupActivityDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<GroupActivityDetailExt> _list2;

        public List<GroupActivityDetailExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<GroupActivityDetailExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private GroupActivityDetail _searchDetail;
        public GroupActivityDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new GroupActivityDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private GroupActivityDetailExt _searchDetailExt;
        public GroupActivityDetailExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new GroupActivityDetailExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
