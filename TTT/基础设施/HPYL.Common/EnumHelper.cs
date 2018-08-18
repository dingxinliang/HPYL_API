#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Common
* 项目描述 ：
* 类 名 称 ：EnumHelper
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Common
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/6 21:48:24
* 更新时间 ：2018/8/6 21:48:24
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Common
{
  public static  class EnumHelper
    {
        /// <summary>
        /// 扩展方法，获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstead">当枚举值没有定义DescriptionAttribute，是否使用枚举名代替，默认是使用</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(this Enum value, Boolean nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute == null && nameInstead == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }

        /// <summary>
        /// 把枚举转换为键值对集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="getText">获得值得文本</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        public static Dictionary<Int32, String> EnumToDictionary(Type enumType, Func<Enum, String> getText)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "enumType");
            }
            Dictionary<Int32, String> enumDic = new Dictionary<int, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                Int32 key = Convert.ToInt32(enumValue);
                String value = getText(enumValue);
                enumDic.Add(key, value);
            }
            return enumDic;
        }

        /// <summary>
        /// 枚举字段描述列表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IList<string> GetEnumDescriptionList(Type t)
        {
            var valueDescList = Enum.GetValues(t).Cast<Enum>().Select(m => GetEnumDescription(m)).ToList();
            return valueDescList;
        }
        /// <summary>
        /// 获取枚举的描述信息（Description特性）
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo fi = type.GetField(enumValue.ToString());
            object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
            return "";
        }

  

    }
}
