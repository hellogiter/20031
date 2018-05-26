using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using MYZJ.VIP.ServiceModel;
using Myzj.OPC.UI.Model.UserRefer;
using ServiceStack.Messaging.Rcon;

namespace Myzj.OPC.UI.ServiceClient
{
    public class UserReferClient : BaseService
    {
        private UserReferClient()
        {
        }

        private static readonly object Lockobj = new object();
        private static UserReferClient _instance;

        public static UserReferClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserReferClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 咨询列表

        /// <summary>
        /// 咨询列表
        /// </summary>
        /// <param name="userRefer"></param>
        /// <returns></returns>
        public GetUserRefer GetUserReferList(GetUserRefer userRefer)
        {
            var req = Mapper.Map<GetUserRefer, QueryUserReferRequest>(userRefer);
            var userReferResult = OpcClient.Send<QueryUserReferResponse>(req);

            if (userReferResult.DoFlag)
            {
                userRefer.List = Mapper.MappGereric<User_ReferExt, UserReferDetail>(userReferResult.ReferDos);
                userRefer.Total = userReferResult.Total;
            }
            return userRefer;
        }

        #endregion

        #region 根据id查询单条信息

        /// <summary>
        /// 根据id查询单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserReferDetail GetUserRegerDetail(int id)
        {
            var result = new UserReferDetail();
            var req = new QueryUserReferByIdRequest();
            req.IntReferID = id;

            var Userres = OpcClient.Send<QueryUserReferByIdResponse>(req);
            if (Userres.DoFlag)
            {
                result = Mapper.Map<User_ReferExt, UserReferDetail>(Userres.ReferDos);
            }
            return result;
        }

        #endregion

        #region 回复咨询列表

        /// <summary>
        /// 回复咨询列表
        /// </summary>
        /// <param name="userRefer"></param>
        /// <returns></returns>
        public bool UpdateUserRefer(UserReferDetail userRefer)
        {
            var req = new UpdateUserReferRequest();
            req.IntReferID = userRefer.IntReferID;
            req.VchReplyContent = userRefer.VchReplyContent;
            req.DtReplyDatetime = userRefer.DtReplyDatetime;
            req.VchReplyPerson = userRefer.VchReplyPerson;

            var result = OpcClient.Send<UpdateUserReferResponse>(req);

            return result.DoFlag;
        }

        #endregion

        #region 新增咨询

        /// <summary>
        /// 新增咨询
        /// </summary>
        public bool AddUserRefer(UserReferDetail userRefer)
        {
            var req = new AddUserReferRequest();
            req.IntProductID = userRefer.IntProductID;
            req.VchEmail = userRefer.VchEmail;
            req.IntUserID = userRefer.IntUserID;
            req.VchProductName = userRefer.VchProductName;
            req.VchUserNick = userRefer.VchUserNick;
            req.VchContent = userRefer.VchContent;
            req.DtDatetime = userRefer.DtDatetime;
            req.IntIsPleased = userRefer.IntIsPleased;
            req.IntReferType = userRefer.IntReferType;
            req.IntOtherIsVisible = userRefer.IntOtherIsVisible;
            req.VchMemLevel = userRefer.VchMemLevel;
            req.IntCateID = userRefer.IntCateID;

            var result = OpcClient.Send<AddUserReferResponse>(req);
            return result.DoFlag;
        }

        #endregion

        #region 根据商品Id查询关联的咨询列表 回复列表

        /// <summary>
        /// 根据商品Id查询对应的咨询列表 回复列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserReferByProduct QueryUserReferByPId(int id, int type, int pageIndex, int PageSize)
        {
            var req = new QueryUserReferByPIdRequest();
            req.IntProductID = id;
            req.IntReferType = type;
            req.PageIndex = pageIndex;
            req.PageSize = PageSize;
            var result = new UserReferByProduct();

            var res = OpcClient.Send<QueryUserReferByPIdResponse>(req);

            if (res.DoFlag)
            {
                result.UserReferDos = Mapper.MappGereric<User_ReferExt, UserReferDetail>(res.ConsultationDos);
            }
            return result;
        }

        #endregion

        #region 检测商品编号是否存在商品表

        public bool CheckPdtInfoById(int id, out string str)
        {
            var req = new QueryPdtBaseInfoByIdRequest();
            req.IntProductID = id;
            string result = "";
            var res = OpcClient.Send<QueryPdtBaseInfoByIdResponse>(req);
            if (res.DoFlag)
            {
                result = res.PdtBaseInfoDos.VchProductName;
            }
            str = result;
            return res.DoFlag;
        }

        #endregion

        #region  修改状态

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateState(int id, int state)
        {
            var req = new UpdateUserReferStateRequest();
            req.IntReferID = id;
            req.IntOtherIsVisible = (byte)state;
            var res = OpcClient.Send<UpdateUserReferStateResponse>(req);
            return res.DoFlag;
        }

        #endregion

        #region 导出execl
        /// <summary>
        /// 导出execl
        /// </summary>
        /// <param name="execlModel"></param>
        /// <returns></returns>
        public List<UserReferDetail> ExportExeclss(ExportExeclModel execlModel)
        {
            bool result = false;
            List<UserReferDetail> list = null;

            //查询数据
            var req = Mapper.Map<ExportExeclModel, QueryUserReferListRequest>(execlModel);
            var userReferResult = OpcClient.Send<QueryUserReferListResponse>(req);

            if (userReferResult.DoFlag)
            {
                list = Mapper.MappGereric<User_ReferExt, UserReferDetail>(userReferResult.ReferDos);
            }
            return list;
        }
        #endregion
    }
}
