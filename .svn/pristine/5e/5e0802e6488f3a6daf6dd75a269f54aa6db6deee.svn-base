using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;
using Myzj.OPC.UI.Model.ExpressModel;

namespace Myzj.OPC.UI.Model.HotStyle
{
    public class HotSubjectRefer : Pager
    {
        private HotSubjectModel _search;
        public HotSubjectModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new HotSubjectModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<HotSubjectModel> _list;
        public List<HotSubjectModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<HotSubjectModel>();
                }
                return _list;
            }
            set { _list = value; }
        }

    }
}
