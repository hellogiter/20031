using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;
using Myzj.OPC.UI.Model.ExpressModel;

namespace Myzj.OPC.UI.Model.HotStyle
{
    public class HotStyleRefer : Pager
    {
        private HotStyleModel _search;
        public HotStyleModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new HotStyleModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<HotStyleModel> _list;
        public List<HotStyleModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<HotStyleModel>();
                }
                return _list;
            }
            set { _list = value; }
        }

    }
}
