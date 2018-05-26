using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCarriage;
using Myzj.OPC.UI.ServiceClient;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class CarriageManagerController : Controller
    {
        //
        // GET: /CarriageManager/

        public ActionResult Index(BaseRefer<BuyAppointGoodsParam> refer)
        {
            var result = new BaseRefer<BuyAppointGoodsParam>();
            result = BaseCarriageConfigClient.Instance.QueryCarriageConfig(refer);
            return View(result);
        }

        public ActionResult EditCarriageRule(int? sysNo)
        {
            ViewBag.Title = "编辑";
            var result = new BaseRefer<BuyAppointGoodsParam>();
            result = BaseCarriageConfigClient.Instance.QueryAllCarriageConfig();
            var list = result.List2.Where(m => m.SysNo == sysNo).FirstOrDefault();
            if (list == null)
            {
                ViewBag.Title = "新增";
                list = new BuyAppointGoodsParam();
            }
            return View(list);
        }

        public JsonResult SaveCarriageRule(BuyAppointGoodsParam param)
        {
            var result = new BaseResponse() { };
            result.DoFlag = false;
            result.DoResult = "保存失败";
            var req = new BaseRefer<BuyAppointGoodsParam>();
            req = BaseCarriageConfigClient.Instance.QueryAllCarriageConfig();
            if (param.IsEnable)
            {
                var list = req.List2.Where(m => m.StartTime <= param.EndTime && m.EndTime >= param.StartTime && m.IsEnable).ToList();
                foreach (var item in list)
                {
                    //校检商品id是否已存在其他策略中
                    if (item.IsEnable && item.SysNo != param.SysNo && item.GoodsIds.Any(m => param.GoodsIds.Any(t => t == m)))
                    {
                        result.DoResult = "商品id已在其他策略中存在";
                        return Json(result);
                    }
                }
            }
            var list2 = req.List2;
            if (param.SysNo > 0)//修改
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    if (list2[i].SysNo == param.SysNo)
                    {
                        list2[i].Platforms = param.Platforms;
                        list2[i].GoodsIds = param.GoodsIds;
                        list2[i].PromIds = param.PromIds;
                        list2[i].ExcludePromIds = param.ExcludePromIds;
                        list2[i].AreaIds = param.AreaIds;
                        list2[i].ExcludeAreaIds = param.ExcludeAreaIds;
                        list2[i].StartTime = param.StartTime;
                        list2[i].EndTime = param.EndTime;
                        list2[i].FullCarriage = param.FullCarriage;
                        list2[i].IsEnable = param.IsEnable;
                        list2[i].Remark = param.Remark;
                    }

                }
            }
            else
            {
                param.SysNo = list2.FirstOrDefault().SysNo + 1;
                while (req.List2.Any(m => m.SysNo == param.SysNo))
                {
                    param.SysNo += 1;
                }
                list2.Add(param);
            }
            BuyAppointGoodsCarriage carriage = new BuyAppointGoodsCarriage();
            carriage.BuyAppointGoodsParams = list2;
            var str = JsonConvert.SerializeObject(carriage);
            var flag = BaseCarriageConfigClient.Instance.SaveCarriageConfig(str);
            result.DoFlag = flag;
            return Json(result);
        }

        public ActionResult AreaList(string id, string AreaName)
        {
            ViewBag.ID = id;
            ViewBag.AreaName = AreaName;
            var dic = new Dictionary<int?, string>();
            if (!string.IsNullOrEmpty(AreaName))
            {
                var list = BaseCarriageConfigClient.Instance.GetAllArea().Where(m => m.Value.Contains(AreaName));
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        if (item.Key.HasValue)
                            dic.Add(item.Key, item.Value);
                    }
                }
            }
            else
            {
                dic = BaseCarriageConfigClient.Instance.GetAllArea();
            }
            return View(dic);
        }

    }
}
