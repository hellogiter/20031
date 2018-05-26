using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.UserPdtComment;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class UserPdtCommentController : BaseController
    {
        // GET: /UserPdtComment/

        #region 评论列表
        public ActionResult Index(UserPdtCommentRefer comment)
        {
            var result = new UserPdtCommentRefer();
            result = UserPdtCommentClient.Instance.QueryUserPdtComment(comment);
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }

        #endregion

        #region 详细信息

        public ActionResult Detail(int? id)
        {
            var result = new UserPdtCommentDetail();
            result.IntCommentID = id;
            result = UserPdtCommentClient.Instance.QueryUserPdtCommentById(result);

            #region 获取评论信息下面的所有回复信息

            var req = new UserPdtCommentCusReplyRefer();
            req.SearchDetail.CommentId = id.Value;

            var resComment = UserPdtCommentClient.Instance.QueryUserPdtCommentCusReply(req);
            ViewBag.CommentCusReply = resComment;

            #endregion

            return View(result);
        }

        #endregion

        #region 批量更新回复内容

        public JsonResult UpdateComment(UserPdtCommentCusReplyBody comment)
        {
            var result = new BaseResponse();
            try
            {
                var res = UserPdtCommentClient.Instance.QueryUserPdtCommentCusReply(comment);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = "批量操作成功... ...";
                }
                else
                {
                    result.DoResult = "批量操作失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "批量操作失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 批量修改评论
        [HttpPost]
        public JsonResult UpdatePlUserPdtComment(UserPdtCommentBody search, int? commentId)
        {
            var result = new BaseResponse();
            if (search.TempCommentDos != null)
            {
                foreach (var temp in search.TempCommentDos)
                {
                    temp.IntReplyUserId = UserInfo.UserSysNo;
                    temp.DtReplyDateTime = DateTime.Now;
                    temp.IntAuditUserID = UserInfo.UserSysNo;
                    temp.DtAuditDate = DateTime.Now;
                }
            }
            var res = UserPdtCommentClient.Instance.UpdatePLUserPdtComment(search);
            if (res)
            {
                result.DoFlag = true;
                result.DoResult = "批量修改成功!";
            }
            else
            {
                result.DoResult = "批量修改失败，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 批量导入评论
        /// <summary>
        /// 批量导入评论
        /// </summary>
        /// <returns></returns>
        public void UploadFile()
        {
            try
            {
                //设置上传目录
                string path = Server.MapPath("~/Content/upload/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                //判断是否已经选择上传文件
                HttpPostedFileBase file = Request.Files["file"];
                if (file != null && file.ContentLength > 0)
                {
                    string filenName = file.FileName;
                    string fileExt = Path.GetExtension(filenName).ToLower().Substring(1);
                    if (fileExt != "xls" && fileExt != "xlsx")
                    {
                        ModelState.AddModelError("", "您选择的不是Excel文件");
                        //return View("Index");
                    }
                    else
                    {
                        #region 上传文件
                        string filepath = path + filenName;
                        file.SaveAs(filepath);
                        //读取excel文件，转换成dataset
                        string strConn;
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath +
                                  ";Extended Properties=Excel 8.0;";
                        OleDbConnection conn = new OleDbConnection(strConn);
                        OleDbDataAdapter oada = new OleDbDataAdapter("select * from [Sheet1$]", strConn);
                        DataTable dt = new DataTable();
                        oada.Fill(dt);
                        #endregion

                        AddPLPLUserPdtComment list = new AddPLPLUserPdtComment();
                        list.AddCommentDos = new List<UserPdtCommentDetail>();
                        #region 循环读取每一行，将数据插入到sql server数据库

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                UserPdtCommentDetail model = new UserPdtCommentDetail();
                                model.IntProductID = Convert.ToInt32(row[0]);
                                model.VchContent = row[1].ToString();
                                model.DtCommentDate = Convert.ToDateTime(row[2]);
                                model.VchEmail = row[3].ToString();
                                model.IntUserID = 0;
                                model.IntOrderNO = 0;
                                model.IntGroupID = 0;
                                model.VchPdtName = "";
                                model.IntStart = 5;
                                model.IntIsMask = 1;
                                model.IntIsHighLight = 0;
                                model.IntIndexVisible = 0;
                                model.IntAuditState = 1;
                                list.AddCommentDos.Add(model);
                            }
                        }
                        #endregion

                        #region 批量导入数据库
                        var res = UserPdtCommentClient.Instance.AddPdtComment(list);
                        if (res)
                        {
                            Response.Write("<script>alert('导入全部成功!');window.location.href='/UserPdtComment/index'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('部分导入成功!,修改后再继续导入!');window.location.href='/UserPdtComment/index'</script>");
                        }
                        #endregion
                    }
                }
                else
                {
                    Response.Write("<script>alert('请选择文件!');window.location.href='/UserPdtComment/index'</script>");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "请选择文件");
                Response.Write("<script>alert('请选择文件!');window.location.href='/UserPdtComment/index'</script>");
            }
        }
        #endregion
    }
}
