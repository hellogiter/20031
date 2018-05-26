using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebPrizeItemRefer:Pager
    {
        private List<WebPrizeItemDetail> _list;

        public List<WebPrizeItemDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebPrizeItemDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebPrizeItemDetail _searchDetail;
        public WebPrizeItemDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebPrizeItemDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
