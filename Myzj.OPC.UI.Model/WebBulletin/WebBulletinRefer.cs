using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WebBulletin
{
    public class WebBulletinRefer : Pager
    {
        private List<WebBulletinDetail> _list;

        public List<WebBulletinDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WebBulletinDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private WebBulletinDetail _searchDetail;
        public WebBulletinDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new WebBulletinDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
