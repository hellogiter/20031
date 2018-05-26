using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.OPC.UI.Model.ShortMessage;

namespace Myzj.OPC.UI.ServiceClient
{
    public class ShortMessageClient : BaseService
    {
        #region 单例
        private ShortMessageClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static ShortMessageClient _instance;
        public static ShortMessageClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ShortMessageClient();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// 查询短信模板列表
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public TemplateListRefer QueryTemplatePageList(TemplateListRefer refer)
        {
            var req = refer.Search;
            var ret = new TemplateListRefer();
            var response = BSClient.Send<QueryTemplateListResponse>(new QueryTemplateList
            {
                TempKey = req.TempKey,
                TempType = req.TempType,
                TempName = req.TempName,
                IsEnable = req.IsEnable,
                Content = req.Content,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
            });
            ret.List = Mapper.MappGereric<TemplateDto, TemplateModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }

        /// <summary>
        /// 查询单个短信模板
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public TemplateModel QueryTemplateEntity(int SysNo)
        {
            var model = new TemplateModel();
            var response = BSClient.Send<QueryTemplateEntityResponse>(new QueryTemplateEntity
            {
                SysNo = SysNo
            });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<TemplateDto, TemplateModel>(response.Dto);
            }
            return model;
        }

        /// <summary>
        /// 修改短信模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateTemplate(TemplateModel model)
        {

            return BSClient.Send<TemplateUpdateResponse>(new TemplateUpdate
                {
                    UpdModel = Mapper.Map<TemplateModel, TemplateDto>(model)
                }).DoFlag;
        }

        /// <summary>
        /// 新增短信模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddTemplate(TemplateModel model)
        {
            return BSClient.Send<TemplateAddResponse>(new TemplateAdd
                {
                    UpdModel = Mapper.Map<TemplateModel, TemplateDto>(model)
                }).DoFlag;
        }


        /// <summary>
        /// 查询发送记录
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public SendRecorsRefer QuerySendRecordsPageList(SendRecorsRefer refer)
        {
            var req = refer.Search;
            var ret = new SendRecorsRefer();
            var response = BSClient.Send<QuerySendRecordsListResponse>(new QuerySendRecordsList
            {
                UserId = req.UserId,
                Mobile = req.Mobile,
                SmsSendRes = req.SmsSendRes,
                TemplSysNO = req.TemplSysNO,
                SmsContent = req.SmsContent,
                SmsProvider = req.SmsProvider,
                SmsChannel = req.SmsChannel,
                SmsSendMode = req.SmsSendMode,
                SendSource = req.SendSource,
                TempKey = req.TempKey,
                SourceTypeSysNo = req.SourceTypeSysNo,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
            });
            ret.List = Mapper.MappGereric<QuerySendRecordsDto, SendRecordsModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }



        public BlackListRefer QueryBackPageList(BlackListRefer refer)
        {
            var req = refer.Search;
            var ret = new BlackListRefer();
            var response = BSClient.Send<QueryBackPageListResponse>(new QueryBackPageList
            {
                Mobile = req.Mobile == null ? null : req.Mobile.Trim(),
                UserGuid = req.UserGuid == null ? null : req.UserGuid.Trim(),
                ClientIp = req.ClientIp == null ? null : req.ClientIp.Trim(),
                IsEnable = req.IsEnable,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
            });
            ret.List = Mapper.MappGereric<BlackListDto, BlackListModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }
        public BlackListModel QueryBackListEntity(int SysNo)
        {
            var model = new BlackListModel();
            var response = BSClient.Send<QueryBackListEntityResponse>(new QueryBackListEntity
            {
                SysNo = SysNo
            });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<BlackListDto, BlackListModel>(response.Dto);
            }
            return model;
        }
        public bool BlackListUpdate(BlackListModel model)
        {

            return BSClient.Send<BlackListUpdateResponse>(new BlackListUpdate
            {
                UpdDto = Mapper.Map<BlackListModel, BlackListDto>(model)
            }).DoFlag;
        }
        public bool BlackListAdd(BlackListModel model)
        {
            return BSClient.Send<BlackListAddResponse>(new BlackListAdd
            {
                AddDto = Mapper.Map<BlackListModel, BlackListDto>(model)
            }).DoFlag;
        }

        public WhiteListRefer QueryWhitePageList(WhiteListRefer refer)
        {
            var req = refer.Search;
            var ret = new WhiteListRefer();
            var response = BSClient.Send<QueryWhitePageListResponse>(new QueryWhitePageList
            {
                Mobile = req.Mobile == null ? null : req.Mobile.Trim(),
                UserName = req.UserName == null ? null : req.UserName.Trim(),
                IsEnable = req.IsEnable,
                PageIndex = refer.PageIndex,
                PageSize = refer.PageSize,
            });
            ret.List = Mapper.MappGereric<WhiteListDto, WhiteListModel>(response.Dtos);
            ret.PageIndex = response.PageIndex;
            ret.PageSize = response.PageSize;
            ret.Total = response.Total;
            return ret;
        }
        public WhiteListModel QueryWhiteListEntity(int SysNo)
        {
            var model = new WhiteListModel();
            var response = BSClient.Send<QueryWhiteListEntityResponse>(new QueryWhiteListEntity
            {
                SysNo = SysNo
            });
            if (response.DoFlag && response.Dto != null)
            {
                model = Mapper.Map<WhiteListDto, WhiteListModel>(response.Dto);
            }
            return model;
        }
        public bool WhiteListUpdate(WhiteListModel model)
        {

            return BSClient.Send<WhiteListUpdateResponse>(new WhiteListUpdate
            {
                UpdDto = Mapper.Map<WhiteListModel, WhiteListDto>(model)
            }).DoFlag;
        }
        public bool WhiteListAdd(WhiteListModel model)
        {
            return BSClient.Send<WhiteListAddResponse>(new WhiteListAdd
            {
                AddDto = Mapper.Map<WhiteListModel, WhiteListDto>(model)
            }).DoFlag;
        }


        public SmsPlaceHolderRefer QuerySmsPlaceHolderPageList(SmsPlaceHolderRefer refer)
        {
            var ret = new SmsPlaceHolderRefer();
            var response = BSClient.Send<QuerySmsTemplatePlaceHolderResponse>(new QuerySmsTemplatePlaceHolder
            {
            });
            ret.List = Mapper.MappGereric<SmsPlaceHolderDto, SmsPlaceHolderModel>(response.Dtos);

            return ret;
        }


        public SmsBalanceRefer QuerySmsBalanceList(SmsBalanceRefer refer)
        {
            var req = refer.Search;
            var ret = new SmsBalanceRefer();
            var response = BSClient.Send<SmsBanlanceResponse>(new SmsBanlance());
            ret.List = Mapper.MappGereric<SmsBalanceDto, SmsBanlanceModel>(response.Dtos);
            return ret;
        }
    }
}
