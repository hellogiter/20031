using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.KeyWord
{
    public class SortProductRefer : Pager
    {
        private List<SortProductDetail> _list;

        public List<SortProductDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SortProductDetail>();
                }
                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }
        public SortProductDetail _sortProductDetail;

        public SortProductDetail SortProductDetail
        {
            get
            {
                if (_sortProductDetail == null)
                {
                    _sortProductDetail = new SortProductDetail();
                }
                return _sortProductDetail;
            }
            set { _sortProductDetail = value; }
        }
    }
    }
