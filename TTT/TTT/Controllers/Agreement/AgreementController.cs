using HPYL.Common;
using HPYL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XL.Model.Message;
using C = HPYL.Common;
using B = HPYL.BLL;

namespace HPYL_API.Controllers
{
    /// <summary>
    /// 协议控制器
    /// </summary>
    public class AgreementController : ApiController
    {
        /// <summary>
        /// 获取协议
        /// </summary>
        /// <param name="AgID">医生登录服务协议 AgID=1 诊所入住协议 AgID=2 关于我们 AgID=4</param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult Getagmt(string AgID, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.AgreementBLL bll = new B.AgreementBLL();
            HPYL.Model.Agreement model = bll.GetModel(AgID);
            apiResult.Data = model;
            if (apiResult.Data != null)
            {
                apiResult.Result = 1;
                apiResult.Message = "加载成功!";

            }
            else
            {
                apiResult.Result = 2;
                apiResult.Message = "加载失败!";
            }

            return apiResult;
        }
    }
}