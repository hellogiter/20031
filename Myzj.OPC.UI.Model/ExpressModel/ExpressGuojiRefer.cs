using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
    public class ExpressGuojiRefer : Pager
    {
        private InterNationalModel _search;
        public InterNationalModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new InterNationalModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<InterNationalModel> _list;
        public List<InterNationalModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<InterNationalModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
