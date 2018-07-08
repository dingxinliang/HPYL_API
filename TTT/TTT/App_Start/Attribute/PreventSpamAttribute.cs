using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace HPYL_API.App_Start.Attribute
{
    /// <summary>
    /// 防止重复提交
    /// </summary>
    public class PreventSpamAttribute: System.Web.Mvc.ActionFilterAttribute
    {
        //处理请求之间的延迟
        public int DelayRequest = 10;
        //防止多次请求时的错误提示信息
        public string ErrorMessage = "Excessive Request Attempts Detected.";
        //出错时URL重定向
        public string RedirectURL;

        /// <summary>
        /// 间隔提交时间
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}