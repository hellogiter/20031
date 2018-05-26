using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebPrizeBundleRefer :Pager
    {
        //WebPrizeBundleDetail
        private List<WebPrizeBundleDetail> _list;

        public List<WebPrizeBundleDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebPrizeBundleDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebPrizeBundleDetail _searchDetail;
        public WebPrizeBundleDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebPrizeBundleDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }


    }
}
