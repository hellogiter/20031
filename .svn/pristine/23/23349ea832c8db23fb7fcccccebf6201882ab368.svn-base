using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class CountGoodsRefer
    {
        private List<CountGoodsDetailInfo> _list;

        public List<CountGoodsDetailInfo> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<CountGoodsDetailInfo>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<CountGoodsDetailInfoExt> _list2;

        public List<CountGoodsDetailInfoExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<CountGoodsDetailInfoExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private CountGoodsDetailInfo _searchDetail;
        public CountGoodsDetailInfo SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new CountGoodsDetailInfo();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private CountGoodsDetailInfoExt _searchDetailExt;
        public CountGoodsDetailInfoExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new CountGoodsDetailInfoExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
