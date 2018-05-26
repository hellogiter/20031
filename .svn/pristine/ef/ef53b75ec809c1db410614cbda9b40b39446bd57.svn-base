using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class CouponAuditRefer : Pager
    {
        private List<CouponAuditDetail> _list;

        public List<CouponAuditDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<CouponAuditDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<CouponAuditDetailExt> _list2;

        public List<CouponAuditDetailExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<CouponAuditDetailExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private CouponAuditDetail _searchDetail;
        public CouponAuditDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new CouponAuditDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private CouponAuditDetailExt _searchDetailExt;
        public CouponAuditDetailExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new CouponAuditDetailExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
