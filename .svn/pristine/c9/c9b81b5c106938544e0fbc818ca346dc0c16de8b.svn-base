using MYZJ.OPC.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class GroupGoodsRefer:Pager
    {
        private List<GroupGoodsDetail> _list;

        public List<GroupGoodsDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<GroupGoodsDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<GroupGoodsDetailExt> _list2;

        public List<GroupGoodsDetailExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<GroupGoodsDetailExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private GroupGoodsDetail _searchDetail;
        public GroupGoodsDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new GroupGoodsDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private GroupGoodsDetailExt _searchDetailExt;
        public GroupGoodsDetailExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new GroupGoodsDetailExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
