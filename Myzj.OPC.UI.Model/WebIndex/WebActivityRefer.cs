using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebIndex
{
    public class WebActivityRefer : Pager
    {
        private List<WebActivityDetail> _list;
        public List<WebActivityDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebActivityDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebActivityDetail _searchDetail;
        public WebActivityDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebActivityDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
