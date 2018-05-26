using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.MKMS.ServiceModel.DiscountCode;
using Myzj.OPC.UI.Model.BaseDiscountCodeConfig;
using Myzj.OPC.UI.Model.Base;

namespace Myzj.OPC.UI.ServiceClient
{
    public class BaseDiscountCodeConfigClient : BaseService
    {
        #region 单例

        private BaseDiscountCodeConfigClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static BaseDiscountCodeConfigClient _instance;
        public static BaseDiscountCodeConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new BaseDiscountCodeConfigClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 新增优惠码活动
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool AddActivity(DiscountActivityRes request,out string message)
        {
            var param = new AddActivityRequest()
                {
                    ActivityName = request.ActivityName,
                    ActivityDescription = request.ActivityDescription,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Remark = request.Remark,
                    CodeType = request.CodeType,
                    SetCodeCount = request.SetCodeCount,
                    CreateCodeCount = 0,
                    LimitCount = request.LimitCount,
                    CouponKeys = request.CouponKeys,
                    CreateTime = DateTime.Now,
                    IsEnable = true,
                    IsDelete = false,
                    
                };
            var response = MKMSClient.Send<AddActivityResponse>(param);
            message = response.DoResult;
            return response.DoFlag;
        }

        /// <summary>
        /// 修改优惠码活动
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public bool UpdateActivity(DiscountActivityRes req, out string message)
        {
            var param = Mapper.Map<DiscountActivityRes, UpdateActivityRequest>(req);
            var response = MKMSClient.Send<UpdateActivityResponse>(param);
            message = response.DoResult;
            return response.DoFlag;
        }

        /// <summary>
        /// 查询优惠码活动
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<DiscountActivityReq, DiscountActivityRes> QueryDiscountActivityList(BaseRefer<DiscountActivityReq, DiscountActivityRes> refer)
        {
            var obj = refer.SearchDetail ?? new DiscountActivityReq();
            var param = new QueryActivityRequest()
            {
                SysNo = obj.SysNo,
                ActivityKey = obj.ActivityKey,
                ActivityName = obj.ActivityName,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime,
                CodeType=obj.CodeType,
                CouponKeys = obj.CouponKeys,
                PageIndex = refer.PageIndex ?? 1,
                PageSize = 30,
            };
            var result = new BaseRefer<DiscountActivityReq, DiscountActivityRes>();
            var response = MKMSClient.Send<QueryActivityResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<DiscountActivity, DiscountActivityRes>(response.DiscountActivityDto);
            }

            return result;
        }

        /// <summary>
        /// 添加优惠码预约执行批次
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AddDiscountBatch(DiscountCodeBatchRes request,out string message)
        {
            var param = new AddDiscountBatchRequest()
            {
                // SysNo = request.SysNo,
                ActivitySysNo = request.ActivitySysNo,
                BatchFileName = request.BatchFileName,
                SetCodeLength = request.SetCodeLength,
                CreateCodeNum = request.CreateCodeNum,
                AdvanceTime = request.AdvanceTime,
                ExeStatus = 0,//新建
                ExeDescription = request.ExeDescription,
                ApplyUserId = request.ApplyUserId,
                ApplyUserName = request.ApplyUserName,
                ApplyTime = DateTime.Now,
                OperationType = request.OperationType,
                // RowCreateDate = request.RowCreateDate,
                IsDelete = false,
            };
            var response = MKMSClient.Send<AddDiscountBatchResponse>(param);
            message = response.DoResult;
            return response.DoFlag;

        }

        public BaseRefer<DiscountCodeBatchReq, DiscountCodeBatchRes> QueryDiscountCodeBatchList(BaseRefer<DiscountCodeBatchReq, DiscountCodeBatchRes> refer)
        {
            var obj = refer.SearchDetail ?? new DiscountCodeBatchReq();
            var param = new QueryDiscountBatchRequest()
            {
                SysNo = obj.SysNo,
                ActivityName = obj.ActivityName,
                ApplyUserName = obj.ApplyUserName,
                ActivityKey = obj.ActivityKey,
                ExeStatus = obj.ExeStatus,
                PageIndex = refer.PageIndex ?? 1,
                PageSize = 30,
            };
            var result = new BaseRefer<DiscountCodeBatchReq, DiscountCodeBatchRes>();
            var response = MKMSClient.Send<QueryDiscountBatchResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<DiscountCodeBatch, DiscountCodeBatchRes>(response.DiscountCodeBatchDto);
            }

