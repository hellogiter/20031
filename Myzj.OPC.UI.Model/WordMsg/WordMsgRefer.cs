using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WordMsg
{
    public class WordMsgRefer : Pager
    {
        private List<WordMsgDetail> _list;
        public List<WordMsgDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WordMsgDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WordMsgDetail _searchDetail;
        public WordMsgDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WordMsgDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
