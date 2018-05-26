using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.WebAward
{
    public class WebLotteryNumberRefer
    {
        private List<WebLotteryNumberDetail> _list;

        public List<WebLotteryNumberDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebLotteryNumberDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebLotteryNumberDetail _searchDetail;
        public WebLotteryNumberDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebLotteryNumberDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
