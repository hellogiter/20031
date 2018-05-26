using System;
using Myzj.OPC.UI.Assembler;
using Myzj.OPC.UI.Assembler.External;
using Myzj.OPC.UI.ServiceClient.Base;
using Myzj.OPC.UI.ServiceClient.External;
using ServiceStack.ServiceClient.Web;

namespace Myzj.OPC.UI.ServiceClient
{
    public class BaseService
    {
        private static ServiceCollection _servcieCollection = null;
        public ServiceCollection ServiceCollection
        {
            get
            {
                if (null == _servcieCollection)
                {
                    _servcieCollection = ServiceCollectionFactory.ServiceCollection;
                }
                return _servcieCollection;
            }
        }

        private static IMapper _mapper = null;
        public IMapper Mapper
        {
            get
            {
                if (null == _mapper)
                {
                    _mapper = AssemblerIoc.GetMapper();
                }
                return _mapper;
            }
        }

        #region  麻辣团
        /// <summary>
        /// 麻辣团
        /// </summary>
        private static JsonServiceClient _spicyGroupServiceClient;
        protected JsonServiceClient SpicyGroupServiceClient
        {
            get
            {
                if (null == _spicyGroupServiceClient)
                {
                    _spicyGroupServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("spicyGroupJsonServiceUrl"));
                }
                return _spicyGroupServiceClient;
            }
        }

