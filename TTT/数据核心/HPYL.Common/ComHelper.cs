using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace HPYL.Common
{
    /// <summary>
    ///  获取post/get集合
    /// </summary>
    public class ComHelper
    {
        /// <summary>
        /// 获取post
        /// </summary>
        /// <returns></returns>
        public static string getPostStr()
        {
            Int32 intLen = Convert.ToInt32(System.Web.HttpContext.Current.Request.InputStream.Length);
            byte[] b = new byte[intLen];
            System.Web.HttpContext.Current.Request.InputStream.Read(b, 0, intLen);
            return System.Text.Encoding.UTF8.GetString(b);
        }

        /// <summary>
        /// 获取post/get集合
        /// </summary>
        /// <param name="ignoreCase">true 不区分大小写，统一返回小写  false 区分大小写</param>
        /// <returns></returns>
        public static SortedDictionary<string, string> GetRequestSortDic(bool ignoreCase)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = HttpContext.Current.Request.Form;

            //coll = HttpContext.Current.Request.Params;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                if (ignoreCase)
                    sArray.Add(requestItem[i].ToLower(), GetString(requestItem[i]));
                else
                    sArray.Add(requestItem[i], GetString(requestItem[i]));
            }

            coll = HttpContext.Current.Request.QueryString;
            requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                if (ignoreCase)
                    sArray.Add(requestItem[i].ToLower(), GetString(requestItem[i]));
                else
                    sArray.Add(requestItem[i], GetString(requestItem[i]));
            }


            ////post上来的json
            //if (HttpContext.Current.Request.RequestType.ToLower()=="post")
            //{
            //    String jsonData = String.Empty;
            //    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Request.InputStream);
            //    //using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Request.InputStream))
            //    //{
            //        jsonData = reader.ReadToEnd();
            //    //}
            //    if (jsonData != String.Empty)
            //    {
            //       SortedDictionary<string, string> pArray = JsonHelper.DeserializeJsonToObject<SortedDictionary<string, string>>(jsonData);
            //       //sArray.Union(pArray);
            //       foreach (var item in pArray)
            //       {
            //           if (ignoreCase)
            //               sArray.Add(item.Key.ToLower(), GetString(item.Value));
            //           else
            //               sArray.Add(item.Key, item.Value);
            //       }

            //    }
            //}

            return sArray;
        }


        /// <summary>
        /// 获取get集合
        /// </summary>
        /// <returns></returns>
        public static SortedDictionary<string, string> GetQueryStringSortDic()
        {
            int i = 0;
            string List = "";
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll = HttpContext.Current.Request.QueryString; ;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {

                if (!requestItem[i].Contains("Sign"))
                {
                    if (!string.IsNullOrEmpty(GetString(requestItem[i])))
                    {
                        List += requestItem[i] + ":" + GetString(requestItem[i]);
                        sArray.Add(requestItem[i], GetString(requestItem[i]));
                    }
                }
            }
            Log.Debug("GET", List);
            return sArray;
        }

        /// <summary>
        /// url参数转成SortedDictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SortedDictionary<string, string> GetSortDic(string parameters)
        {
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll = HttpUtility.ParseQueryString(parameters);
            foreach (string key in coll.Keys)
            {
                sArray.Add(key, coll[key]);
            }

            return sArray;
        }

        public static SortedDictionary<string, string> GetSortDic2(string parameters)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll = HttpUtility.ParseQueryString(parameters);
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], coll[requestItem[i]]);
            }
            /*
              for (int i = 0; i < myCol.Count; i++)  
                Console.WriteLine("   [{0}]     {1,-10} {2}", i, myCol.GetKey(i), myCol.Get(i));  
             */
            return sArray;
        }

        /// <summary>
        /// 从字典取值
        /// </summary>
        /// <param name="m_values"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetDicValue(SortedDictionary<string, string> m_values, string key)
        {
            string o = "";
            m_values.TryGetValue(key, out o);
            if (null != o)
                return o.ToString();
            else
                return "";
        }

        /// <summary>
        /// 从当前环境中获取
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string GetString(string name)
        {
            string res = "";
            var v = HttpContext.Current.Request[name];
            if (v != null)
            {
                res = v.ToString();
            }
            return res;
        }
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertIntDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">原串</param>
        /// <returns></returns>
        public static string ToMD5(string str)
        {
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }
        /// <summary>
        /// 获取Sign
        /// </summary>
        /// <param name="inputPara"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string GetResponseMysign(SortedDictionary<string, string> inputPara, string privateKey)
        {
            inputPara.Add("Key", privateKey);
            string fullstring = GetPostStrings(inputPara, "sign");
            return ToMD5(fullstring);
        }
        public static string GetResponseMysign(SortedDictionary<string, string> inputPara)
        {

            return GetResponseMysign(inputPara, System.Configuration.ConfigurationManager.AppSettings["PrivateKey"].ToString());
        }


        public static bool CheckSign(Model.BaseModel o)
        {
            SortedDictionary<string, string> dic = ToSortMap(o);
            string mySign = GetResponseMysign(dic);
            Log.Debug("SIGN", mySign);
            return o.Sign.Equals(mySign);
        }

        public static bool CheckSign(string Sign)
        {
            SortedDictionary<string, string> dic = GetQueryStringSortDic();
            string mySign = GetResponseMysign(dic);
            return Sign.Equals(mySign);
        }

        public static bool CheckRequest(Model.BaseModel model, out int result, out string message)
        {
            //调试模式不验证签名和时间戳
            if (System.Configuration.ConfigurationManager.AppSettings["DebugModel"].ToString() == "true")
            {
                result = 1;
                message = "调试模式通过";
                return true;
            }
            else
            {
                //正式模式
                if (model.Ts.Length != 10)
                {
                    result = -1;
                    message = "请求已过期!";
                    return false;
                }
                else
                {
                    //验证时间戳
                    var tsDate = ComHelper.ConvertIntDateTime(model.Ts.ToString());
                    if (tsDate > DateTime.Now.AddMinutes(5) || tsDate < DateTime.Now.AddMinutes(-5))
                    {
                        result = -2;
                        message = "请求已过期!";
                        return false;

                    }
                    //验证签名
                    if (CheckSign(model))
                    {
                        result = 1;
                        message = "请求验证通过";
                        return true;
                    }
                    else
                    {
                        result = -3;
                        message = "签名错误!";
                        return false;
                    }

                }

            }


        }

        public static bool CheckRequest(string Sign, string Ts, out int result, out string message)
        {
            //调试模式不验证签名和时间戳
            if (System.Configuration.ConfigurationManager.AppSettings["DebugModel"].ToString() == "true")
            {
                // CheckSign(Sign);

                result = 1;
                message = "调试模式通过";
                return true;
            }
            else
            {
                //正式模式
                if (Ts.Length != 10)
                {
                    result = -1;
                    message = "请求已过期!";
                    return false;
                }
                else
                {
                    //验证时间戳
                    var tsDate = ComHelper.ConvertIntDateTime(Ts.ToString());
                    if (tsDate > DateTime.Now.AddMinutes(5) || tsDate < DateTime.Now.AddMinutes(-5))
                    {
                        result = -2;
                        message = "请求已过期!";
                        return false;

                    }
                    //验证签名
                    if (CheckSign(Sign))
                    {
                        result = 1;
                        message = "请求验证通过";
                        return true;
                    }
                    else
                    {
                        result = -3;
                        message = "签名错误!";
                        return false;
                    }

                }

            }


        }

        private static string GetPostStrings(SortedDictionary<string, string> inputPara, string excepted)
        {
            Dictionary<string, string> sPara = new Dictionary<string, string>();
            //过滤空值、sign与sign_type参数
            foreach (KeyValuePair<string, string> temp in inputPara)
            {
                //if (temp.Key.ToLower() != excepted && temp.Value != "" && temp.Value != null)
                //{
                //    sPara.Add(temp.Key.ToLower(), temp.Value);
                //}
                if (temp.Key.ToLower() != excepted)
                {
                    sPara.Add(temp.Key, temp.Value);
                }
            }
            //获得签名结果
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in sPara)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }
            //去掉最後一個&字符
            int nLen = prestr.Length;
            if (nLen > 1)
                prestr.Remove(nLen - 1, 1);
            return prestr.ToString();
        }
        /// <summary>
        /// 获取十位的时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GenerateTimeStamp(DateTime dt)
        {
            // Default implementation of UNIX time of the current UTC time  
            TimeSpan ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        /// <summary>
        /// 
        /// 将对象属性转换为key-value对
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Dictionary<String, Object> ToMap(Object o)
        {
            Dictionary<String, Object> map = new Dictionary<string, object>();

            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new Object[] { }));
                }
            }

            return map;

        }

        public static SortedDictionary<string, string> ToSortMap(Object o)
        {
            string test = "";
            SortedDictionary<string, string> map = new SortedDictionary<string, string>();

            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    try
                    {
                        if (!p.Name.Contains("Sign"))
                        {
                            if (!string.IsNullOrEmpty(mi.Invoke(o, new Object[] { }).ToString()))
                            {
                                test += "" + p.Name + ":" + mi.Invoke(o, new Object[] { }).ToString() + "";
                                map.Add(p.Name, mi.Invoke(o, new Object[] { }).ToString());
                            }
                        }
                    }
                    catch
                    {
                        //test += "" + p.Name + ":";
                        //map.Add(p.Name, "");

                    }
                }
            }
            Log.Debug("Post:", test);
            return map;

        }
    }
}
