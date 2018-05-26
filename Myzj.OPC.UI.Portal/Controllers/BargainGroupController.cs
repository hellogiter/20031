using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Common;
using Myzj.OPC.UI.Model.BargainGroup;
using Myzj.OPC.UI.Model.Base;
using Myzj.OPC.UI.ServiceClient;

namespace Myzj.OPC.UI.Portal.Controllers
{
    public class BargainGroupController : BaseController
    {

        #region 活动管理

        #region 查询列表
        /// <summary>
        /// 活动列表视图
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ActionResult GroupActivityIndex(GroupActivityRefer refer)
        {
            var result = BargainGroupConfigClient.Instance.QueryGroupActivity(refer);

            return View(result);
        }
        #endregion

        #region 新增
        /// <summary>
        /// 添加活动 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateGroupActivity()
        {
            return View();
        }

        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AddGroupActivity(GroupActivityDetail model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证

            model.GroupUserCanCount = model.GroupUserCanCount ?? 0;
            model.GroupUserInCount = model.GroupUserInCount ?? 0;

            if (string.IsNullOrEmpty(model.GroupActivityName))
            {
                result.DoResult = "请填写活动名称";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.GroupActivityDes))
            {
                result.DoResult = "请填写活动描述";
                return Json(result);
            }

            if (!model.OpenOrCanCount.HasValue || model.OpenOrCanCount == 0)
            {
                result.DoResult = "请输入每个会员可建团或可参团总数量";
                return Json(result);
            }
            else
            {
                if ((model.GroupUserCanCount ?? 0) > 0 || (model.GroupUserInCount ?? 0) > 0)
                {
                    if ((model.GroupUserCanCount + model.GroupUserInCount) != model.OpenOrCanCount)
                    {
                        result.DoResult = "可建团的总数量+可参团的总数量必须等于可建团或参团的总数量";
                        return Json(result);
                    }
                }
            }

            if ((model.OpenOrCanCount ?? 0) < 0)
            {
                result.DoResult = "每个会员可建团或参团总数必须>=0";
                return Json(result);
            }
            if ((model.GroupUserInCount ?? 0) < 0)
            {
                result.DoResult = "每个会员可建团总数量必须>=0";
                return Json(result);
            }
            if ((model.GroupUserCanCount ?? 0) < 0)
            {
                result.DoResult = "每个会员可参团总数量必须>=0";
                return Json(result);
            }

            if (!model.StartTime.HasValue)
            {
                result.DoResult = "请填写开始时间";
                return Json(result);
            }

            if (!model.EndTime.HasValue)
            {
                result.DoResult = "请填写结束时间";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.ActivityHeadPicUrl))
            {
                result.DoResult = "请填写头图";
                return Json(result);
            }

            model.CreatePeople = UserInfo.UserSysNo;
            model.CreateTime = DateTime.Now;
            model.IsDelete = false;
            #endregion

            try
            {
                var refer = new GroupActivityRefer();
                refer.SearchDetail.GroupActivityName = model.GroupActivityName;
                var item = BargainGroupConfigClient.Instance.QueryGroupActivity(refer);
                if (item.List2 != null && item.List2.Any())
                {
                    result.DoResult = "添加的活动 已存在";
                    return Json(result);
                }

                result.DoFlag = BargainGroupConfigClient.Instance.AddGroupActivity(model);
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常，请稍后重试... ...";
            }

