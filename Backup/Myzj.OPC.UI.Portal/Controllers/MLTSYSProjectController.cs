using System;
using System.Linq;
using System.Web.Mvc;
using Myzj.OPC.UI.Model;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.MLTSYSProjectMannger;
using Myzj.OPC.UI.ServiceClient.MLTSYSProjectClient;


namespace Myzj.OPC.UI.Portal.Controllers
{
    public class MLTSYSProjectController : BaseController, IBaseController
    {
        #region 绑定状态
        //绑定初始值
        public void Action_Load()
        {
            //专题状态
            var accountStatus = typeof(AppEnum.State).GetEnumList();
            ViewData["accountStatus"] = new KvSelectList(accountStatus);

            //图片类型
            var imageType = typeof(AppEnum.ImageType).GetEnumList();
            ViewData["imageType"] = new KvSelectList(imageType);
        }

        // GET: /MLTSYSProject/

        [HttpGet]
        public ActionResult Index()
        {
            MLTSysProjectInfo(new MLTSYSProjectSearchReq());
            return View();
        }
        #endregion

        #region 模糊查询
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <returns></returns>
        [ActionLocator("Query", "Pager")]
        public ActionResult Query(MLTSYSProjectSearchReq MlTSPJReq)
        {
            MLTSysProjectInfo(MlTSPJReq);
            ViewData.Model = MlTSPJReq;
            return View("Index");
        }
        #endregion

