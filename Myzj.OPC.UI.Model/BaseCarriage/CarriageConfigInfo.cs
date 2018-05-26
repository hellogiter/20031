﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BaseCarriage
{
    public class CarriageConfigInfo
    {
        public Nullable<int> SysNo { get; set; }
        public string ExecMethod { get; set; }
        public string Configure { get; set; }
        public string RuleName { get; set; }
        public string RuleDescribe { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    }

    public class BuyAppointGoodsCarriage
    {
        public List<BuyAppointGoodsParam> BuyAppointGoodsParams { get; set; }
    }
   
    public class BuyAppointGoodsParam
    {
        public int? SysNo { get; set; }
        public List<int?> Platforms { get; set; }
        public List<int?> GoodsIds { get; set; }
        public List<int?> PromIds { get; set; }
        public List<int?> ExcludePromIds { get; set; }
        public List<int?> AreaIds { get; set; }
        public List<int?> ExcludeAreaIds { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? FullCarriage { get; set; }
        public bool IsEnable { get; set; }
        public string Remark { get; set; }
        [System.Web.Script.Serialization.ScriptIgnore]
        public int? GoodsId { get; set; }
        [System.Web.Script.Serialization.ScriptIgnore]
        public int? AreaId { get; set; }
        [System.Web.Script.Serialization.ScriptIgnore]
        public int? IsEnableNum { get; set; }
    }
}
