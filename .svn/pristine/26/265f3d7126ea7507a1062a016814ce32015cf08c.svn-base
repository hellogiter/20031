using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ShortMessage
{
    public class TemplateListRefer : Pager
    {
        private TemplateModel _search;

        public TemplateModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new TemplateModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<TemplateModel> _list;

        public List<TemplateModel> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<TemplateModel>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
