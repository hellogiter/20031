using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebAwardRefer : Pager
    {
        private List<WebAwardDetail> _list;

        public List<WebAwardDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebAwardDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebAwardDetail _searchDetail;
        public WebAwardDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebAwardDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
