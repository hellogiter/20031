using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseDiscountCodeConfig
{
    public class DiscountCodeBatchReq
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> ActivitySysNo { get; set; }
        public string BatchFileName { get; set; }
        public Nullable<int> SetCodeLength { get; set; }
        public Nullable<int> CreateCodeNum { get; set; }
        public Nullable<System.DateTime> AdvanceTime { get; set; }
        public Nullable<int> ExeStatus { get; set; }
        public string ExeDescription { get; set; }
        public Nullable<int> ApplyUserId { get; set; }
        public string ApplyUserName { get; set; }
        public Nullable<System.DateTime> ApplyTime { get; set; }
        public Nullable<int> OperationType { get; set; }
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        public string ActivityKey { get; set; }
        public string ActivityName { get; set; }
   
    }

    public class DiscountCodeBatchRes
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> ActivitySysNo { get; set; }
        public string BatchFileName { get; set; }
        public Nullable<int> SetCodeLength { get; set; }
        /// <summary>
        /// 生成码数量
        /// </summary>
        public Nullable<int> CreateCodeNum { get; set; }
        public Nullable<System.DateTime> AdvanceTime { get; set; }
        public Nullable<int> ExeStatus { get; set; }
        public string ExeDescription { get; set; }
        public Nullable<int> ApplyUserId { get; set; }
        public string ApplyUserName { get; set; }
        public Nullable<System.DateTime> ApplyTime { get; set; }
        public Nullable<int> OperationType { get; set; }
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        public string ActivityKey { get; set; }
        public string ActivityName { get; set; }
        /// <summary>
        /// 生成码数量上限
        /// </summary>
        public int? SetCodeCount { get; set; }
        /// <summary>
        /// 已生成码数量
        /// </summary>
        public int? CreateCodeCount { get; set; }
        
    }
}
