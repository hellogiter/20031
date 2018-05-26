using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.FloorConfig
{
    public class FloorConfigRefer : Pager
    {
        private List<FloorConfigDetail> _list;

        public List<FloorConfigDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<FloorConfigDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private FloorConfigDetail _searchDetail;
        public FloorConfigDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new FloorConfigDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
