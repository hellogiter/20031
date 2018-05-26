using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.CMS.ServiceModel;
using Myzj.OPC.UI.Model.SaleHotStyleSpecialSubject;

namespace Myzj.OPC.UI.ServiceClient
{
    public class SaleHotStyleSpecialSubjectClient : BaseService
    {
        private SaleHotStyleSpecialSubjectClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static SaleHotStyleSpecialSubjectClient _instance;
        public static SaleHotStyleSpecialSubjectClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SaleHotStyleSpecialSubjectClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 活动专题列表
        /// <summary>
        /// 活动专题列表
        /// </summary>
        /// <param name="specialSubject"></param>
        /// <returns></returns>
        public SaleHotStyleSpecialSubjectRefer QuertSaleHotStyleSpeciaSubject(SaleHotStyleSpecialSubjectRefer specialSubject)
        {
            var result = new SaleHotStyleSpecialSubjectRefer();
            var req = new QuerySaleHotStyleSpeciaSubjectRequest();
            if (specialSubject.SearchDetail != null)
            {
                req.SubjectName = specialSubject.SearchDetail.SubjectName;
                req.IsEnable = specialSubject.SearchDetail.IsEnable;
                req.isExpire = specialSubject.SearchDetail.isExpire;
                req.ApplyPlace = specialSubject.SearchDetail.ApplyPlace;
                req.IsTop = specialSubject.SearchDetail.IsTop;
            }
            req.PageIndex = specialSubject.PageIndex;
            req.PageSize = specialSubject.PageSize;
            var res = CMSClient.Send<QuerySaleHotStyleSpeciaSubjectResponse>(req);
            if (res.DoFlag)
            {
                result.List =
                    Mapper.MappGereric<Sale_HotStyle_SpecialSubjectExt, SaleHotStyleSpecialSubjectDetail>(
                        res.HotStyleSpecialDos);
                result.Total = res.Total;
            }
            result.SearchDetail = specialSubject.SearchDetail;
            result.PageIndex = specialSubject.PageIndex;
            result.PageSize = specialSubject.PageSize;

            return result;
        }

        #endregion

        #region 根据Id查询单条活动专题信息
        /// <summary>
        ///  根据Id查询单条活动专题信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SaleHotStyleSpecialSubjectDetail QuertSaleHotStyleSpeciaSubjectById(int id)
        {
            var result = new SaleHotStyleSpecialSubjectDetail();
            var req = new QuerySaleHotStyleSpeciaSubjectByIdRequest();
            req.Id = id;
            var res = CMSClient.Send<QuerySaleHotStyleSpeciaSubjectByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Sale_HotStyle_SpecialSubjectExt, SaleHotStyleSpecialSubjectDetail>(res.HotStyleSpecialDos);
            }
            return result;
        }

        #endregion

        #region 修改专题活动
        /// <summary>
        /// 修改专题活动
        /// </summary>
        /// <returns></returns>
        public bool Update(SaleHotStyleSpecialSubjectDetail specialSubject)
        {
            var req = Mapper.Map<SaleHotStyleSpecialSubjectDetail, UpdateSaleHotStyleSpeciaSubjectRequest>(specialSubject);
            var res = CMSClient.Send<UpdateSaleHotStyleSpeciaSubjectResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 新增专题活动
        /// <summary>
        /// 修改专题活动
        /// </summary>
        /// <returns></returns>
        public bool Add(SaleHotStyleSpecialSubjectDetail specialSubject)
        {
            var req = Mapper.Map<SaleHotStyleSpecialSubjectDetail, AddSaleHotStyleSpeciaSubjectRequest>(specialSubject);
            var res = CMSClient.Send<AddSaleHotStyleSpeciaSubjectResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改专题活动排序
        /// <summary>
        /// 修改专题活动排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool UpdateSort(int id, int sort)
        {
            var req = new UpdateSaleHotStyleSpecialSubjectSortRequest();
            req.Id = id;
            req.Sort = sort;
            var res = CMSClient.Send<UpdateSaleHotStyleSpecialSubjectSortResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改专题活动状态
        /// <summary>
        /// 修改专题活动状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateState(int id, int state)
        {
            var req = new UpdateSaleHotStyleSpeciaSubjectStateRequest();
            req.Id = id;
            req.IsEnable = Convert.ToBoolean(state);
            var res = CMSClient.Send<UpdateSaleHotStyleSpeciaSubjectStateResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 设置活动专题置顶/取消置顶
        /// <summary>
        /// 设置活动专题置顶/取消置顶
        /// </summary>
        /// <param name="id"></param>
        /// <param name="top"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool UpdateIsTop(int id, int top, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var req = new UpdateSaleHotStyleSpeciaSubjectTopRequest();
            req.Id = id;
            req.IsTop = (short)top;
            req.TopBeginTime = startDate;
            req.TopEndTime = endDate;

            var res = CMSClient.Send<UpdateSaleHotStyleSpeciaSubjectTopResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除专题活动
        /// <summary>
        /// 删除专题活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelSaleHotStyleSpeciaSubject(int id)
        {
            var req = new DelSaleHotStyleSpeciaSubjectRequest();
            req.Id = id;
            req.IsDeleted = true;
            var res = CMSClient.Send<DelSaleHotStyleSpeciaSubjectResponse>(req);
            return res.DoFlag;
        }
        #endregion

    }
}
