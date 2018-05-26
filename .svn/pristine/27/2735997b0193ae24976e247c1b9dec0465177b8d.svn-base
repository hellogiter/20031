using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class CouponInfoDtailRefer : Pager
    {
        private List<CouponInfoDetail> _list;

        public List<CouponInfoDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<CouponInfoDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<CouponInfoDetailExt> _list2;

        public List<CouponInfoDetailExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<CouponInfoDetailExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private CouponInfoDetail _searchDetail;
        public CouponInfoDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new CouponInfoDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private CouponInfoDetailExt _searchDetailExt;
        public CouponInfoDetailExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new CouponInfoDetailExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
