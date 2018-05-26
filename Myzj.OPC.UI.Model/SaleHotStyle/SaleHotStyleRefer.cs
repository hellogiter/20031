using System.Collections.Generic;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.SaleHotStyle
{
    public class SaleHotStyleRefer : Pager
    {
        private List<SaleHotStyleDetail> _list;

        public List<SaleHotStyleDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SaleHotStyleDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private SaleHotStyleDetail _searchDetail;
        public SaleHotStyleDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new SaleHotStyleDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
