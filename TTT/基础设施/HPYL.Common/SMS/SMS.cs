using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;

namespace HPYL.Common
{
    public class SMS
    {
        public static readonly string MessageAddress = "http://api.mysubmail.com/message/send.xml";
        public static readonly string Messageappid = "27329";
        public static readonly string signature = "96863d9c92f2ba5bd577e8693e447bdc";

        private static HPYL.Model.SMS.ShortMessage SubmitMessageInfo(String url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(MessageAddress);
            byte[] postBytes = Encoding.ASCII.GetBytes(url);
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            webrequest.ContentLength = postBytes.Length;
            using (Stream reqStream = webrequest.GetRequestStream())
            {
                reqStream.Write(postBytes, 0, postBytes.Length);
            }
            HPYL.Model.SMS.ShortMessage model_ShortMessage = new Model.SMS.ShortMessage();
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            using (WebResponse wr = webrequest.GetResponse())
            {
                StreamReader sr = new StreamReader(wr.GetResponseStream(), System.Text.Encoding.UTF8);
                System.IO.StreamReader xmlStreamReader = sr;
                xmlDoc.Load(xmlStreamReader);
            }
            if (xmlDoc == null)
            {
                model_ShortMessage = null;
            }
            else
            {
                model_ShortMessage.Returnstatus = xmlDoc.GetElementsByTagName("status").Item(0).InnerText.ToString();
                model_ShortMessage.Message = xmlDoc.GetElementsByTagName("send_id").Item(0).InnerText.ToString();
               // model_ShortMessage.Remainpoint = xmlDoc.GetElementsByTagName("fee").Item(0).InnerText.ToString();
                model_ShortMessage.TaskID = xmlDoc.GetElementsByTagName("sms_credits").Item(0).InnerText.ToString();
                model_ShortMessage.SuccessCounts = xmlDoc.GetElementsByTagName("fee").Item(0).InnerText.ToString();

            }
            return model_ShortMessage;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GetCode(int n)
        {
            string code = string.Empty;

            //char[] constant = { '0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                code += constant[rd.Next(0, constant.Length)];
            }

            return code;
        }
      
        /// <summary>
        /// 发送动态密码
        /// </summary>
        /// <param name="strPhone"></param>
        /// <param name="code"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public static bool Send(string strPhone,string contents)
        {
            try
            {
                Regex dReg = new Regex("[0-9]{11,11}");
                if (dReg.IsMatch(strPhone))
                {

                    Encoding myEncoding = Encoding.GetEncoding("UTF-8");
                    string url = "appid=" + HttpUtility.UrlEncode(Messageappid, myEncoding) + "&to=" + HttpUtility.UrlEncode(strPhone, myEncoding) +  "&content=" + HttpUtility.UrlEncode(contents, myEncoding) + "&signature=" + HttpUtility.UrlEncode(signature, myEncoding);
                    HPYL.Model.SMS.ShortMessage model_ShortMessage = SubmitMessageInfo(url);
                    //未获得返回值
                    if (model_ShortMessage == null)
                    {
                        return false;
                    }
                    else
                    {
                        //返回值为成功
                        if (model_ShortMessage.Returnstatus == "success")
                        {
                            return true;
                        }
                        //返回值为失败
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
            catch //(Exception e)
            {
                return false;
            }
        }
        //public static bool Send(string strPhone, string strMessage)
        //{
        //    try
        //    {
        //        Regex dReg = new Regex("[0-9]{11,11}");
        //        if (dReg.IsMatch(strPhone))
        //        {
        //            Encoding myEncoding = Encoding.GetEncoding("UTF-8");
        //            string strRegisterPhone = strPhone;
        //            string url = "action=send&userid=&account=" + HttpUtility.UrlEncode(MessageAccount, myEncoding) + "&password=" + HttpUtility.UrlEncode(MessagePwd, myEncoding) + "&mobile=" + HttpUtility.UrlEncode(strRegisterPhone, myEncoding) + "&content=" + HttpUtility.UrlEncode(strMessage.TrimEnd(' ') + "【" + Messagesign + "】", myEncoding) + "&sendTime=&extno=";
        //            HPYL.Model.SMS.ShortMessage model_ShortMessage = SubmitMessageInfo(url);
        //            //未获得返回值
        //            if (model_ShortMessage == null)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                //返回值为成功
        //                if (model_ShortMessage.Returnstatus == "Success")
        //                {
        //                    return true;
        //                }
        //                //返回值为失败
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch //(Exception e)
        //    {
        //        return false;
        //    }
        //}
    }
}
