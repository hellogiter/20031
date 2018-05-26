using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
    public class ExpressOrderStatusRefer : Pager
    {
        private OrderStatusModel _search;

        public OrderStatusModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new OrderStatusModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<OrderStatusModel> _list;

        public List<OrderStatusModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<OrderStatusModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
