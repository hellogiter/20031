using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model.WebIndex;

namespace Myzj.OPC.UI.ServiceClient
{
    public class WebIndexRapidInClien : BaseService
    {
        private WebIndexRapidInClien()
        {
        }
        private static readonly object Lockobj = new object();
        private static WebIndexRapidInClien _instance;
        public static WebIndexRapidInClien Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new WebIndexRapidInClien();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 快速入口管理
        /// <summary>
        /// 快速入口管理
        /// </summary>
        /// <param name="wordMsg"></param>
        /// <returns></returns>
        public WebIndexRefer QueryWordMsgRefer(WebIndexRefer webIndex)
        {
            var result = new WebIndexRefer();
            var req = new QueryWebIndexRapidInRequest();
            if (webIndex.SearchDetail != null)
            {
                //条件查询
                req.VchName = webIndex.SearchDetail.VchName;
                req.IntIsVisibleIndex = webIndex.SearchDetail.IntIsVisibleIndex;
                req.IntNewUserVerify = webIndex.SearchDetail.IntNewUserVerify;
                req.IntSystemType = webIndex.SearchDetail.IntSystemType;
            }
            req.PageIndex = webIndex.PageIndex.GetValueOrDefault(); ;
            req.PageSize = webIndex.PageSize.GetValueOrDefault(); ;

            var res = BSClient.Send<QueryWebIndexRapidInResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Web_Index_Rapid_InExt, WebIndexDetail>(res.RapidInDos);
                result.Total = res.Total;
            }
            result.SearchDetail = webIndex.SearchDetail;
            result.PageIndex = webIndex.PageIndex;
            result.PageSize = webIndex.PageSize;

            return result;
        }
        #endregion

        #region 管理活动列表
        /// <summary>
        /// 管理活动列表
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public WebActivityRefer QueryWebActivity(WebActivityRefer activity)
        {
            var result = new WebActivityRefer();
            var req = new QueryWebActivityRequest();
            if (activity.SearchDetail != null)
            {
                //条件查询
            }
            var res = BSClient.Send<QueryWebActivityResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Web_ActivityExt, WebActivityDetail>(res.ActivityDos);
            }
            return result;
        }
        #endregion

        #region 根据ID查询详细信息
        /// <summary>
        ///  根据ID查询详细信息
        /// </summary>
        /// <param name="webIndex"></param>
        /// <returns></returns>
        public WebIndexDetail QueryById(int id)
        {
            var result = new WebIndexDetail();
            var req = new QueryWebIndexRapidInByIdRequest();
            req.IntRapidInID = id;

            var res = BSClient.Send<QueryWebIndexRapidInByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Web_Index_Rapid_InExt, WebIndexDetail>(res.RapidInDos);
            }
            return result;
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="webIndex"></param>
        /// <returns></returns>
        public bool AddWordMsgRefer(WebIndexDetail webIndex)
        {
            var req = Mapper.Map<WebIndexDetail, AddWebIndexRapidInRequest>(webIndex);

            var res = BSClient.Send<AddWebIndexRapidInResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="webIndex"></param>
        /// <returns></returns>
        public bool UpdateWordMsgRefer(WebIndexDetail webIndex)
        {
            var req = Mapper.Map<WebIndexDetail, UpdateWebIndexRapidInRequest>(webIndex);
            var res = BSClient.Send<UpdateWebIndexRapidInResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改排序
        /// <summary>
        /// 修改排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool UpdateSort(int id, int sort)
        {
            var req = new UpdateWebIndexRapidInSortRequest();
            req.IntRapidInID = id;
            req.IntSort = sort;
            var res = BSClient.Send<UpdateWebIndexRapidInSortResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改状态
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool UpdateVisible(int id, byte isvisible)
        {
            var req = new UpdateWebIndexRapidInVisibleRequest();
            req.IntRapidInID = id;
            req.IntIsVisibleIndex = isvisible;
            var res = BSClient.Send<UpdateWebIndexRapidInVisibleResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelWordMsgRefer(int id)
        {
            var req = new DelWebIndexRapidInRequest();
            req.IntRapidInID = id;
            var res = BSClient.Send<DelWebIndexRapidInResponse>(req);
            return res.DoFlag;
        }

        #endregion
    }
}
