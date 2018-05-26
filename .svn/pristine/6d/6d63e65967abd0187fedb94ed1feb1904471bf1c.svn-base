using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.MKMS.ServiceModel;
using Myzj.OPC.UI.Model.WordLibManage;
using Myzj.OPC.UI.ServiceClient;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class WordLibManageController : BaseController
    {
        //
        // GET: /WordLibManage/

        /// <summary>
        /// Indexes the specified search.查询列表
        /// </summary>
        /// <param name="search">The search.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public ActionResult Index(WordLibManageRefer search)
        {
            var result = new WordLibManageRefer();
            if (search.WordLibManageDetail.KeyWord != null)
            {
                search.WordLibManageDetail.KeyWord = search.WordLibManageDetail.KeyWord.Trim();
            }
            if (search.WordLibManageDetail.EnableStr >-1)
            {
                search.WordLibManageDetail.Enable = search.WordLibManageDetail.EnableStr>0;
            }

            result = WordLibManageConfigClient.Instance.QueryWordLibManagePageList(search);
            return View(result);
        }


        /// <summary>
        /// Edits the detail.编辑一条数据
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public ActionResult EditDetail(int? id)
        {
            WordLibManageDetail result=new WordLibManageDetail();
            if (id > 0)
            {
                result = WordLibManageConfigClient.Instance.QueryWordLibManageEntity(id??0);
            }
            return View(result);
        }

        /// <summary>
        /// Forbiddens the type list.获取类型列表
        /// </summary>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public ActionResult ForbiddenTypeList()
        {
            var result = WordLibManageConfigClient.Instance.QueryForbiddenTypeList();
            return View(result);
        }

        /// <summary>
        /// Edits the FBD tp detail.修改时查询一条数据
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public ActionResult EditFbdTpDetail(int? id)
        {
            ForbiddenTypeDetail result = new ForbiddenTypeDetail();
            if (id > 0)
            {
                result = WordLibManageConfigClient.Instance.QueryForbiddenTypeEntity(id ?? 0);
            }
            return View(result);
        }


        /// <summary>
        /// Updates the or add entity.添加或更新记录
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/2/2016
        public JsonResult UpdateOrAddEntity(WordLibManageDetail model)
        {
            var result = new BaseResponse() {DoFlag = false, DoResult = model.Id > 0 ? "编辑失败" : "新增失败"};
            if (model.Id > 0)
            {
                model.LastOperator = UserInfo.UserSysNo.ToString();
                model.LastUpdateTime = DateTime.Now;
                if (model.KeyWord.TrimEnd(';').IndexOf(';') > 0)
                {
                    result.DoFlag = false;
                    result.DoResult = "只能更新一个词语";
                }
                else
                {
                    model.KeyWord = model.KeyWord.TrimEnd(';');
                    var res = WordLibManageConfigClient.Instance.UpdateWordLibManageEntity(model);
                    result.DoResult = res.DoResult;
                    result.DoFlag = res.DoFlag;
                }
            }
            else
            {
                model.CreateTime=DateTime.Now;
                model.Operator = UserInfo.UserSysNo.ToString();
                model.LastOperator = UserInfo.UserSysNo.ToString();
                model.LastUpdateTime = DateTime.Now;
                var res = WordLibManageConfigClient.Instance.AddWordLibManage(model);
                result.DoFlag = res.DoFlag;
                result.DoResult = res.DoResult;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Updates the or add tp entity.添加或更新一个类型
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/8
        public JsonResult UpdateOrAddFbTpEntity(ForbiddenTypeDetail model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = model.Id > 0 ? "编辑失败" : "新增失败" };
            if (model.Id > 0)
            {
                var res = WordLibManageConfigClient.Instance.UpdateFbTpEntity(model);
                result.DoResult = res.DoResult;
                result.DoFlag = res.DoFlag;
            }
            else
            {
                var res = WordLibManageConfigClient.Instance.AddForbiddenType(model);
                result.DoFlag = res.DoFlag;
                result.DoResult = res.DoResult;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Deletes the or lock entity.
        /// </summary>
        /// <param name="paramJson">The parameter json.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 6/3/2016
        public JsonResult DelOrLockEntity(ParamJson paramJson)
        {
            //var JsonObj = JsonConvert.DeserializeObject<ParamJson>(paramJson);
            string ids = paramJson.Ids;
            int isDel = paramJson.IsDel;
            int isEnable = paramJson.IsEnable;
            var result = new BaseResponse() { DoFlag = false, DoResult = (isDel > 0) ? "删除失败" : (isEnable > 0 ? "禁用失败" : "启用失败") };
            if (string.IsNullOrEmpty(ids))
            {
                result.DoResult = "请您先勾选";
                return Json(result);
            }
            var listId = ids.Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(int.Parse).ToList();
            string lastoperator = UserInfo.UserSysNo.ToString();
            DateTime lastupdatetime = DateTime.Now;
            var res = WordLibManageConfigClient.Instance.SetIsDelOrEnable(listId, isDel, isEnable, lastoperator,lastupdatetime);
            result.DoFlag = res.DoFlag;
            result.DoResult = res.DoResult;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Deletes the fb tp entity.删除类型
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/10
        [HttpPost]
        public JsonResult DeleteFbTpEntity(string ids)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "删除失败"};
            if (string.IsNullOrEmpty(ids))
            {
                result.DoResult = "请您先勾选";
                return Json(result);
            }
            var listId = ids.Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(int.Parse).ToList();
            var res = WordLibManageConfigClient.Instance.DeleteForbiddenTp(listId);
            result.DoFlag = res.DoFlag;
            result.DoResult = res.DoResult;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Resets the index.对类型排序
        /// </summary>
        /// <returns></returns>
        /// Creator:ysx2012
        /// 2016/6/6
        public JsonResult ResetIndex()
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "重建失败" };
            var res = WordLibManageConfigClient.Instance.ResetIndex();
            if (res.DoFlag)
            {
                result.DoFlag = true;
                result.DoResult = "重建成功";
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}
