using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.BaseCouponConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class CouponSendManagerController : BaseController
    {
        //
        // GET: /CouponSendManager/

        public ActionResult Index()
        {
            return View();
        }


        //发送优惠券
        public JsonResult Save(string memNos, string couponKey)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "发送失败，请稍后重试... ..." };
            try
            {
                var list = new List<M_SendInfo>();
                memNos = memNos.Replace("，", ",").Trim();//替换中文字符
                foreach (var item in memNos.Split(','))
                {
                    var userId = 0;
                    int.TryParse(item, out userId);
                    list.Add(new M_SendInfo
                        {
                            CouponKey = couponKey,
                            UserId = userId,
                            SendDescription = "系统发送"
                        });
                }
                var request = new CouponSendDetail
                    {
                        Operator = UserInfo.UserSysNo,
                        ClientIp = ServiceData.GetClientIP(),
                        Sends = list
                    };
                var success = "";
                var error = "";
                var doResult = "";
                result.DoFlag = BaseCouponConfigClient.Instance.SendCopuonFunction(request, out doResult, out success, out error);
                result.DoResult = doResult + ";" + success + ";" + error;
            }
            catch (Exception ex)
            {
                result.DoResult = "发送异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //查询列表
        public ActionResult SendRecord(SendCouponRecordRefer refer)
        {
            var result = new SendCouponRecordRefer();
            result = BaseCouponConfigClient.Instance.QuerySendCouponPageList(refer);

            return View(result);
        }

        //用户优惠券作废
        public JsonResult CancelCoupon(string sysNos, string remarks)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "作废失败" };
            if (string.IsNullOrEmpty(sysNos))
            {
                result.DoResult = "请选择作废项";
                return Json(result);
            }
            if (string.IsNullOrEmpty(remarks))
            {
                result.DoResult = "请填写作废原因";
                return Json(result);
            }
            remarks += ",操作类型：作废 ,操作人：" + UserInfo.UserName + ",  操作时间：" + DateTime.Now;

            var listSysNos = sysNos.Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(int.Parse).ToList();
            result.DoResult = BaseCouponConfigClient.Instance.CancelCoupon(listSysNos, remarks);
            if (!string.IsNullOrEmpty(result.DoResult))
                result.DoFlag = true;
            return Json(result);
        }

        //查询批量发送优惠券批次
        public ActionResult QueryBatchSendCoupon(BaseRefer<CouponBatchSendDetail, CouponBatchSendDetailExt> refer)
        {
            var result = new BaseRefer<CouponBatchSendDetail, CouponBatchSendDetailExt>();
            result = BaseCouponConfigClient.Instance.QueryCouponBatchSend(refer);
            return View(result);
        }

        //上传批量发送优惠券文件
        public ActionResult BatchSendCoupon()
        {
            return View();
        }

        //下载模板、
        public FileResult GetFile()
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "TempExcel\\";
            //string fileName = "批量导入优惠劵格式模板(20151102).xlsx";
            var url = Configurator.JsonServiceUrl("DownFile");
            var fileName = Server.MapPath(url);

            var name = Path.GetFileName(fileName);
            return File(fileName, "application/ms-excel", Url.Encode(name));
        }

        public ActionResult ImprotSendCoupon()
        {
            ViewBag.Message = "";
            var exeType = Request.Form["ExeType"];
            var dTime = Request.Form["txtAdvanceTime"];
            ViewBag.AdvanceTime = dTime;
        
            if (exeType == "1")
            {
                if (string.IsNullOrEmpty(dTime))
                {
                    ViewBag.Message = "请输入预约时间";
                    return View("BatchSendCoupon");
                }

                //if (DateTime.Parse(dTime) <= DateTime.Now.AddMinutes(10))
                //{
                //    ViewBag.Message = "预约时间要在当前时间10分钟之后";
                //    return View("BatchSendCoupon");
                //}
            }
           
            var file = Request.Files["files"];
            if (file == null)
            {
                ViewBag.Message = "请选择上传文件";
                return View("BatchSendCoupon");
            }


            try
            {
                var filename = Path.GetFileName(file.FileName);
                if (string.IsNullOrEmpty(filename))
                {
                    ViewBag.Message = "请选择上传文件";
                    return View("BatchSendCoupon");
                }
                var filesize = file.ContentLength;//获取上传文件的大小单位为字节byte
                var fileEx = Path.GetExtension(filename);//获取上传文件的扩展名
                var noFileName = Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名
                int maxSize = 4000 * 1024;//定义上传文件的最大空间大小为4M
                var fileType = ".xls,.xlsx";//定义上传文件的类型字符串

                var fileName = noFileName + "_" + System.Guid.NewGuid() + fileEx;
                if (!fileType.Contains(fileEx))
                {
                    ViewBag.Message = "文件类型不对，只能导入xls和xlsx格式的文件";
                    return View("BatchSendCoupon");
                }
                if (filesize >= maxSize)
                {
                    ViewBag.Message = "上传文件超过4M，不能上传";
                    return View("BatchSendCoupon");
                }
                var url = Configurator.JsonServiceUrl("UploadFile");
                if (!Directory.Exists(url))//如果不存在就创建file文件夹
                {
                  //  Directory.CreateDirectory(Server.MapPath("~/TempExcel"));
                    Directory.CreateDirectory(url);
                }
                //string virtualPath = string.Format("~/TempExcel/{0}", fileName);
                string virtualPath = string.Format("{0}{1}",url,fileName);
                // 文件系统不能使用虚拟路径
               // string path = this.Server.MapPath(virtualPath);
                file.SaveAs(virtualPath);
                string batchFileName = fileName;
                DateTime advanceTime =exeType=="1"?DateTime.Parse(dTime):DateTime.Now;
                int? userid = UserInfo.UserSysNo;
                string applyPeople = UserInfo.UserName;
                DateTime applyTime = DateTime.Now;
                int? exeState = 0;
                
                string exeDescription = "";

                var flag = BaseCouponConfigClient.Instance.AddCouponBatchSend(batchFileName, advanceTime, userid, applyPeople, applyTime, exeState, int.Parse(exeType), exeDescription);
                if (flag)
                {
                    ViewBag.Message = "上传成功";
                    if (exeType == "0")//立即执行
                    {
                        //根据文件名 查询批次
                        var refer = new BaseRefer<CouponBatchSendDetail, CouponBatchSendDetailExt>();
                        refer.SearchDetail=new CouponBatchSendDetail();
                        refer.SearchDetail.BatchFileName = batchFileName;
                        var list = BaseCouponConfigClient.Instance.QueryCouponBatchSend(refer).List2;
                        if (list != null && list.Any())
                        {
                           var sysNo=list.First().SysNo;
                          flag =BaseCouponConfigClient.Instance.ExeImprot(sysNo);
                          if (flag)
                          {
                              ViewBag.Message = "执行成功";
                          }
                          else
                          {
                              ViewBag.Message = "执行失败";
                          }

                        }
                    }
                }
                else
                {
                    ViewBag.Message = "上传失败";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }
            return View("BatchSendCoupon");
        }

        //取消执行
        public JsonResult CancelBatchSendCoupon(int sysNo)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "取消失败" };
            var flag = BaseCouponConfigClient.Instance.CancelCouponBatchSend(sysNo);
            if (flag)
            {
                result.DoFlag = true;
                result.DoResult = "取消成功";
            }
            return Json(result);
        }
    }
}
