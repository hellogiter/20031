using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.VIP.Model;
using MYZJ.VIP.ServiceModel;
using Myzj.CMS.Model;
using Myzj.OPC.UI.Model.WebBulletin;

namespace Myzj.OPC.UI.ServiceClient
{
    public class WebBulletinClient : BaseService
    {
        private WebBulletinClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static WebBulletinClient _instance;
        public static WebBulletinClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new WebBulletinClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 公告列表
        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="bulletin"></param>
        /// <returns></returns>
        public WebBulletinRefer QueryWebBulletin(WebBulletinRefer bulletin)
        {
            var result = new WebBulletinRefer();
            var req = new QueryWebBulletinRequest();

            if (bulletin.SearchDetail != null)
            {
                req.VchBulletinName = bulletin.SearchDetail.VchBulletinName;
                req.IntIsEnable = bulletin.SearchDetail.IntIsEnable;
            }
            req.PageIndex = bulletin.PageIndex;
            req.PageSize = bulletin.PageSize;
            var res = CMSClient.Send<QueryWebBulletinResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Web_BulletinExt, WebBulletinDetail>(res.BulletinDos);
                result.Total = res.Total;
            }
            result.SearchDetail = bulletin.SearchDetail;
            result.PageIndex = bulletin.PageIndex;
            result.PageSize = bulletin.PageSize;
            return result;
        }
        #endregion

        #region 根据Id查询详细信息
        /// <summary>
        /// 根据Id查询详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebBulletinDetail QueryWebBulletinById(int id)
        {
            var result = new WebBulletinDetail();
            var req = new QueryWebBulletinByIdRequest();
            req.IntBulletinID = id;
            var res = CMSClient.Send<QueryWebBulletinByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Web_BulletinExt, WebBulletinDetail>(res.BulletinDos);
            }
            return result;
        }
        #endregion

        #region 新增公告
        /// <summary>
        /// 新增公告
        /// </summary>
        /// <param name="bulletin"></param>
        /// <returns></returns>
        public bool AddWebBulletin(WebBulletinDetail bulletin)
        {
            var req = Mapper.Map<WebBulletinDetail, AddWebBulletinRequest>(bulletin);
            var res = CMSClient.Send<AddWebBulletinResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改公告
        /// <summary>
        /// 新增公告
        /// </summary>
        /// <param name="bulletin"></param>
        /// <returns></returns>
        public bool UpdateWebBulletin(WebBulletinDetail bulletin)
        {
            var req = Mapper.Map<WebBulletinDetail, UpdateWebBulletinRequest>(bulletin);
            var res = CMSClient.Send<UpdateWebBulletinResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改公告排序
        /// <summary>
        /// 修改公告排序
        /// </summary>
        /// <param name="bulletin"></param>
        /// <returns></returns>
        public bool UpdateWebBulletinSort(int id, int sort)
        {
            var req = new UpdateWebBulletinSortRequest();
            req.IntBulletinID = id;
            req.IntSort = sort;

            var res = CMSClient.Send<UpdateWebBulletinSortResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改公告状态
        /// <summary>
        /// 修改公告状态
        /// </summary>
        /// <param name="bulletin"></param>
        /// <returns></returns>
        public bool UpdateWebBulletinState(int id, byte state)
        {
            var req = new UpdateWebBulletinStateRequest();
            req.IntBulletinID = id;
            req.IntIsEnable = state;

            var res = CMSClient.Send<UpdateWebBulletinStateResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 删除公告
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelWebBulletin(int id)
        {
            var req = new DelWebBulletinRequest();
            req.IntBulletinID = id;
            var res = CMSClient.Send<DelWebBulletinResponse>(req);
            return res.DoFlag;
        }
        #endregion
    }
}
