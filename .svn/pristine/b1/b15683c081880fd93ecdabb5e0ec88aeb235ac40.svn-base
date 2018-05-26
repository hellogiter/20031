using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebAwardRecordRefer :Pager
    {
        private List<WebAwardRecordDetail> _list;

        public List<WebAwardRecordDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebAwardRecordDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebAwardRecordDetail _searchDetail;
        public WebAwardRecordDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebAwardRecordDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
