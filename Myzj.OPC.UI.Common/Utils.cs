using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Myzj.OPC.UI.Common
{
    public class Utils
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="txtEncrypt">加密字符串</param>
        /// <param name="number">固定入参16,密码截取前16位</param>
        /// <returns>密文</returns>
        public static string MD5Encrypt(string txtEncrypt, int number)
        {
            byte[] buffer1 = Encoding.Default.GetBytes(txtEncrypt);
            buffer1 = new MD5CryptoServiceProvider().ComputeHash(buffer1);
            string text1 = "";
            for (int num1 = 0; num1 < buffer1.Length; num1++)
            {
                text1 = text1 + buffer1[num1].ToString("x").PadLeft(2, '0');
            }
            if (number == 0x10)
            {
                text1 = text1.Substring(8, 0x10);
            }
            return text1;
        }
    }
}
