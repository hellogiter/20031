using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;
using Myzj.OPC.UI.Model.Base;

namespace Myzj.OPC.UI.Model.SpreadInfo
{
    public class SpreadInfoRefer : Pager
    {
        private List<SpreadInfoDetail> _list;

        public List<SpreadInfoDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SpreadInfoDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private SpreadInfoDetail _searchDetail;
        public SpreadInfoDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new SpreadInfoDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }



}
