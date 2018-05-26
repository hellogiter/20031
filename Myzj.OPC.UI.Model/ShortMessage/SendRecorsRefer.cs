using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ShortMessage
{
   public class SendRecorsRefer:Pager
    {
       private SendRecordsModel _search;

       public SendRecordsModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new SendRecordsModel();
                }
                return _search;
            }
            set { _search = value; }
        }

       private List<SendRecordsModel> _list;

       public List<SendRecordsModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SendRecordsModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
