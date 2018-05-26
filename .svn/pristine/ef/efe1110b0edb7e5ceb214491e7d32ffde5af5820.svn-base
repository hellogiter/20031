using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Myzj.CMS.ServiceModel;
using Myzj.OPC.UI.Model.ProductLabel;

namespace Myzj.OPC.UI.ServiceClient
{
    public class ProductLabelClient : BaseService
    {
        private ProductLabelClient()
        {
        }
        private static readonly object Lockobj = new object();
        private static ProductLabelClient _instance;
        public static ProductLabelClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProductLabelClient();
                        }
                    }
                }
                return _instance;
            }
        }

        #region 商品标签列表
        /// <summary>
        /// 商品标签列表
        /// </summary>
        /// <param name="productLabel"></param>
        /// <returns></returns>
        public ProductLabelRefer QueryBasetLabels(ProductLabelRefer productLabel)
        {
            var result = new ProductLabelRefer();
            var req = new QueryBasetLabelsRequest();

            if (productLabel.SearchDetail != null)
            {
                req.LabelName = productLabel.SearchDetail.LabelName;
                req.LabelcontentValue = productLabel.SearchDetail.LabelcontentValue;
            }

            req.PageIndex = productLabel.PageIndex;
            req.PageSize = productLabel.PageSize;
            var res = CMSClient.Send<QueryBasetLabelsResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<base_t_LabelsExt, ProductLabelDetail>(res.BaseTLabelsDos);
                result.Total = res.Total;
            }
            result.SearchDetail = productLabel.SearchDetail;
            result.PageIndex = productLabel.PageIndex;
            result.PageSize = productLabel.PageSize;
            return result;
        }
        #endregion

        #region 详细信息
        /// <summary>
        /// 详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductLabelDetail QueryBasetLabelsById(int id)
        {
            var result = new ProductLabelDetail();
            var req = new QueryBasetLabelsByIdRequest();
            req.ID = id;
            var res = CMSClient.Send<QueryBasetLabelsByIdResponse>(req);
            if (res.DoFlag)
            {
                result = Mapper.Map<base_t_LabelsExt, ProductLabelDetail>(res.BaseTLabelsDos);
            }
            return result;
        }
        #endregion

        #region 新增商品标签
        /// <summary>
        /// 新增商品标签
        /// </summary>
        /// <param name="productLabel"></param>
        /// <returns></returns>
        public bool AddBasetLabels(ProductLabelDetail productLabel)
        {
            var req = Mapper.Map<ProductLabelDetail, AddBasetLabelsRequest>(productLabel);
            var res = CMSClient.Send<AddBasetLabelsResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 修改商品标签
        /// <summary>
        /// 修改商品标签
        /// </summary>
        /// <param name="productLabel"></param>
        /// <returns></returns>
        public bool UpdateBasetLabels(ProductLabelDetail productLabel)
        {
            var req = Mapper.Map<ProductLabelDetail, UpdateBasetLabelsRequest>(productLabel);
            var res = CMSClient.Send<UpdateBasetLabelsResponse>(req);
            return res.DoFlag;
        }
        #endregion

        #region 删除商品标签
        /// <summary>
        /// 删除商品标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelBasetLabels(int id)
        {
            var req = new DelBasetLabelsRequest();
            req.ID = id;
            var res = CMSClient.Send<DelBasetLabelsResponse>(req);
            return res.DoFlag;
        }
        #endregion

    }
}
