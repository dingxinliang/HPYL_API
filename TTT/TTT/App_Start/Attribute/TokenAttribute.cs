using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using XL.Model.Message;
using XL.Util;
using XL.Util.Token;

using XL.Model;

using XL.Application.Code;
using XL.Util.Security;

namespace HPYL_API.App_Start.Attribute
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2017-2018 北京佰云信息技术有限公司
    /// 创建人：DXL
    /// 日 期：2017-09-09 21:40:37 
    /// 描 述： 
    /// </summary>
	public   class TokenAttribute : ActionFilterAttribute
    {

     
        /// <summary>
        /// Filter 校验签名
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            try
            {
               
                var result = false;
                var apiresult = new CallBackResult();
                var request = filterContext.Request;
                //根据请求类型拼接参数
                dynamic form = HttpContext.Current.Request.QueryString;

             

                #region sign签名验证
                //签名验证
                switch (request.Method.Method)
                {
                    case "POST":
                        Stream stream = HttpContext.Current.Request.InputStream;
                        HttpContext.Current.Request.InputStream.Position = 0;//核心代码
                        string responseJson = string.Empty;
                        //接收客户端json数据
                        StreamReader streamReader = new StreamReader(stream);
                        var jsonres = streamReader.ReadToEnd().ToString();
                        LogHelper.WriteLog("jsonres:"+ jsonres, "");
                        //转换成dynamic 对象，不在针对模型创建class
                        var DynamicObject = JsonConvert.DeserializeObject<dynamic>(jsonres);
                       
                        //签名验证
                        result = TokenHelper.CheckRequest(DynamicObject, out apiresult.Result, out apiresult.Message);
                        break;
                    case "GET":
                        result = TokenHelper.CheckRequest((form["Sign"] == null ? "" : form["Sign"]), (form["Ts"] == null ? "" : form["Ts"]), out apiresult.Result, out apiresult.Message);
                        break;
                }

                //如果验证不成功返回验证信息
                if (!result)
                {
                    filterContext.Response = new HttpResponseMessage { Content = new StringContent(Json.Encode(apiresult), Encoding.GetEncoding("UTF-8"), "application/json") };
                    base.OnActionExecuting(filterContext);
                    return;
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteError("验证",ex);
                filterContext.Response = new HttpResponseMessage { Content = new StringContent(Json.Encode(ex.Message), Encoding.GetEncoding("UTF-8"), "application/json") };
                base.OnActionExecuting(filterContext);
                return;
            }

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}