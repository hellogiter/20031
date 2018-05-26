using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ShortMessage
{
   public class BlackListRefer:Pager
    {
       private BlackListModel _search;

       public BlackListModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new BlackListModel();
                }
                return _search;
            }
            set { _search = value; }
        }

       private List<BlackListModel> _list;

       public List<BlackListModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<BlackListModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
