using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MYZJ.UDP.ServiceModel;
using Myzj.BS.ServiceModel.Carriage;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCarriage;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.ServiceClient
{
    public class BaseCarriageConfigClient : BaseSingleton<BaseCarriageConfigClient>
    {
        public BaseRefer<BuyAppointGoodsParam> QueryCarriageConfig(BaseRefer<BuyAppointGoodsParam> refer)
        {
            var result = new BaseRefer<BuyAppointGoodsParam>();

            var response = BSClient.Send<QueryCarriageConfigResponse>(new QueryCarriageConfigRequest()
                {
                    ExecMethod = "BuyAppointGoodsCarriage"
                });
            if (response.DoFlag && response.CarriageRule != null)
            {
                if (!string.IsNullOrEmpty(response.CarriageRule.Configure))
                {
                    var goodsCarriage = JsonConvert.DeserializeObject<BuyAppointGoodsCarriage>(response.CarriageRule.Configure);
                    if (goodsCarriage != null && goodsCarriage.BuyAppointGoodsParams.Count > 0)
                    {
                        var search = refer.SearchDetail;
                        var list = new List<BuyAppointGoodsParam>();
                        list = goodsCarriage.BuyAppointGoodsParams;
                        if (search != null)
                        {
                            if (search.GoodsId.HasValue)
                                list = goodsCarriage.BuyAppointGoodsParams.Where(m => m.GoodsIds.Any(t => t == search.GoodsId)).ToList();
                            if (search.IsEnableNum == 1)
                            {
                                list = goodsCarriage.BuyAppointGoodsParams.Where(m => m.IsEnable).ToList();
                            }
                            else if (search.IsEnableNum == 0)
                            {
                                list = goodsCarriage.BuyAppointGoodsParams.Where(m => !m.IsEnable).ToList();
                            }
                            if (search.AreaId.HasValue && search.AreaId > 0)
                                list = goodsCarriage.BuyAppointGoodsParams.Where(m => m.AreaIds.Any(t => t == search.AreaId)).ToList();
                        }
                        int pageIndex = refer.PageIndex ?? 1;
                        int pageSize = 20;
                        result.Total = list.Count;
                        result.List2 = list.OrderByDescending(m => m.SysNo).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                        result.PageIndex = pageIndex;
                        result.PageSize = pageSize;

                    }
                }
            }
            return result;
        }

        public BaseRefer<BuyAppointGoodsParam> QueryAllCarriageConfig()
        {
            var result = new BaseRefer<BuyAppointGoodsParam>();

            var response = BSClient.Send<QueryCarriageConfigResponse>(new QueryCarriageConfigRequest()
            {
                ExecMethod = "BuyAppointGoodsCarriage"
            });
            if (response.DoFlag && response.CarriageRule != null)
            {
                if (!string.IsNullOrEmpty(response.CarriageRule.Configure))
                {
                    var goodsCarriage = JsonConvert.DeserializeObject<BuyAppointGoodsCarriage>(response.CarriageRule.Configure);
                    if (goodsCarriage != null && goodsCarriage.BuyAppointGoodsParams.Count > 0)
                    {
                        result.List2 = goodsCarriage.BuyAppointGoodsParams.OrderByDescending(m => m.SysNo).ToList();
                    }
                }
            }
            return result;
        }

        public bool SaveCarriageConfig(string config)
        {

            var response = BSClient.Send<UpdateCarriageConfigRes>(new UpdateCarriageConfigReq
            {
                ExecMethod = "BuyAppointGoodsCarriage",
                Configure = config
            });
            return response.DoFlag;
        }

        //获取省
        public Dictionary<int?, string> GetAllArea()
        {
            var dic = new Dictionary<int?, string>();
            dic.Add(0, "全国");
            var response = UdpClient.Send<PcaDicResponse>(new PcaDicReq { });
            if (response.DoFlag && response.PcaDictionary.Count > 0)
            {
                foreach (var item in response.PcaDictionary)
                {
                    if (item.Value.ParentId == 0)
                        dic.Add(item.Key, item.Value.RegionName);
                }
            }
            return dic;
        }

        public string GetAreaName(List<int?> areaIds)
        {
            List<string> str = new List<string>();
            if (areaIds.Count > 0)
            {
                var dic = GetAllArea();
                if (areaIds.Any(m => m == 0))
                {
                    return "全国";
                }
                foreach (var item in areaIds)
                {
                    var val = dic.Where(m => m.Key == item).FirstOrDefault();
                    if (!string.IsNullOrEmpty(val.Value))
                    {
                        str.Add(val.Value);
                    }
                }
            }

            return string.Join(",",str);
        }

        //获取平台
        public string GetPlatforms(List<int?> platforms)
        {
            List<string> str = new List<string>();
            if (platforms != null && platforms.Count > 0)
            {
                foreach (var item in platforms)
                {
                    switch (item)
                    {
                        case 0:
                            str.Add("全部");
                            return string.Join(",", str);
                        case 1:
                            str.Add("PC网站");
                            break;
                        case 2:
                            str.Add("Wap网站");
                            break;
                        case 4:
                            str.Add("安卓APP");
                            break;
                        case 5:
                            str.Add("苹果APP");
                            break;
                        case 8:
                            str.Add("Ipad");
                            break;
                    }
                }
            }
            return string.Join(",", str);
        }
    }
}
