using MYZJ.OPC.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class SendCouponRecordRefer:Pager
    {
        private List<SendCouponRecordDetail> _list;

        public List<SendCouponRecordDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SendCouponRecordDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        private List<SendCouponRecordDetailExt> _list2;

        public List<SendCouponRecordDetailExt> List2
        {
            get
            {
                if (_list2 == null)
                {
                    _list2 = new List<SendCouponRecordDetailExt>();
                }

                return _list2;
            }
            set { _list2 = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private SendCouponRecordDetail _searchDetail;
        public SendCouponRecordDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new SendCouponRecordDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }

        private SendCouponRecordDetailExt _searchDetailExt;
        public SendCouponRecordDetailExt SearchDetailExt
        {
            get
            {
                if (_searchDetailExt == null)
                {
                    _searchDetailExt = new SendCouponRecordDetailExt();
                }
                return _searchDetailExt;
            }
            set { _searchDetailExt = value; }
        }
    }
}
