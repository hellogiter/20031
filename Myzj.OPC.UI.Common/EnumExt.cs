using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace System
{
    public static class EnumExt
    {
        public static string GetDescription(this Enum sourceEnum)
        {
            object enumValue = (object)sourceEnum;
            Type enumType = sourceEnum.GetType();
            return enumType.GetEnumDescription(enumValue);
        }

        public static string GetEnumDescription(this Type enumType, object enumValue)
        {
            try
            {
                FieldInfo fi = enumType.GetField(Enum.GetName(enumType, enumValue));
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : Enum.GetName(enumType, enumValue);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        public static string GetEnumName(this Type enumType, object enumValue)
        {
            try
            {
                return Enum.GetName(enumType, enumValue);
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        public static SortedList<int, string> GetEnumList(this Type enumType)
        {
            SortedList<int, string> sortedList = null;
            var enumNames = Enum.GetValues(enumType);
            int length = enumNames.Length;
            if (length > 0)
            {
                sortedList = new SortedList<int, string>();
                for (int i = 0; i < length; i++)
                {
                    string enumName = enumNames.GetValue(i).ToString();
                    object enumValue = Enum.Parse(enumType, enumName);
                    string enumDescription = enumType.GetEnumDescription(enumValue);
                    sortedList.Add((int)enumValue, enumDescription);
                }
            }
            return sortedList;
        }

        public static SortedList<string, string> GetEnumStringList(this Type enumType)
        {
            SortedList<string, string> sortedList = null;
            var enumNames = Enum.GetValues(enumType);
            int length = enumNames.Length;
            if (length > 0)
            {
                sortedList = new SortedList<string, string>();
                for (int i = 0; i < length; i++)
                {
                    string enumName = enumNames.GetValue(i).ToString();
                    object enumValue = Enum.Parse(enumType, enumName);
                    string enumDescription = enumType.GetEnumDescription(enumValue);
                    sortedList.Add(enumName, enumDescription);
                }
            }
            return sortedList;
        }
    }
}
