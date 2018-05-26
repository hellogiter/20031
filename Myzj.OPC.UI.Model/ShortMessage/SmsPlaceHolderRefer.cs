using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ShortMessage
{
   public class SmsPlaceHolderRefer:Pager
    {
       private SmsPlaceHolderModel _search;

        public SmsPlaceHolderModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new SmsPlaceHolderModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<SmsPlaceHolderModel> _list;

        public List<SmsPlaceHolderModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SmsPlaceHolderModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
