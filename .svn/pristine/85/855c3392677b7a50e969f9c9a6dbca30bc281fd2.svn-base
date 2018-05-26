using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Portal.UploadService;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Preview()
        {
            return View();
        }

        #region 图片上传
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        public ActionResult ImgUpload()
        {
            return View();
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ImageUploading()
        {
            var result = new BaseResponse();

            var hfc = System.Web.HttpContext.Current.Request.Files;
            string imgPath = "";
            if (hfc[0].ContentLength > 0)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") +
                    DateTime.Now.Millisecond.ToString() + "_" + hfc[0].FileName;

                string fileSuffix = "";
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileSuffix = fileName.Substring(fileName.Length - 4, 4).ToLower();
                }
                if ((fileSuffix == ".jpg" || fileSuffix == ".jpeg" || fileSuffix == ".bmp" || fileSuffix == ".png" ||
                     fileSuffix == ".gif") && (fileName.StartsWith("..") == false))
                {
                    byte[] b = new byte[hfc[0].ContentLength];
                    System.IO.Stream fs;
                    fs = hfc[0].InputStream;
                    fs.Read(b, 0, hfc[0].ContentLength); //将输入流读入二进制数组中

                    var uploadClient = new Upload_pictureClient();
                    try
                    {
                        var uploadResult = uploadClient.WcfUploadPicture(b, fileName);
                        if (uploadResult == "文件上传成功")
                        {
                            result.DoFlag = true;
                            imgPath = "/product/userupload/" + fileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                   
                }
                else
                {
                    result.DoResult = "请上传正确的图片类型！如：jpg,png,gif后缀名结尾";
                }
                
            }
            else
            {
                result.DoResult = "请选择上传的图片";
            }

            return Json(new { DoFlag = result.DoFlag, DoResult = result.DoResult, imgPath = imgPath }, "text/html", JsonRequestBehavior.AllowGet);

           // return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
