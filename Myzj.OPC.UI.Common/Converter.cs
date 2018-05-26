using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Myzj.OPC.UI.Common
{
    public class Converter
    {
        /// <summary>
        /// 获得int
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认Int值</param>
        /// <returns>转换后值</returns>
        public static int ParseInt(object obj, int defValue)
        {
            int result = -1;
            try
            {
                if (obj != null)
                {
                    string res = obj.ToString();
                    if (!int.TryParse(res, out result))
                    {
                        result = defValue;
                    }
                }
                else
                {
                    result = defValue;
                }
            }
            catch
            {
                result = defValue;
            }
            return result;
        }

        /// <summary>
        /// obj转string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string ParseString(object obj, string defValue)
        {
            string result = string.Empty;
            try
            {
                if (obj == null)
                    result = defValue;
                else
                    result = obj.ToString();
            }
            catch
            {
                result = defValue;
            }
            return result;
        }

        ///// <summary>
        ///// 将金额转换成 int 类型
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="defValue"></param>
        ///// <returns></returns>
        //public static int ParseIntDecimal(decimal? dec, int defValue)
        //{
        //    int result = 0;

        //    try
        //    {
        //        return Convert.ToInt32((dec * 100));
        //    }
        //    catch
        //    {
        //        result = defValue;
        //    }

        //    return result;
        //}

        /// <summary>
        /// 将空类型转换不为空
        /// </summary>
        /// <param name="dec"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static decimal ParseDecimalNull(decimal? dec, decimal defValue)
        {
            decimal result = 0;

            try
            {
                if (dec != null)
                {
                    result = (decimal)dec;
                }
                else
                {
                    result = defValue;
                }
            }
            catch
            {
                result = defValue;
            }

            return result;
        }

        /// <summary>
        /// 获得Datetime
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认时间</param>
        /// <returns>转换后值</returns>
        public static DateTime ParseDateTime(object obj, DateTime defValue)
        {
            DateTime result = DateTime.Now;
            try
            {
                if (!DateTime.TryParse(obj.ToString(), out result))
                {
                    result = defValue;
                }
            }
            catch
            {

            }
            return result;
        }


        /// <summary>
        /// 获得Decimal
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认decimal值</param>
        /// <returns>转换后值</returns>
        public static decimal ParseDecimal(object obj, decimal defValue)
        {
            decimal result = new decimal(0);
            try
            {
                string res = obj.ToString();
                if (!decimal.TryParse(res, out result))
                {
                    result = defValue;
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 获得Decimal
        /// </summary>
        /// <param name="obj">转换前值</param>
        /// <param name="defValue">默认decimal值</param>
        /// <returns>转换后值</returns>
        public static decimal ParseDecimalFormat(object obj, decimal defValue)
        {
            decimal result = new decimal(0);
            try
            {
                result = Converter.ParseDecimal(Converter.ParseDecimal(obj, 0).ToString("f2"), 0);
            }
            catch
            {
            }
            return result;
        }

        #region

        /// <summary>
        /// 解析使用平台
        /// </summary>
        /// <param name="systemType"></param>
        /// <returns></returns>
        public static string UsePlatform(string systemType)
        {
            string message = "";

            if (systemType == null || systemType.Contains("[0]"))
            {
                message = "无限制";
            }
            else
            {
                if (systemType.Contains("[1]"))
                {
                    message = "PC商城、";
                }
                if (systemType.Contains("[2]"))
                {
                    message += "手机网站、";
                }

                if (systemType.Contains("[4]") && !systemType.Contains("[5]"))
                {
                    message += "AndroId App、";
                }
                else if (systemType.Contains("[5]") && !systemType.Contains("[4]"))
                {
                    message += "Ios App、";
                }
                else if (systemType.Contains("[4]") && systemType.Contains("[5]"))
                {
                    message += "App、";
                }

                if (systemType.Contains("[8]"))
                {
                    message += "Ipad、";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    if (message.Substring(message.Length - 1, 1) == "、")
                    {
                        message = "限 " + message.Substring(0, message.Length - 1) + " 使用";
                    }
                }
            }

            return message;
        }

        /// <summary>
        /// 解析优惠劵限制会员等级
        /// </summary>
        /// <param name="setMemberLevel"></param>
        /// <returns></returns>
        public static string CouponMemberLevel(string setMemberLevel)
        {
            string message = "";

            if (message == null || setMemberLevel.Contains("[0]"))
            {
                message = "无限制";
            }
            else
            {
                if (setMemberLevel.Contains("[1]"))
                {
                    message += "普通会员、";
                }

                if (setMemberLevel.Contains("[2]"))
                {
                    message += "星星宝宝、";
                }

                if (setMemberLevel.Contains("[3]") || setMemberLevel.Contains("[17]"))
                {
                    message += "月亮宝宝、";
                }

                if (setMemberLevel.Contains("[4]") || setMemberLevel.Contains("[18]"))
                {
                    message += "太阳宝宝、";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    if (message.Substring(message.Length - 1, 1) == "、")
                    {
                        message = message.Substring(0, message.Length - 1) + " 可使用";
                    }
                }
            }

            return message;
        }

        #endregion

        public static string ConvertExpressContent(string jsons)
        {
            var html = jsons;
            try
            {
                if (!string.IsNullOrEmpty(jsons))
                {
                    html = "解析无数据：" + jsons.Replace("\"", "'");
                }
                var model = ConvertByContent(jsons);
                if (model != null && model.LogiscticNo != null)
                {
                    var builder = new StringBuilder();
                    builder.Append("快递单号：" + model.LogiscticNo + "<br/>");
                    builder.Append("快递公司：" + model.LogisticsName + "<br/>");
                    foreach (var item in model.ResultDtos)
                    {
                        builder.Append(item.LogisticsTime + item.Content + "<br/>");
                    }
                    html = builder.ToString();
                }
            }
            catch (Exception e)
            {


            }

            return html;
        }

        /// <summary>
        /// Json转化为List
        /// </summary>
        /// <param name="contetn"></param>
        /// <returns></returns>
        public static M_WayBillDto ConvertByContent(string content)
        {
            var model = new M_WayBillDto();
            try
            {
                if (!string.IsNullOrEmpty(content))
                {
                    var obj = JsonConvert.DeserializeObject<DeliveryList>(content);
                    model.LogiscticNo = obj.BillNo;
                    model.LogisticsName = obj.DeliveryName;
                    model.LogisticsLink = obj.DeliveryUrl;

                    model.ResultDtos = new List<M_WaBillContentDto>();
                    if (obj.Tracks != null && obj.Tracks.Any())
                    {
                        var kv = obj.Tracks.Select(item => new M_WaBillContentDto()
                        {
                            Content = string.Join(",", item.Content),
                            LogisticsTime = Convert.ToDateTime(item.OperationTime)
                        }).ToList();
                        model.ResultDtos = kv;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return model;
        }
    }

    public class M_WayBillDto
    {
        public string LogiscticNo { get; set; }
        public string LogisticsName { get; set; }
        public string LogisticsLink { get; set; }
        public List<M_WaBillContentDto> ResultDtos { get; set; }
    }
    public class M_WaBillContentDto
    {
        public string Content { get; set; }
        public DateTime? LogisticsTime { get; set; }
    }
    public class DeliveryList
    {
        /// <summary>
        /// 物流公司
        /// </summary>
        public string DeliveryName { get; set; }

        /// <summary>
        /// 物流公司URL
        /// </summary>
        public string DeliveryUrl { get; set; }

        /// <summary>
        /// 运单号，订单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 将物流信息关闭时，显示的提示信息
        /// </summary>
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 物流跟踪
        /// </summary>
        //public List<DeliveryTrack> Track { get; set; }

        /// <summary>
        /// 手机端调用
        /// </summary>
        public List<DeliveryTracks> Tracks { get; set; }
    }
    public class DeliveryTracks
    {
        public string OperationTime { get; set; }

        public string[] Content { get; set; }
    }
}
