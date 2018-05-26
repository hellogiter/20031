using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class CouponBabyCoinRefer : Pager
    {
        private List<CouponBabyCoinDetail> _list;

        public List<CouponBabyCoinDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<CouponBabyCoinDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private CouponBabyCoinDetail _searchDetail;
        public CouponBabyCoinDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new CouponBabyCoinDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
