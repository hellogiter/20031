using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.BargainGroup
{
    public class GroupRecordDetail
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> GroupActivitySysNo { get; set; }
        public Nullable<int> GroupGoodsSysNo { get; set; }
        public Nullable<int> GroupStructureSysNo { get; set; }
        public Nullable<int> UserId { get; set; }
        public string NickName { get; set; }
        public string HeadPicUrl { get; set; }
        public string UserEmail { get; set; }
        public string UserMobile { get; set; }
        public string PromSysNos { get; set; }
        public Nullable<bool> IsReceive { get; set; }
        public string UserGuid { get; set; }
        public string ClientIp { get; set; }
        public string SourceTypeSysNo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        public int? GoodsId { get; set; }
        public string GoodsName { get; set; }
       
    }


    public class GroupRecordDetailExt
    {
        //记录Sysno
        public Nullable<int> SysNo { get; set; }
        //会员id
        public Nullable<int> UserId { get; set; }
        //会员手机
        public string UserMobile { get; set; }
        public string NickName { get; set; }
        //是否领取
        public Nullable<bool> IsReceive { get; set; }
        public string ClientIp { get; set; }
        //参团日期
        public Nullable<System.DateTime> CreateTime { get; set; }
        //活动Sysno
        public Nullable<int> GroupActivitySysNo { get; set; }
        //商品SysNo
        public Nullable<int> GroupGoodsSysNo { get; set; }
        //商品id
        public int? GoodsId { get; set; }
        //商品名
        public string GoodsName { get; set; }
        //团Sysno
        public Nullable<int> GroupStructureSysNo { get; set; }
        //团长会员Id
        public Nullable<int> GroupHeadId { get; set; }
        //团长是否面单
        public Nullable<bool> GroupIsPayFree { get; set; }
        //团是否有效
        public Nullable<bool> GroupIsDeleted { get; set; }
        //团创建时间
        public Nullable<System.DateTime> GroupCreateDate { get; set; }
    }
}
