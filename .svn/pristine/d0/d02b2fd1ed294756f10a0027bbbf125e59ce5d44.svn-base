// ***********************************************************************
// Copyright (c) 2016 holyca,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.Model.WordLibManage
// Author:holyca
// Created:2016/5/30 17:09:39
// Description:
// ***********************************************************************
// Last Modified By:HOLYCA20151208
// Last Modified On:2016/5/30 17:09:39
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.WordLibManage
{
    public class WordLibManageRefer : Pager
    {
        private List<WordLibManageDetail> _list;
        public List<WordLibManageDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<WordLibManageDetail>();
                }
                return _list;
            }
            set { _list = value; }
        }

        private List<ForbiddenTypeDetail> _fblist;
        public List<ForbiddenTypeDetail> FbList
        {
            get
            {
                if (_fblist == null)
                {
                    _fblist = new List<ForbiddenTypeDetail>();
                }
                return _fblist;
            }
            set { _fblist = value; }
        }

        public Dictionary<string,object> Filters { get; set; }

        public WordLibManageDetail _wordLibManageDetail;
        public ForbiddenTypeDetail _forbiddenTypeDetail;

        public WordLibManageDetail WordLibManageDetail
        {
            get
            {
                if (_wordLibManageDetail == null)
                {
                    _wordLibManageDetail=new WordLibManageDetail();
                }
                return _wordLibManageDetail;
            }
            set { _wordLibManageDetail = value; }
        }

        public ForbiddenTypeDetail ForbiddenTypeDetail
        {
            get
            {
                if (_forbiddenTypeDetail == null)
                {
                    _forbiddenTypeDetail = new ForbiddenTypeDetail();
                }
                return _forbiddenTypeDetail;
            }
            set { _forbiddenTypeDetail = value; }
        }

    }
}