            return Json(result);
        }

        #endregion

        #region 修改
        /// <summary>
        /// 更新活动 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult EditGroupActivity(int sysNo)
        {
            var refer = new GroupActivityRefer();
            var gad = new GroupActivityDetailExt();
            refer.SearchDetail.SysNo = sysNo;
            var result = BargainGroupConfigClient.Instance.QueryGroupActivity(refer);
            if (result.List2 != null && result.List2.Any())
            {
                gad = result.List2.First();
            }
            return View(gad);
        }

        /// <summary>
        /// 更新活动
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateGroupActivity(GroupActivityDetail model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证

            model.GroupUserCanCount = model.GroupUserCanCount ?? 0;
            model.GroupUserInCount = model.GroupUserInCount ?? 0;

            if (string.IsNullOrEmpty(model.GroupActivityName))
            {
                result.DoResult = "请填写活动名称";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.GroupActivityDes))
            {
                result.DoResult = "请填写活动描述";
                return Json(result);
            }

            //if (!model.GroupUserInCount.HasValue)
            //{
            //    result.DoResult = "请输入可建团的总数量";
            //    return Json(result);
            //}
            //if (!model.GroupUserCanCount.HasValue)
            //{
            //    result.DoResult = "请输入可参团的总数量";
            //    return Json(result);
            //}

            if (!model.OpenOrCanCount.HasValue || model.OpenOrCanCount == 0)
            {
                result.DoResult = "请输入可建团或可参团总量";
                return Json(result);
            }
            else
            {
                if ((model.GroupUserCanCount ?? 0) > 0 || (model.GroupUserInCount ?? 0) > 0)
                {
                    if ((model.GroupUserCanCount + model.GroupUserInCount) != model.OpenOrCanCount)
                    {
                        result.DoResult = "可建团的总数量+可参团的总数量必须等于可建团或参团的总数量";
                        return Json(result);
                    }
                }
            }

            if ((model.OpenOrCanCount ?? 0) < 0)
            {
                result.DoResult = "每个会员可建团或参团总数必须>=0";
                return Json(result);
            }
            if ((model.GroupUserInCount ?? 0) < 0)
            {
                result.DoResult = "每个会员可建团总数量必须>=0";
                return Json(result);
            }
            if ((model.GroupUserCanCount ?? 0) < 0)
            {
                result.DoResult = "每个会员可参团总数量必须>=0";
                return Json(result);
            }




            if (!model.StartTime.HasValue)
            {
                result.DoResult = "请填写开始时间";
                return Json(result);
            }

            if (!model.EndTime.HasValue)
            {
                result.DoResult = "请填写结束时间";
                return Json(result);
            }

            #endregion
            try
            {
                var flag = BargainGroupConfigClient.Instance.UpdateGroupActivity(model);
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
        #endregion

        #region 删除
        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public JsonResult DeleteGroupActivity(int sysNo)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "删除失败 ，请稍后重试……"
            };
            var model = new GroupActivityDetail();
            model.SysNo = sysNo;
            model.IsDelete = true;
            try
            {
                var flag = BargainGroupConfigClient.Instance.UpdateGroupActivity(model);
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
            return Json(result);

        }
        #endregion

        #endregion

        #region 商品管理

        #region 查询列表
        /// <summary>
        /// 砍价团列表页
        /// </summary>
        /// <param name="refer"></param>
        /// <returns></returns>
        public ActionResult Index(GroupGoodsRefer refer)
        {
            var id = Request.QueryString["GroupActivitySysNo"];
            if (id != null)
            {
                refer.SearchDetail.GroupActivitySysNo = int.Parse(id);
                ViewBag.GroupActivitySysNo = id;
                var actRef = BargainGroupConfigClient.Instance.QueryGroupActivity(new GroupActivityRefer()
                      {
                          SearchDetail = new GroupActivityDetail()
                              {
                                  SysNo = Convert.ToInt32(id)
                              }
                      });
                ViewBag.GroupActivityBeforePay = false;
                if (actRef.List2.Any())
                {
                    ViewBag.GroupActivityBeforePay = actRef.List2.First().BeforePay ?? false;
                };
            }
            var result = BargainGroupConfigClient.Instance.QueryGroupGoodsPageList(refer);

            return View(result);
        }
        #endregion

        #region 查询单个
        /// <summary>
        ///  根据商品ID 查询商品信息
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public JsonResult GetGoodsInfoByGoodsId(string goodsId)
        {
            var result = BargainGroupConfigClient.Instance.QueryGoodsInfoById(int.Parse(goodsId));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 新增
        public ActionResult BargainGroupCreate(int groupActivitySysNo)
        {
            ViewBag.GroupActivitySysNo = groupActivitySysNo;
            //查询活动是先付还是后付
            var actModel = BargainGroupConfigClient.Instance.QueryGroupActivity(new GroupActivityRefer()
                {
                    SearchDetail = new GroupActivityDetail()
                        {
                            SysNo = groupActivitySysNo
                        }
                });
            ViewBag.ActBeforePay = actModel.List2.First().BeforePay ?? false;


            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult BargainGroupAdd(GroupGoodsDetail model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证

            if (string.IsNullOrEmpty(model.PicUrl))
            {
                result.DoResult = "请正确填写图片地址";
                return Json(result);
            }
            if (!model.GoodsId.HasValue)
            {
                result.DoResult = "请正确填写商品ID";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.GoodsName))
            {
                result.DoResult = "没有商品名称";
                return Json(result);
            }

            if (!model.VipPrice.HasValue)
            {
                result.DoResult = "没有商品原价";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.GoodsDes))
            {
                result.DoResult = "请正确填写商品描述";
                return Json(result);
            }

            if (!model.GroupPrice.HasValue)
            {
                result.DoResult = "请正确填写商品价格";
                return Json(result);
            }

            if (!model.SetCanGroupCount.HasValue)
            {
                result.DoResult = "请正确填写参团人数";
                return Json(result);
            }

            if (!model.SetJianGroupCount.HasValue)
            {
                result.DoResult = "请正确填写建团数";
                return Json(result);
            }

            if ((model.GroupPrice ?? 0) <= 0)
            {
                result.DoResult = "商品价格必须大于0";
                return Json(result);
            }
            if ((model.SetCanGroupCount ?? 0) <= 0)
            {
                result.DoResult = "设置成团人数必须大于0";
                return Json(result);
            }
            if ((model.SetJianGroupCount ?? 0) <= 0)
            {
                result.DoResult = "设置建团总数必须大于0";
                return Json(result);
            }
            //if (model.SetJianGroupCount > 1000)
            //{
            //    result.DoResult = "建团数不能超过1000";
            //    return Json(result);
            //}

            if (!model.StartTime.HasValue)
            {
                result.DoResult = "请正确填写开始时间";
                return Json(result);
            }

            if (!model.EndTime.HasValue)
            {
                result.DoResult = "请正确填写结束时间";
                return Json(result);
            }

            var actRef = BargainGroupConfigClient.Instance.QueryGroupActivity(new GroupActivityRefer()
            {
                SearchDetail = new GroupActivityDetail()
                {
                    SysNo = model.GroupActivitySysNo
                }
            });
            var actModel = actRef.List2.First();
            if (model.StartTime < actModel.StartTime)
            {
                result.DoResult = "商品开始时间必须大于活动开始时间" + actModel.StartTime;
                return Json(result);
            }
            if (model.EndTime > actModel.EndTime)
            {
                result.DoResult = "商品结束时间必须小于活动结束时间" + actModel.EndTime;
                return Json(result);
            }

            if (!model.Sort.HasValue)
            {
                result.DoResult = "请正确填写排序值";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.PromSysNos))
            {
                result.DoResult = "请正确填写促销ID";
                return Json(result);
            }
            if (!model.GroupActivitySysNo.HasValue)
            {
                result.DoResult = "请正确填活动SysNo";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.PingPlayDesc))
            {
                result.DoResult = "拼团玩法图片地址必填";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.ZeroPayDesc) && !string.IsNullOrEmpty(model.ZeroPayUserLabel))
            {
                result.DoResult = "当商品支持一元购时，一元购规则图片地址必填";
                return Json(result);
            }


            if (!model.IsDelete.HasValue)
                model.IsDelete = false;
            if (!model.IsEnable.HasValue)
                model.IsEnable = true;

            model.CreatePeople = UserInfo.UserSysNo;
            model.CreateTime = DateTime.Now;

            model.JianGroupCount = 0;
            #endregion

            //新增
            try
            {



                var refer = new GroupGoodsRefer();
                refer.SearchDetail.GoodsId = model.GoodsId;
                refer.SearchDetail.GroupActivitySysNo = model.GroupActivitySysNo;
                var item = BargainGroupConfigClient.Instance.QueryGroupGoodsPageList(refer);
                if (item.List2 != null && item.List2.Any())
                {
                    result.DoResult = "添加的商品ID 已存在";
                    return Json(result);
                }
                var gr = new GroupActivityRefer();
                gr.SearchDetail.SysNo = model.GroupActivitySysNo;
                var activity = BargainGroupConfigClient.Instance.QueryGroupActivity(gr);
                if (activity.List2 == null || !activity.List2.Any())
                {
                    result.DoResult = "活动SysNo 不存在";
                    return Json(result);
                }

                result.DoFlag = BargainGroupConfigClient.Instance.AddGroupGoods(model);
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常，请稍后重试... ...";
            }

            return Json(result);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 砍价团信息编辑页
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public ActionResult BargainGroupEdit(int sysNo)
        {
            var result = BargainGroupConfigClient.Instance.QueryGroupGoodsInfoBySysNo(sysNo);
            //查询活动是先付还是后付
            var actModel = BargainGroupConfigClient.Instance.QueryGroupActivity(new GroupActivityRefer()
            {
                SearchDetail = new GroupActivityDetail()
                {
                    SysNo = result.GroupActivitySysNo
                }
            });
            ViewBag.ActBeforePay = actModel.List2.First().BeforePay ?? false;
            return View(result);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult BargainGroupUpdate(GroupGoodsDetail model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证
            if (string.IsNullOrEmpty(model.GoodsDes))
            {
                result.DoResult = "请正确填写商品描述";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.PicUrl))
            {
                result.DoResult = "请正确填写图片地址";
                return Json(result);
            }
            if (!model.GroupPrice.HasValue)
            {
                result.DoResult = "请正确填写商品价格";
                return Json(result);
            }
            if (!model.SetJianGroupCount.HasValue)
            {
                result.DoResult = "请正确填写建团数";
                return Json(result);
            }

            if ((model.GroupPrice ?? 0) <= 0)
            {
                result.DoResult = "商品价格必须大于0";
                return Json(result);
            }
            if ((model.SetCanGroupCount ?? 0) <= 0)
            {
                result.DoResult = "设置成团人数必须大于0";
                return Json(result);
            }
            if ((model.SetJianGroupCount ?? 0) <= 0)
            {
                result.DoResult = "设置建团总数必须大于0";
                return Json(result);
            }


            //if (model.SetJianGroupCount > 1000)
            //{
            //    result.DoResult = "建团数不能超过1000";
            //    return Json(result);
            //}

            if (!model.StartTime.HasValue)
            {
                result.DoResult = "请正确填写开始时间";
                return Json(result);
            }

            if (!model.EndTime.HasValue)
            {
                result.DoResult = "请正确填写结束时间";
                return Json(result);
            }

            var actRef = BargainGroupConfigClient.Instance.QueryGroupActivity(new GroupActivityRefer()
            {
                SearchDetail = new GroupActivityDetail()
                {
                    SysNo = model.GroupActivitySysNo
                }
            });

            var actModel = actRef.List2.First();
            if (model.StartTime < actModel.StartTime)
            {
                result.DoResult = "商品开始时间必须大于活动开始时间" + actModel.StartTime;
                return Json(result);
            }
            if (model.EndTime > actModel.EndTime)
            {
                result.DoResult = "商品结束时间必须小于活动结束时间" + actModel.EndTime;
                return Json(result);
            }


            if (!model.Sort.HasValue)
            {
                result.DoResult = "请正确填写排序值";
                return Json(result);
            }

            if (string.IsNullOrEmpty(model.PromSysNos))
            {
                result.DoResult = "请正确填写促销ID";
                return Json(result);
            }

            if (!model.GroupActivitySysNo.HasValue)
            {
                result.DoResult = "请正确填活动SysNo";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.PingPlayDesc))
            {
                result.DoResult = "拼团玩法图片地址必填";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.ZeroPayDesc) && !string.IsNullOrEmpty(model.ZeroPayUserLabel))
            {
                result.DoResult = "当商品支持一元购时，一元购规则图片地址必填";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.ZeroPayDesc))
            {
                model.ZeroPayDesc = "";
            }
            if (model.NoJoinUserLabel == "null")
            {
                model.NoJoinUserLabel = "";
            }
            if (model.ZeroPayUserLabel == "null")
            {
                model.ZeroPayUserLabel = "";
            }

            #endregion
            try
            {
                var refer = new GroupActivityRefer();
                refer.SearchDetail.SysNo = model.GroupActivitySysNo;
                var activity = BargainGroupConfigClient.Instance.QueryGroupActivity(refer);
                if (activity.List2 == null || !activity.List2.Any())
                {
                    result.DoResult = "活动SysNo 不存在";
                    return Json(result);
                }
                var flag = BargainGroupConfigClient.Instance.UpdateGroupGoods(model);
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
        #endregion

        #region 统计商品参团数据
        /// <summary>
        /// 统计商品信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        //public ActionResult CountGoodsInfo(CountGoodsRefer refer)
        //{
        //    refer.SearchDetail.GroupActivitySysNo = int.Parse(Request.QueryString["GroupActivitySysNo"]);
        //    if ((refer.SearchDetail.GoodsId ?? 0) == 0)
        //    {
        //        refer.SearchDetail.GoodsId = int.Parse(Request.QueryString["GoodsId"]);
        //    }
        //    var result = BargainGroupConfigClient.Instance.CountGroupGoodsInfo(refer);

        //    return View(result);
        //}

        public ActionResult CountGoodsInfo(GroupStructureListRefer refer)
        {
            ViewBag.ActivitySysNo = refer.SearchDetail.ActivitySysNo = int.Parse(Request.QueryString["GroupActivitySysNo"]);
            if ((refer.SearchDetail.GoodsSysNo ?? 0) == 0)
            {
                ViewBag.GoodsSysNo = refer.SearchDetail.GoodsSysNo = int.Parse(Request.QueryString["GoodsSysNo"]);
            }
            var result = BargainGroupConfigClient.Instance.GroupStructureList(refer);
            return View(result);
        }
        #endregion

        #endregion

        #region 商品-查看活动参团记录
        public ActionResult GroupRecordIndex(GroupRecordRefer refer)
        {
            var id = Request.QueryString["ActivitySysNo"];
            if (id != null)
            {
                refer.SearchDetail.GroupActivitySysNo = int.Parse(id);
                ViewBag.GroupActivitySysNo = id;
            }
            var result = BargainGroupConfigClient.Instance.QueryGroupRecord(refer);

            return View(result);
        }

        #endregion

    }
}
