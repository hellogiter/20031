using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseCouponConfig
{
    public class AuditRoleDetail
    {
        public int? SysNo { get; set; }
        public int? AuditRole { get; set; }
        public string RoleName { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime RowCreateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
