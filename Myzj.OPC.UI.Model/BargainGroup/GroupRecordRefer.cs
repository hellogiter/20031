using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class GroupRecordRefer:Pager
    {
        private List<GroupRecordDetail> _list;

        public List<GroupRecordDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<GroupRecordDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<GroupRecordDetailExt> _list2;

        public List<GroupRecordDetailExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<GroupRecordDetailExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private GroupRecordDetail _searchDetail;
        public GroupRecordDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new GroupRecordDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private GroupRecordDetailExt _searchDetailExt;
        public GroupRecordDetailExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new GroupRecordDetailExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