        #region 专题列表
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="MlTSPJReq"></param>
        private void MLTSysProjectInfo(MLTSYSProjectSearchReq MlTSPJReq)
        {
            MlTSPJReq.PageIndex = MlTSPJReq.PageIndex ?? 1;
            MlTSPJReq.PageSize = MlTSPJReq.PageSize ?? 10;

            try
            {
                var response = ServiceCollection.MLTSYSProjectServieClient.SysProjectListRequest(MlTSPJReq);

                if (response.DoFlag)
                {
                    if (response.BaseMLTSYSProjectDtos != null && response.BaseMLTSYSProjectDtos.Any())
                    {
                        ViewData["Detail"] = response.BaseMLTSYSProjectDtos;
                        ViewData["Pager"] = new Pager()
                        {
                            PageIndex = MlTSPJReq.PageIndex,
                            PageSize = MlTSPJReq.PageSize,
                            Total = response.Total
                        };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region 新增专题
        //新增专题
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 添加专题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddSysProject(AddSysProject model)
        {
            bool flag = false;

            try
            {
                var obj = new AddMLTSYSProjectServiceClient();
                flag = obj.AddSysProject(model);
            }
            catch (Exception ex)
            {

            }
            return Json(flag, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改专题

        public ActionResult Edit(int? id)
        {
            if (id == null || id < 0)
            {
                ViewData["ErrorMsg"] = "参数错误";
                return View();
            }
            try
            {
                var response = ServiceCollection.EditByIdMLTSYSProjectServiceClient.editByIdMLTSysProjectRequest(new EditMLTSYSProjectReq()
                {
                    ProjectId = id
                });
                if (response.DoFlag)
                {
                    ViewData.Model = response;
                }
                else
                {
                    ViewData["ErrorMsg"] = string.Format("查询失败，失败信息：{0}", response.DoResult);
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMsg"] = string.Format("查询异常，异常信息：{0}", ex.Message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditMLTSYSProjectRes editBaseAccountRes)
        {
            try
            {
                editBaseAccountRes.editTime = DateTime.Now;
                var response = ServiceCollection.EditMLTSYSProjectServiceClient.editMLTSysProjectRequest(editBaseAccountRes);
                if (!response.DoFlag)
                {

                    response.DoResult = string.Format("编辑失败"); 
                }
                else
                {
                    response.DoResult = string.Format("编辑成功");
                    return Redirect(string.Format("Index"));
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new EditMLTSYSProjectRes()
                {
                    DoFlag = false,
                    DoResult = string.Format("编辑异常，异常信息：{0}", ex.Message)
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 删除专题
        [HttpPost]
        public JsonResult DelMLTSYSProject(int id)
        {
            var jsonResult = new BaseResponse() { };
            try
            {
                var response = ServiceCollection.MLTSYSProjectServieClient.DeleteMLTProject(id);
                if (response)
                {
                    jsonResult.DoFlag = true;
                }
                else
                {
                    jsonResult.DoFlag = false;
                }
                return Json(jsonResult);
            }
            catch (Exception exception)
            {
                jsonResult.DoResult = string.Format("删除异常，异常信息：{0}", exception.Message);
                return Json(jsonResult);
            }
        }
        #endregion

        #region 修改专题排序
        /// <summary>
        /// 修改排序
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateSort(int id, int sort)
        {
            try
            {
                var response = ServiceCollection.EditByIdMLTSYSProjectServiceClient.editByIdMLTSysProjectRequest(new EditMLTSYSProjectReq()
                {
                    ProjectId = id
                });
                if (!response.DoFlag)
                {
                    response.DoResult = string.Format("查询失败!");
                }
                else
                {
                    response.Sort = sort;
                    response.ProjectId = id;
                    var responseResult =
                        ServiceCollection.EditMLTSYSProjectServiceClient.editMLTSysProjectRequest(response);
                    if (responseResult.DoFlag)
                    {
                        response.DoResult = string.Format("编辑成功!");
                    }
                    else
                    {
                        response.DoResult = string.Format("编辑失败!");
                    }
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new EditMLTSYSProjectRes()
                    {
                        DoFlag = false,
                        DoResult = string.Format("编辑异常，异常信息：{0}", exception.Message)
                    }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改专题状态
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateStates(EditMLTSYSProjectRes editState)
        {
            try
            {
                var response =
                    ServiceCollection.EditMLTSYSProjectServiceClient.EditMLTProjectState(editState);
                if (response.DoFlag)
                {
                    response.DoResult = string.Format("编辑成功!");
                }
                else
                {
                    response.DoResult = string.Format("编辑失败!");
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new EditMLTSYSProjectRes()
                {
                    DoFlag = false,
                    DoResult = string.Format("编辑异常，异常信息：{0}", exception.Message)
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 专题图片
        public ActionResult MLTSYSProjectImage(int id)
        {
            if (id < 0)
            {
                ViewData["ErrorMsg"] = "参数错误";
                return View();
            }
            MLTSYSProjectImageReq MLTSPImage = new MLTSYSProjectImageReq();

            MLTSPImage.ProjectId = id;
            ViewBag.ProjectId = id;

            MLTSYSProjectImageInfo(MLTSPImage);
            return View();
        }

        //[ActionLocator("subQuery")]
        public ActionResult MLTSYSProjectImageDetail(MLTSYSProjectImageReq MLTSPImage)
        {
            MLTSYSProjectImageInfo(MLTSPImage);
            ViewData.Model = MLTSPImage;
            return View("MLTSYSProjectImage");
        }

        public void MLTSYSProjectImageInfo(MLTSYSProjectImageReq MLTSPImage)
        {
            MLTSPImage.PageIndex = MLTSPImage.PageIndex ?? 1;
            MLTSPImage.PageSize = MLTSPImage.PageSize ?? 10;
            try
            {
                var response = ServiceCollection.MLTSYSProjectImageServieClient.SysProjectImageRequest(MLTSPImage);

                if (response.DoFlag)
                {
                    if (response.List != null && response.List.Any())
                    {
                        ViewData["Detail"] = response.List;
                        ViewData["Pager"] = new Pager()
                        {
                            PageIndex = MLTSPImage.PageIndex,
                            PageSize = MLTSPImage.PageSize,
                            Total = response.Total
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 修改专题图片

        public ActionResult EeitMLTSYSProjectImage(int id)
        {
            if (id < 0)
            {
                ViewData["ErrorMsg"] = "参数错误";
                return View();
            }
            try
            {
                var response =
                    ServiceCollection.EditByIdMLTSYSProjectServiceClient.editByIdMLTSysProjectImageRequest(new EditMLTSYSProjectImageReq
                        {
                            ImageId = id
                        });
                if (response.DoFlag)
                {
                    ViewData.Model = response;
                }
                else
                {
                    ViewData["ErrorMsg"] = string.Format("查询失败，失败信息：{0}", response.ImageId);
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMsg"] = string.Format("查询异常，异常信息：{0}", ex.Message);
            }
            return View();
        }

        [ActionLocator("Edit")]
        public ActionResult Edit(EditMLTSYSProjectImageRes editMLTSYSImage)
        {
            try
            {
                var response = ServiceCollection.EditMLTSYSProjectServiceClient.editMLTSYSProjectImageReq(editMLTSYSImage);
                if (!response.DoFlag)
                {
                    response.DoResult = string.Format("编辑失败");
                }
                else
                {
                    response.DoResult = string.Format("编辑成功");
                }
                return Redirect(string.Format("/MLTSYSProject/MLTSYSProjectImage/{0}", editMLTSYSImage.ProjectId));
            }
            catch (Exception ex)
            {
                return Json(new EditMLTSYSProjectRes()
                {
                    DoFlag = false,
                    DoResult = string.Format("编辑异常，异常信息：{0}", ex.Message)
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 新增专题图片

        public ActionResult AddMLTSYSProjectImage(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        [ActionLocator("AddMLTSYSProjectImageDot")]
        public ActionResult AddMLTSYSProjectImageDot(AddMLTSYSProjectImageReq addMLTSYSImage)
        {
            try
            {
                var response = ServiceCollection.AddMLTSYSProjectServiceClient.AddMLTSysProjectImage(addMLTSYSImage);
                if (!response.DoFlag)
                {
                    response.DoResult = string.Format("添加失败，失败信息：{0}", response.DoResult);
                }
                else
                {
                    response.DoResult = string.Format("添加成功，添加的AccountID：{0}", response.ImageId);
                }
                return Redirect(string.Format("/MLTSYSProject/MLTSYSProjectImage/{0}", addMLTSYSImage.ProjectId));
            }
            catch (Exception exception)
            {
                AddMLTSYSProjectImageRes addBaseAccountRes = new AddMLTSYSProjectImageRes()
                {
                    DoFlag = false,
                    DoResult = string.Format("添加异常，异常信息：{0}", exception.Message)
                };
                return Json(addBaseAccountRes, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region  修改专题图片状态
        public JsonResult UpdateImageStates(int id, int State)
        {
            try
            {
                var response = ServiceCollection.EditByIdMLTSYSProjectServiceClient.editByIdMLTSysProjectImageRequest(new EditMLTSYSProjectImageReq()
                {
                    ImageId = id
                });
                if (!response.DoFlag)
                {
                    response.DoResult = string.Format("编辑失败!");
                }
                else
                {
                    response.ImageState = State;
                    response.ImageId = id;
                    var responseResult =
                        ServiceCollection.EditMLTSYSProjectServiceClient.editMLTSYSProjectImageReq(response);
                    if (responseResult.DoFlag)
                    {
                        response.DoResult = string.Format("编辑成功!");
                    }
                    else
                    {
                        response.DoResult = string.Format("编辑失败!");
                    }
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new EditMLTSYSProjectImageRes()
                {
                    DoFlag = false,
                    DoResult = string.Format("编辑异常，异常信息：{0}", exception.Message)
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改专题图片顺序
        [HttpPost]
        public JsonResult UpdateImageSort(int id, int sort)
        {
            try
            {
                var response = ServiceCollection.EditByIdMLTSYSProjectServiceClient.editByIdMLTSysProjectImageRequest(new EditMLTSYSProjectImageReq()
                {
                    ImageId = id
                });
                if (!response.DoFlag)
                {
                    response.DoResult = string.Format("编辑失败!");
                }
                else
                {
                    response.Sort = sort;
                    response.ImageId = id;
                    var responseResult =
                        ServiceCollection.EditMLTSYSProjectServiceClient.editMLTSYSProjectImageReq(response);
                    if (responseResult.DoFlag)
                    {
                        response.DoResult = string.Format("编辑成功!");
                    }
                    else
                    {
                        response.DoResult = string.Format("编辑失败!");
                    }
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new EditMLTSYSProjectImageRes()
                {
                    DoFlag = false,
                    DoResult = string.Format("编辑异常，异常信息：{0}", exception.Message)
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
