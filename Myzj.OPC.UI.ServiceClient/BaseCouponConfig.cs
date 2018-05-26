using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using MYZJ.Authorization.Dto;
using MYZJ.Finance.UI.Common;
using MYZJ.Promotion.Engine.ServiceModel;
using MYZJ.Promotion.Engine.ServiceModel.ForUI;
using Myzj.Goods.ServiceModel;
using Myzj.Goods.ServiceModel.UnifyGoods;
using Myzj.MKMS.ServiceModel.Coupon;
using MYZJ.UIS.ServiceModel;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.ServiceClient
{


    public class BaseCouponConfigClient : BaseSingleton<BaseCouponConfigClient>
    {
        #region 单例

        //private BaseCouponConfigClient()
        //{
        //}
        //private static readonly object Lockobj = new object();
        //private static BaseCouponConfigClient _instance;
        //public static BaseCouponConfigClient Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (Lockobj)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new BaseCouponConfigClient();
        //                }
        //            }
        //        }
        //        return _instance;
        //    }
        //}

        #endregion

        /// <summary>
        /// 1新增优惠券
        /// </summary>
        /// <param name="request">实体</param>
        /// <returns></returns>
        public bool AddCouponInfo(CouponInfoDetailExt request)
        {
            var param = Mapper.Map<CouponInfoDetailExt, AddCouponInfo>(request);
            param.UserId = request.CreatePeople;
            var response = MKMSClient.Send<AddCouponInfoResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 2修改优惠券
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool UpdateCouponInfo(CouponInfoDetailExt request)
        {
            var param = Mapper.Map<CouponInfoDetailExt, CouponInfoDto>(request);
            var response = MKMSClient.Send<UpdateCouponInfoResponse>(new UpdateCouponInfo
                {
                    SysNo = request.SysNo,
                    CouponKey = request.CouponKey,
                    UserId = request.UpdatePeople,
                    UpdateTo = param
                });
            return response.DoFlag;
        }

        public bool UpdateAuditLevel(int? SysNo, int? AuditeLevel)
        {

            var response = MKMSClient.Send<UpdateAuditLevelRes>(new UpdateAuditLevel
            {
                SysNo = SysNo,
                AuditLevel = AuditeLevel
            });
            return response.DoFlag;
        }

        /// <summary>
        /// 3删除与禁用优惠券
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="sysNo">优惠券SysNo</param>
        /// <param name="type">0删除,1(禁用启用)</param>
        /// <param name="isTrue">true删除与启用,false禁用</param>
        /// <returns></returns>
        public bool DeleteCouponInfo(int? userId, int? sysNo, int? type, bool isTrue)
        {
            var param = new DeleteCouponInfo();
            param.UserId = userId;
            param.SysNo = sysNo;
            if ((type ?? 0) == 0)
            {
                param.IsDelete = true;
            }
            else
            {
                param.IsEnable = isTrue;
            }

            var response = MKMSClient.Send<DeleteCouponInfoResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sysNo"></param>
        /// <param name="userId"></param>
        /// <param name="auditState"></param>
        /// <param name="operationType"></param>
        /// <returns></returns>
        public bool UpdateAuditState(int? sysNo, int? userId, int? auditState, int? operationType)
        {
            var param = new UpdateAuditStateRequest()
                {
                    SysNo = sysNo,
                    UserId = userId,
                    OperationType = operationType,
                    AuditState = auditState
                };
            var response = MKMSClient.Send<UpdateAuditStateResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 4复制优惠券
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public bool CopyCouponInfo(int? userId, int? sysNo)
        {
            var param = new CopyCouponInfo
                {
                    UserId = userId,
                    SysNo = sysNo
                };
            var response = MKMSClient.Send<CopyCouponInfoResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 5查询优惠券列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CouponInfoDtailRefer QueryCouponInfoPageList(CouponInfoDtailRefer request)
        {
            var obj = request.SearchDetail;

            //var where = " and  a.IsDelete=0";
            var where = "";
            where = " and a.SysNo NOT IN(SELECT SysNo FROM dbo.C_CouponInfo WHERE a.IsDelete=1 AND a.AuditState=2) ";
            if (!string.IsNullOrEmpty(obj.CouponKey))
            {
                where += " AND a.CouponKey LIKE '%" + obj.CouponKey + "%'";
            }
            if (!string.IsNullOrEmpty(obj.CouponName))
            {
                where += " AND a.CouponName LIKE '%" + obj.CouponName + "%'";
            }
            if ((obj.SysNo ?? 0) != 0)
            {
                where += " AND  a.SysNo=" + obj.SysNo + " ";
            }
            if (obj.AuditState != null)
            {
                where += " AND a.AuditState =" + obj.AuditState + " ";
            }
            if (obj.Status != null && obj.Status != -1)
            {
                if (obj.Status == 3)//已删除
                {
                    where += " and  a.IsDelete=1";
                }
                else
                {
                    where += " and  a.IsDelete=0";
                    if (obj.Status == 4)//已禁用
                    {
                        where += " and  a.IsEnable=0";

                    }
                    else
                    {
                        where += " and  a.IsEnable=1";
                        if (obj.Status == 0)//未开始
                        {
                            where += " And a.StartTime>'" + DateTime.Now + "'";
                        }
                        else if (obj.Status == 1)//可使用
                        {
                            where += " And a.StartTime<='" + DateTime.Now + "' And a.EndTime>'" + DateTime.Now + "'";
                        }
                        else if (obj.Status == 2)//已过期
                        {
                            where += " And a.EndTime<='" + DateTime.Now + "'";
                        }
                    }
                }
            }
            if (obj.StartTime.HasValue)
            {
                where += " And a.StartTime>='" + obj.StartTime + "'";
            }
            if (obj.EndTime.HasValue)
            {
                where += " And a.EndTime<='" + obj.EndTime + "'";
            }

            //if (obj.StartTime.HasValue && !obj.EndTime.HasValue)
            //{
            //    where += " And a.StartTime>='" + obj.StartTime + "'";
            //    //where += " And a.EndTime>'" + obj.StartTime + "'";
            //}
            //if (obj.StartTime.HasValue && obj.EndTime.HasValue)
            //{
            //    //where += " And a.StartTime>='" + obj.StartTime + "'";
            //    //where += " And a.EndTime<='" + obj.EndTime + "'";
            //    where += " And a.EndTime>'" + obj.StartTime + "'";
            //}
            //if (!obj.StartTime.HasValue && obj.EndTime.HasValue)
            //{
            //    where += " And a.EndTime<='" + obj.EndTime + "'";
            //}

            if (obj.CouponType.HasValue && obj.CouponType == 2)
            {
                where += " And a.BasicsExt like '%\"CouponType\":\"" + obj.CouponType + "\"%'";
            }
            else if (obj.CouponType.HasValue && obj.CouponType == 0)
            {
                where += " And a.SysNo NOT IN(SELECT SysNo FROM dbo.C_CouponInfo WHERE BasicsExt like '%\"CouponType\":\"" + 2 + "\"%') ";
            }
           
            if (obj.IsCodeToCoupon.HasValue && obj.IsCodeToCoupon == 1)
            {
                where += "And a.BasicsExt like '%\"IsCodeToCoupon\":\"" + obj.IsCodeToCoupon + "\"%'";
            }
            else if (obj.IsCodeToCoupon.HasValue && obj.IsCodeToCoupon == 0)
            {
                where += " And a.SysNo NOT IN(SELECT SysNo FROM dbo.C_CouponInfo WHERE BasicsExt like '%\"IsCodeToCoupon\":\"" + 1 + "\"%') ";
            }

            if (obj.IsGetCoupon.HasValue && obj.IsGetCoupon == 1)
            {
                where += "And a.BasicsExt like '%\"IsGetCoupon\":\"true\"%'";
            }
            else if (obj.IsGetCoupon.HasValue && obj.IsGetCoupon == 0)
            {
                where += " And a.SysNo NOT IN(SELECT SysNo FROM dbo.C_CouponInfo WHERE BasicsExt like '%\"IsGetCoupon\":\"true\"%') ";
            }

            if (obj.IsShowOnDetail.HasValue && obj.IsShowOnDetail == 1)
            {
                where += "And a.BasicsExt like '%\"IsShowOnDetail\":\"true\"%'";
            }
            else if (obj.IsShowOnDetail.HasValue && obj.IsShowOnDetail == 0)
            {
                where += " And a.SysNo NOT IN(SELECT SysNo FROM dbo.C_CouponInfo WHERE BasicsExt like '%\"IsShowOnDetail\":\"true\"%') ";
            }

            var result = new CouponInfoDtailRefer();
            var param = new QueryCouponInfoPageList
                {
                    where = where,
                    order = " ORDER by a.UpdateTime desc",
                    PageIndex = request.PageIndex ?? 1,
                    PageSize = 20
                };

            var response = MKMSClient.Send<QueryCouponInfoPageListResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;//total
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
               
                result.List2 = Mapper.MappGereric<CouponInfoDto, CouponInfoDetailExt>(response.CouponInfoPageListDtos);//result
            }
           
            var list = ConvertCouponList(result);
            //if (list != null && list.Count > 0)
            //{
            //    if (obj.CouponType.HasValue && obj.CouponType == 2) //折扣券
            //    {
            //        list = list.Where(m => m.CouponType == obj.CouponType).ToList();
            //    }
            //    else if (obj.CouponType.HasValue && obj.CouponType == 0) //满减券
            //    {
            //        list = list.Where(m => m.CouponType != 2).ToList();
            //    }

            //    if (obj.IsCodeToCoupon.HasValue && obj.IsCodeToCoupon == 1)  //码转券
            //    {
            //        list = list.Where(m => m.IsCodeToCoupon == 1).ToList();
            //    }
            //    else if (obj.IsCodeToCoupon.HasValue && obj.IsCodeToCoupon == 0) //普通券
            //    {
            //        list = list.Where(m => m.CouponType != 1).ToList();
            //    }
            //}


            result.List2 = list;
            return result;
        }

        /// <summary>
        /// 查询品牌列表
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public Dictionary<int?, string> QueryBrandList(string brandName = null)
        {
            var param = new QueryBrandListReq
                {
                    BrandName = brandName
                };
            var dic = new Dictionary<int?, string>();
            var result = GoodsClient.Send<QueryBrandListRes>(param);
            if (result.DoFlag)
            {
                foreach (var item in result.BrandList)
                {
                    if (item.BrandID.HasValue)
                        dic.Add(item.BrandID, item.BrandName);
                }
            }
            return dic;
        }

        /// <summary>
        /// 获得所有部门列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int?, string> GetDeptList()
        {

            var dic = new Dictionary<int?, string>();
            var param = new QueryDepartmentServiceReq();
            var result = PromotionClient.Send<QueryDepartmentServiceRes>(param);
            if (result.DoFlag)
            {
                foreach (var item in result.QueryDepartmentServiceDtos)
                {
                    if (item.SysNo.HasValue)
                        dic.Add(item.SysNo, item.DepShortName);
                }
            }
            return dic;
        }
        /// <summary>
        /// 查询促销类型
        /// </summary>
        /// <returns></returns>
        public Dictionary<int?, string> GetPromotionList()
        {
            var dic = new Dictionary<int?, string>();
            var result = PromotionClient.Send<QueryPromTypeByResponse>(new QueryPromTypeBy { });
            if (result.DoFlag)
            {
                foreach (var item in result.QueryPromTypeDtos)
                {
                    if (item.PromTypeSysNo.HasValue)
                        dic.Add(item.PromTypeSysNo, item.PromTypeName);
                }
            }
            return dic;
        }

        /// <summary>
        /// 统计优惠券 已领取 或者 已使用的数量
        /// </summary>
        /// <param name="couponKey"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isUsed"></param>
        /// <returns></returns>
        public int CountCoupon(string couponKey, DateTime? startTime, DateTime? endTime, bool? isUsed)
        {
            var param = new CountCouponRequest()
                {
                    CouponKey = couponKey,
                    StartTime = startTime,
                    EndTime = endTime,
                    IsUsed = isUsed
                };
            var result = MKMSClient.Send<CountCouponResponse>(param);
            var count = 0;
            if (result.DoFlag)
            {
                count = result.Total;
            }
            return count;
        }

        /// <summary>
        /// 6查询单条优惠券
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CouponInfoDetailExt QueryCouponInfoEntity(int? sysNo)
        {
            var result = new CouponInfoDetailExt();
            var param = new QueryCouponInfoEntity()
                {
                    SysNo = sysNo
                };
            var response = MKMSClient.Send<QueryCouponInfoEntityResponse>(param);
            if (response.DoFlag)
            {
                result = Mapper.Map<CouponInfoDto, CouponInfoDetailExt>(response.CouponInfoEntity);
                var baseExt = result.BasicsExt;
                var obj = JsonConvert.DeserializeObject<M_BasicsExtInfo>(baseExt);
                if (obj != null)
                {
                    result.SendLimitUserCount = obj.SendLimitUserCount;
                    result.SendLimitCount = obj.SendLimitCount;
                    result.WillReachWarning = obj.WillReachWarning ?? 0;
                    result.UseSetDays = obj.UseSetDays;
                    if (obj.BatchUses != null)
                        result.BatchUses = obj.BatchUses;
                    result.DeptId = obj.DeptId;
                    result.CouponType = obj.CouponType;
                    result.Discount = obj.Discount;
                    result.DiscountUpperLimit = obj.DiscountUpperLimit;
                    result.IsCodeToCoupon = obj.IsCodeToCoupon;
                    result.IsGetCoupon = obj.IsGetCoupon;
                    result.IsShowOnDetail = obj.IsShowOnDetail;
                  //  result.CouponCategorySource = obj.CouponCategorySource;
                }

                var ruleExt = result.CouponRule;
                var obj2 = JsonConvert.DeserializeObject<M_CouponRuleInfo>(ruleExt);
                if (obj2 != null)
                {
                    result.Platform = obj2.PlatformEntity.Platform;
                    result.ApplicableFirstCategory = obj2.GoodsEntity.ApplicableFirstCategory;
                    result.ApplicableSecondCategory = obj2.GoodsEntity.ApplicableSecondCategory;
                    result.ApplicableThreeCategory = obj2.GoodsEntity.ApplicableThreeCategory;
                    result.ExcludeFirstCategory = obj2.GoodsEntity.ExcludeFirstCategory;
                    result.ExcludeSecondCategory = obj2.GoodsEntity.ExcludeSecondCategory;
                    result.ExcludeThreeCategory = obj2.GoodsEntity.ExcludeThreeCategory;

                    result.C_ApplicableFirstCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ApplicableFirstCategory));//分类名称
                    result.C_ApplicableSecondCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ApplicableSecondCategory));//分类名称
                    result.C_ApplicableThreeCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ApplicableThreeCategory));//分类名称
                    result.C_ExcludeFirstCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ExcludeFirstCategory));//分类名称
                    result.C_ExcludeSecondCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ExcludeSecondCategory));//分类名称
                    result.C_ExcludeThreeCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ExcludeThreeCategory));//分类名称

                    result.ApplicableGoodsId = obj2.GoodsEntity.ApplicableGoodsId;
                    result.ExcludeGoodsId = obj2.GoodsEntity.ExcludeGoodsId;

                    result.ApplicablePromotion = obj2.PromotionEntity.ApplicablePromotion;
                    result.ExcludePromotion = obj2.PromotionEntity.ExcludePromotion;

                    result.ApplicableMemberLevel = obj2.MemberLevelEntity.ApplicableMemberLevel;

                    result.ApplicablePosition = obj2.PositionEntity.ApplicablePosition;
                    result.MallType = obj2.MallTypeEntity.MallType;
                    result.PromType = obj2.PromTypeEntity == null ? null : obj2.PromTypeEntity.PromType;
                    result.Supplier = obj2.SupplierEntity.Supplier;
                    result.Special = obj2.SpecialEntity.Special;
                    result.ApplicableBrand = obj2.BrandEntity.ApplicableBrand;
                    result.ExcludeBrand = obj2.BrandEntity.ExcludeBrand;
                }
            }
            return result;
        }

        /// <summary>
        /// 7批量审核优惠券
        /// </summary>
        /// <param name="request">审核记录List</param>
        /// <param name="auditPeople">审核人id</param>
        /// <returns></returns>
        public bool CouponBatchAudit(List<CouponAuditDetail> request, int? auditPeople)
        {
            var param = new CouponBatchAudit
                {
                    CouponsAudit = Mapper.MappGereric<CouponAuditDetail, CouponBatchAuditList>(request),
                    UserId = auditPeople//审核人
                };
            var response = MKMSClient.Send<CouponBatchAuditResponse>(param);
            return response.DoFlag;
        }

        /// <summary>
        /// 8查询审核历史记录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CouponAuditRefer QueryCouponAuditPageList(CouponAuditRefer request, List<int?> auditLevel = null)
        {
            var obj = request.SearchDetail;
            var where = " AND b.IsDelete=0 AND a.AuditState=0";//待审核的

            if (!string.IsNullOrEmpty(obj.CouponKey))
            {
                where += " AND a.CouponKey LIKE '%" + obj.CouponKey + "%'";
            }
            if (!string.IsNullOrEmpty(obj.CouponName))
            {
                where += " AND a.CouponName LIKE '%" + obj.CouponName + "%'";
            }
            if (obj.AuditState.HasValue)
            {
                where += " AND a.AuditState =" + obj.AuditState;
            }
            if (obj.IsDelete != null)
            {
                where += " AND a.IsDelete ='" + obj.IsDelete + "' ";
            }
            if (obj.IsEnable != null)
            {
                where += " AND a.IsEnable ='" + obj.IsEnable + "' ";
            }
            if ((obj.SysNo ?? 0) != 0)
            {
                where += " AND  a.SysNo=" + obj.SysNo + " ";
            }
            if (auditLevel != null)
            {
                where += " And b.AuditLevel in (" + string.Join(",", auditLevel) + ")";
            }
            var result = new CouponAuditRefer();
            var param = new QueryCouponAuditPageList
            {
                where = where,
                order = " ORDER by a.UpdateTime desc",
                PageIndex = request.PageIndex ?? 1,
                PageSize = 20
            };

            var response = MKMSClient.Send<QueryCouponAuditPageListResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;//total
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<QueryCouponAuditPageListDto, CouponAuditDetailExt>(response.QueryCouponAuditPageListDtos);//result
            }
            result.List2 = ConvertCouponAuditList(result);//转化json参数字段
            result.SearchDetail = obj;
            return result;
        }

        /// <summary>
        /// convert audit
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public List<CouponAuditDetailExt> ConvertCouponAuditList(CouponAuditRefer result)
        {
            var extList = new List<CouponAuditDetailExt>();
            foreach (var item in result.List2)
            {
                var baseExt = item.BasicsExt;
                var aa = JsonConvert.DeserializeObject<M_BasicsExtInfo>(baseExt);
                if (aa != null)
                {
                    item.SendLimitUserCount = aa.SendLimitUserCount;
                    item.SendLimitCount = aa.SendLimitCount;
                    item.UseSetDays = aa.UseSetDays;
                    if (aa.BatchUses != null)
                        item.BatchUses = aa.BatchUses;
                }

                var ruleExt = item.CouponRule;
                try
                {
                    var obj2 = JsonConvert.DeserializeObject<M_CouponRuleInfo>(ruleExt);
                    if (obj2 != null)
                    {
                        item.Platform = obj2.PlatformEntity.Platform;
                        item.ApplicableFirstCategory = obj2.GoodsEntity.ApplicableFirstCategory;
                        item.ApplicableSecondCategory = obj2.GoodsEntity.ApplicableSecondCategory;
                        item.ApplicableThreeCategory = obj2.GoodsEntity.ApplicableThreeCategory;
                        item.ExcludeFirstCategory = obj2.GoodsEntity.ExcludeFirstCategory;
                        item.ExcludeSecondCategory = obj2.GoodsEntity.ExcludeSecondCategory;
                        item.ExcludeThreeCategory = obj2.GoodsEntity.ExcludeThreeCategory;
                        item.ApplicableGoodsId = obj2.GoodsEntity.ApplicableGoodsId;
                        item.ExcludeGoodsId = obj2.GoodsEntity.ExcludeGoodsId;

                        item.ApplicablePromotion = obj2.PromotionEntity.ApplicablePromotion;
                        item.ExcludePromotion = obj2.PromotionEntity.ExcludePromotion;

                        item.ApplicableMemberLevel = obj2.MemberLevelEntity.ApplicableMemberLevel;

                        item.ApplicablePosition = obj2.PositionEntity.ApplicablePosition;
                        item.MallType = obj2.MallTypeEntity.MallType;
                        item.Supplier = obj2.SupplierEntity.Supplier;
                        item.Special = obj2.SpecialEntity.Special;
                        item.ApplicableBrand = obj2.BrandEntity.ApplicableBrand;
                        item.ExcludeBrand = obj2.BrandEntity.ExcludeBrand;
                    }
                    extList.Add(item);
                }
                catch (Exception)
                {

                }
            }
            return extList;
        }

        /// <summary>
        /// convert
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public List<CouponInfoDetailExt> ConvertCouponList(CouponInfoDtailRefer result)
        {
            var extList = new List<CouponInfoDetailExt>();
            foreach (var item in result.List2)
            {
                try
                {
                    var baseExt = item.BasicsExt;

                    var aa = JsonConvert.DeserializeObject<M_BasicsExtInfo>(baseExt);
                    if (aa != null)
                    {
                        item.SendLimitUserCount = aa.SendLimitUserCount;
                        item.SendLimitCount = aa.SendLimitCount;
                        item.UseSetDays = aa.UseSetDays;
                        if (aa.BatchUses != null)
                            item.BatchUses = aa.BatchUses;

                        item.CouponType = aa.CouponType;
                        item.Discount = aa.Discount;
                        item.DiscountUpperLimit = aa.DiscountUpperLimit;
                        item.IsCodeToCoupon = aa.IsCodeToCoupon;
                        item.IsGetCoupon = aa.IsGetCoupon;
                        item.IsShowOnDetail = aa.IsShowOnDetail;
                    }

                    var ruleExt = item.CouponRule;

                    var obj2 = JsonConvert.DeserializeObject<M_CouponRuleInfo>(ruleExt);
                    if (obj2 != null)
                    {
                        item.Platform = obj2.PlatformEntity.Platform;
                        item.ApplicableFirstCategory = obj2.GoodsEntity.ApplicableFirstCategory;
                        item.ApplicableSecondCategory = obj2.GoodsEntity.ApplicableSecondCategory;
                        item.ApplicableThreeCategory = obj2.GoodsEntity.ApplicableThreeCategory;
                        item.ExcludeFirstCategory = obj2.GoodsEntity.ExcludeFirstCategory;
                        item.ExcludeSecondCategory = obj2.GoodsEntity.ExcludeSecondCategory;
                        item.ExcludeThreeCategory = obj2.GoodsEntity.ExcludeThreeCategory;
                        item.ApplicableGoodsId = obj2.GoodsEntity.ApplicableGoodsId;
                        item.ExcludeGoodsId = obj2.GoodsEntity.ExcludeGoodsId;

                        item.ApplicablePromotion = obj2.PromotionEntity.ApplicablePromotion;
                        item.ExcludePromotion = obj2.PromotionEntity.ExcludePromotion;

                        item.ApplicableMemberLevel = obj2.MemberLevelEntity.ApplicableMemberLevel;

                        item.ApplicablePosition = obj2.PositionEntity.ApplicablePosition;
                        item.MallType = obj2.MallTypeEntity.MallType;
                        item.PromType = obj2.PromTypeEntity == null ? null : obj2.PromTypeEntity.PromType;
                        item.Supplier = obj2.SupplierEntity.Supplier;
                        item.Special = obj2.SpecialEntity.Special;
                        item.ApplicableBrand = obj2.BrandEntity.ApplicableBrand;
                        item.ExcludeBrand = obj2.BrandEntity.ExcludeBrand;
                    }
                }
                catch (Exception e)
                {

                }
                extList.Add(item);
            }
            return extList;
        }

        /// <summary>
        /// 查询发货仓库
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WareHouseDetail> QueryWareHouseList()
        {
            //var req = new QueryWareHouse();
            //var res = GoodsClient.Send<QueryWareHouseResponse>(req);
            // var result = Mapper.MappGereric<QueryWareHouseDto, WareHouseDetail>(res.QueryWareHouseDtos);
            var req = new ShowStock();
            var res = UisJsonServiceClient.Send<ShowStockResponse>(req);

            var wareHouse = new List<WareHouseDetail>();
            foreach (var item in res.StockPocos)
            {
                var detail = new WareHouseDetail();
                detail.Id = item.StockNo;
                detail.WarehouseName = item.StockName;
                wareHouse.Add(detail);
            }
            return wareHouse;
        }

        /// <summary>
        /// 查询分类名称
        /// </summary>
        /// <param name="IntCateId"></param>
        /// <returns></returns>
        public string QueryWebCateName(string IntCateId)
        {
            var res = MKMSClient.Send<QueryWebCateNameResponse>(new QueryWebCateName
                {
                    IntCateId = IntCateId
                });
            var result = res.DoResult;
            return result;
        }

        /// <summary>
        /// 发送优惠券
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool SendCopuonFunction(CouponSendDetail request, out string DoResult, out string Success, out string Error)
        {
            var param = new SendCoupon
                {
                    Operator = request.Operator,
                    ClientIp = request.ClientIp,
                    SourceTypeSysNo = 102,
                    GuidEquipment = Guid.NewGuid().ToString(),
                    SendSource = "运营后台系统发券",
                    Sends = Mapper.MappGereric<M_SendInfo, SendInfo>(request.Sends),
                };
            var response = MKMSClient.Send<SendCouponResponse>(param);
            Success = JsonConvert.SerializeObject(response.ResultSendSuccess);
            Error = JsonConvert.SerializeObject(response.ResultSendFailure);
            DoResult = response.DoResult;
            return response.DoFlag;

        }

        /// <summary>
        /// 发送优惠券记录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SendCouponRecordRefer QuerySendCouponPageList(SendCouponRecordRefer request)
        {
            var obj = request.SearchDetail;
            var where = " 1=1 And TM.IsDelete=0 And TD.IsDelete=0";
            if (!string.IsNullOrEmpty(obj.CouponKey))
            {
                where += " And TM.CouponKey='" + obj.CouponKey + "'";
            }
            if (obj.UserId.HasValue)
                where += " And TM.UserId=" + obj.UserId;
            if (obj.SysNo.HasValue)
                where += " And TD.SysNo=" + obj.SysNo;
            if (!string.IsNullOrWhiteSpace(obj.DiscountCode))
            {
                where += " And TM.DiscountCode='" + obj.DiscountCode + "'";
            }
            if (!string.IsNullOrEmpty(obj.CouponName))
            {
                where += " And TD.CouponName like '%" + obj.CouponName + "%' ";
            }
            var result = new SendCouponRecordRefer();
            var param = new QuerySendCouponPageList
            {
                Where = where,
                PageIndex = request.PageIndex ?? 1,
                PageSize = 20
            };
            var response = MKMSClient.Send<QuerySendCouponPageListResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<QuerySendCouponPageListDto, SendCouponRecordDetailExt>(response.QuerySendCouponPageListDtos);
            }
            return result;
        }

        /// <summary>
        /// 用户优惠券作废
        /// </summary>
        /// <param name="SysNos"></param>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public string CancelCoupon(List<int> SysNos, string remarks)
        {

            var param = new CancelCouponRequest()
                {
                    SysNos = SysNos,
                    Remarks = remarks
                };
            var response = MKMSClient.Send<CancelCouponResponse>(param);
            if (response.DoFlag)
            {
                return response.DoResult;
            }
            return null;
        }

        /// <summary>
        /// 查询优惠券操作记录
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<CouponLogDetail, CouponLogDetailExt> QueryCouponLog(BaseRefer<CouponLogDetail, CouponLogDetailExt> refer)
        {
            var obj = refer.SearchDetail ?? new CouponLogDetail();
            var param = new QueryCouponLogRequest()
            {
                PageIndex = refer.PageIndex,
                PageSize = 20,
                CouponKey = obj.CouponKey
            };
            var result = new BaseRefer<CouponLogDetail, CouponLogDetailExt>();
            var response = MKMSClient.Send<QueryCouponLogResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<CouponLog, CouponLogDetailExt>(response.CouponLogDto);
            }

            return result;
        }
        /// <summary>
        /// 查询优惠券操作明细
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public Dictionary<CouponInfoData, CouponInfoData> QueryCouponLogDetail(int sysNo)
        {
            var dic = new Dictionary<CouponInfoData, CouponInfoData>();
            var param = new QueryCouponLogBySysNoRequest()
            {
                SysNo = sysNo
            };

            var response = MKMSClient.Send<QueryCouponLogBySysNoResponse>(param);
            if (response.DoFlag)
            {
                var cld = Mapper.Map<CouponLogData, CouponLogDetailExt>(response.CouponLogDataDto);
                if (cld != null)
                {
                    try
                    {
                        var d1 = JsonConvert.DeserializeObject<List<CouponInfoData>>(cld.OldData);
                        var d2 = JsonConvert.DeserializeObject<List<CouponInfoData>>(cld.NewData);
                        var oldData = new CouponInfoData();
                        var newData = new CouponInfoData();
                        if (d1 != null)
                        {
                            oldData = GetData(d1.First());
                        }
                        if (d2 != null)
                        {
                            newData = GetData(d2.First());
                        }
                        dic.Add(oldData, newData);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return dic;
        }

        public CouponInfoData GetData(CouponInfoData data)
        {
            var baseExt = data.BasicsExt;
            var obj = JsonConvert.DeserializeObject<M_BasicsExtInfo>(baseExt);
            if (obj != null)
            {
                data.SendLimitUserCount = obj.SendLimitUserCount;
                data.SendLimitCount = obj.SendLimitCount;
                data.WillReachWarning = obj.WillReachWarning ?? 0;
                data.UseSetDays = obj.UseSetDays;
                if (obj.BatchUses != null)
                    data.BatchUses = obj.BatchUses;
                data.DeptId = obj.DeptId;
                data.CouponType = obj.CouponType;
                data.IsCodeToCoupon = obj.IsCodeToCoupon;
                data.Discount = obj.Discount;
                data.DiscountUpperLimit = obj.DiscountUpperLimit;
                data.IsGetCoupon = obj.IsGetCoupon;
                data.IsShowOnDetail = obj.IsShowOnDetail;
               // data.CouponCategorySource = obj.CouponCategorySource;
            }

            var ruleExt = data.CouponRule;
            var obj2 = JsonConvert.DeserializeObject<M_CouponRuleInfo>(ruleExt);
            if (obj2 != null)
            {
                data.Platform = obj2.PlatformEntity.Platform;
                data.ApplicableFirstCategory = obj2.GoodsEntity.ApplicableFirstCategory;
                data.ApplicableSecondCategory = obj2.GoodsEntity.ApplicableSecondCategory;
                data.ApplicableThreeCategory = obj2.GoodsEntity.ApplicableThreeCategory;
                data.ExcludeFirstCategory = obj2.GoodsEntity.ExcludeFirstCategory;
                data.ExcludeSecondCategory = obj2.GoodsEntity.ExcludeSecondCategory;
                data.ExcludeThreeCategory = obj2.GoodsEntity.ExcludeThreeCategory;

                data.C_ApplicableFirstCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ApplicableFirstCategory));//分类名称
                data.C_ApplicableSecondCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ApplicableSecondCategory));//分类名称
                data.C_ApplicableThreeCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ApplicableThreeCategory));//分类名称
                data.C_ExcludeFirstCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ExcludeFirstCategory));//分类名称
                data.C_ExcludeSecondCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ExcludeSecondCategory));//分类名称
                data.C_ExcludeThreeCategory = QueryWebCateName(string.Join(",", obj2.GoodsEntity.ExcludeThreeCategory));//分类名称

                data.ApplicableGoodsId = obj2.GoodsEntity.ApplicableGoodsId;
                data.ExcludeGoodsId = obj2.GoodsEntity.ExcludeGoodsId;

                data.ApplicablePromotion = obj2.PromotionEntity.ApplicablePromotion;
                data.ExcludePromotion = obj2.PromotionEntity.ExcludePromotion;

                data.ApplicableMemberLevel = obj2.MemberLevelEntity.ApplicableMemberLevel;

                data.ApplicablePosition = obj2.PositionEntity.ApplicablePosition;
                data.MallType = obj2.MallTypeEntity.MallType;
                data.PromType = obj2.PromTypeEntity == null ? null : obj2.PromTypeEntity.PromType;
                data.Supplier = obj2.SupplierEntity.Supplier;
                data.Special = obj2.SpecialEntity.Special;
                data.ApplicableBrand = obj2.BrandEntity.ApplicableBrand;
                data.ExcludeBrand = obj2.BrandEntity.ExcludeBrand;
            }
            return data;
        }


        #region 优惠券导入批次

        //添加导入批次
        public bool AddCouponBatchSend(string batchFileName, DateTime? advanceTime, int? userid, string applyPeople, DateTime? applyTime, int? exeState, int? exeType, string exeDescription)
        {
            var param = new AddCouponBatchSendRequest()
                {
                    BatchFileName = batchFileName,
                    AdvanceTime = advanceTime,
                    ApplyUserId = userid,
                    ApplyPeople = applyPeople,
                    ApplyTime = applyTime,
                    ExeState = exeState,
                    ExeType = exeType,
                    ExeDescription = exeDescription
                };
            var response = MKMSClient.Send<AddCouponBatchSendResponse>(param);
            return response.DoFlag;
        }

        //查询导入批次
        public BaseRefer<CouponBatchSendDetail, CouponBatchSendDetailExt> QueryCouponBatchSend(BaseRefer<CouponBatchSendDetail, CouponBatchSendDetailExt> refer)
        {
            var obj = refer.SearchDetail ?? new CouponBatchSendDetail();
            if (obj.ExeState == -2)
            {
                obj.ExeState = null;
            }
            var param = new QueryCouponBatchSendRequest()
            {
                PageIndex = refer.PageIndex ?? 1,
                PageSize = 20,
                BatchFileName = obj.BatchFileName,
                ApplyPeople = obj.ApplyPeople,
                ExeState = obj.ExeState
            };
            var result = new BaseRefer<CouponBatchSendDetail, CouponBatchSendDetailExt>();
            var response = MKMSClient.Send<QueryCouponBatchSendResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<CouponBatchSend, CouponBatchSendDetailExt>(response.CouponBatchSendDto);
            }

            return result;
        }
        //执行导入
        public bool ExeImprot(int? sysNo)
        {
            var param = new CouponBatchSendRequest()
                {
                    SysNo = sysNo
                };
            var response = MkmsServiceClient.Send<CouponBatchSendResponse>(param);
            return response.DoFlag;
        }


        //取消执行
        public bool CancelCouponBatchSend(int sysNo)
        {
            var param = new CancelCouponBatchRequest()
                {
                    SysNo = sysNo
                };
            var response = MKMSClient.Send<CancelCouponBatchResponse>(param);
            return response.DoFlag;
        }

        #endregion

        #region 优惠券审核角色管理

        //添加
        public bool AddRole(AuditRoleDetail role, out string result)
        {
            var param = new AddRoleRequest()
            {
                AuditRole = role.AuditRole,
                RoleName = role.RoleName,
                Remarks = role.Remarks,
                CreateTime = DateTime.Now,
                IsDelete = false
            };

            var response = MKMSClient.Send<AddRoleResponse>(param);
            result = response.DoResult;
            return response.DoFlag;
        }

        //修改
        public bool UpdateRole(AuditRoleDetail role, out string result)
        {
            var param = new UpdateRoleRequest()
            {
                SysNo = role.SysNo,
                AuditRole = role.AuditRole,
                RoleName = role.RoleName,
                Remarks = role.Remarks,
                IsDelete = role.IsDelete
            };

            var response = MKMSClient.Send<UpdateRoleResponse>(param);
            result = response.DoResult;
            return response.DoFlag;
        }

        //查询
        public List<AuditRoleDetail> QueryRole(int? sysNo = null)
        {
            var list = new List<AuditRoleDetail>();
            var param = new QueryRoleRequest()
                {
                    SysNo = sysNo
                };
            var response = MKMSClient.Send<QueryRoleResponse>(param);
            if (response.DoFlag)
            {
                list = Mapper.MappGereric<CouponAuditRole, AuditRoleDetail>(response.CouponAuditRoleList);
            }
            return list;
        }



        #endregion

        #region 优惠券审核用户角色配置

        //添加
        public bool AddUserRole(AuditRoleConfigDetailExt detail, out string message)
        {
            var param = new AddUserRoleRequest()
            {
                MemberId = detail.MemberId,
                MemberName = detail.MemberName,
                MemberRole = detail.MemberRole,
                Mobile = detail.Mobile,
                //  DeptId = detail.DeptId,
                Remarks = detail.Remarks,
                CreateTime = DateTime.Now,

            };

            var response = MKMSClient.Send<AddUserRoleResponse>(param);
            message = response.DoResult;
            return response.DoFlag;
        }

        //修改
        public bool UpdateUserRole(AuditRoleConfigDetailExt detail, out string message)
        {
            var param = new UpdateUserRoleRequest()
            {
                SysNo = detail.SysNo,
                MemberId = detail.MemberId,
                MemberName = detail.MemberName,
                MemberRole = detail.MemberRole,
                Mobile = detail.Mobile,
                // DeptId = detail.DeptId,
                Remarks = detail.Remarks,
                IsDelete = detail.IsDelete
            };

            var response = MKMSClient.Send<UpdateUserRoleResponse>(param);
            message = response.DoResult;
            return response.DoFlag;
        }

        //删除
        public bool DeleteUserRole(int? UserId)
        {
            //var param = new DeleteUserRoleRequest()
            //{
            //   UserId = UserId
            //};
            //var response = MKMSClient.Send<DeleteUserRoleResponse>(param);
            //return response.DoFlag;
            return false;
        }

        //查询
        public BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt> QueryUserRole(BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt> refer)
        {
            var obj = refer.SearchDetail ?? new AuditRoleConfigDetail();
            var param = new QueryUserRoleRequest()
                {
                    PageIndex = refer.PageIndex,
                    PageSize = 20,
                    SysNo = obj.SysNo,
                    MemberId = obj.MemberId,
                    MemberName = obj.MemberName,
                    MemberRole = obj.MemberRole,
                };
            var result = new BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt>();
            var response = MKMSClient.Send<QueryUserRoleResponse>(param);
            if (response.DoFlag)
            {
                result.List2 = Mapper.MappGereric<CouponAuditRoleConfigure, AuditRoleConfigDetailExt>(response.CouponAuditRoleConfigureList);
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.Total = response.Total;
            }
            return result;
        }

        public List<int?> GetUserRole(int? userId)
        {
            if (!userId.HasValue)
                return null;
            var param = new QueryUserRoleRequest()
            {
                MemberId = userId,
            };
            var result = new BaseRefer<AuditRoleConfigDetail, AuditRoleConfigDetailExt>();
            var response = MKMSClient.Send<QueryUserRoleResponse>(param);
            if (response.DoFlag)
            {
                result.List2 = Mapper.MappGereric<CouponAuditRoleConfigure, AuditRoleConfigDetailExt>(response.CouponAuditRoleConfigureList);
            }
            return result.List2.Select(m => m.MemberRole).ToList();
        }

        //获取所有的角色
        public Dictionary<int?, string> GetAllRole()
        {
            var list = new List<AuditRoleDetail>();
            var param = new QueryRoleRequest();

            var response = MKMSClient.Send<QueryRoleResponse>(param);
            if (response.DoFlag)
            {
                list = Mapper.MappGereric<CouponAuditRole, AuditRoleDetail>(response.CouponAuditRoleList);
            }
            return list.Where(item => item.AuditRole.HasValue).ToDictionary(item => item.AuditRole, item => item.RoleName);
        }


        //获取系统所有的部门
        public Dictionary<int, string> GetAllDept()
        {
            var result = AuthorizationServiceClient.Get<DepartmentFilterResponse>("/Department?SearchAll=true");
            return result.Entities.ToDictionary(item => item.SysNo, item => item.Name);
        }



        //获取当前部门下所有的用户
        public Dictionary<int, string> GetAllUser(int deptSysNo)
        {
            var dic = new Dictionary<int, string>();
            var result =
                AuthorizationServiceClient.Get<DepartmentResponse>(string.Format("/Department/{0}", deptSysNo));
            //if (result != null && result.Users != null && result.Users.Any())
            //{
            //    foreach (var item in result.Users)
            //    {
            //        dic.Add(item.SysNo, item.Name);
            //    }
            //}

            return dic;
        }

        #endregion

        #region 优惠劵审核等级规配置
        //添加
        public bool AddRule(AuditRuleDetail rule, out string message)
        {
            var param = new AddRuleRequest()
            {
                AuditLevelRuleName = rule.AuditLevelRuleName,
                AuditLevelRule = rule.AuditLevelRule,
                AuditLevel = rule.AuditLevel,
                Remarks = rule.Remarks,
                CreateTime = DateTime.Now,
            };

            var response = MKMSClient.Send<AddRuleResponse>(param);
            message = response.DoResult;
            return response.DoFlag;
        }

        //修改
        public bool UpdateRule(AuditRuleDetail rule, out string result)
        {
            var param = new UpdateRuleRequest()
            {
                SysNo = rule.SysNo,
                AuditLevelRuleName = rule.AuditLevelRuleName,
                AuditLevelRule = rule.AuditLevelRule,
                Remarks = rule.Remarks,
                IsDelete = rule.IsDelete
            };

            var response = MKMSClient.Send<UpdateRuleResponse>(param);
            result = response.DoResult;
            return response.DoFlag;
        }

        //查询
        public List<AuditRuleDetail> QueryRule(int? sysNo = null)
        {
            var list = new List<AuditRuleDetail>();
            var param = new QueryRuleRequest()
            {
                SysNo = sysNo
            };
            var response = MKMSClient.Send<QueryRuleResponse>(param);
            if (response.DoFlag)
            {
                list = Mapper.MappGereric<CouponAuditLevelRule, AuditRuleDetail>(response.CouponAuditRuleList);
            }
            return list;
        }
        //获取规则
        public AuditRules GetRule(string jsonStr)
        {
            try
            {
                var rule = JsonConvert.DeserializeObject<AuditRules>(jsonStr);
                return rule;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //根据CouponKey 获取审核等级
        public string GetAuditLevel(string couponKey)
        {
            var param = new CheckCouponAuditLevel()
            {
                CouponKey = couponKey
            };

            var response = MKMSClient.Send<CheckCouponAuditLevelResponse>(param);
            return response.DoResult;
        }

        #endregion

        public string GetStatus(int operationType)
        {
            switch (operationType)
            {
                case 1:
                    return "新增";

                case 2:
                    return "修改";

                case 3:
                    return "删除";

                case 4:
                    return "禁用/启用";

                case 5:
                    return "审核通过";

                case 6:
                    return "驳回";

                case 7:
                    return "作废";

                case 8:
                    return "提交审核";

            }
            return null;
        }

        public string GetAuditStatus(int? type)
        {
            //-1 编辑保存  0 待审核 1 驳回 2 审核通过
            switch (type)
            {
                case -1:
                    return "编辑保存";

                case 0:
                    return "待审核";

                case 1:
                    return "驳回";

                case 2:
                    return "审核通过";

            }
            return null;
        }

        /// <summary>
        /// 券的分类来源
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetCouponCategorySource()
        {
            var source = new Dictionary<int, string>();
            source.Add(0, "活动");
            source.Add(1, "招新_赠品_线上");
            source.Add(2, "招新_赠品_地推");
            source.Add(3, "招新_现金_线上");
            source.Add(4, "招新_现金_地推");
            source.Add(5, "会员福利");
            return source;
        }
    }
}
