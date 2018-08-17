using HPYL.BLL;
using HPYL.Model;
using HPYL_API.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XL.Application.Code;
using XL.Model.Message;
using HPYL.Model.SMS;
using C = HPYL.Common;
using B = HPYL.BLL;

namespace HPYL_API.Controllers
{
    /// <summary>
    /// 短信控制器
    /// </summary>
    public class SMSController : ApiController
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="obj">'login'</param>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult Send([FromBody]MSMS obj)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            bool isTrue = C.SMS.Send(obj.Phone, obj.Message);
            if (isTrue)
            {
                apiResult.Result =1;
                apiResult.Message = "发送成功!";

            }
            else
            {
                apiResult.Result = 2;
                apiResult.Message = "发送失败!";
            }

            return apiResult;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="obj">phone(手机号),sigin:短信标示如（login、pwd）</param>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult SendCode([FromBody]MSMS obj)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            //验证次数 目前3次一小时
            if (new B.Members().CodeV(obj.Phone, obj.sigin))
            {
                string code = C.SMS.GetCode(4);
                //写入数据
                if (new B.Members().AddPhoneMsg(obj.Phone, code, obj.Message, obj.sigin) > 0)
                {
                    apiResult.Result = 1;
                    apiResult.Message = "发送成功!";
                }
                else
                {
                    apiResult.Result = 2;
                    apiResult.Message = "发送失败!";
                }

            }
            else
            {
                apiResult.Result = 3;
                apiResult.Message = "同一小时只能发送3次信息!";
            }

            return apiResult;
        }
        /// <summary>
        /// 动态登录获取验证码
        /// </summary>
        /// <param name="obj">参数：Phone</param>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult SendLogin([FromBody]MSMS obj)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            //测试阶段取消 验证次数
            //if (new B.Members().CodeV(obj.Phone, "login"))
            //{
            // string code = C.SMS.GetCode(4);
            string code = "1111";
            string contents = "验证码：" + code + "，你正在进行动态密码登录,请勿将验证码告知他人并确认该申请是您本人操作!";
                // bool isTrue = C.SMS.Send(obj.Phone, code, contents);
                //暂时没有对接短信接口， 不需验证
                
                //if (isTrue)
                //{
                    //写入数据
                    if (new B.Members().AddPhoneMsg(obj.Phone, code, contents, "login") > 0)
                    {
                        apiResult.Result = 1;
                        apiResult.Message = "发送成功!";
                    }
                    else
                    {
                        apiResult.Result = 2;
                        apiResult.Message = "发送失败!";
                    }

                //}
                //else
                //{
                //    apiResult.Result = 3;
                //    apiResult.Message = "发送失败!";
                //}
            //}
            //else
            //{
            //    apiResult.Result = 4;
            //    apiResult.Message = "同一小时只能发送3次信息!";
            //}

            return apiResult;
        }

        /// <summary>
        ///  验证码验证
        /// </summary>
        /// <param name="obj">参数：Phone,code,sigin标示</param>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult CodeValidate([FromBody]MSMS obj)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            //写入数据
            if (new B.Members().CodeValidate(obj.Phone, obj.code, obj.sigin) > 0)
            {
                apiResult.Result = 1;
                apiResult.Message = "验证成功!";
            }
            else
            {
                apiResult.Result = 2;
                apiResult.Message = "验证失败!";
            }


            return apiResult;
        }



    }
}