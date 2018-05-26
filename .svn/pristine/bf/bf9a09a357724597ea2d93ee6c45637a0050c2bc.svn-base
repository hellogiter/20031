using Myzj.OPC.UI.Model.AdminCarriage;
using Myzj.OPC.UI.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class AdminCarriageController : Controller
    {
        //
        // GET: /AdminCarriage/

        public ActionResult Index()
        {
            var list = AdminCarriageClient.Instance.GetCarriageStrategy();
            ViewBag.Carriage_Strategy=new SelectList(list,"Sysno","StrategyName").AsEnumerable();

            ViewBag.WindowRoot = Request.Url.Authority;
            if (!Request.Url.Authority.Contains("http"))
            {
                ViewBag.WindowRoot = "http://" + Request.Url.Authority;
            }
            return View();
        }

        public ActionResult Item(int strategyId=1)
        {
            var list = AdminCarriageClient.Instance.GetCarriagePlugByStrategyId(strategyId);
            return View(list);
        }


        #region 购买指定商品指定平台包邮活动
        public ActionResult Detail10()
        {
            //var plug = AdminCarriageClient.Instance.GetPlugConfigure(10);

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //var ret = jss.Deserialize<BuyAppointGoods>(plug);
            return View();
        }

        public ActionResult Detail10Show()
        {
           
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(10);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<BuyAppointGoods>(plug);
            return View(ret);
        }

        public ActionResult Detail10Operation(int rowindex=-1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(10);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<BuyAppointGoods>(plug);

            BuyAppointGoodsParam param=new BuyAppointGoodsParam ();

            if (rowindex >= 0)
            {
                param = ret.BuyAppointGoodsParams[rowindex];
            }
            else
            {
                param.StartTime = string.Empty;
                param.EndTime = string.Empty;
                param.Priority = 1;
                param.Platforms = new List<string>();
                param.GoodsIds = new List<string>();
            }
            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug10Configure(string id, string platform ,string productids,string dateFrom,string dateEnd,int priority,int carriage)
        {
            var platformList = platform.Split(new char[]{',','，'});
            var productidlist = productids.Split(new char[] { ',', '，' });

            Myzj.OPC.UI.Model.AdminCarriage.power.BuyAppointGoodsParam param = new Myzj.OPC.UI.Model.AdminCarriage.power.BuyAppointGoodsParam
            {
                EndTime = dateEnd,
                StartTime = dateFrom,
                FullCarriage = carriage,
                Priority = priority,
                Platforms = platformList.ToList ().Select(x => int.Parse(x)).ToList(),
                GoodsIds = productidlist.ToList().Select(x => int.Parse(x)).ToList()
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(10);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.power.BuyAppointGoods>(plug);

            ret.BuyAppointGoodsParams[Convert.ToInt32( id)] = param;

            return AdminCarriageClient.Instance.UpdatePlugConfigure(10, jss.Serialize(ret)); 
        }

        public bool AddPlug10Configure(string platform, string productids, string dateFrom, string dateEnd, int priority, int carriage)
        {
            var platformList = platform.Split(new char[] { ',', '，' });
            var productidlist = productids.Split(new char[] { ',', '，' });

            Myzj.OPC.UI.Model.AdminCarriage.power.BuyAppointGoodsParam param = new Myzj.OPC.UI.Model.AdminCarriage.power.BuyAppointGoodsParam
            {
                EndTime = dateEnd,
                StartTime = dateFrom,
                FullCarriage = carriage,
                Priority = priority,
                Platforms = platformList.ToList().Select(x => int.Parse(x)).ToList(),
                GoodsIds = productidlist.ToList().Select(x => int.Parse(x)).ToList()
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(10);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.power.BuyAppointGoods>(plug);

            ret.BuyAppointGoodsParams.Add(param);

            return AdminCarriageClient.Instance.UpdatePlugConfigure(10, jss.Serialize(ret)); 
        }
        #endregion


        #region 指定平台，指定时间包邮
        public ActionResult Detail11()
        {
            return View();
        }

        public ActionResult Detail11Show()
        {

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(11);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<FreeShipping>(plug);
            return View(ret);
        }

        public ActionResult Detail11Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(11);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<FreeShipping>(plug);

            FreeShippingParam param = new FreeShippingParam();

            if (rowindex >= 0)
            {
                param = ret.FreeShippingParams[rowindex];
            }
            else
            {
                param.StartTime = string.Empty;
                param.EndTime = string.Empty;
                param.Priority = 1;
                param.Platforms = new List<int>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug11Configure(string id, string platform, string dateFrom, string dateEnd, int priority, int carriage)
        {
            var platformList = platform.Split(new char[] { ',', '，' });
            FreeShippingParam param = new FreeShippingParam
            {
                EndTime = dateEnd,
                StartTime = dateFrom,
                FullCarriage = carriage,
                Priority = priority,
                Platforms = platformList.ToList().Select(x => int.Parse(x)).ToList()
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(11);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.FreeShipping>(plug);
            ret.FreeShippingParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(11, jss.Serialize(ret)); 
        }

        public bool AddPlug11Configure(string platform, string dateFrom, string dateEnd, int priority, int carriage)
        {
            var platformList = platform.Split(new char[] { ',', '，' });

            FreeShippingParam param = new FreeShippingParam
            {
                EndTime = dateEnd,
                StartTime = dateFrom,
                FullCarriage = carriage,
                Priority = priority,
                Platforms = platformList.ToList().Select(x => int.Parse(x)).ToList()
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(11);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.FreeShipping>(plug);

            ret.FreeShippingParams.Add(param);

            return AdminCarriageClient.Instance.UpdatePlugConfigure(11, jss.Serialize(ret)); 
        }
        #endregion


        #region 海淘运费计算(按照订单购买金额计算)
        public ActionResult Detail9()
        {
            return View();
        }

        public ActionResult Detail9Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(9);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<SeaWashesOrderMoney>(plug);
            return View(ret);
        }

        public ActionResult Detail9Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(9);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<SeaWashesOrderMoney>(plug);

            SeaWashesOrderMoneyParam param = new SeaWashesOrderMoneyParam();

            if (rowindex >= 0)
            {
                param = ret.SeaWashesOrderMoneyParams[rowindex];
            }
            else
            {              
                param.Priority = 1;
                param.OrderMoneyList = new List<OrderMoneyItem>();
                param.FullMessage = string.Empty;
                param.NotFullMessage = string.Empty;
                param.Suppliers = new List<int>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug9Configure(string id, string suppliers, string notFullMessage, string fullMessage, int priority, string orderMoneyItems)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var OrderMoneyItems = jss.Deserialize<List<OrderMoneyItem>>(orderMoneyItems);
            var supps = suppliers.Split(new char[] { ',', '，' });
            SeaWashesOrderMoneyParam param = new SeaWashesOrderMoneyParam
            {
                Suppliers = supps.ToList().Select(x => int.Parse(x)).ToList(),
                FullMessage = fullMessage,
                NotFullMessage = notFullMessage,
                Priority = priority,
                OrderMoneyList = OrderMoneyItems
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(9);

           
            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.SeaWashesOrderMoney>(plug);
            ret.SeaWashesOrderMoneyParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(9, jss.Serialize(ret)); 
        }

        public bool AddPlug9Configure(string id, string suppliers, string notFullMessage, string fullMessage, int priority, string orderMoneyItems)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var OrderMoneyItems = jss.Deserialize<List<OrderMoneyItem>>(orderMoneyItems);
            var supps = suppliers.Split(new char[] { ',', '，' });
            SeaWashesOrderMoneyParam param = new SeaWashesOrderMoneyParam
            {
                Suppliers = supps.ToList().Select(x => int.Parse(x)).ToList(),
                FullMessage = fullMessage,
                NotFullMessage = notFullMessage,
                Priority = priority,
                OrderMoneyList = OrderMoneyItems
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(9);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.SeaWashesOrderMoney>(plug);
            ret.SeaWashesOrderMoneyParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(9, jss.Serialize(ret));
        }
        #endregion


        #region 会员等级运费计算
        public ActionResult Detail2()
        {
            return View();
        }

        public ActionResult Detail2Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(2);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<Level>(plug);

            foreach (var item in ret.LevelParams)
            {
                for (int i = 0; i < item.Levels.Count; i++)
                {
                    if (item.Levels[i] == 17)
                    {
                        item.Levels[i] = 5;
                    }
                    else if (item.Levels[i] == 18)
                    {
                        item.Levels[i] = 6;
                    }
                }
            }

            return View(ret);
        }

        public ActionResult Detail2Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(2);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<Level>(plug);

            LevelParam param = new LevelParam();

            if (rowindex >= 0)
            {
                param = ret.LevelParams[rowindex];
            }
            else
            {
                param.Priority = 1;
               
                param.Levels = new List<int>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug2Configure(string id, string levels, string freeShippingMoney, string fullCarriage, int priority, string noFullCarriage)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            var list = levels.Split(new char[] { ',', '，' });
            LevelParam param = new LevelParam
            {
                Priority = priority,
                Levels = list.Select(x=>int.Parse (x)).ToList(),
                FreeShippingMoney =int.Parse ( freeShippingMoney),
                FullCarriage =int.Parse ( fullCarriage),
                NoFullCarriage = int.Parse (noFullCarriage)
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(2);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.Level>(plug);
            ret.LevelParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(2, jss.Serialize(ret));
        }

        public bool AddPlug2Configure(string id, string levels, string freeShippingMoney, string fullCarriage, int priority, string noFullCarriage)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var list = levels.Split(new char[] { ',', '，' });
            LevelParam param = new LevelParam
            {
                Priority = priority,
                Levels = list.Select(x => int.Parse(x)).ToList(),
                FreeShippingMoney = int.Parse(freeShippingMoney),
                FullCarriage = int.Parse(fullCarriage),
                NoFullCarriage = int.Parse(noFullCarriage)
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(2);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.Level>(plug);
            ret.LevelParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(2, jss.Serialize(ret));
        }
        #endregion


        #region 江浙沪粤运费计算
        public ActionResult Detail3()
        {
            return View();
        }

        public ActionResult Detail3Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(3);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<JZH>(plug);          

            return View(ret);
        }

        public ActionResult Detail3Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(3);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<JZH>(plug);

            JZHParam param = new JZHParam();

            if (rowindex >= 0)
            {
                param = ret.JZHParams[rowindex];
            }
            else
            {
                param.Priority = 1;
                param.AreaIds = new List<int>();
                param.ExcludeAreaIds = new List<int>();
                param.JZHSections = new List<JZHSection>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug3Configure(string id, string AreaIds, string ExcludeAreaIds, int priority, string JZHSections)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<JZHSection>>(JZHSections);
            var areaids = AreaIds.Split(new char[] { ',', '，' });
            var eareaids = ExcludeAreaIds.Split(new char[] { ',', '，' });
            JZHParam param = new JZHParam
            {
                AreaIds = areaids.ToList().Select(x => int.Parse(x)).ToList(),
                ExcludeAreaIds = eareaids.ToList().Select(x => int.Parse(x)).ToList(),
                Priority = priority,
                JZHSections = Sections
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(3);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.JZH >(plug);
            ret.JZHParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(3, jss.Serialize(ret));
        }

        public bool AddPlug3Configure(string id, string AreaIds, string ExcludeAreaIds, int priority, string JZHSections)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<JZHSection>>(JZHSections);
            var areaids = AreaIds.Split(new char[] { ',', '，' });
            var eareaids = ExcludeAreaIds.Split(new char[] { ',', '，' });
            JZHParam param = new JZHParam
            {
                AreaIds = areaids.ToList().Select(x => int.Parse(x)).ToList(),
                ExcludeAreaIds = eareaids.ToList().Select(x => int.Parse(x)).ToList(),
                Priority = priority,
                JZHSections = Sections
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(3);



            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.JZH>(plug);
            ret.JZHParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(3, jss.Serialize(ret));
        }
        #endregion


        #region 其他地区运费计算
        public ActionResult Detail4()
        {
            return View();
        }

        public ActionResult Detail4Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(4);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<_OtherParams>(plug);

            return View(ret);
        }

        public ActionResult Detail4Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(4);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<_OtherParams>(plug);

            OtherParam param = new OtherParam();

            if (rowindex >= 0)
            {
                param = ret.OtherParams[rowindex];
            }
            else
            {
                param.Priority = 1;
                param.AreaIds = new List<int>();
                param.ExcludeAreaIds = new List<int>();
                param.OtherSections = new List<JZHSection>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug4Configure(string id, string AreaIds, string ExcludeAreaIds, int priority, string OtherSections)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<JZHSection>>(OtherSections);
            var areaids = AreaIds.Split(new char[] { ',', '，' });
            var eareaids = ExcludeAreaIds.Split(new char[] { ',', '，' });
            OtherParam param = new OtherParam
            {
                AreaIds = areaids.ToList().Select(x => int.Parse(x)).ToList(),
                ExcludeAreaIds = eareaids.ToList().Select(x => int.Parse(x)).ToList(),
                Priority = priority,
                OtherSections=Sections 
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(4);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage._OtherParams>(plug);
            ret.OtherParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(4, jss.Serialize(ret));
        }

        public bool AddPlug4Configure(string id, string AreaIds, string ExcludeAreaIds, int priority, string OtherSections)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<JZHSection>>(OtherSections);
            var areaids = AreaIds.Split(new char[] { ',', '，' });
            var eareaids = ExcludeAreaIds.Split(new char[] { ',', '，' });
            OtherParam param = new OtherParam
            {
                AreaIds = areaids.ToList().Select(x => int.Parse(x)).ToList(),
                ExcludeAreaIds = eareaids.ToList().Select(x => int.Parse(x)).ToList(),
                Priority = priority,
                OtherSections = Sections
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(4);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage._OtherParams>(plug);
            ret.OtherParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(4, jss.Serialize(ret));
        }
        #endregion


        #region 偏远地区运费计算
        public ActionResult Detail5()
        {
            return View();
        }

        public ActionResult Detail5Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(5);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<_RemoteParams>(plug);

            return View(ret);
        }

        public ActionResult Detail5Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(5);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<_RemoteParams>(plug);

            RemoteParam param = new RemoteParam();

            if (rowindex >= 0)
            {
                param = ret.RemoteParams[rowindex];
            }
            else
            {
                param.Priority = 1;
                param.AreaIds = new List<int>();
                param.ExcludeAreaIds = new List<int>();
                param.RemoteSections = new List<RemoteSection>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug5Configure(string id, string AreaIds, string ExcludeAreaIds, int priority, string RemoteSections)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<RemoteSection>>(RemoteSections);
            var areaids = AreaIds.Split(new char[] { ',', '，' });
            var eareaids = ExcludeAreaIds.Split(new char[] { ',', '，' });
            RemoteParam param = new RemoteParam
            {
                AreaIds = areaids.ToList().Select(x => int.Parse(x)).ToList(),
                ExcludeAreaIds = eareaids.ToList().Select(x => int.Parse(x)).ToList(),
                Priority = priority,
                 RemoteSections=Sections 
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(5);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage._RemoteParams >(plug);
            ret.RemoteParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(5, jss.Serialize(ret));
        }

        public bool AddPlug5Configure(string id, string AreaIds, string ExcludeAreaIds, int priority, string RemoteSections)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<RemoteSection>>(RemoteSections);
            var areaids = AreaIds.Split(new char[] { ',', '，' });
            var eareaids = ExcludeAreaIds.Split(new char[] { ',', '，' });
            RemoteParam param = new RemoteParam
            {
                AreaIds = areaids.ToList().Select(x => int.Parse(x)).ToList(),
                ExcludeAreaIds = eareaids.ToList().Select(x => int.Parse(x)).ToList(),
                Priority = priority,
                RemoteSections = Sections
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(5);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage._RemoteParams>(plug);
            ret.RemoteParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(5, jss.Serialize(ret));
        }
        #endregion



        #region 母婴之家运费规则
        public ActionResult Detail1()
        {
            return View();
        }
        #endregion


        #region 运费0元
        public ActionResult Detail8()
        {
            return View();
        }
        #endregion


        #region 海淘运费计算(按照购买数量收取150元运费)
        public ActionResult Detail6()
        {
            return View();
        }

        public ActionResult Detail6Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(6);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<SeaWashesBuyCount>(plug);

            return View(ret);
        }

        public ActionResult Detail6Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(6);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<SeaWashesBuyCount>(plug);

            SeaWashesBuyCountParam param = new SeaWashesBuyCountParam();

            if (rowindex >= 0)
            {
                param = ret.SeaWashesBuyCountParams[rowindex];
            }
            else
            {
                param.Priority = 1;
                param.Suppliers = new List<int>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug6Configure(string id, string Suppliers, int BuyCount, int FullCarriage, int NoFullCarriage, int Priority)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            SeaWashesBuyCountParam param = new SeaWashesBuyCountParam
            {
                Suppliers = Suppliers.Split(new char[] { ',', '，' }).ToList().Select(x => int.Parse(x)).ToList(),
                BuyCount = BuyCount,
                FullCarriage = FullCarriage,
                NoFullCarriage = NoFullCarriage,
                Priority = Priority
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(6);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.SeaWashesBuyCount>(plug);
            ret.SeaWashesBuyCountParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(6, jss.Serialize(ret));
        }

        public bool AddPlug6Configure(string id, string Suppliers, int BuyCount, int FullCarriage, int NoFullCarriage, int Priority)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            SeaWashesBuyCountParam param = new SeaWashesBuyCountParam
            {
                Suppliers = Suppliers.Split(new char[] { ',', '，' }).ToList().Select(x => int.Parse(x)).ToList(),
                BuyCount = BuyCount,
                FullCarriage = FullCarriage,
                NoFullCarriage = NoFullCarriage,
                Priority = Priority
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(6);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.SeaWashesBuyCount>(plug);
            ret.SeaWashesBuyCountParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(6, jss.Serialize(ret));
        }
        #endregion


        #region 海淘运费计算(按照重量等级计算)
        public ActionResult Detail7()
        {
            return View();
        }

        public ActionResult Detail7Show()
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(7);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<SeaWashesWeight>(plug);

            return View(ret);
        }

        public ActionResult Detail7Operation(int rowindex = -1)
        {
            var plug = AdminCarriageClient.Instance.GetPlugConfigure(7);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ret = jss.Deserialize<SeaWashesWeight>(plug);

            SeaWashesWeightParam param = new SeaWashesWeightParam();

            if (rowindex >= 0)
            {
                param = ret.SeaWashesWeightParams[rowindex];
            }
            else
            {
                param.Priority = 1;
                param.Suppliers = new List<int>();
                param.WeightList = new List<_WeightList>();
            }

            ViewBag.rowindex = rowindex;
            return View(param);
        }

        public bool UpdatePlug7Configure(string id, string Suppliers, int priority, string WeightList)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<_WeightList>>(WeightList);
            var suppliers = Suppliers.Split(new char[] { ',', '，' });

            SeaWashesWeightParam param = new SeaWashesWeightParam
            {
                WeightList = Sections,
                Suppliers = suppliers.Select(x => int.Parse(x)).ToList(),
                Priority = priority
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(7);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.SeaWashesWeight>(plug);
            ret.SeaWashesWeightParams[Convert.ToInt32(id)] = param;
            return AdminCarriageClient.Instance.UpdatePlugConfigure(7, jss.Serialize(ret));
        }

        public bool AddPlug7Configure(string id, string Suppliers, int priority, string WeightList)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var Sections = jss.Deserialize<List<_WeightList>>(WeightList);
            var suppliers = Suppliers.Split(new char[] { ',', '，' });

            SeaWashesWeightParam param = new SeaWashesWeightParam
            {
                WeightList = Sections,
                Suppliers = suppliers.Select(x => int.Parse(x)).ToList(),
                Priority = priority
            };

            var plug = AdminCarriageClient.Instance.GetPlugConfigure(7);


            var ret = jss.Deserialize<Myzj.OPC.UI.Model.AdminCarriage.SeaWashesWeight>(plug);
            ret.SeaWashesWeightParams.Add(param);
            return AdminCarriageClient.Instance.UpdatePlugConfigure(7, jss.Serialize(ret));
        }
        #endregion
    }
}
