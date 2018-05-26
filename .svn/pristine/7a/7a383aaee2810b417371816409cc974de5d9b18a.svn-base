// ***********************************************************************
// Copyright (c) 2016 holyca,All rights reserved.
// CLR Version : 4.0.30319.34209
// Project:
// Assembly:Myzj.OPC.UI.ServiceClient
// Author:holyca
// Created:2016/5/30 18:02:00
// Description:
// ***********************************************************************
// Last Modified By:HOLYCA20151208
// Last Modified On:2016/5/30 18:02:00
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model.WordLibManage;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.ServiceClient
{
    /// <summary>
    /// 词库管理操作数据方法
    /// </summary>
    /// Creator:ysx2012
    /// 5/30/2016
    /// <seealso cref="Myzj.OPC.UI.ServiceClient.BaseService" />
    public class WordLibManageConfigClient : BaseService
    {
        #region 单例
        private WordLibManageConfigClient()
        {

        }
        private static readonly object Lockobj = new object();
        private static WordLibManageConfigClient _instance;
        public static WordLibManageConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new WordLibManageConfigClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion


        /// <summary>
        /// Queries the word library manage page list.查询列表
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public WordLibManageRefer QueryWordLibManagePageList(WordLibManageRefer request)
        {
            var result = new WordLibManageRefer();
            var req = new QueryWordLibPageListReqeust()
            {
                Enable = request.WordLibManageDetail.Enable,
                ForbiddenType = request.WordLibManageDetail.ForbiddenType,
                Type = request.WordLibManageDetail.Type,
                KeyWord = request.WordLibManageDetail.KeyWord,
                Sort = request.WordLibManageDetail.Sort,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
          
            
            var res = BSClient.Send<QueryWordLibPageListResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<WordLibManage, WordLibManageDetail>(res.WordLibManage);
                result.Total = res.Total;
            }
            result.WordLibManageDetail = request.WordLibManageDetail;
            result.PageIndex = request.PageIndex;
            result.PageSize = request.PageSize;
            return result;
        }


        /// <summary>
        /// Queries the word library manage entity.Id查询单条记录
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public WordLibManageDetail QueryWordLibManageEntity(int id)
        {
            var result = new WordLibManageDetail();
            var req = new QueryWordLibManageEntity() { Id = id };
            var res = BSClient.Send<QueryWordLibManageEntityResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<WordLibManage, WordLibManageDetail>(res.WordLibManageEntity);
            }
            return result;
        }


        /// <summary>
        /// Updates the word library manage entity.更新一条数据
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public  UpdateWordLibManageResponse UpdateWordLibManageEntity(WordLibManageDetail request)
        {
            var req = new UpdateWordLibManageRequest()
            {
                Id = request.Id,
                UpdateTo = Mapper.Map<WordLibManageDetail, WordLibManage>(request)
            };
            var res = BSClient.Send<UpdateWordLibManageResponse>(req);
            return res;
        }


        /// <summary>
        /// Adds the word library manage.添加数据
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public AddWordLibManageResponse AddWordLibManage(WordLibManageDetail request)
        {
            var req = Mapper.Map<WordLibManageDetail, AddWordLibManageRequest>(request);
            req.IsDelete = request.IsDelete ?? false;
            var res = BSClient.Send<AddWordLibManageResponse>(req);
            return res;
        }


        /// <summary>
        /// Sets the is delete or enable.设置删除或禁用
        /// </summary>
        /// <param name="idList">The identifier list.</param>
        /// <param name="isDel">The is delete.</param>
        /// <param name="isEnable">The is enable.</param>
        /// <param name="lastoperator">The lastoperator.</param>
        /// <param name="lastupdateTime">The lastupdate time.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public SetIsDeleteOrEnableResponse SetIsDelOrEnable(List<int> idList, int isDel, int isEnable,string lastoperator,DateTime lastupdateTime)
        {
            var result = new SetIsDeleteOrEnableResponse();
            var req = new SetIsDeleteOrEnableRequest()
            {
                Ids = idList,
                IsDelete = isDel > 0 ? true : false,
                Enable = isEnable <= 0,
                LastOperator = lastoperator,
                LastUpdateTime = lastupdateTime
            };
            result = BSClient.Send<SetIsDeleteOrEnableResponse>(req);
            return result;
        }


        /// <summary>
        /// Deletes the forbidden tp.批量删除类型
        /// </summary>
        /// <param name="idList">The identifier list.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/10
        public DeleteFbTpResponse DeleteForbiddenTp(List<int> idList)
        {
            var result = new DeleteFbTpResponse();
            var req = new DeleteFbTpRequest()
            {
                Ids = idList
            };
            result = BSClient.Send<DeleteFbTpResponse>(req);
            return result;
        }


        /// <summary>
        /// Resets the index.重建索引
        /// </summary>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/10
        public RebuildForbiddenDicResponse ResetIndex()
        {
            var result = new RebuildForbiddenDicResponse();
            result = BSClient.Send<RebuildForbiddenDicResponse>(new RebuildForbiddenDic());
            return result;
        }


        /// <summary>
        /// Gets the forbidden type list.获取禁词类型
        /// </summary>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/1/2016
        public Dictionary<int?, string> GetForbiddenTypeList()
        {
            //var dic = new Dictionary<int?, string>();
            var list = new List<ForbiddenTypeDetail>();
            var result = BSClient.Send<ForbiddenTypeListResponse>(new ForbiddenTypeListRequest());
            if (result.DoFlag)
            {
                //foreach (var item in result.ForbiddenType)
                //{
                //    if (!string.IsNullOrEmpty(item.Type) && item.Id.HasValue)
                //        dic.Add(item.Id, item.Type);
                //}

                list = Mapper.MappGereric<ForbiddenType, ForbiddenTypeDetail>(result.ForbiddenTypeList).ToList();
            }
            return list.Where(item => (!string.IsNullOrEmpty(item.Type) && item.TypeId.HasValue)).ToDictionary(item => item.TypeId, item => item.Type);
            //return dic;
        }


        /// <summary>
        /// Queries the forbidden type list.获取类型列表
        /// </summary>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public List<ForbiddenTypeDetail> QueryForbiddenTypeList()
        {
            var result = new List<ForbiddenTypeDetail>();
            var res = BSClient.Send<ForbiddenTypeListResponse>(new ForbiddenTypeListRequest());
            if (res.DoFlag)
            {
                result = Mapper.MappGereric<ForbiddenType, ForbiddenTypeDetail>(res.ForbiddenTypeList).ToList();
            }
            return result;
        }


        /// <summary>
        /// Queries the forbidden type entity.查询一个类型
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public ForbiddenTypeDetail QueryForbiddenTypeEntity(int id)
        {
            var result = new ForbiddenTypeDetail();
            var req = new QueryFbTpEntity() { Id = id };
            var res = BSClient.Send<QueryFbTpEntityResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<ForbiddenType, ForbiddenTypeDetail>(res.ForbiddenTypeEntity);
            }
            return result;
        }


        /// <summary>
        /// Updates the fb tp entity.更新一条数据
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public UpdateFbTpResponse UpdateFbTpEntity(ForbiddenTypeDetail request)
        {
            var req = new UpdateFbTpRequest()
            {
                Id = request.Id,
                UpdateTo = Mapper.Map<ForbiddenTypeDetail, ForbiddenType>(request)
            };
            var res = BSClient.Send<UpdateFbTpResponse>(req);
            return res;
        }


        /// <summary>
        /// Adds the word library manage.新增一个类型
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public AddFbTpResponse AddForbiddenType(ForbiddenTypeDetail request)
        {
            var req = Mapper.Map<ForbiddenTypeDetail, AddFbTpRequest>(request);
            var res = BSClient.Send<AddFbTpResponse>(req);
            return res;
        }

    }
}