        /// <summary>
        /// 麻辣堂
        /// </summary>
        protected static JsonServiceClient MltClient
        {
            get
            {
                if (null == _spicyGroupServiceClient)
                {
                    _spicyGroupServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("spicyGroupJsonServiceUrl"));
                }
                return _spicyGroupServiceClient;
            }
        }

        #endregion

        #region 运营中心VIP库
        /// <summary>
        /// 运营中心
        /// </summary>
        private static JsonServiceClient _opcServiceClient;
        protected static JsonServiceClient OpcClient
        {
            get
            {
                if (null == _opcServiceClient)
                {
                    _opcServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("opcGroupJsonServiceUrl"));
                }
                return _opcServiceClient;
            }
        }
        #endregion

        #region 运营中心MKMS库
        /// <summary>
        /// 运营中心
        /// </summary>
        private static JsonServiceClient _mkmsServiceClient;
        protected static JsonServiceClient MKMSClient
        {
            get
            {
                if (null == _mkmsServiceClient)
                {
                    _mkmsServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("MYZJmkmsGroupJsonServiceUrl"));
                }
                return _mkmsServiceClient;
            }
        }

        /// <summary>
        /// mkms只用于 读取文件
        /// </summary>
        private static JsonServiceClient _mkmsReadServiceClient;
        public JsonServiceClient MkmsServiceClient
        {
            get
            {
                if (null == _mkmsReadServiceClient)
                {
                    _mkmsReadServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("MkmsServiceUrl"));
                }
                return _mkmsReadServiceClient;
            }
        }
        #endregion

        #region 鲍双龙搜索接口
        //MYZJSearchEngineServiceUrl
        private static JsonServiceClient _searchEngineServiceClient;
        protected static JsonServiceClient SearchEngineClient
        {
            get
            {
                if (null == _searchEngineServiceClient)
                {
                    _searchEngineServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("SearchEngineServiceUrl"));
                }
                return _searchEngineServiceClient;
            }
        }

        #endregion

        #region 统一商品Goods服务
        private static JsonServiceClient _goodsServiceClient;
        protected static JsonServiceClient GoodsClient
        {
            get
            {
                if (null == _goodsServiceClient)
                {
                    _goodsServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("MYZGoodsJsonServiceUrl"));
                }
                return _goodsServiceClient;
            }
        }

        #endregion

        #region 运营中心CMS库
        private static JsonServiceClient _cmsServiceClient;
        protected static JsonServiceClient CMSClient
        {
            get
            {
                if (null == _cmsServiceClient)
                {
                    _cmsServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("MYZJCMSGroupJsonServiceUrl"));
                }
                return _cmsServiceClient;
            }
        }
        #endregion

        #region 运营中心BS库
        private static JsonServiceClient _bsServiceClient;
        protected static JsonServiceClient BSClient
        {
            get
            {
                if (null == _bsServiceClient)
                {
                    _bsServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("MYZJBSGroupJsonServiceUrl"));
                }
                return _bsServiceClient;
            }
        }
        #endregion

        #region  Ueditor配置
        private static JsonServiceClient _UeditorServiceClient;
        protected static JsonServiceClient UeditorClient
        {
            get
            {
                if (null == _UeditorServiceClient)
                {
                    _UeditorServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("remoteRoot"));
                }
                return _UeditorServiceClient;
            }
        }
        #endregion

        private static JsonServiceClient _dataCenterJsonServiceUrl;
        public JsonServiceClient DataCenterJsonServiceClient
        {
            get
            {
                if (null == _dataCenterJsonServiceUrl)
                {
                    _dataCenterJsonServiceUrl = new JsonServiceClient(Configurator.JsonServiceUrl("dataCenterJsonServiceUrl"));
                }
                return _dataCenterJsonServiceUrl;
            }
        }

        #region 新促销服务20007 MyzjPromotionServiceUrl

        private static JsonServiceClient _promotionServiceClient;
        protected static JsonServiceClient PromotionClient
        {
            get
            {
                if (null == _promotionServiceClient)
                {
                    _promotionServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("MyzjPromotionServiceUrl"));
                }
                return _promotionServiceClient;
            }
        }
        #endregion

        #region 下单占用库存服务20007 UisJsonServiceUrl


        private static JsonServiceClient _uisJsonServiceClient;

        protected static JsonServiceClient UisJsonServiceClient
        {
            get
            {
                if (null == _uisJsonServiceClient)
                {
                    _uisJsonServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("UisJsonServiceUrl"));
                }
                return _uisJsonServiceClient;
            }
        }
        #endregion


        #region  统一登录 用户相关服务1002 AuthorizationServiceUrl

        private static JsonServiceClient _authorizationServiceClient;
        protected static JsonServiceClient AuthorizationServiceClient
        {
            get
            {
                if (null == _authorizationServiceClient)
                {
                    _authorizationServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("AuthorizationServiceUri"));
                }
                return _authorizationServiceClient;
            }
        }

        #endregion



        private static JsonServiceClient _vipServiceClient;
        protected static JsonServiceClient VIPClient
        {
            get
            {
                if (null == _vipServiceClient)
                {
                    _vipServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("vipJsonServiceUrl"));
                }
                return _vipServiceClient;
            }
        }

        private static JsonServiceClient _myzjVipServiceClient;
        protected static JsonServiceClient MYZJVIPClient
        {
            get
            {
                if (null == _myzjVipServiceClient)
                {
                    _myzjVipServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("myzjVipJsonServiceUrl"));
                }
                return _myzjVipServiceClient;
            }
        }


        private static JsonServiceClient _udpServiceClient;
        protected static JsonServiceClient UdpClient
        {
            get
            {
                if (null == _udpServiceClient)
                {
                    _udpServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("udpJsonServiceUrl"));
                }
                return _udpServiceClient;
            }
        }



        private static JsonServiceClient _tmOutServiceClient;
        protected static JsonServiceClient TmOutServiceClient
        {
            get
            {
                if (null == _tmOutServiceClient)
                {
                    _tmOutServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("TmOutServiceClient"));
                }
                return _tmOutServiceClient;
            }
        }


		private static JsonServiceClient _upsReadServiceClient;
		public JsonServiceClient UpsServiceClient
		{
			get
			{
				if (null == _upsReadServiceClient)
				{
					_upsReadServiceClient = new JsonServiceClient(Configurator.JsonServiceUrl("UpsJsonServiceUrl"));
				}
				return _upsReadServiceClient;
			}
		}

    }

    public class BaseSingleton<T> : BaseService where T : class,new()
    {
        #region 单例

        protected static T newObj()
        {
            return new T();
        }

        private static readonly object Lockobj = new object();
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = newObj();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion
    }
}
