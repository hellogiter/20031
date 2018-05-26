using Myzj.BS.ServiceModel;
using Myzj.OPC.UI.Model.AdminCarriage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Myzj.OPC.UI.ServiceClient
{
    public class AdminCarriageClient : BaseService
    {
        private AdminCarriageClient()
        {

        }
        
        private static readonly object Lockobj = new object();
        private static AdminCarriageClient _instance;
        public static AdminCarriageClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new AdminCarriageClient();
                        }
                    }
                }
                return _instance;
            }
        }

        public List<Carriage_Strategy> GetCarriageStrategy()
        {
            var list = new List<Carriage_Strategy>();

            var request = new CarriageStrategyRequest();

            var response = BSClient.Send<CarriageStrategyResponse>(request);

            if (response.DoFlag)
            {
                list = Mapper.Map < List < CarriageStrategy >,List<Carriage_Strategy>>( response.CarriageStrategies);
            }

            return list;
        }

        public List<Carriage_Plug> GetCarriagePlugByStrategyId(int strategyId)
        {
            var list = new List<Carriage_Plug>();

            var request = new CarriagePlugRequest
            {
                StrategyId = strategyId
            };

            var response = BSClient.Send<CarriagePlugResponse>(request);

            if (response.DoFlag)
            {
                list = Mapper.Map<List<CarriagePlug>, List<Carriage_Plug>>(response.list);
            }

            return list;
        }

        public string GetPlugConfigure(int plugId)
        {
            var ret = string.Empty;

            var request = new PlugConfigueRequest { PlugId = plugId };

            var response = BSClient.Send<PlugConfigueResponse>(request);

            if (response.DoFlag)
            {
                ret = response.Configure;
            }

            return ret;
        }

        public bool UpdatePlugConfigure(int plugId, string configure)
        {

            var request = new UpdatePlugConfigueRequest
            {
                Configure = configure,
                PlugId = plugId
            };

            var response = BSClient.Send<UpdatePlugConfigueResponse>(request);

            return response.DoFlag;

        }
    }
}
