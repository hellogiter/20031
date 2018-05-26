using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.MKMS.ServiceModel;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.SpreadInfo;

namespace Myzj.OPC.UI.ServiceClient
{
    public class SpreadInfoClient : BaseService
    {
        private SpreadInfoClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static SpreadInfoClient _instance;
        public static SpreadInfoClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SpreadInfoClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 推广信息列表
        /// <summary>
        /// 推广信息列表
        /// </summary>
        /// <param name="spreadInfo"></param>
        /// <returns></returns>
        public SpreadInfoRefer QuertSpreadInfo(SpreadInfoRefer spreadInfo)
        {
            var result = new SpreadInfoRefer();
            var req = new GetSpreadInfoListRequest();

            if (spreadInfo.SearchDetail != null)
            {
                req.UserId = spreadInfo.SearchDetail.UserId;
                req.UserName = spreadInfo.SearchDetail.UserName;
            }
            req.PageIndex = spreadInfo.PageIndex;
            req.PageSize = spreadInfo.PageSize;

            var res = MKMSClient.Send<GetSpreadInfoListResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<SpreadExt, SpreadInfoDetail>(res.SpreadDos);
                result.Total = res.Total;
            }
            result.SearchDetail = spreadInfo.SearchDetail;
            result.PageIndex = spreadInfo.PageIndex;
            result.PageSize = spreadInfo.PageSize;

            return result;
        }
        #endregion

