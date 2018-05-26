using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.HotStyle;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers.HotStyle
{
    public class HotExecController : Controller
    {
        #region 爆款

        //拖拽排序
        public bool SortableHotStyle(string oldIds, string newIds)
        {
            return HotStyleClient.Instance.SortableHotStyle(oldIds, newIds);
        }
        //置顶
        public JsonResult SetTopHotStyle(int id)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "置顶失败，请稍后重试... ..." };
            result.DoFlag = HotStyleClient.Instance.SetTop(id);
            return Json(result);
        }
        //新增
        public JsonResult AddHotStyle(HotStyleModel model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证

          var hotstyleModel=  HotStyleClient.Instance.QueryHotStylePageList(new HotStyleRefer()
                {
                    Search = new HotStyleModel()
                        {
                            ProductId = model.ProductId
                        }
                });
            if (hotstyleModel.List.Any())
            {
                result.DoResult = "此商品ID已存在";
                return Json(result);
            }


            //if (string.IsNullOrEmpty(model.LogiscticId))
            //{
            //    result.DoResult = "请填写配送商ID";
            //    return Json(result);
            //}

            //if (string.IsNullOrEmpty(model.LogiscticCompanyName))
            //{
            //    result.DoResult = "请填写配送商名称";
            //    return Json(result);
            //}

            //model.RowCreateDate = DateTime.Now;
            //model.IsDel = 0;
            #endregion

            try
            {
                var flag = HotStyleClient.Instance.AddHotStyle(new HotStyleModel
                {
                    ProductId = model.ProductId,
                    Sort = 0,
                    ApplyPlace = model.ApplyPlace,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    HotDescription = model.HotDescription,
                    PictureUrl = model.PictureUrl,
                    PictureUrlTrans = model.PictureUrlTrans,
                    CreateBy = 888,
                    CreateDate = DateTime.Now,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsDeleted = false,
                    IsEnable = model.IsEnable,
                    HotTag = model.HotTag,
                    CountryId = model.CountryId,
                    ApplyLabel = model.ApplyLabel ?? "",
                    IsExpire = 0
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "添加成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常";
            }

            return Json(result);
        }
        //修改
        public JsonResult UpdHotStyle(HotStyleModel model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证


            //if (string.IsNullOrEmpty(model.LogiscticId))
            //{
            //    result.DoResult = "请填写配送商ID";
            //    return Json(result);
            //}
            //if (string.IsNullOrEmpty(model.LogiscticCompany))
            //{
            //    model.LogiscticCompany = "";
            //}

            //if (string.IsNullOrEmpty(model.LogiscticCompanyName))
            //{
            //    result.DoResult = "请填写配送商名称";
            //    return Json(result);
            //}
            //model.RowCreateDate = DateTime.Now;
            //model.IsDel = 0;
            #endregion

            try
            {
                var updModel = new HotStyleModel
                    {
                        Id = model.Id,
                        ProductId = model.ProductId,
                        ApplyPlace = model.ApplyPlace,
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                        HotDescription = model.HotDescription,
                        PictureUrl = model.PictureUrl,
                        PictureUrlTrans = model.PictureUrlTrans,
                        CreateBy = 888,
                        CreateDate = DateTime.Now,
                        UpdateBy = 888,
                        UpdateDate = DateTime.Now,
                        IsDeleted = false,
                        IsEnable = model.IsEnable,
                        HotTag = model.HotTag,
                        CountryId = model.CountryId,
                        ApplyLabel = model.ApplyLabel ?? "",
                        IsExpire = 0
                    };
                var flag = HotStyleClient.Instance.UpdateHotStyle(updModel);
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "更新成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "更新异常";
            }
            return Json(result);
        }
        //删除
        public JsonResult DelHotStyle(int Id)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "作废失败 ，请稍后重试……"
            };
            try
            {
                var model = HotStyleClient.Instance.QueryHotStyleModel(Id);
                var flag = HotStyleClient.Instance.UpdateHotStyle(new HotStyleModel
                {
                    Id = Id,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsDeleted = true,
                    ApplyLabel = "",
                    IsExpire = 0,
                    CreateDate = model.CreateDate
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "删除成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //启用1禁用2
        public JsonResult EnableHotStyle(int Id, int type)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };

            try
            {
                var enalbe = true;
                var desc = "启用";
                if (type == 1)
                {
                    enalbe = false;
                    desc = "禁用";
                }
                var model = HotStyleClient.Instance.QueryHotStyleModel(Id);
                var flag = HotStyleClient.Instance.UpdateHotStyle(new HotStyleModel
                {
                    Id = Id,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsEnable = enalbe,
                    ApplyLabel = "",
                    IsExpire = 0,
                    CreateDate = model.CreateDate
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = desc + "成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "更新异常";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //刷新缓存
        public JsonResult RefreshHotStyleCache(string ApplyPlace)
        {
            var result = new BaseResponse();
            result.DoFlag = HotStyleClient.Instance.RefreshHotStyleCache(ApplyPlace);
            result.DoResult = "Success";
            return Json(result);
        }

        public JsonResult GetUnifyGoods(int pid)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "*商品不存在"
            };
            var ret = HotStyleClient.Instance.QueryUnionGoods(pid);
            if (ret.DoFlag && ret.GoodsDetails != null)
            {
                result.DoFlag = true;
                result.Data = ret.GoodsDetails.title;
                result.DoResult= ret.GoodsDetails.PdtDesc;
            }
            return Json(result);
        }
        #endregion

        #region 专题

        //拖拽排序
        public bool SortableHotSubject(string oldIds, string newIds)
        {
            return HotStyleClient.Instance.SortableHotSubject(oldIds, newIds);
        }
        //置顶
        public JsonResult SetTopHotSubject(int id)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "置顶失败，请稍后重试... ..." };
            result.DoFlag = HotStyleClient.Instance.SetSubjectTop(id);
            return Json(result);
        }
        //新增
        public JsonResult AddHotSubject(HotSubjectModel model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证

            //if (string.IsNullOrEmpty(model.LogiscticId))
            //{
            //    result.DoResult = "请填写配送商ID";
            //    return Json(result);
            //}

            //if (string.IsNullOrEmpty(model.LogiscticCompanyName))
            //{
            //    result.DoResult = "请填写配送商名称";
            //    return Json(result);
            //}

            //model.RowCreateDate = DateTime.Now;
            //model.IsDel = 0;
            #endregion

            try
            {
                var flag = HotStyleClient.Instance.AddHotSubject(new HotSubjectModel
                {
                    SubjectName = model.SubjectName,
                    SujectDesc = model.SujectDesc,
                    ApplyPlace = model.ApplyPlace,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    PictureUrl = model.PictureUrl,
                    PictureUrlTrans = model.PictureUrlTrans,
                    CreateBy = 888,
                    CreateDate = DateTime.Now,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsDeleted = false,
                    IsEnable = model.IsEnable,
                    SetDiscount = model.SetDiscount,
                    ClickUrl = model.ClickUrl,
                    AppClickUrl = model.AppClickUrl,
                    Sort = 0
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "添加成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常";
            }

            return Json(result);
        }
        //修改
        public JsonResult UpdHotSubject(HotSubjectModel model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证

            #endregion
            try
            {
                var flag = HotStyleClient.Instance.UpdateHotSubject(new HotSubjectModel
                {
                    Id = model.Id,
                    SubjectName = model.SubjectName,
                    SujectDesc = model.SujectDesc,
                    ApplyPlace = model.ApplyPlace,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    PictureUrl = model.PictureUrl,
                    PictureUrlTrans = model.PictureUrlTrans,
                    CreateBy = 888,
                    CreateDate = DateTime.Now,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsDeleted = false,
                    IsEnable = model.IsEnable,
                    SetDiscount = model.SetDiscount,
                    ClickUrl = model.ClickUrl,
                    AppClickUrl = model.AppClickUrl,
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "修改成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常";
            }
            return Json(result);
        }
        //删除
        public JsonResult DelHotSubject(int Id)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "作废失败 ，请稍后重试……"
            };
            try
            {
                var flag = HotStyleClient.Instance.UpdateHotSubject(new HotSubjectModel
                {
                    Id = Id,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsDeleted = true
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = "作废成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "作废异常";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //启用1禁用2
        public JsonResult EnableHotSubject(int Id, int type)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };

            try
            {
                var enalbe = true;
                var desc = "启用";
                if (type == 1)
                {
                    enalbe = false;
                    desc = "禁用";
                }
                var flag = HotStyleClient.Instance.UpdateHotSubject(new HotSubjectModel
                {
                    Id = Id,
                    UpdateBy = 888,
                    UpdateDate = DateTime.Now,
                    IsEnable = enalbe
                });
                if (flag)
                {
                    result.DoFlag = true;
                    result.DoResult = desc + "成功";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "更新异常";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //刷新缓存
        public JsonResult RefreshHotSujectCache(string ApplyPlace)
        {
            var result = new BaseResponse();
            result.DoFlag = HotStyleClient.Instance.RefreshHotSujectCache(ApplyPlace);
            result.DoResult = "Success";
            return Json(result);
        }

        #endregion

    }
}
