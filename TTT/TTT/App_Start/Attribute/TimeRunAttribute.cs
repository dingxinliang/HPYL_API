using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using XL.Util.Log;

namespace HPYL_API.XLAttribute
{

    /// <summary>
    /// 版 本 1.0
    /// Copyright (c) 2017-2018 北京佰云信息技术有限公司
    /// 创建人：DXL
    /// 日 期：2017-09-09 21:40:37 
    /// 描 述： 接口运行效率监控
    /// </summary>
    public class TimeRunAttribute : ActionFilterAttribute
    {
        private const string Key = "__XL_Log__";
        //private Log _logger;
        ///// <summary>
        ///// 日志操作
        ///// </summary>
        //public Log Logger
        //{
        //    get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        //}

        private   readonly Log logger = LogFactory.GetLogger("TimeRunAttribute");
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (SkipLogging(actionContext))
            {
                return;
            }
            var stopWatch = new Stopwatch();
            actionContext.Request.Properties[Key] = stopWatch;
            stopWatch.Start();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(Key))
            {
                return;
            }

            var stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;
            if (stopWatch != null)
            {
                stopWatch.Stop();
                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                var controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                //Debug.Print(string.Format("[API {0}- {1}: time {2}.]", controllerName, actionName, stopWatch.Elapsed));
                logger.Info(string.Format("[API {0}- {1}: time {2}.]", controllerName, actionName, stopWatch.Elapsed));
            }
        }

        private static bool SkipLogging(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<NoLogAttribute>().Any() ||
                    actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<NoLogAttribute>().Any();
        }
    }


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoLogAttribute : Attribute
    {

    }
}
