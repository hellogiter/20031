using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.Model.WebAward;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class WebAwardController : BaseController
    {
        // WebAward
        //strName=最上级名称
        //awardId =最上级编号

        //***********************dbo.Web_Award*********************************

        #region 抽奖活动列表
        public ActionResult Index(WebAwardRefer webAward)
        {
            var result = new WebAwardRefer();
            result = WebAwardClient.Instance.QueryWebAward(webAward);

            //根据用户Id查询用户名称
            if (result != null && result.List.Count > 0)
            {
                for (int i = 0; i < result.List.Count; i++)
                {
                    var UserDetail = WebAwardClient.Instance.GetUserName(result.List[i].IntCreateUser);
                    result.List[i].UserName = UserDetail.UserName;
                }
            }
            return View(result);
        }

        public ActionResult Item()
        {
            return View();
        }
        #endregion

        #region 详情信息
        public ActionResult Detail(int? id)
        {
            var result = new WebAwardDetail();
            result.IntAwardId = id;
            if (id > 0)
            {
                result = WebAwardClient.Instance.QueryWebAwardById(result);
            }
            return View(result);
        }
        #endregion

        #region 修改/新增抽奖活动
        public JsonResult SaveWebAward(WebAwardDetail webAward)
        {
            var result = new BaseResponse() { };
            try
            {
                if (webAward.IntAwardId > 0)
                {
                    //修改
                    var res = WebAwardClient.Instance.UpdateWebAward(webAward);
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
                    webAward.IntCreateUser = UserInfo.UserSysNo;
                    webAward.DtCreateTime = DateTime.Now;
                    //新增
                    var res = WebAwardClient.Instance.AddWebAward(webAward);
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

        #region 修改抽奖活动状态
        public JsonResult SaveWebAwardState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebAwardClient.Instance.UpdateWebAwardStatus(id, state);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改出错，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常,请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //***********************dbo.WebAwardUserTags*********************************

        #region 用户标签组配置列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">抽奖活动配置ID</param>
        /// <param name="strName">抽奖活动名称</param>
        /// <returns></returns>
        public ActionResult WebAwardUserTagsItem(int id, string strName)
        {
            var result = new WebAwardUserTagsRefer();
            result.SearchDetail.IntAwardId = id;

            if (id > 0)
            {
                result = WebAwardClient.Instance.QueryWebAwardUserTags(result);
            }
            ViewBag.AwardID = id;
            ViewBag.strName = strName;
            return View(result);
        }
        #endregion

        #region 根据用户标签组配置Id查询单条信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="awardId">抽奖活动配置ID</param>
        /// <param name="awardName">抽奖活动配置名称</param>
        /// <returns></returns>
        public ActionResult WebAwardUserTagsDetail(int? id, int? awardId, string awardName)
        {
            var result = new WebAwardUserTagsDetail();
            if (id > 0)
            {
                result = WebAwardClient.Instance.QueryWebAwardUserTagsById(id.Value);
            }
            ViewBag.IntAwardId = awardId;
            ViewBag.vchAwardName = awardName;

            return View(result);
        }
        #endregion

        #region 修改/新增用户标签组配置
        public JsonResult SaveUserTags(WebAwardUserTagsDetail userTags)
        {
            var result = new BaseResponse();
            try
            {
                if (userTags.IntTagsId > 0)
                {
                    //修改
                    userTags.IntUpdateUserId = UserInfo.UserSysNo;
                    userTags.DtUpdateTime = DateTime.Now;
                    var res = WebAwardClient.Instance.UpdateWebAwardUserTags(userTags);
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
                    userTags.DtCreateTime = DateTime.Now;
                    userTags.IntCreateUserId = UserInfo.UserSysNo;
                    userTags.IntStatus = 1;
                    var res = WebAwardClient.Instance.AddWebAwardUserTags(userTags);
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
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改用户标签组配置状态
        public JsonResult UpdateUserTagsState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebAwardClient.Instance.UpdateWebAwardUserTagsState(id, state);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "修改出错，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "修改异常,请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //***********************dbo.Web_Award_LotteryNumber*********************************

        #region 抽奖次数配置列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tageId">用户标签组ID</param>
        ///  /// <param name="tagsName">用户标签组名</param>
        /// <param name="strName">抽奖活动配置名称</param>
        /// <returns></returns>
        public ActionResult WebLotteryNumberItem(int? tageId, string tagsName, string strName)
        {
            var result = new WebLotteryNumberRefer();

            var req = new WebLotteryNumberRefer();
            req.SearchDetail.IntTagsId = tageId;

            if (req.SearchDetail.IntTagsId > 0)
            {
                result = WebAwardClient.Instance.QueryWebAwardLotteryNumber(req);
            }
            ViewBag.IntTagsId = tageId;
            ViewBag.TagsName = tagsName;
            ViewBag.strName = strName;

            return View(result);
        }
        #endregion

        #region 根据抽奖次数配置Id查询单条信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">次数配置主键</param>
        /// /// <param name="tagsId">用户标签组主键</param>
        /// <param name="tagsName">用户标签组名</param>
        /// <returns></returns>
        public ActionResult WebLotteryNumberDetail(int? id, int? tagsId, string tagsName)
        {
            var result = new WebLotteryNumberDetail();
            result.IntNumId = id;

            if (result.IntNumId > 0)
            {
                result = WebAwardClient.Instance.QueryWebAwardLotteryNumberById(result);
            }
            ViewBag.TagsId = tagsId;
            ViewBag.vchTagsName = tagsName;

            return View(result);
        }
        #endregion

        #region 修改/新增抽奖次数配置
        public JsonResult SaveWebLotteryNumber(WebLotteryNumberDetail lotteryNumber)
        {
            var result = new BaseResponse();
            try
            {
                if (lotteryNumber.IntNumId > 0)
                {
                    //修改 
                    lotteryNumber.IntUpdateUserId = UserInfo.UserSysNo;
                    lotteryNumber.DtUpdateTime = DateTime.Now;
                    var res = WebAwardClient.Instance.UpdateWebAwardLotteryNumber(lotteryNumber);
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
                    lotteryNumber.DtCreateTime = DateTime.Now;
                    lotteryNumber.IntCreateUserId = UserInfo.UserSysNo;
                    lotteryNumber.IntStatus = 1;
                    var res = WebAwardClient.Instance.AddWebAwardLotteryNumber(lotteryNumber);
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
                result.DoResult = "修改异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改抽奖次数配置状态
        public JsonResult SaveLotteryNumberState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebAwardClient.Instance.UpdateWebAwardLotteryNumberState(id, state);
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

        //***********************dbo.Web_Award_Prize*********************************

        #region 奖项配置列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numId">次数配置主键</param>
        /// <param name="awardId">活动配置ID</param>
        /// <param name="strName">活动配置名称</param>
        /// <returns></returns>
        public ActionResult WebAwardPrizeItem(int? numId, int? awardId, string strName)
        {
            var result = new WebPrizeRefer();
            result.SearchDetail.IntNumId = numId;
            result.SearchDetail.IntAwardId = awardId;
            result = WebAwardClient.Instance.QueryWebAwardPrize(result);

            //奖品类型列表
            var webAwardPrizeModel = WebAwardClient.Instance.QueryWebAwardPrizeModel();
            ViewBag.WebAwardPrizeModel = webAwardPrizeModel;

            ViewBag.IntNumId = numId;
            ViewBag.strName = strName;
            ViewBag.AwardId = awardId;
            return View(result);
        }
        #endregion

        #region 根据奖项配置ID查询单条信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">奖项配置主键</param>
        /// <param name="intNumId">次数配置主键</param>
        /// <param name="intAwardId">活动配置ID</param>
        /// <param name="strName">活动配置名称</param>
        /// <returns></returns>
        public ActionResult WebAwardPrizeDetail(int? id, int? intNumId, int? intAwardId, string strName)
        {
            var result = new WebPrizeDetail();
            result.IntPrizeId = id;
            result = WebAwardClient.Instance.QueryWebAwardPrizeById(result);
            ViewBag.intNumId = intNumId;//次数配置ID
            ViewBag.intAwardId = intAwardId;//活动Id
            ViewBag.vchAwardName = strName;//活动名称

            //奖品类型列表
            var webAwardPrizeModel = WebAwardClient.Instance.QueryWebAwardPrizeModel();
            ViewBag.WebAwardPrizeModel = webAwardPrizeModel;

            return View(result);
        }
        #endregion

        #region  修改/新增奖项配置
        public JsonResult SaveWebAwardPrize(WebPrizeDetail webPrize)
        {
            var result = new BaseResponse();
            try
            {
                if (webPrize.IntPrizeId > 0)
                {
                    webPrize.DtUpdateTime = DateTime.Now;
                    webPrize.DtUpdateUser = UserInfo.UserSysNo;
                    //修改
                    var res = WebAwardClient.Instance.UpdateWebAwardPrize(webPrize);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ....";
                    }
                }
                else
                {
                    webPrize.DtCreateTime = DateTime.Now;
                    webPrize.DtCreateUser = UserInfo.UserSysNo;
                    webPrize.IntStatus = 1;

                    if (webPrize.IntAwardId > 0)
                    {
                        webPrize.IntNumId = 0;
                    }
                    if (webPrize.IntNumId > 0)
                    {
                        webPrize.IntAwardId = 0;
                    }

                    //新增
                    var res = WebAwardClient.Instance.AddWebAwardPrize(webPrize);
                    if (res)
                    {
                        result.DoFlag = true;
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ....";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常，请稍后重试... ....";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改奖项配置状态
        public JsonResult UpdateWebAwardPrizeState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebAwardClient.Instance.UpdateWebAwardPrizeState(id, state);
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

        //***********************dbo.Web_Award_PrizeItem*********************************

        #region  奖品配置列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prizeId">奖项配置ID</param>
        /// <param name="prizeType">奖项配置类型</param>
        /// <param name="awardId">抽奖活动ID</param>
        /// <param name="strName">抽奖活动名称</param>
        /// <returns></returns>
        public ActionResult WebPrizeItem(int? prizeId, int? prizeType, int? awardId, string strName)
        {
            var result = new WebPrizeItemRefer();
            result.SearchDetail.IntPrizeId = prizeId;
            result.SearchDetail.IntAwardId = awardId;
            result = WebAwardClient.Instance.QueryWebAwardPrizeItem(result);


            ViewBag.PrizeId = prizeId;
            ViewBag.AwardId = awardId;
            ViewBag.strName = strName;
            ViewBag.PrizeType = prizeType;

            return View(result);
        }
        #endregion

        #region 根据奖品配置Id查询单条信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="prizeId">奖项配置ID</param>
        ///  /// <param name="prizeType">奖项配置类型</param>
        /// /// <param name="awardId">抽奖活动ID</param>
        /// <param name="strName">抽奖活动名称</param>
        /// <returns></returns>
        public ActionResult WebPrizeItemDetail(int? id, int? prizeId, int? prizeType, int? awardId, string strName)
        {
            var result = new WebPrizeItemDetail();
            result = WebAwardClient.Instance.QueryWebAwardPrizeItemById(id ?? 0);

            #region 加载数据
            //奖品类型列表
            var webAwardPrizeModel = WebAwardClient.Instance.QueryWebAwardPrizeModel();
            ViewBag.WebAwardPrizeModel = webAwardPrizeModel;

            //获取抽奖模型列表->奖品描述（一级分类）
            var Prize = QueryLotteryTemplate(2);
            ViewBag.PrizeDescription = Prize;

            //(二级分类)
            var PrizeTwo = WebAwardClient.Instance.QueryWebLotteryTemplateConfigure(4);
            ViewBag.PrizeTwo = PrizeTwo;


            //获取抽奖模型列表->旋转角度（一级分类）
            var Rotation = QueryLotteryTemplate(1);
            ViewBag.RotationDescription = Rotation;

            //(二级分类)
            var RotaionTwo = WebAwardClient.Instance.QueryWebLotteryTemplateConfigure(1);
            ViewBag.RotaionTwo = RotaionTwo;
            #endregion

            ViewBag.AwardId = awardId;
            ViewBag.strName = strName;
            ViewBag.PrizeId = prizeId;
            ViewBag.PrizeType = prizeType;

            return View(result);
        }
        #endregion

        #region 获取抽奖模型表
        public List<WebLotteryTemplateDetail> QueryLotteryTemplate(int type)
        {
            var result = new List<WebLotteryTemplateDetail>();

            result = WebAwardClient.Instance.QueryWebLotteryTemplate(type);

            return result;
        }
        #endregion

        #region  根据抽奖模块Id查询Web_LotteryTemplateConfigure对应的配置
        public JsonResult QueryWebLotteryTemplateConfigure(int ltSysNos)
        {
            var result = new List<WebLotteryTempConDetail>();
            try
            {
                result = WebAwardClient.Instance.QueryWebLotteryTemplateConfigure(ltSysNos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 根据抽奖模型Id查询Value值
        public JsonResult QueryWebLotteryTemplateById(int id)
        {
            var result = new WebLotteryTempConDetail();
            result = WebAwardClient.Instance.QueryWebLotteryTemplateById(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 新增/修改奖品配置
        public JsonResult SavePrizeItem(WebPrizeItemDetail prizeItem)
        {
            var result = new BaseResponse();
            try
            {
                if (prizeItem.IntPrizeItemId > 0)
                {
                    //修改
                    var res = WebAwardClient.Instance.UpdateWebAwardPrizeItem(prizeItem);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "修改成功!";
                    }
                    else
                    {
                        result.DoResult = "修改失败，请稍后重试... ...";
                    }
                }
                else
                {
                    if (prizeItem.IntAwardId > 0)
                    {
                        prizeItem.IntPrizeId = 0;
                    }
                    if (prizeItem.IntPrizeId > 0)
                    {
                        prizeItem.IntAwardId = 0;
                    }

                    prizeItem.IntStatus = 1;
                    //新增
                    var res = WebAwardClient.Instance.AddWebAwardPrizeItem(prizeItem);
                    if (res)
                    {
                        result.DoFlag = true;
                        result.DoResult = "新增成功!";
                    }
                    else
                    {
                        result.DoResult = "新增失败，请稍后重试... ...";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "保存异常... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除奖品配置
        public JsonResult DelWebAwardPrizeItem(int id)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebAwardClient.Instance.DelWebAwardPrizeItem(id);
                if (res)
                {
                    result.DoFlag = true;
                }
                else
                {
                    result.DoResult = "删除失败，请稍后重试... ...";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "删除异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //***********************dbo.Web_Prize_Bundle*********************************

        #region 捆绑奖品列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">奖品设置ID</param>
        /// <param name="strName">抽奖活动名称</param>
        /// <returns></returns>
        public ActionResult WebPrizeBundleItem(int id, string strName)
        {
            var result = new WebPrizeBundleRefer();
            result.SearchDetail.IntPrizeItemId = id;
            result = WebAwardClient.Instance.QueryWebPrizeBundle(result);
            ViewBag.strName = strName;
            ViewBag.IntPrizeItemId = id;
            return View(result);
        }
        #endregion

        #region 根据捆绑奖品Id查询单条信息
        public ActionResult WebPrizeBundleDetail(int? id, string name)
        {
            var result = new WebPrizeBundleDetail();
            result.BSysNos = id;
            if (id > 0)
            {
                result = WebAwardClient.Instance.QueryWebPrizeBundleById(result);
            }
            ViewBag.name = name;
            ViewBag.IntPrizeItemId = id;
            return View(result);
        }
        #endregion

        #region 修改/新增捆绑奖品

        public JsonResult SaveWebPrizeBundle(WebPrizeBundleDetail prizeBundle)
        {
            var result = new BaseResponse();
            try
            {
                if (prizeBundle.BSysNos > 0)
                {
                    //修改
                    var res = WebAwardClient.Instance.UpdateWebPrizeBundle(prizeBundle);
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
                    prizeBundle.IntStatus = 1;
                    var res = WebAwardClient.Instance.AddWebPrizeBundle(prizeBundle);
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 修改捆绑奖品的状态
        public JsonResult UpdateWebPrizeBundleState(int id, int state)
        {
            var result = new BaseResponse();
            try
            {
                var res = WebAwardClient.Instance.UpdateWebPrizeBundleState(id, state);
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

        //***********************dbo.Web_Award_Record*********************************

        #region 奖品明细/抽奖明细
        public ActionResult WebAwardRecordIndex(WebAwardRecordRefer record, int? id, string name)
        {
            var result = new WebAwardRecordRefer();
            //record.SearchDetail.IntAwardId = id;

            //result = WebAwardClient.Instance.QueryWebAwardRecordItem(record);

            ////获取指定活动所有的奖项设置
            //var req = new WebPrizeRefer();
            //var res = WebAwardClient.Instance.QueryWebAwardPrize(req);
            //if (res.List != null && res.List.Count > 0)
            //{
            //    //生成下拉列表并绑定值
            //    List<SelectListItem> ddClass = new List<SelectListItem>();
            //    foreach (var cls in res.List)
            //    {
            //        ddClass.Add(new SelectListItem() { Value = cls.IntPrizeId.ToString(), Text = cls.vchAwardName });
            //    }
            //    ViewData.Add("SearchDetail.IntPrizeNo", ddClass);
            //}
            //ViewBag.Name = name;
            //ViewBag.Id = id;
            return View(result);
        }

        public ActionResult WebAwardRecordItem()
        {
            return View();
        }
        #endregion

        #region 拉取特殊奖品明细
        public ActionResult WebAwardRecordSpecialItem(int intawardid, string dtCreateTime, string dtEndCreateTime)
        {
            var result = new List<WebAwardRecordDetail>();
            if (intawardid > 0)
            {
                //   DateTime a = Convert.ToDateTime();
                //DateTime b = Convert.ToDateTime(dtEndCreateTime.ToString());

                DateTime a = DateTime.Parse(dtCreateTime);
                DateTime b = DateTime.Parse(dtEndCreateTime);

                result = WebAwardClient.Instance.QueryWebAwardRecordSpecial(intawardid, a, b);
            }
            return View(result);
            //return PartialView("WebAwardRecordIndex", result);
        }
        #endregion

        //***********************dbo.Web_Award_Record*********************************

        #region 分享、点赞、晒照片管理
        public ActionResult TenYearPhotoShowItem()
        {
            return View();
        }
        #endregion

        //***********************其他*********************************

        #region 检测商品编号是否存在商品表中
        public JsonResult CheckPdtInfoById(int productId)
        {
            var result = new BaseResponse();
            string str = "";
            try
            {
                var res = WebAwardClient.Instance.CheckPdtInfoById(productId, out str);
                if (res)
                {
                    result.DoFlag = true;
                    result.DoResult = str;
                }
                else
                {
                    result.DoResult = "错误：系统未在商品表中找到商品Id，请检查";
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "检测异常，请稍后重试... ...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 配置奖品关联Id（优惠劵 优惠码）
        public JsonResult CheckPrizeCaseId(int prizeId, int prizeType)
        {
            var result = new BaseResponse();
            try
            {
                if (prizeType == 1 || prizeType == 2)
                {
                    //获取当所有指定优惠券ID的券信息
                    CouponsInfoDetail couponsInfo = WebAwardClient.Instance.QueryCouponsInfo(prizeId);
                    if (couponsInfo != null)
                    {
                        result.DoFlag = true;
                        result.DoResult = "优惠劵：【" + couponsInfo.CouponName + " StartTime：" + couponsInfo.Effectivetime + " EndTime：" + couponsInfo.ExpiryDate + " 类型：" + couponsInfo.CouponType + " 状态：" + couponsInfo.Is_enable + "】";
                    }
                    else
                    {
                        result.DoResult = "<font color=\"red\">错误：系统未关联到优惠劵，请检查</font>";
                    }
                }
                else if (prizeType == 3 || prizeType == 6)
                {
                    //获取当所有指定优惠码ID的码信息
                    CouponActivityDetail couponaCtivity = WebAwardClient.Instance.QueryCouponActivityDetail(prizeId);
                    if (couponaCtivity != null || couponaCtivity.CouponActId > 0)
                    {
                        result.DoFlag = true;
                        result.DoResult = "优惠码：【" + couponaCtivity.ActivityName + " StartTime：" + couponaCtivity.StartTime +
                                          " EndTime：" + couponaCtivity.EndTime + " 类型：" + couponaCtivity.CouponType + " 状态：" +
                                          couponaCtivity.Status + "】";
                        //获取当前促销区域
                        List<CouponPromotionsDetail> list = WebAwardClient.Instance.QueryCouponPromotions(prizeId);
                        if (list != null && list.Count > 0)
                        {
                            foreach (var item in list)
                            {
                                //获取当前促销区域促销活动
                                PromInfoDetail prom = WebAwardClient.Instance.QueryPromInfo(item.PromId.Value);
                                if (prom != null && prom.PromId > 0)
                                {
                                    result.DoFlag = true;
                                    result.DoResult += "<br/>促&nbsp;&nbsp;销：【" + prom.PromName + " StartTime：" +
                                                      prom.StartTime + " EndTime：" + prom.EndTime + " 状态：" + prom.Status +
                                                      " 是否删除：" + prom.IsDel + "】";
                                }
                                else
                                {
                                    result.DoResult += "<br/><font color=\"red\">错误：系统未查到当前优惠码活动关联的促销，请检查</font>";
                                }
                            }
                        }
                        else
                        {
                            result.DoResult += "<br/><font color=\"red\">错误：系统未查到当前优惠码活动关联的促销，请检查</font>";
                        }
                    }
                    else
                    {
                        result.DoResult += "<font color=\"red\">错误：系统未关联到优惠码活动，请检查</font>";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DoResult = "<font color=\"red\">错误：未知类型，系统无法检测</font>";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
