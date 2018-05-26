using System;
using System.Collections.Generic;
using MYZJ.OPC.UI.Model;
using Myzj.OPC.UI.Model.Base;

namespace Myzj.OPC.UI.Model.SpreadInfo
{

    #region 推广点列表
    public class SpreadInfoDetail
    {
        public int SpreadId { get; set; }
        public string SpreadKey { get; set; }
        public AppEnum.SpreadType SpreadType { get; set; }
        public DateTime CreateTime { get; set; }
        public AppEnum.SpreadSite Site { get; set; }
        public AppEnum.SpreadState Status { get; set; }
        public bool IsDelete { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public string UserName { get; set; }//推广点名称/归属名称

    }
    #endregion

    #region 创建推广用户信息
    public class CreateSpreadUser
    {
        public Nullable<int> SpreadId { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public int ActivityId { get; set; }

        public int ParentUserId { get; set; }

        public string Remark { get; set; }

        public AppEnum.SpreadState Status { get; set; }

        public int CreateUserId { get; set; }

        public bool SpreadEnable { get; set; }

        public AppEnum.SpreadType SpreadType { get; set; }
        public int Type { get; set; }
    }
    #endregion

    #region 归属地列表
    public class SpreadUserDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        //public string Phone { get; set; }
        public int ParentUserId { get; set; }
    }

    #endregion

    #region 获取所有启用中活动列表
    public class Activity
    {
        public Dictionary<int, string> Data { get; set; }
    }
    #endregion

    #region  获取活动列表页
    public class SpreadActivityRefer : Pager
    {
        private List<SpreadActivity> _list;

        public List<SpreadActivity> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<SpreadActivity>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private SpreadActivity _searchDetail;
        public SpreadActivity SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new SpreadActivity();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }

    public class SpreadActivity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityPic { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<int> LimitNumber { get; set; }
        public AppEnum.ActivityStatus Status { get; set; }
        public string NecessaryInfoJson { get; set; }
        public string ShareInfoJson { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool EnableOldUser { get; set; }
        public bool IsDelete { get; set; }
        public string BackGroundPhotoUrl { get; set; }
        public string Remark { get; set; }
        public string RoleDetail { get; set; }
        public PhotoJson Photo { get; set; }
    }

    /// <summary>
    /// 分享信息
    /// </summary>
    public class ShareInfo
    {
        public string Title { get; set; }
        public string SharePic { get; set; }
        public string Describition { get; set; }
        public string Successtips { get; set; }
        public int MsgId { get; set; }
    }

    /// <summary>
    /// 推广需要的信息
    /// </summary>
    public class NecessaryInfoJson
    {
        public string Phone { get; set; }
        public string BirthdayTime { get; set; }
        public string Logo { get; set; }
        public string Prize { get; set; }
        public string Modular { get; set; }//活动模块
    }

    public class BackGroundData
    {
        public string HeadImg { get; set; }
        public string BackImg { get; set; }
        public string FootImg { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
    }

    #endregion

    #region 创建活动
    public class AddSpreadActivity
    {
        public Nullable<int> ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityPic { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> LimitNumber { get; set; }
        public AppEnum.ActivityStatus Status { get; set; }
        public string NecessaryInfoJson { get; set; }
        public string ShareInfoJson { get; set; }
        public Nullable<int> CreateByUserId { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public bool EnableOldUser { get; set; }
        public bool IsDelete { get; set; }
        public string BackGroundPhotoUrl { get; set; }
        public string Remark { get; set; }
        public string RoleDetail { get; set; }
        public short ActivitySite { get; set; }
        public List<TempActivityPrize> PrizeList { get; set; }//奖品
        public string PrizeId { get; set; }//抵扣卷ID
        public string CouponId { get; set; }//优惠劵ID
        public List<SpreadActivityPrize> ActivityPrize { get; set; }



        public NecessaryInfoJson NecessaryData { get; set; }
        public ShareInfo ShareData { get; set; }
        public PhotoJson Photo { get; set; }
        public bool EnableAndroid
        {
            get { return (ActivitySite & (short)AppEnum.ActivitySite.Andriod) == (short)AppEnum.ActivitySite.Andriod; }
        }

        public bool EnableIos
        {
            get { return (ActivitySite & (short)AppEnum.ActivitySite.Ios) == (short)AppEnum.ActivitySite.Ios; }
        }
        public bool EnableWeb
        {
            get { return (ActivitySite & (short)AppEnum.ActivitySite.WebSite) == (short)AppEnum.ActivitySite.WebSite; }
        }

        public bool EnableWap
        {
            get { return (ActivitySite & (short)AppEnum.ActivitySite.Wap) == (short)AppEnum.ActivitySite.Wap; }
        }

        public bool EnableIpad
        {
            get { return (ActivitySite & (short)AppEnum.ActivitySite.Ipad) == (short)AppEnum.ActivitySite.Ipad; }
        }
    }
    public class PhotoJson
    {
        public string HeadImg { get; set; }

        public string BackImg { get; set; }

        public string FootImg { get; set; }
    }
    public class TempActivityPrize
    {
        public string PrizeIdentity { get; set; }

        public short PrizeType { get; set; }
    }
    public class SpreadActivityPrize
    {
        public int ActivityId { get; set; }
        public string PrizeIdentity { get; set; }
        public AppEnum.PrizeType PrizeType { get; set; }
        public DateTime CreateTime { get; set; }
    }
    #endregion

    #region 获取用户信息通过第三方标识
    public class GetUserByUnionIdentity
    {
        public string Identity { get; set; }

        public AppEnum.SpreadUnionIdentityType IdentityType { get; set; }
    }

    public class ResultUserByUnionIdentity : BaseResponse
    {
        public UserInfoDetail UserInfo { get; set; }

        public SpreadUserRoleDetail RoleInfo { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfoDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public string Password { get; set; }
        public int ParentUserId { get; set; }
        public AppEnum.UserStatus UserStatus { get; set; }
        public int RoleId { get; set; }
    }
    public class SpreadUserRoleDetail
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public AppEnum.RoleLevel RoleLevel { get; set; }
    }
    #endregion

    #region 地推注册/提交数据统计

    public class SpreadBaseRefer : Pager
    {
        public DateTime? StartTime { get; set; }

        public DateTime? EndtTime { get; set; }

        public int? RegionId { get; set; }

        public int? SpreadId { get; set; }

        public List<SpreadBase> List { get; set; }
    }

    public class SpreadBase
    {
        public int? Total { get; set; }
        public int? SubmitCount { get; set; }
        public int? RegisterCount { get; set; }
        public DateTime? QueryTime { get; set; }

    }
    #endregion

    #region 未注册用户数据

    public class UnRegisterUserRefer : Pager
    {
        private List<UnRegisterUserDetail> _list;

        public List<UnRegisterUserDetail> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<UnRegisterUserDetail>();
                }

                return _list;
            }
            set { _list = value; }
        }

        public Dictionary<string, object> Filters { get; set; }

        private UnRegisterUserDetail _searchDetail;
        public UnRegisterUserDetail SearchDetail
        {
            get
            {
                if (_searchDetail == null)
                {
                    _searchDetail = new UnRegisterUserDetail();
                }
                return _searchDetail;
            }
            set { _searchDetail = value; }
        }
    }

    public class UnRegisterUserDetail
    {
        public string Phone { get; set; }
        public string BirthDay { get; set; }
        public string ActivityName { get; set; }
        public string SpreadUserName { get; set; }
        public DateTime SubmitTime { get; set; }
    }
    #endregion

}
