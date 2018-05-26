using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebAwardUserTagsRefer :Pager
    {
        private List<WebAwardUserTagsDetail> _list;

        public List<WebAwardUserTagsDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebAwardUserTagsDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebAwardUserTagsDetail _searchDetail;
        public WebAwardUserTagsDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebAwardUserTagsDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
