using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.FloorConfig;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class FloorConfigController : BaseController
    {
        // GET: /FloorConfig/

        //*****************操作dbo.FloorConfig表******************************

        #region 楼层配置列表
        public ActionResult Index(FloorConfigRefer floorConfig)
        {
            var result = new FloorConfigRefer();
            result = FloorConfigClient.Instance.QueryFloorConfigRefer(floorConfig);

            //获取楼层类型
            var resultItem = FloorConfigClient.Instance.QueryFloorItemsConfig(1);

            //生成下拉列表并绑定值
            List<SelectListItem> ddClass = new List<SelectListItem>();
            foreach (var cls in resultItem)
            {
                ddClass.Add(new SelectListItem() { Value = cls.SysNo.ToString(), Text = cls.FloorTypeName });
            }
            ViewData.Add("SearchDetail.TempFloorType", ddClass);

            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 根据Id查询单条信息

        public ActionResult Detail(int? id)
        {
            var result = new FloorConfigDetail();
            if (id > 0)
            {
                result = FloorConfigClient.Instance.QueryFloorConfigById(id.Value);
            }
            //获取楼层类型
            var resultItem = FloorConfigClient.Instance.QueryFloorItemsConfig(1);
            ViewBag.ItemModel = resultItem;
            return View(result);
        }

        #endregion

        #region 修改/新增楼层配置

        public JsonResult Save(FloorConfigDetail floorConfig)
        {
            var result = new BaseResponse() { };
            try
            {
                if (floorConfig.SysNo > 0)
                {
                    //修改
                    // floorConfig.UpdateBy = UserInfo.UserSysNo;
                    floorConfig.UpdateBy = 123456;
                    floorConfig.UpdateTime = DateTime.Now;
                    var res = FloorConfigClient.Instance.UpdateFloorConfig(floorConfig);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ...";
                    }
                }
                else
                {
                    //新增
                    // floorConfig.Createby = UserInfo.UserSysNo;
                    floorConfig.CreateTime = DateTime.Now;
                    floorConfig.UpdateBy = 123456;
                    var res = FloorConfigClient.Instance.AddFloorConfig(floorConfig);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后重试... ...";
            }
            return Json(result);
        }

        #endregion

        #region 修改楼层配置排序

        public JsonResult UpdateSort(int id, int sort)
        {
            var result = new BaseResponse();
            try
            {
                var res = FloorConfigClient.Instance.UpdateFloorConfigSort(id, sort);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 删除楼层配置

        public JsonResult Del(int id)
        {
            var result = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var res = FloorConfigClient.Instance.DelFloorConfig(id);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "删除失败，请稍后重试... ...";
                    }
                }
                else
                {
                    result.DoResult = "参数出错... ...";
                }
            }
            catch (Exception)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //*****************操作FloorDetailConfig表******************************

        #region 根据楼层配置FloorDetailConfig->floorid查询相关联的楼层配置详细配置列表信息
        /// <summary>
        /// 根据楼层配置FloorDetailConfig->floorid查询相关联的楼层配置详细配置列表信息
        /// </summary>
        /// <param name="id">楼层配置ID</param>
        /// <param name="name">楼层名称</param>
        /// <returns></returns>
        public ActionResult FloorItem(int id, string name)
        {
            var model = new FloorDetailRefer();
            model.SearchDetail.FloorID = id;
            if (id > 0)
            {
                model = FloorConfigClient.Instance.QueryFloorDetail(model);
            }
            ViewBag.Name = name;
            ViewBag.FloorID = id;
            return View(model);
        }
        #endregion

        #region 根据FloorDetailConfig->Id查询单条信息
        /// <summary>
        /// 根据FloorDetailConfig->Id查询单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strName">上一级名称</param>
        /// <param name="name">当前级别名称</param>
        /// <param name="floorId">楼层ID</param>
        /// <returns></returns>
        public ActionResult FloorDetail(int? id, string strName, string name, int floorId)
        {
            var result = new FloorDetailDetail();

            if (id > 0)
            {
                result = FloorConfigClient.Instance.QueryFloorDetailById(id.Value);
            }

            //获取楼层类型
            var resultItem = FloorConfigClient.Instance.QueryFloorItemsConfig(2);
            ViewBag.ItemModel = resultItem;

            ViewBag.StrName = strName;
            ViewBag.Name = name;
            ViewBag.FloorID = floorId;
            return View(result);
        }

        #endregion

        #region 修改/新增楼层配置FloorDetailConfig相关信息

        public JsonResult SaveFloorDetail(FloorDetailDetail floorDetail)
        {
            var result = new BaseResponse() { };
            try
            {
                if (floorDetail.SysNO > 0)
                {
                    //修改
                    var res = FloorConfigClient.Instance.UpdateFloorDetail(floorDetail);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ...";
                    }
                }
                else
                {
                    //新增
                    var res = FloorConfigClient.Instance.AddFloorDetail(floorDetail);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ...";
                    }

                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后重试... ...";
            }
            return Json(result);
        }

        #endregion

        #region 修改楼层配置FloorDetailConfig相关信息排序

        public JsonResult UpdateDetailSort(int id, int sort)
        {
            var result = new BaseResponse();
            try
            {
                var res = FloorConfigClient.Instance.UpdateDetailSort(id, sort);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 删除楼层配置FloorDetailConfig相关信息

        public JsonResult DelDetail(int id)
        {
            var result = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var res = FloorConfigClient.Instance.DelDetail(id);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "删除失败，请稍后重试... ...";
                    }
                }
                else
                {
                    result.DoResult = "参数出错... ...";
                }
            }
            catch (Exception)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //*****************操作FloorLabelConfig表******************************

        #region 根据楼层floordetailId查询相关联的楼层配置详细配置列表信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">楼层详情配置ID</param>
        /// <param name="strName">首级别名称</param>
        /// <param name="name">上一级名称</param>
        /// /// <param name="floorId">上一级楼层Id</param>
        /// <returns></returns>
        public ActionResult FloorLabelItem(int id, string strName, string name, int floorId)
        {
            var result = new FloorLabelRefer();
            result.SearchDetail.FloorDetailID = id;
            if (id > 0)
            {
                result = FloorConfigClient.Instance.QueryFloorLabel(result);
            }
            ViewBag.StrName = strName;
            ViewBag.Name = name;
            ViewBag.FloorId = floorId;
            return View(result);
        }
        #endregion

        #region 根据FloorLabelConfig->Id查询单条信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="strName">首级名称</param>
        /// <param name="name">当前级名称</param>
        /// <param name="floorId">楼层编号</param>
        /// <returns></returns>
        public ActionResult FloorLabelDetail(int? id, string strName, string name,int floorId)
        {
            var result = new FloorLabelDetail();
            if (id > 0)
            {
                result = FloorConfigClient.Instance.QueryFloorLabelById(id.Value);
            }

            //获取楼层类型
            var resultItem = FloorConfigClient.Instance.QueryFloorItemsConfig(3);
            ViewBag.ItemModel = resultItem;
            ViewBag.StrName = strName;
            ViewBag.Name = name;
            ViewBag.FloorId = floorId;

            return View(result);
        }
        #endregion

        #region 修改/新增FloorLabelConfig

        public JsonResult SaveFloorLabel(FloorLabelDetail floorLabel)
        {
            var result = new BaseResponse() { };
            try
            {
                if (floorLabel.SysNo > 0)
                {
                    //修改
                    var res = FloorConfigClient.Instance.UpdateFloorLabel(floorLabel);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ...";
                    }
                }
                else
                {
                    //新增
                    var res = FloorConfigClient.Instance.AddFloorLabel(floorLabel);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ...";
                    }

                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后重试... ...";
            }
            return Json(result);
        }

        #endregion

        #region 修改FloorLabelConfig排序
        public JsonResult UpdateFloorLableSort(int id, int sort)
        {
            var result = new BaseResponse();
            try
            {
                var res = FloorConfigClient.Instance.UpdateFloorLabelSort(id, sort);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除FloorLabelConfig
        public JsonResult DelFloorLabel(int id)
        {
            var result = new BaseResponse();
            try
            {
                if (id > 0)
                {
                    var res = FloorConfigClient.Instance.DelFloorLabel(id);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "删除失败，请稍后重试... ...";
                    }
                }
                else
                {
                    result.DoResult = "参数出错... ...";
                }
            }
            catch (Exception)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 检测商品编号是否存在商品表
        public JsonResult CheckPdtInfoById(int id)
        {
            var result = new BaseResponse();
            try
            {
                string str;
                var res = FloorConfigClient.Instance.CheckPdtInfoById(id, out str);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = str;
                }
                else
                {
                    result.DoResult = "<font style='color:red'>错误：系统未在商品表中找到商品Id，请检查</font>";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "<font style='color:red'>错误：检测异常，请稍后重试...</font>";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
