using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using HPYL_API.App_Start.Attribute;
namespace HPYL_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API 路由
            config.MapHttpAttributeRoutes();
            //config.Filters.Add(new  HPYL_API.App_Start.Attribute.TokenAttribute());

            config.Filters.Add(new ExceptionAttribute());//全局异常监控

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
