using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ProductLabel
{
    public class ProductLabelRefer : Pager
    {
        private List<ProductLabelDetail> _list;

        public List<ProductLabelDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ProductLabelDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private ProductLabelDetail _searchDetail;
        public ProductLabelDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new ProductLabelDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
