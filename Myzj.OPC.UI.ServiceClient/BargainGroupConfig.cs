using Myzj.MKMS.ServiceModel.BargainGroup;
using Myzj.OPC.UI.Model.BargainGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Myzj.OPC.UI.ServiceClient
{
    public class BargainGroupConfigClient : BaseService
    {
        #region 单例
        private BargainGroupConfigClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static BargainGroupConfigClient _instance;
        public static BargainGroupConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new BargainGroupConfigClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        //添加团信息
        public bool AddGroupGoods(GroupGoodsDetail request)
        {
            var param = Mapper.Map<GroupGoodsDetail, AddGroupGoodsRequest>(request);
            var response = MKMSClient.Send<AddGroupGoodsResponse>(param);
            return response.DoFlag;
        }

        //查询团信息
        public GroupGoodsRefer QueryGroupGoodsPageList(GroupGoodsRefer refer)
        {
            var obj = refer.SearchDetail;

            var result = new GroupGoodsRefer();
            var param = new QueryGroupGoodsPageListRequest
            {
                GoodsId = obj.GoodsId,
                GoodsName = obj.GoodsName,
                GroupActivitySysNo = obj.GroupActivitySysNo,
                PageIndex = 1,
                PageSize = 30
            };
            var response = MKMSClient.Send<QueryGroupGoodsPageListResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<QueryGroupGoodsPageListDto, GroupGoodsDetailExt>(response.QueryGroupGoodsPageListDtos);
            }
            return result;
        }

        //根据SysNo 查询团信息
        public GroupGoodsDetailExt QueryGroupGoodsInfoBySysNo(int sysNo)
        {
            var groupGooodsInfo = new GroupGoodsDetailExt();
            var param = new QueryGroupGoodsPageListRequest() { SysNo = sysNo };
            var response = MKMSClient.Send<QueryGroupGoodsPageListResponse>(param);

            if (response.DoFlag)
            {
                groupGooodsInfo = Mapper.Map<QueryGroupGoodsPageListDto, GroupGoodsDetailExt>(response.QueryGroupGoodsPageListDtos.First());
            }
            return groupGooodsInfo;
        }

        //查询商品信息
        public GoodsInfo QueryGoodsInfoById(int proId)
        {
            var result = new GoodsInfo();
            var param = new QueryGoodsInfoRequest()
                {
                    intProductID = proId
                };
            var response = MKMSClient.Send<QueryGoodsInfoResponse>(param);
            if (response.DoFlag)
            {
                result = Mapper.Map<QueryGoodsInfo, GoodsInfo>(response.QueryGoodsInfoDto);
            }
            return result;
        }

        //更新商品信息
        public bool UpdateGroupGoods(GroupGoodsDetail request)
        {
            var upd = new UpdateGroupInfo();
            upd.SysNo = request.SysNo;
            upd.UpdateTo = request;
            var param = Mapper.Map<UpdateGroupInfo, UpdateGroupGoodsRequest>(upd);
            var response = MKMSClient.Send<UpdateGroupGoodsResponse>(param);
            return response.DoFlag;
        }

        //统计数据
        public CountGoodsRefer CountGroupGoodsInfo(CountGoodsRefer refer)
        {
            var result = new CountGoodsRefer();
            var obj = refer.SearchDetail;
            var param = new CountGoodsInfoRequest()
                {
                    SysNo = obj.SysNo,
                    StartTime = obj.StartTime,
                    EndTime = obj.EndTime,
                    GoodsId = obj.GoodsId,
                    GroupActivitySysNo = obj.GroupActivitySysNo
                };
            var response = MKMSClient.Send<CountGoodsInfoResponse>(param);

            if (response.DoFlag)
            {

                result.List2 = Mapper.MappGereric<CountGoodsInfo, CountGoodsDetailInfoExt>(response.CountGoodsInfoDto);
            }
            return result;
        }

        /// <summary>
        /// 查询所有商品团列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public GroupStructureListRefer GroupStructureList(GroupStructureListRefer refer)
        {
            var where = "";
            
            if (refer.SearchDetail.SysNo.HasValue)
            {
                where += (" and a.SysNo=" + refer.SearchDetail.SysNo);
            }
            if (refer.SearchDetail.GrouState>=1)
            {
                where += (" and (CASE WHEN a.IsDelete='1' THEN 3   WHEN a.IsDelete='0' THEN CASE WHEN cangroupcount=b.SetCanGroupCount THEN 2 ELSE 1 end END) =" + refer.SearchDetail.GrouState);
            }
            if ((refer.SearchDetail.UserId??0) >0)
            {
                where += (" and a.UserId="+ refer.SearchDetail.UserId);
            }
            var result = new GroupStructureListRefer();
            var search = refer.SearchDetail;
            var reqeust = new QueryGroupStructureList
                {
                    ActivitySysNo = search.ActivitySysNo,
                    GoodsSysNo = search.GoodsSysNo,
                    Where = where,
                    Order = " order by a.CreateTime desc",
                    PageIndex = refer.PageIndex ?? 1,
                    PageSize = 20
                };
            var response = MKMSClient.Send<QueryGroupStructureListResponse>(reqeust);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List = Mapper.MappGereric<QueryGroupStructureListDto, GroupStructureListSearchResult>(response.QueryGroupStructureListDtos);
            }
            return result;
        }


        //添加活动信息
        public bool AddGroupActivity(GroupActivityDetail request)
        {
            var param = Mapper.Map<GroupActivityDetail, AddGroupActivityRequest>(request);
            var response = MKMSClient.Send<AddGroupActivityResponse>(param);
            return response.DoFlag;
        }

        //更新活动信息
        public bool UpdateGroupActivity(GroupActivityDetail request)
        {
            UpdateGroupActivityInfo upd = new UpdateGroupActivityInfo();
            upd.SysNo = request.SysNo;
            upd.UpdateTo = request;
            var param = Mapper.Map<UpdateGroupActivityInfo, UpdateGroupActivityRequest>(upd);
            var response = MKMSClient.Send<UpdateGroupActivityResponse>(param);
            return response.DoFlag;
        }

        //查询活动信息
        public GroupActivityRefer QueryGroupActivity(GroupActivityRefer refer)
        {
            var obj = refer.SearchDetail;

            var result = new GroupActivityRefer();
            var param = new QueryGroupActivityRequest()
            {
                SysNo = obj.SysNo,
                GroupActivityName = obj.GroupActivityName,
                IntBeforePay = obj.IntBeforePay,
                PageIndex = refer.PageIndex ?? 1,
                PageSize = 20
            };
            var response = MKMSClient.Send<QueryGroupActivityResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<GroupActivityInfo, GroupActivityDetailExt>(response.GroupActivityInfoDto);
            }
            return result;
        }


        //查询参团记录
        public GroupRecordRefer QueryGroupRecord(GroupRecordRefer refer)
        {
            var obj = refer.SearchDetail;

            var result = new GroupRecordRefer();
            var param = new QueryGroupRecordRequest()
            {
                UserId = obj.UserId,
                GroupActivitySysNo = obj.GroupActivitySysNo,
            };
            var response = MKMSClient.Send<QueryGroupRecordResponse>(param);
            if (response.DoFlag)
            {
                result.List2 = Mapper.MappGereric<GroupRecord, GroupRecordDetailExt>(response.GroupRecordsDto);
            }
            return result;
        }

    }
}
