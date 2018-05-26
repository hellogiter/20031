using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 金额转化扩展
    /// </summary>
    public static class AmountExt
    {
        public static string ToYuan(this int? amount)
        {
            return amount == null ? "0.00" : (amount / 100.00).ToString();
        }

        public static string ToYuan(this long? amount)
        {
            return amount == null ? "0.00" : (amount / 100.00).ToString();
        }

        /// <summary>
        /// 由元转为分，转为long?
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static long? ToLongCent(this string amount)
        {
            decimal amt = Convert.ToDecimal(string.IsNullOrEmpty(amount) ? "0" : amount);
            return Convert.ToInt64(amt * 100);
        }

        /// <summary>
        /// 由元转为分，转化为int?
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static int? ToIntCent(this string amount)
        {
            decimal amt = Convert.ToDecimal(string.IsNullOrEmpty(amount) ? "0" : amount);
            return Convert.ToInt32(amt * 100);
        }
    }
}
