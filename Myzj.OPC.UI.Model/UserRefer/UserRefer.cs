using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.UserRefer
{
    public class UserRefer : Pager
    {
        private List<UserReferDetail> _list;

        public List<UserReferDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<UserReferDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private UserReferDetail _searchDetail;
        public UserReferDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new UserReferDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }

    public class GetUserRefer : Pager
    {
        public Nullable<int> IntProductID { get; set; }//商品id
        public string IntUserID { get; set; }//用户Id
        public string VchContent { get; set; }//咨询内容
        public Nullable<System.DateTime> DtDatetime { get; set; }//咨询开始时间
        public Nullable<System.DateTime> DtEndDatetime { get; set; }//咨询结束时间
        public Nullable<int> ReplyStatus { get; set; }//是否回复   //0.未回复  1.回复
        public List<UserReferDetail> List { get; set; }// 投诉列表
    }
}
