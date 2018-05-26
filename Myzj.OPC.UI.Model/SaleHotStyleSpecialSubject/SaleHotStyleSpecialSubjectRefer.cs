﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.SaleHotStyleSpecialSubject
{
    public class SaleHotStyleSpecialSubjectRefer : Pager
    {
        private List<SaleHotStyleSpecialSubjectDetail> _list;

        public List<SaleHotStyleSpecialSubjectDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SaleHotStyleSpecialSubjectDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private SaleHotStyleSpecialSubjectDetail _searchDetail;
        public SaleHotStyleSpecialSubjectDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new SaleHotStyleSpecialSubjectDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }
}