        #region 获取归属地列表
        /// <summary>
        /// 获取归属地列表
        /// </summary>
        /// <returns></returns>
        public List<SpreadUserDetail> QueryRegionList()
        {
            var result = new List<SpreadUserDetail>();
            var req = new GetRegionListRequest();

            var res = MKMSClient.Send<GetRegionListResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.MappGereric<Spread_UserExt, SpreadUserDetail>(res.SpreadUserDos);
            }
            return result;
        }
        #endregion

        #region 修改推广信息
        /// <summary>
        /// 修改推广信息
        /// </summary>
        /// <param name="spreadUser"></param>
        /// <returns></returns>
        public bool UpdateSpreadInfo(CreateSpreadUser spreadUser)
        {
            var req = Mapper.Map<CreateSpreadUser, UpdateSpreadInfoByKeyRequest>(spreadUser);
            var res = MKMSClient.Send<UpdateSpreadInfoByKeyResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改推广信息状态
        /// <summary>
        /// 修改推广信息状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateSpreadInfoState(int id, string state)
        {
            var req = new UpdateSpreadInfoByKeyStateRequest();
            req.SpreadId = id;

            if (state == AppEnum.SpreadState.Normal.ToString())
            {
                req.Status = 1;
            }
            else if (state == AppEnum.SpreadState.Disable.ToString())
            {
                req.Status = 2;
            }
            else if (state == AppEnum.SpreadState.Scrap.ToString())
            {
                req.Status = 3;
            }
            var res = MKMSClient.Send<UpdateSpreadInfoByKeyStateResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 获取活动列表
        /// <summary>
        /// 获取活动列表
        /// </summary>
        /// <returns></returns>
        public Activity QueryAllActivity()
        {
            var result = new Activity();
            var req = new GetAllActivityRequest();
            var res = MKMSClient.Send<GetAllActivityResponse>(req);
            if (res.DoFlag)
            {
                result.Data = res.Data;
            }
            return result;
        }
        #endregion

        #region 创建推广点/推广人员信息
        /// <summary>
        /// 创建推广点/推广人员信息
        /// </summary>
        /// <returns></returns>
        public bool CreateSpreadUser(CreateSpreadUser spreadUser)
        {
            var req = Mapper.Map<CreateSpreadUser, CreateSpreadUserRequest>(spreadUser);
            var res = MKMSClient.Send<CreateSpreadUserReponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 创建归属地
        /// <summary>
        /// 创建归属地
        /// </summary>
        /// <param name="spreadUser"></param>
        /// <returns></returns>
        public bool CreateRegionUser(CreateSpreadUser spreadUser)
        {
            var req = Mapper.Map<CreateSpreadUser, CreateRegionUserRequest>(spreadUser);
            var res = MKMSClient.Send<CreateRegionUserReponse>(req);
            return res.DoFlag;
        }

        #endregion

        //***************************************************************************

        #region 推广活动列表
        /// <summary>
        /// 推广活动列表
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public SpreadActivityRefer QueryActivityListByPage(SpreadActivityRefer activity)
        {
            var result = new SpreadActivityRefer();
            var req = new ActivityListByPageRequest();
            req.PageIndex = activity.PageIndex;
            req.PageSize = activity.PageSize;

            var res = MKMSClient.Send<ActivityListByPageResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Spread_ActivityExt, SpreadActivity>(res.Data);
                result.Total = res.Sum;
            }

            result.SearchDetail = activity.SearchDetail;
            result.PageIndex = activity.PageIndex;
            result.PageSize = activity.PageSize;

            return result;
        }
        #endregion

        #region 查询活动详情
        /// <summary>
        /// 查询活动详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AddSpreadActivity QuerySpreadActivityById(int id)
        {
            var result = new AddSpreadActivity();
            var req = new QuerySpreadActivityByIdRequest();
            req.ActivityId = id;

            var res = MKMSClient.Send<QuerySpreadActivityByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Spread_ActivityExt, AddSpreadActivity>(res.ActivityDos);
                result.ActivityPrize = Mapper.MappGereric<Spread_Activity_PrizeExt, SpreadActivityPrize>(res.ActivityPrize);
            }
            return result;
        }
        #endregion

        #region 创建推广活动
        /// <summary>
        /// 创建推广活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool AddSpreadActivity(AddSpreadActivity activity)
        {
            var req = Mapper.Map<AddSpreadActivity, AddSpreadActivityRequest>(activity);

            req.PrizeList = new List<ActivityPrize>();

            int codeLeg = 0;
            int couponleg = 0;
            if (!string.IsNullOrEmpty(activity.PrizeId))
            {
                codeLeg = activity.PrizeId.Length;
            }
            if (!string.IsNullOrEmpty(activity.CouponId))
            {
                couponleg = activity.CouponId.Length;
            }


            var pPrizIdList = new string[codeLeg];
            var pcouponIdList = new string[couponleg];

            if (!string.IsNullOrEmpty(activity.PrizeId))
            {
                pPrizIdList = activity.PrizeId.Split(new string[] { " ", ",", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (!string.IsNullOrEmpty(activity.CouponId))
            {
                pcouponIdList = activity.CouponId.Split(new string[] { " ", ",", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (pPrizIdList != null && pPrizIdList.Length > 0)
            {
                foreach (var pid in pPrizIdList)
                {
                    req.PrizeList.Add(new ActivityPrize()
                    {
                        PrizeIdentity = pid,
                        PrizeType = PrizeType.Code
                    });
                }
            }

            if (pcouponIdList != null && pcouponIdList.Length > 0)
            {
                foreach (var prize in pcouponIdList)
                {
                    string couponId = prize;
                    req.PrizeList.Add(new ActivityPrize()
                    {
                        PrizeIdentity = couponId,

                        PrizeType = PrizeType.Coupon
                    });
                }
            }

            var res = MKMSClient.Send<AddSpreadActivityResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改推广活动
        /// <summary>
        /// 修改推广活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool UpdateActivity(AddSpreadActivity activity)
        {
            //var req = Mapper.Map<AddSpreadActivity, UpdateSpreadActivityRequest>(activity);
            var req = new UpdateSpreadActivityRequest();
            req.ActivityId = activity.ActivityId;
            req.ActivityName = activity.ActivityName;
            req.ActivityPic = activity.ActivityPic;
            req.StartTime = activity.StartTime ?? DateTime.Now;
            req.EndTime = activity.EndTime ?? DateTime.Now;
            req.LimitNumber = activity.LimitNumber;
            req.Status = (short)activity.Status;
            req.NecessaryInfoJson = activity.NecessaryInfoJson;
            req.ShareInfoJson = activity.ShareInfoJson;
            req.EnableOldUser = activity.EnableOldUser;

            req.IsDelete = activity.IsDelete;
            req.BackGroundPhotoUrl = activity.BackGroundPhotoUrl;
            req.Remark = activity.Remark;
            req.RoleDetail = activity.RoleDetail;

            var res = MKMSClient.Send<UpdateSpreadActivityResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改推广活动状态
        /// <summary>
        /// 修改推广活动状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateState(int id, int state)
        {
            var req = new UpdateSpreadActivityStateRequest();
            req.ActivityId = id;

            req.Status = (Myzj.MKMS.ServiceModel.ActivityStatus)state;

            var res = MKMSClient.Send<UpdateSpreadActivityStateResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 删除推广活动
        /// <summary>
        /// 删除推广活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelActivity(int id)
        {
            var req = new DelSpreadActivityRequest();
            req.ActivityId = id;
            var res = MKMSClient.Send<DelSpreadActivityResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 推广统计列表
        /// <summary>
        /// 推广统计列表
        /// </summary>
        /// <param name="spreadBase"></param>
        /// <returns></returns>
        public SpreadBaseRefer QueryAllSpreadDataReport(SpreadBaseRefer spreadBase)
        {
            var req = Mapper.Map<SpreadBaseRefer, GetAllSpreadDataReportRequest>(spreadBase);

            var res = MKMSClient.Send<GetAllSpreadDataReportResponse>(req);
            if (res.DoFlag)
            {
                spreadBase.List = Mapper.MappGereric<SpreadBaseReport, SpreadBase>(res.Data);
                spreadBase.Total = res.RowCount;
            }
            return spreadBase;
        }
        #endregion

        #region 获取所有未注册用户数据统计列表
        /// <summary>
        /// 获取所有未注册用户数据统计列表
        /// </summary>
        /// <param name="unRegisterUser"></param>
        /// <returns></returns>
        public List<UnRegisterUserDetail> QueryUnRegisterUser(UnRegisterUserRefer unRegisterUser)
        {
            var result = new List<UnRegisterUserDetail>();
            var req = new UnRegisterUserListRequest();

            var res = MKMSClient.Send<UnRegisterUserListResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.MappGereric<UnRegisterUserList, UnRegisterUserDetail>(res.Data);
            }
            return result;
        }
        #endregion

        //***************************************************************************

        #region 通过第三方标识查找用户信息
        /// <summary>
        /// 通过第三方标识查找用户信息
        /// </summary>
        /// <param name="userBy"></param>
        /// <returns></returns>
        public ResultUserByUnionIdentity QueryUserByUnionIdentity(GetUserByUnionIdentity userBy)
        {
            var result = new ResultUserByUnionIdentity();
            var req = Mapper.Map<GetUserByUnionIdentity, GetUserByUnionIdentityRequest>(userBy);

            var res = MKMSClient.Send<GetUserByUnionIdentityResponse>(req);
            if (res.DoFlag)
            {
                result.UserInfo = Mapper.Map<UserInfo, UserInfoDetail>(res.UserInfo);
                result.RoleInfo = Mapper.Map<Spread_User_RoleExt, SpreadUserRoleDetail>(res.RoleInfo);
            }
            return result;
        }
        #endregion

    }
}
