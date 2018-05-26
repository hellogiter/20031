using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Myzj.MKMS.ServiceModel.SortProduct;
using Myzj.OPC.UI.Model.KeyWord;

namespace Myzj.OPC.UI.ServiceClient
{
    public class SortProductConfigClient : BaseService
    {
        #region 单例 
        private SortProductConfigClient()
        { 
        }
        private static readonly object Lockobj = new object();
        private static SortProductConfigClient _instance; 
        public static SortProductConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance=new SortProductConfigClient();
                        }
                    }
                }
                return _instance;
            }
        } 
        #endregion

        /// <summary>
        /// 新增商品搜索指定位置显示
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddSortProductResponse AddSortProduct(SortProductDetail request)
        {
            var req = Mapper.Map<SortProductDetail, AddSortProductRequest>(request);
            req.IsDelete = request.IsDelete??false;
            var response = MKMSClient.Send<AddSortProductResponse>(req);
            return response;
        }

        /// <summary>
        /// 修改商品搜索指定位置显示
        /// </summary>
        /// <param name="request"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public UpdateSortProductResponse UpdateSortProduct(SortProductDetail request)
        { 
            var param = new UpdateSortProductRequest()
            {
                Id = request.Id,
                KeyWordType = request.KeyWordType,
                KeyWord = request.KeyWord,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                ProductJson = request.ProductJson,
                Enable = request.Enable,
                LastOperator = request.LastOperator,
                LastUpdateTime = request.LastUpdateTime, 
            };
            var response = MKMSClient.Send<UpdateSortProductResponse>(param); 
            return response;
        }
        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public SortProductDetail QuerySortProductEntity(int id)
        {
            var sortProductInfo = new SortProductDetail();
            var param = new QuerySortProductEntity() {Id = id};
            var response = MKMSClient.Send<QuerySortProductEntityResponse>(param);
            if (response.DoFlag)
            {
                sortProductInfo = Mapper.Map<SortProductDto, SortProductDetail>(response.SortProductEntity); 
            }
            return sortProductInfo;
        }

        /// <summary>
        /// 查询商品指定位置列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SortProductRefer QuerySortProductPageList(SortProductRefer request)
        { 
            var result = new SortProductRefer();
            var req = new QuerySortProductPageList(); 
            req.PageIndex = request.PageIndex;
            req.PageSize = request.PageSize; 
            req.KeyWordType = request.SortProductDetail.KeyWordType;
            req.KeyWord = request.SortProductDetail.KeyWord;
            req.ProductId = request.SortProductDetail.ProductJson;
            req.Enable = request.SortProductDetail.Enable;
            req.Usablestatus = request.SortProductDetail.Usablestatus; 

            var res = MKMSClient.Send<QuerySortProductPageListResponse>(req);
            if (res.DoFlag)
            {
                result.List = Mapper.MappGereric<SortProductDto, SortProductDetail>(res.SortProductListDto);
                result.Total = res.Total;
            }
            result.SortProductDetail = request.SortProductDetail;
            result.PageIndex = request.PageIndex;
            result.PageSize = request.PageSize;
            return result;
        }

        /// <summary>
        /// 批量删除商品搜索指定显示数据
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public string DelSortProduct(List<int> idList)
        {
            var param = new DelSortProductRequest()
            {
                Ids = idList
            };
            var response = MKMSClient.Send<DelSortProductResponse>(param);
            if (response.DoFlag)
            {
                return response.DoResult;
            }
            return null; 
        }

    }
}
