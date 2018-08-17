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

namespace HPYL_API.Controllers.RecruitPlan
{
    /// <summary>
    /// 申请医生协议控制器
    /// </summary>
    public class RecruitPlanController : ApiController
    {
        /// <summary>
        /// 申请医生协议 
        /// </summary>
        /// <param name="Id">参考值 id=2</param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult RecruitPlanContent(string Id, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.RecruitPlanBLL bll = new B.RecruitPlanBLL();
            HPYL.Model.RecruitPlan model = bll.GetModel(long .Parse(Id));
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