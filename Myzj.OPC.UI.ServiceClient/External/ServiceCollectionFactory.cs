using Myzj.OPC.UI.ServiceClient.Base;

namespace Myzj.OPC.UI.ServiceClient.External
{
    public class ServiceCollectionFactory
    {
        private static ServiceCollection _serviceCollectionFactory;
        public static ServiceCollection ServiceCollection
        {
            get
            {
                if (null == _serviceCollectionFactory)
                {
                    _serviceCollectionFactory = new ServiceCollection();
                }
                return _serviceCollectionFactory;
            }
        }
    }
}
