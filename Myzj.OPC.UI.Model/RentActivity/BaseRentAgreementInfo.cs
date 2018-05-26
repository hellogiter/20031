using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.RentActivity
{
    public class BaseRentAgreementInfo
    {
        public Nullable<int> SysNo { get; set; }
        public string AgreementName { get; set; }
        public string AgreementContent { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    }
}
