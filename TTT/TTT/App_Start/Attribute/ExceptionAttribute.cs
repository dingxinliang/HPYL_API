using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using XL.Application.Code;
using XL.Model.Message;

namespace HPYL_API.App_Start.Attribute
{

    /// <summary>
    /// 异常记录
    /// </summary>
    public class ExceptionAttribute: ExceptionFilterAttribute
    {
        /// <summary>
        /// 重写基类的异常处理方法
        /// </summary>
        /// <param name="actionExecutedContext">异常</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1.异常日志记录（正式项目里面一般是用log4net记录异常日志）
            new CCBException("" + DateTime.Now + "-异常信息:", actionExecutedContext.Exception);
            var Result = new CallBackResult() { Message = "请求失败", Result = 0 };
           
                Result.Message = "请求失败";
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, Result);
            base.OnException(actionExecutedContext);
        }
    }

   
}