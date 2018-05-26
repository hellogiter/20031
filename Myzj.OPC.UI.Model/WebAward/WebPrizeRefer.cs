using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebPrizeRefer : Pager
    {
        private List<WebPrizeDetail> _list;

        public List<WebPrizeDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebPrizeDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebPrizeDetail _searchDetail;
        public WebPrizeDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebPrizeDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
