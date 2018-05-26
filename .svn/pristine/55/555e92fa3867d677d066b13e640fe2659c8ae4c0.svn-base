using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.VIP.ServiceModel;
using Myzj.OPC.UI.Model.WebUserBe;

namespace Myzj.OPC.UI.ServiceClient
{
    public class WebUserBehaviorClient : BaseService
    {

        private WebUserBehaviorClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static WebUserBehaviorClient _instance;
        public static WebUserBehaviorClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new WebUserBehaviorClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 用户行为管理列表
        /// <summary>
        /// 用户行为管理列表
        /// </summary>
        /// <returns></returns>
        public UserBehaviorRefer GetUserBehavior(UserBehaviorRefer userBehavior)
        {
            var result = new UserBehaviorRefer();
            var req = new QueryWebLimitUserBehaviorRequest();

            if (userBehavior.SearchDetail != null)
            {
                req.ObjectType = userBehavior.SearchDetail.ObjectType;
                req.BegionIp = userBehavior.SearchDetail.BegionIp;
                req.EndIp = userBehavior.SearchDetail.EndIp;
                req.IsEnable = userBehavior.SearchDetail.IsEnable;
                req.UserBehaviorId = userBehavior.SearchDetail.TempUserId;
                req.LimitBegionTime = userBehavior.SearchDetail.LimitBegionTime;
                req.LimitEndTime = userBehavior.SearchDetail.LimitEndTime;
                req.ShowMesage = userBehavior.SearchDetail.ShowMesage;
                req.Remarks = userBehavior.SearchDetail.Remarks;
            }
            req.PageIndex = userBehavior.PageIndex;
            req.PageSize = userBehavior.PageSize;

            var res = OpcClient.Send<QueryWebLimitUserBehaviorResponse>(req);

            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Web_LimitUserBehaviorExt, UserBehaviorDetail>(res.UserBehaviorDos);
                result.Total = res.Total;
            }
            result.SearchDetail = userBehavior.SearchDetail;
            result.PageIndex = userBehavior.PageIndex;
            result.PageSize = userBehavior.PageSize;

            return result;
        }
        #endregion

        #region 根据Id查询详细信息
        /// <summary>
        /// 根据Id查询详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserBehaviorDetail GetuserBehaviorById(int id)
        {
            var result = new UserBehaviorDetail();
            var req = new QueryWebLimitUserBehaviorByIdRequest();
            req.SysNo = id;

            var res = OpcClient.Send<QueryWebLimitUserBehaviorByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Web_LimitUserBehaviorExt, UserBehaviorDetail>(res.UserBehaviorDos);
            }
            return result;
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="userBehavior"></param>
        /// <returns></returns>
        public bool AdduserBehavior(UserBehaviorDetail userBehavior)
        {
            var req = Mapper.Map<UserBehaviorDetail, AddWebLimitUserBehaviorRequest>(userBehavior);
            var res = OpcClient.Send<AddWebLimitUserBehaviorResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="userBehavior"></param>
        /// <returns></returns>
        public bool UpdateuserBehavior(UserBehaviorDetail userBehavior)
        {
            var req = Mapper.Map<UserBehaviorDetail, UpdateWebLimitUserBehaviorRequest>(userBehavior);
            var res = OpcClient.Send<UpdateWebLimitUserBehaviorResponse>(req);
            return res.DoFlag;
        }

        #endregion

        #region 修改状态
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateuserBehaviorState(int id, int state)
        {
            var req = new UpdateWebLimitUserBehaviorStateRequest();
            req.SysNo = id;
            req.IsEnable = state;
            var res = OpcClient.Send<UpdateWebLimitUserBehaviorStateResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeluserBehavior(int id)
        {
            var req = new DelWebLimitUserBehaviorRequest();
            req.SysNo = id;

            var res = OpcClient.Send<DelWebLimitUserBehaviorResponse>(req);

            return res.DoFlag;
        }

        #endregion
    }
}
