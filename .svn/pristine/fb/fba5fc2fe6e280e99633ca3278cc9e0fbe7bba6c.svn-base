using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.CouponActivity
{
   public class CouponActivityConfigureRefer:Pager
    {
        public Dictionary<string, object> Filters { get; set; }
        private CouponActivityConfigureDetail _searchDetail;
        public CouponActivityConfigureDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new CouponActivityConfigureDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private List<CouponActivityConfigureDetail> _list;
        public List<CouponActivityConfigureDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<CouponActivityConfigureDetail>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
