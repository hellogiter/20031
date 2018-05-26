using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebPrizeModelRefer:Pager
    {
        private List<WebPrizeModelDetail> _list;

        public List<WebPrizeModelDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebPrizeModelDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebPrizeModelDetail _searchDetail;
        public WebPrizeModelDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebPrizeModelDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
