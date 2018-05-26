using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.OrderProductState
{
    public class OrderProductStateRefer : Pager
    {
        private List<OrderProductStateDetail> _List;
        public List<OrderProductStateDetail> List
        {
            get
            {
                if (_List == null)
                {
                    _List = new List<OrderProductStateDetail>();
                }
                return _List;
            }
            set { _List = value; }
        }

        public Dictionary<string, object> Filters { get; set; }
        private OrderProductStateDetail _searchDetail;
        public OrderProductStateDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new OrderProductStateDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

    }
}
