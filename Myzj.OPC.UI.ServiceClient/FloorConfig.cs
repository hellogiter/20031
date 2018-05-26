using System;
using System.Collections.Generic;
using MYZJ.VIP.ServiceModel;
using Myzj.CMS.ServiceModel;
using Myzj.OPC.UI.Model.FloorConfig;

namespace Myzj.OPC.UI.ServiceClient
{
    public class FloorConfigClient : BaseService
    {
        private FloorConfigClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static FloorConfigClient _instance;
        public static FloorConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new FloorConfigClient();
                        }
                    }
                }
                return _instance;
            }
        }

        //*****************操作dbo.FloorConfig表******************************
        #region 楼层配置列表
        /// <summary>
        /// 楼层配置列表
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public FloorConfigRefer QueryFloorConfigRefer(FloorConfigRefer floorConfig)
        {
            var result = new FloorConfigRefer();
            var req = new QueryFloorConfigRequest();

            if (floorConfig.SearchDetail != null)
            {
                req.FloorName = floorConfig.SearchDetail.FloorName;

                if (floorConfig.SearchDetail.TempFloorType <= 0)
                {
                    req.FloorType = -1;
                }
                else
                {
                    req.FloorType = floorConfig.SearchDetail.TempFloorType;
                }
            }
            req.PageIndex = floorConfig.PageIndex;
            req.PageSize = floorConfig.PageSize;

            var res = CMSClient.Send<QueryFloorConfigResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<FloorConfigExt, FloorConfigDetail>(res.FloorConfigDos);
                result.Total = res.Total;
            }
            result.SearchDetail = floorConfig.SearchDetail;
            result.PageIndex = floorConfig.PageIndex;
            result.PageSize = floorConfig.PageSize;

            return result;
        }
        #endregion

        #region 楼层配置的类型
        /// <summary>
        /// 楼层配置的类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<FloorItemsConfigDetail> QueryFloorItemsConfig(int id)
        {
            var req = new QueryFloorItemsConfigRequest();
            req.FloorTypeID = id;

            var res = CMSClient.Send<QueryFloorItemsConfigResponse>(req);

            var result = Mapper.MappGereric<FloorItemsConfigExt, FloorItemsConfigDetail>(res.FloorItemsDos);
            return result;
        }
        #endregion

        #region 根据楼层配置Id查询单条信息
        /// <summary>
        /// 根据楼层配置Id查询单条信息
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public FloorConfigDetail QueryFloorConfigById(int id)
        {
            var result = new FloorConfigDetail();
            var req = new QueryFloorConfigByIdRequest();
            req.SysNo = id;

            var res = CMSClient.Send<QueryFloorConfigByIdResponse>(req);
            result = Mapper.Map<FloorConfigExt, FloorConfigDetail>(res.FloorConfigDos);
            return result;
        }
        #endregion

        #region 新增楼层配置
        /// <summary>
        /// 新增楼层配置
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public bool AddFloorConfig(FloorConfigDetail floorConfig)
        {
            var req = Mapper.Map<FloorConfigDetail, AddFloorConfigRequest>(floorConfig);
            var res = CMSClient.Send<AddFloorConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改楼层配置
        /// <summary>
        /// 修改楼层配置
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public bool UpdateFloorConfig(FloorConfigDetail floorConfig)
        {
            var req = Mapper.Map<FloorConfigDetail, UpdateFloorConfigRequest>(floorConfig);
            var res = CMSClient.Send<UpdateFloorConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改楼层配置排序
        /// <summary>
        /// 修改楼层配置排序
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public bool UpdateFloorConfigSort(int id, int sort)
        {
            var req = new UpdateFloorConfigSortRequest();
            req.SysNo = id;
            req.Sequence = sort;

            var res = CMSClient.Send<UpdateFloorConfigSortResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除楼层配置
        /// <summary>
        /// 修改楼层配置
        /// </summary>
        /// <param name="floorConfig"></param>
        /// <returns></returns>
        public bool DelFloorConfig(int id)
        {
            var req = new DelFloorConfigRequest();
            req.SysNo = id;

            var res = CMSClient.Send<DelFloorConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        //*****************操作FloorDetailConfig表******************************

        #region 根据楼层配置Id查询相关联的楼层配置详细配置列表信息
        /// <summary>
        /// 根据楼层配置Id查询相关联的楼层配置详细配置列表信息
        /// </summary>
        /// <param name="floorDetail"></param>
        /// <returns></returns>
        public FloorDetailRefer QueryFloorDetail(FloorDetailRefer floorDetail)
        {
            var result = new FloorDetailRefer();
            var req = new QueryFloorDetailConfigByFloorIdRequest();
            if (floorDetail.SearchDetail != null)
            {
                req.FloorID = floorDetail.SearchDetail.FloorID;
            }
            req.PageIndex = floorDetail.PageIndex ?? 0;
            req.PageSize = floorDetail.PageSize ?? 0;

            var res = CMSClient.Send<QueryFloorDetailConfigByFloorIdResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<FloorDetailConfigExt, FloorDetailDetail>(res.FloorDetailDos);
                result.Total = res.Total;
            }
            result.SearchDetail = floorDetail.SearchDetail;
            result.PageIndex = floorDetail.PageIndex;
            result.PageSize = floorDetail.PageSize;

            return result;
        }
        #endregion

        #region 根据Id查询单条信息
        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FloorDetailDetail QueryFloorDetailById(int id)
        {
            var result = new FloorDetailDetail();
            var req = new QueryFloorDetailConfigByIdRequest();
            req.SysNO = id;
            var res = CMSClient.Send<QueryFloorDetailConfigByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<FloorDetailConfigExt, FloorDetailDetail>(res.FloorDetailDos);
            }
            return result;
        }
        #endregion

        #region 新增楼层配置相关信息
        /// <summary>
        /// 新增楼层配置相关信息
        /// </summary>
        /// <param name="floorDetail"></param>
        /// <returns></returns>
        public bool AddFloorDetail(FloorDetailDetail floorDetail)
        {
            var req = Mapper.Map<FloorDetailDetail, AddFloorDetailConfigRequest>(floorDetail);
            var res = CMSClient.Send<AddFloorDetailConfigResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改楼层配置相关信息
        /// <summary>
        /// 修改楼层配置相关信息
        /// </summary>
        /// <param name="floorDetail"></param>
        /// <returns></returns>
        public bool UpdateFloorDetail(FloorDetailDetail floorDetail)
        {
            var req = Mapper.Map<FloorDetailDetail, UpdateFloorDetailConfigRequest>(floorDetail);
            var res = CMSClient.Send<UpdateFloorDetailConfigResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改楼层配置相关信息排序
        /// <summary>
        /// 修改楼层配置相关信息排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool UpdateDetailSort(int id, int sort)
        {
            var req = new UpdateFloorDetailConfigSortRequest();
            req.SysNO = id;
            req.Sequence = sort;
            var res = CMSClient.Send<UpdateFloorDetailConfigSortResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 删除楼层配置相关信息
        /// <summary>
        /// 删除楼层配置相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelDetail(int id)
        {
            var req = new DelFloorDetailConfigRequest();
            req.SysNO = id;
            var res = CMSClient.Send<DelFloorDetailConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        //*****************操作FloorLabelConfig表******************************

        #region 根据楼层FloorLabelConfig->floordetailId查询相关联的楼层配置详细配置列表信息
        /// <summary>
        /// 根据楼层floordetailId查询相关联的楼层配置详细配置列表信息
        /// </summary>
        /// <param name="floorLabel"></param>
        /// <returns></returns>
        public FloorLabelRefer QueryFloorLabel(FloorLabelRefer floorLabel)
        {
            var result = new FloorLabelRefer();
            var req = new QueryFloorLabelConfigByfloordetailIdRequest();
            if (floorLabel.SearchDetail != null)
            {
                req.FloorDetailID = floorLabel.SearchDetail.FloorDetailID;
            }

            var res = CMSClient.Send<QueryFloorLabelConfigByfloordetailIdResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<FloorLabelConfigExt, FloorLabelDetail>(res.FloorDetailDos);
                result.Total = res.Total;
            }
            result.SearchDetail = floorLabel.SearchDetail;

            return result;
        }
        #endregion

        #region 根据FloorLabelConfig->Id查询单条信息
        /// <summary>
        /// 根据FloorLabelConfig->Id查询单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FloorLabelDetail QueryFloorLabelById(int id)
        {
            var result = new FloorLabelDetail();
            var req = new QueryFloorLabelConfigByIdRequest();
            req.SysNo = id;

            var res = CMSClient.Send<QueryFloorLabelConfigByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<FloorLabelConfigExt, FloorLabelDetail>(res.FloorDetailDos);
            }
            return result;
        }
        #endregion

        #region 修改FloorLabelConfig
        /// <summary>
        /// 修改FloorLabelConfig
        /// </summary>
        /// <param name="floorLabel"></param>
        /// <returns></returns>
        public bool UpdateFloorLabel(FloorLabelDetail floorLabel)
        {
            var req = Mapper.Map<FloorLabelDetail, UpdateFloorLabelConfigRequest>(floorLabel);

            var res = CMSClient.Send<UpdateFloorLabelConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 新增FloorLabelConfig
        /// <summary>
        /// 新增FloorLabelConfig
        /// </summary>
        /// <param name="floorLabel"></param>
        /// <returns></returns>
        public bool AddFloorLabel(FloorLabelDetail floorLabel)
        {
            var req = Mapper.Map<FloorLabelDetail, AddFloorLabelConfigRequest>(floorLabel);

            var res = CMSClient.Send<AddFloorLabelConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改FloorLabelConfig排序
        /// <summary>
        /// 修改FloorLabelConfig排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool UpdateFloorLabelSort(int id, int sort)
        {
            var req = new UpdateFloorLabelConfigSortRequest();
            req.SysNO = id;
            req.Sequence = sort;

            var res = CMSClient.Send<UpdateFloorLabelConfigSortResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除FloorLabelConfig
        /// <summary>
        /// 删除FloorLabelConfig
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelFloorLabel(int id)
        {
            var req = new DelFloorLabelConfigRequest();
            req.SysNO = id;
            var res = CMSClient.Send<DelFloorLabelConfigResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 检测商品编号是否存在商品表
        public bool CheckPdtInfoById(int id, out string str)
        {
            var req = new QueryPdtBaseInfoByIdRequest();
            req.IntProductID = id;
            var res = OpcClient.Send<QueryPdtBaseInfoByIdResponse>(req);
            if (res.DoFlag)
            {
                str = res.PdtBaseInfoDos.VchPorductNO;
            }
            else
            {
                str = "";
            }
            return res.DoFlag;
        }
        #endregion
    }
}
