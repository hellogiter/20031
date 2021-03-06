﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.ExpressModel
{
    public class ExpressInfoRefer : Pager
    {
        public Dictionary<string, object> Filters { get; set; }
        public string DoResult = "";
        private ExpressInfoSearchModel _search;
        public ExpressInfoSearchModel Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new ExpressInfoSearchModel();
                }
                return _search;
            }
            set { _search = value; }
        }

        private List<ExpressInfoModelExt> _list;
        public List<ExpressInfoModelExt> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<ExpressInfoModelExt>();
                }
                return _list;
            }
            set { _list = value; }
        }
    }
}
