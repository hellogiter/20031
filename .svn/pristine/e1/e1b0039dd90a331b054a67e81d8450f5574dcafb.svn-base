using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ShortMessage
{
   public class WhiteListRefer : Pager
    {
       private WhiteListModel _search;

       public WhiteListModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new WhiteListModel();
                }
                return _search;
            }
            set { _search = value; }
        }

       private List<WhiteListModel> _list;

       public List<WhiteListModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WhiteListModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
