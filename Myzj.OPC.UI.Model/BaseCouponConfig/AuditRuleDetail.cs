using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class AuditRuleDetail
    {
        public int? SysNo { get; set; }
        public string AuditLevelRuleName { get; set; }
        public string AuditLevelRule { get; set; }
        public int? AuditLevel { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? RowCreateDate { get; set; }
        public bool IsDelete { get; set; }
    }


    //规则
    public class AuditRules
    {
        public List<ParamRule> ParamRule { get; set; }
        public decimal? CheckMoeny { get; set; }
    }

    public class ParamRule
    {
        public decimal StartMoeny { get; set; }
        public decimal EndMoeny { get; set; }
        public int AuditLevel { get; set; }
    }
}
