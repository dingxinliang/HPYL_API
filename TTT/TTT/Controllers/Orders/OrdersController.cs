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
using XL.Util.WebControl;
using XL.Application.Code;

namespace HPYL_API.Controllers
{
    /// <summary>
    /// 订单控制器
    /// </summary>
    public class OrdersController : ApiController
    {
        private B.orders bll = new B.orders();
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult List(string strWhere, int page = 1, int pagesize = 20)
        {
            CallBackResult apiResult = new CallBackResult();

            if (!string.IsNullOrEmpty("strWhere"))
            {
                try
                {
                    Pagination pagination = new Pagination();
                    pagination.page = page;
                    pagination.rows = pagesize;
                    pagination.sidx = "OrderDate";
                    pagination.sord = "desc";


                    apiResult.Data = bll.GetListPage(pagination, strWhere);
                    if (apiResult.Data != null)
                    {

                        apiResult.Result = 1;
                        apiResult.Message = "加载成功";
                    }
                    else
                    {
                        apiResult.Result = 2;
                        apiResult.Message = "加载失败!";
                    }

                }
                catch (Exception ex)
                {
                    apiResult.Result = 0;
                    apiResult.Message = "加载失败";
                    new CCBException("订单信息列表:", ex);
                }
            }
            else
            {
                apiResult.Result = 0;
                apiResult.Message = "参数无效";
            }
            return apiResult;
        }
    }
}