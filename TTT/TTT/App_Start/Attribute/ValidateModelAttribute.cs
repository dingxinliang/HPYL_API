using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using XL.Model.Message;

namespace HPYL_API.App_Start.Attribute
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
          {
 
            if (!actionContext.ModelState.IsValid)
            {
 
                var Result = new CallBackResult() { Message = "请求参数无效",Result=0 };
                //自定义错误信息
               var item = actionContext.ModelState.Values.Take(1).SingleOrDefault();
                Result.Message = item.Errors.Where(b => !string.IsNullOrWhiteSpace(b.ErrorMessage)).Take(1).SingleOrDefault().ErrorMessage;
                 actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, Result);
             }
         }
    }
}