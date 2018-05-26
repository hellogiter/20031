using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Myzj.OPC.UI.Model.ShortMessage;
using Myzj.OPC.UI.ServiceClient;
using BaseResponse = Myzj.OPC.UI.Model.Base.BaseResponse;

namespace Myzj.OPC.UI.Portal.Controllers.ShortMessage
{
    public class ShortMessageExecController : BaseController
    {
        //
        // GET: /ShortMessageExec/


        public JsonResult AddSmsTemplate(TemplateModel model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证


            if (string.IsNullOrEmpty(model.TempName))
            {
                result.DoResult = "模板名称不为空";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                result.DoResult = "模板内容不为空";
                return Json(result);
            }
            if (!model.TempType.HasValue)
            {
                result.DoResult = "模板类型为数字";
                return Json(result);
            }


            model.RowCreateDate = DateTime.Now;
            model.IsDel = false;
            #endregion

            try
            {
                result.DoFlag = ShortMessageClient.Instance.AddTemplate(model);
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常，请稍后重试... ...";
            }

            return Json(result);
        }
        public JsonResult UpdSmsTemplate(TemplateModel model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证

            if (string.IsNullOrEmpty(model.TempName))
            {
                result.DoResult = "模板名称不为空";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                result.DoResult = "模板内容不为空";
                return Json(result);
            }
            if (!model.TempType.HasValue)
            {
                result.DoResult = "模板类型为数字";
                return Json(result);
            }

            model.RowModifyDate = DateTime.Now;
            model.IsDel = false;
            #endregion


            try
            {
                var flag = ShortMessageClient.Instance.UpdateTemplate(model);
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
        public JsonResult EnableSmsTemplate(int SysNo, bool Enable)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "修改失败 ，请稍后重试……"
            };

            try
            {
                var flag = ShortMessageClient.Instance.UpdateTemplate(new TemplateModel
                {
                    SysNo = SysNo,
                    RowCreateDate = DateTime.Now,
                    IsEnable = Enable
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DelSmsTemplate(int SysNo)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "删除失败 ，请稍后重试……"
            };

            try
            {
                var flag = ShortMessageClient.Instance.UpdateTemplate(new TemplateModel
                {
                    SysNo = SysNo,
                    RowCreateDate = DateTime.Now,
                    IsDel = true
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

        public JsonResult AddBlackList(BlackListModel model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证
            if (!string.IsNullOrEmpty(model.Mobile))
            {
                if (!Regex.IsMatch(model.Mobile, @"^[1]+[3,5]+\d{9}"))
                {
                    result.DoResult = "手机号码验证不正确";
                    return Json(result);
                }
            }

            if (string.IsNullOrEmpty(model.LimitReason))
            {
                result.DoResult = "限制原因不为空";
                return Json(result);
            }
            if (!model.LimitEndTime.HasValue)
            {
                result.DoResult = "限制日期不为空";
                return Json(result);
            }
            model.Operator = UserInfo.UserName;
            model.RowCreateDate = DateTime.Now;
            model.IsDel = false;
            #endregion

            try
            {
                if (!string.IsNullOrEmpty(model.Mobile))
                {
                    var refer = ShortMessageClient.Instance.QueryBackPageList(new BlackListRefer()
                    {
                        Search = new BlackListModel()
                        {
                            Mobile = model.Mobile
                        }
                    });
                    if (refer.List.Any())
                    {
                        result.DoResult = "此手机号已添加黑名单";
                        return Json(result);
                    }
                }

                result.DoFlag = ShortMessageClient.Instance.BlackListAdd(model);
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常，请稍后重试... ...";
            }

            return Json(result);
        }
        public JsonResult UpdBlackList(BlackListModel model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证

            if (!string.IsNullOrEmpty(model.Mobile))
            {
                if (!Regex.IsMatch(model.Mobile, @"^[1]+[3,5]+\d{9}"))
                {
                    result.DoResult = "手机号码验证不正确";
                    return Json(result);
                }
            }

            if (string.IsNullOrEmpty(model.LimitReason))
            {
                result.DoResult = "限制原因不为空";
                return Json(result);
            }

            if (!model.LimitEndTime.HasValue)
            {
                result.DoResult = "限制日期不为空";
                return Json(result);
            }
            if (string.IsNullOrEmpty(model.UserGuid))
            {
                model.UserGuid = "";
            }
            if (string.IsNullOrEmpty(model.Mobile))
            {
                model.Mobile = "";
            }
            if (string.IsNullOrEmpty(model.ClientIp))
            {
                model.ClientIp = "";
            }
            if (string.IsNullOrEmpty(model.Remark))
            {
                model.Remark = "";
            }

            model.RowModifyDate = DateTime.Now;
            model.IsDel = false;
            model.IsEnable = model.IsEnable ?? true;
            model.Operator = UserInfo.UserName;
            #endregion

            try
            {
                var flag = ShortMessageClient.Instance.BlackListUpdate(model);
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
        public JsonResult EnableBlackList(int SysNo, bool Enable)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "修改失败 ，请稍后重试……"
            };

            try
            {
                var flag = ShortMessageClient.Instance.BlackListUpdate(new BlackListModel
                {
                    SysNo = SysNo,
                    RowCreateDate = DateTime.Now,
                    IsEnable = Enable
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DelBlackList(int SysNo)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "删除失败 ，请稍后重试……"
            };

            try
            {
                var flag = ShortMessageClient.Instance.BlackListUpdate(new BlackListModel
                {
                    SysNo = SysNo,
                    RowCreateDate = DateTime.Now,
                    IsDel = true
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

        public JsonResult AddWhiteList(WhiteListModel model)
        {
            var result = new BaseResponse() { DoFlag = false, DoResult = "添加失败，请稍后重试... ..." };
            #region 参数验证

            if (string.IsNullOrEmpty(model.Mobile))
            {
                result.DoResult = "手机号不为空";
                return Json(result);
            }
            else
            {
                if (!Regex.IsMatch(model.Mobile, @"^[1]+[3,5]+\d{9}"))
                {
                    result.DoResult = "手机号码验证不正确";
                    return Json(result);
                }
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                result.DoResult = "用户姓名不为空";
                return Json(result);
            }


            model.RowCreateTime = DateTime.Now;
            model.IsEnable = 1;
            #endregion

            try
            {
                var refer = ShortMessageClient.Instance.QueryWhitePageList(new WhiteListRefer()
                      {
                          Search = new WhiteListModel()
                              {
                                  Mobile = model.Mobile
                              }
                      });
                if (refer.List.Any())
                {
                    result.DoResult = "此手机号已添加白名单";
                    return Json(result);
                }
                result.DoFlag = ShortMessageClient.Instance.WhiteListAdd(model);
            }
            catch (Exception ex)
            {
                result.DoResult = "添加异常，请稍后重试... ...";
            }

            return Json(result);
        }
        public JsonResult UpdWhiteList(WhiteListModel model)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "更新失败 ，请稍后重试……"
            };
            #region 参数验证

            if (string.IsNullOrEmpty(model.Mobile))
            {
                result.DoResult = "手机号不为空";
                return Json(result);
            }
            else
            {
                if (!Regex.IsMatch(model.Mobile, @"^[1]+[3,5]+\d{9}"))
                {
                    result.DoResult = "手机号码验证不正确";
                    return Json(result);
                }
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                result.DoResult = "用户姓名不为空";
                return Json(result);
            }

            model.RowCreateTime = DateTime.Now;
            model.IsEnable = model.IsEnable ?? 1;
            #endregion


            try
            {
                var flag = ShortMessageClient.Instance.WhiteListUpdate(model);
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
        public JsonResult EnableWhiteList(int SysNo, int Enable)
        {
            var result = new BaseResponse()
            {
                DoFlag = false,
                DoResult = "修改失败 ，请稍后重试……"
            };

            try
            {
                var flag = ShortMessageClient.Instance.WhiteListUpdate(new WhiteListModel
                {
                    SysNo = SysNo,
                    IsEnable = Enable
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
