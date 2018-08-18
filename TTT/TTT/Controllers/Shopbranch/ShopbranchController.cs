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
    /// 医生控制器
    /// </summary>
    public class ShopbranchController : ApiController
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult List(string Where, string Sign, string Ts)
        {
            //  ShopStatus not in (1,2,4,5)
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.ShopbranchBLL bll = new B.ShopbranchBLL();
            List<HPYL.Model.Shopbranch> mlist = bll.GetModelList(Where);
            apiResult.Data = mlist;
            if (apiResult.Data != null && mlist.Count > 0)
            {
                apiResult.Result = 1;
                apiResult.Message = "加载成功!";

            }
            else
            {
                apiResult.Result = 2;
                apiResult.Message = "无数据!";
            }

            return apiResult;
        }
        /// <summary>
        /// 单个数据详情
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult Detail(string Ids, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.ShopbranchBLL bll = new B.ShopbranchBLL();
            HPYL.Model.Shopbranch model = bll.GetModel(long.Parse(Ids));
            apiResult.Data = model;
            if (apiResult.Data != null && model!=null)
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