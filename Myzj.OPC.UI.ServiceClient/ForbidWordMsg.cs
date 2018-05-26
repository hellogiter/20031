using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYZJ.VIP.ServiceModel;
using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model.WordMsg;

namespace Myzj.OPC.UI.ServiceClient
{
    public class ForbidWordMsgClient : BaseService
    {
        private ForbidWordMsgClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static ForbidWordMsgClient _instance;
        public static ForbidWordMsgClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ForbidWordMsgClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 禁词列表
        /// <summary>
        /// 禁词列表
        /// </summary>
        /// <returns></returns>
        public WordMsgRefer QueryGetWordMsg(WordMsgRefer wordMsg)
        {
            var result = new WordMsgRefer();
            var req = new QueryWebForbidWordMessageRequest();
            if (wordMsg.SearchDetail != null)
            {
                req.VchForbidWord = wordMsg.SearchDetail.VchForbidWord;
                req.IntWordType = wordMsg.SearchDetail.IntWordType;
            }
            req.PageIndex = wordMsg.PageIndex.GetValueOrDefault(); ;
            req.PageSize = wordMsg.PageSize.GetValueOrDefault(); ;

            var res = BSClient.Send<QueryWebForbidWordMessageResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<Web_Forbid_Word_MessageExt, WordMsgDetail>(res.ForbidWordDos);
                result.Total = res.Total;
            }
            result.SearchDetail = wordMsg.SearchDetail;
            result.PageIndex = wordMsg.PageIndex;
            result.PageSize = wordMsg.PageSize;
            return result;
        }
        #endregion

        #region 根据Id查询单条信息
        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <returns></returns>
        public WordMsgDetail QueryById(int id)
        {
            var result = new WordMsgDetail();
            var req = new QueryWebForbidWordMessageByIdRequest();
            req.IntForbidID = id;

            var res = BSClient.Send<QueryWebForbidWordMessageByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<Web_Forbid_Word_MessageExt, WordMsgDetail>(res.ForbidWordDos);
            }
            return result;
        }
        #endregion

        #region 新增禁词
        public bool AddWordMsg(WordMsgDetail wordMsg)
        {
            var req = new AddWebForbidWordMessageRequest();
            req.IntWordType = wordMsg.IntWordType;
            req.VchForbidWord = wordMsg.VchForbidWord;
            var res = BSClient.Send<AddWebForbidWordMessageResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 修改禁词
        public bool UpdateWordMsg(WordMsgDetail wordMsg)
        {
            var req = new UpdateWebForbidWordMessageRequest();
            req.IntForbidID = wordMsg.IntForbidID;
            req.IntWordType = wordMsg.IntWordType;
            req.VchForbidWord = wordMsg.VchForbidWord;
            var res = BSClient.Send<UpdateWebForbidWordMessageResponse>(req);

            return res.DoFlag;
        }
        #endregion

        #region 删除禁词
        public bool DelWordMsg(int id)
        {
            var req = new DelWebForbidWordMessageRequest();
            req.IntForbidID = id;
            var res = BSClient.Send<DelWebForbidWordMessageResponse>(req);

            return res.DoFlag;
        }
        #endregion
    }
}
