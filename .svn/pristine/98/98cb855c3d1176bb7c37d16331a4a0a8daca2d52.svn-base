using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.FloorConfig
{
    public class FloorLabelRefer : Pager
    {
        private List<FloorLabelDetail> _list;

        public List<FloorLabelDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<FloorLabelDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private FloorLabelDetail _searchDetail;
        public FloorLabelDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new FloorLabelDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