            return result;
        }

        //执行状态转换
        public string GetExeStatusStr(int? exeStatus)
        {
            switch (exeStatus)
            {
                case 0:
                    return "新建";
                case 1:
                    return "执行中";
                case 2:
                    return "完成";
                case 3:
                    return "失败";
                case 4:
                    return "取消";
            }
            return "";
        }

        public bool CancelExecuteBatch(int? sysNo, string operater)
        {
            var param = new UpdateDiscountBatchStateRequest()
                {
                    SysNo = sysNo,
                    ExeStatus = 4,  //取消执行
                    ExeDescription = "后台系统：取消执行，操作人：" + operater + ",操作时间：" + DateTime.Now,
                };
            var response = MKMSClient.Send<UpdateActivityResponse>(param);
            return response.DoFlag;
        }


        /// <summary>
        /// 查询用户优惠码
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<DiscountCodeUserReq, DiscountCodeUserRes> QueryDiscountCodeUserList(BaseRefer<DiscountCodeUserReq, DiscountCodeUserRes> refer)
        {
            var obj = refer.SearchDetail ?? new DiscountCodeUserReq();
            var param = new QueryDiscountUserRequest()
            {
                ActivityKey = obj.ActivityKey,
                DiscountCode = obj.DiscountCode,
                UserId = obj.UserId,
                State = obj.State,
                PageIndex = refer.PageIndex ?? 1,
                PageSize = 30,
            };
            var result = new BaseRefer<DiscountCodeUserReq, DiscountCodeUserRes>();
            var response = MKMSClient.Send<QueryDiscountUserResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<DiscountCodeUser, DiscountCodeUserRes>(response.DiscountCodeUserDto);
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

            var param = new CancelDiscountCodeRequest()
            {
                SysNos = SysNos,
                Remark = remarks
            };
            var response = MKMSClient.Send<CancelDiscountCodeResponse>(param);
            if (response.DoFlag)
            {
                return response.DoResult;
            }
            return null;
        }


        /// <summary>
        /// 查询优惠码明细
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes> QueryDiscountCodeDetailList(BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes> refer)
        {
            var obj = refer.SearchDetail ?? new DiscountCodeDetailRes();
            var param = new QueryCodeDetailRequest()
            {
                BatchSysNo=obj.BatchSysNo,
                ActivityKey = obj.ActivityKey,
                ActivityName=obj.ActivityName,
                STime = obj.STime,
                ETime = obj.ETime,
                DiscountCode = obj.DiscountCode,
                PageIndex = refer.PageIndex ?? 1,
                PageSize = refer.PageSize,
            };
            var result = new BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes>();
            var response = MKMSClient.Send<QueryCodeDetailResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<DiscountCodeDetail, DiscountCodeDetailRes>(response.DiscountCodeDetailDto);
            }
            return result;
        }

        public BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes> QueryDiscountCodeDetailList(BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes> refer ,string type)
        {
            var obj = refer.SearchDetail ?? new DiscountCodeDetailRes();
            var param = new QueryCodeDetailRequest()
            {
                BatchSysNo = obj.BatchSysNo,
                ActivityKey = obj.ActivityKey,
                ActivityName = obj.ActivityName,
                STime = obj.STime,
                ETime = obj.ETime,
                DiscountCode = obj.DiscountCode,
            };
            var result = new BaseRefer<DiscountCodeDetailRes, DiscountCodeDetailRes>();
            var response = MKMSClient.Send<QueryCodeDetailResponse>(param);
            if (response.DoFlag)
            {
                result.Total = response.Total;
                result.PageIndex = response.PageIndex;
                result.PageSize = response.PageSize;
                result.List2 = Mapper.MappGereric<DiscountCodeDetail, DiscountCodeDetailRes>(response.DiscountCodeDetailDto);
            }
            return result;
        }
        /// <summary>
        /// 删除优惠码
        /// </summary>
        /// <param name="discountCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteDiscountCode(string discountCode,out string message)
        {
            var param = new DeleteDiscountCodeRequest()
            {
                DiscountCode = discountCode
            };
            var response = MKMSClient.Send<DeleteDiscountCodeResponse>(param);
            message = response.DoResult;
            return response.DoFlag;
        }
    }
}
