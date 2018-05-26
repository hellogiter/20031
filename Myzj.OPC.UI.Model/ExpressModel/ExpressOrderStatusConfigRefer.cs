using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
  public  class ExpressOrderStatusConfigRefer:Pager
    {
      private OrderStatusConfigModel _search;
      public OrderStatusConfigModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new OrderStatusConfigModel();
                }
                return _search;
            }
            set { _search = value; }
        }

      private List<OrderStatusConfigModel> _list;
      public List<OrderStatusConfigModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<OrderStatusConfigModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
