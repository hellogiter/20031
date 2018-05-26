using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
    public class ExpressAcessConfigRefer : Pager
    {
        private SelfAccessConfigModel _search;

        public SelfAccessConfigModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new SelfAccessConfigModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<SelfAccessConfigModel> _list;

        public List<SelfAccessConfigModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SelfAccessConfigModel>();
                }
                return _list;
            }
            set { _list = value; }
        }

    }
}
