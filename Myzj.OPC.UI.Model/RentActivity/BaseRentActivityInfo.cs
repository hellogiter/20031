using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.Model.RentActivity
{
    public class BaseRentActivityInfo
    {
        public Nullable<int> SysNo { get; set; }
        public string ActivityKey { get; set; }         //活动key
        public string ActivityName { get; set; }        //活动名称
        public Nullable<System.DateTime> StartTime { get; set; }//活动开始时间
        public Nullable<System.DateTime> EndTime { get; set; }//活动结束时间
        public Nullable<System.DateTime> PreStartTime { get; set; }//活动预约开始时间
        public Nullable<System.DateTime> PreEndTime { get; set; } //活动预约结束时间
        public string ActivityDes { get; set; }  //活动描述
        public string PromotionId { get; set; }  //关联促销
        public Nullable<int> GoodsTotalCount { get; set; }  // 活动商品总数量
        public string Remarks { get; set; }     //备注
        public Nullable<System.DateTime> RowCreateDate { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string ActivityJsonContent { get; set; }   //活动扩展字段

        public ActivityExtend Extend { get; set; }
    }

    public class ActivityExtend
    {
        /// <summary>
        /// 头图
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 活动内容图
        /// </summary>
        public string ActivityContentImgUrl { get; set; }
        /// <summary>
        /// 申请流程图
        /// </summary>
        public string ActivityProcessImgUrl { get; set; }
        /// <summary>
        /// 收回流程图
        /// </summary>
        public string RecycleProcessImgUrl { get; set; }

        /// <summary>
        /// 抢租回顾 晒单图
        /// </summary>
        public string ReviewImgUrlList { get; set; }

        /// <summary>
        /// 租赁答疑图
        /// </summary>
        public string QAndAImgUrl { get; set; }

    }
}
