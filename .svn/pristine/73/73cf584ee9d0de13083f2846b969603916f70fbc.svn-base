using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ShortMessage
{
    public class SmsBalanceRefer : Pager
    {
        private SmsBanlanceModel _search;

        public SmsBanlanceModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new SmsBanlanceModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<SmsBanlanceModel> _list;

        public List<SmsBanlanceModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SmsBanlanceModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
