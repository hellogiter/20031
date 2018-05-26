using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.OPC.UI.Model;

namespace Myzj.OPC.UI.Model.UserPdtComment
{
    public class UserPdtCommentCusReplyDetail
    {
        public Nullable<int> CusReply { get; set; }
        public Nullable<int> OrderNO { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CommentId { get; set; }
        public string CusReplyContent { get; set; }
        public Nullable<System.DateTime> CusReplyDateTime { get; set; }
        public Nullable<int> IsMask { get; set; }
        public Nullable<int> AuditState { get; set; }
        public Nullable<int> AuditUserID { get; set; }
        public Nullable<System.DateTime> AuditDateTime { get; set; }
        public string Remark { get; set; }
    }
}
