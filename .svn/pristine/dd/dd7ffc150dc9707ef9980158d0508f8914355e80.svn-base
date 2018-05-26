using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using ServiceStack.Text;

namespace MYZJ.Finance.UI.Common
{
    public class Serializer
    {
        private static readonly JavaScriptSerializer _jss = new JavaScriptSerializer();

        public static string SerializeToString<T>(T value)
        {
            if (null == value)
            {
                return string.Empty;
            }
            return TypeSerializer.SerializeToString(value);
        }

        public static string SerializerToStringWithQuot<T>(T t)
        {
            if (null == t)
            {
                return string.Empty;
            }
            return _jss.Serialize(t);
        }

        public static T DeserializeFromString<T>(string value)
        {
            return TypeSerializer.DeserializeFromString<T>(value);
        }

        public static T DeserializeFromStringWithQuot<T>(string value)
        {
            return _jss.Deserialize<T>(value);
        }
    }
}
