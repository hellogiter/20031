using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.UserRefer
{
    [Serializable]
    public class UserReferBody
    {
        public UserReferDetail UserRefer { get; set; }
    }

    public class UserReferByProduct
    {
        public IEnumerable<UserReferDetail> UserReferDos { get; set; }
    }

    #region 导出条件

    public class ExportExeclModel : Pager
    {
        public Nullable<int> IntProductID { get; set; }//商品id
        public string IntUserID { get; set; }//用户Id
        public string VchContent { get; set; }//咨询内容
        public Nullable<System.DateTime> DtDatetime { get; set; }//咨询开始时间
        public Nullable<System.DateTime> DtEndDatetime { get; set; }//咨询结束时间
        public Nullable<int> ReplyStatus { get; set; }//是否回复   //0.未回复  1.回复
    }

    #endregion






}
