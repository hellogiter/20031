using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.UserPdtComment
{

    #region 批量修改
    public class UserPdtCommentBody
    {
        public List<TempComment> TempCommentDos { get; set; }
    }
    #endregion


    #region 批量新增
    public class AddPLPLUserPdtComment
    {
        public List<UserPdtCommentDetail> AddCommentDos { get; set; }
    }
    #endregion

    #region 临时修改模型
    //临时修改模型
    public class TempComment
    {
        public int IntCommentID { get; set; }//编号
        public Nullable<int> IntIsOnTop { get; set; }//是否置顶
        public Nullable<int> IntIsHighLight { get; set; }//是否精华
        public string VchReplyContent { get; set; }//回复评论内容
        public Nullable<int> IntIsMask { get; set; }//是否显示
        public Nullable<int> IntIndexVisible { get; set; }//是否首页显示
        public Nullable<int> IntAuditState { get; set; }//审核状态
        public Nullable<int> IntAuditUserID { get; set; }//审核人
        public Nullable<System.DateTime> DtAuditDate { get; set; }//审核时间
        public Nullable<System.DateTime> DtReplyDateTime { get; set; }//回复时间
        public Nullable<int> IntReplyUserId { get; set; }//回复评论人
    }
    #endregion


}
