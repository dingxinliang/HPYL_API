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
    /// 新闻控制器
    /// </summary>
    public class ArticlesController : ApiController
    {
        private B.ArticlesBLL bll = new B.ArticlesBLL();
        /// <summary>
        /// 资讯列表
        /// </summary>
        /// <param name="NewsClass"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult List(string NewsClass, int page = 1, int pagesize = 20)
        {
            CallBackResult apiResult = new CallBackResult();

            if (!string.IsNullOrEmpty("NewsClass"))
            {
               
                try
                {
                    Pagination pagination = new Pagination();
                    pagination.page = page;
                    pagination.rows = pagesize;
                    pagination.sidx = "AddDate";
                    pagination.sord = "desc";

                  
                    apiResult.Data = bll.GetListPage(pagination, long.Parse(NewsClass));
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
                    new CCBException("资讯信息列表:", ex);
                }
            }
            else
            {
                apiResult.Result = 0;
                apiResult.Message = "参数无效";
            }
            return apiResult;
        }
        /// <summary>
        /// 新闻详情
        /// </summary>
        /// <param name="NewsId"></param>
       
        /// <returns></returns>
        [HttpGet]
        public CallBackResult Detail(string NewsId)
        {
            CallBackResult apiResult = new CallBackResult();
            HPYL.Model.Articles model = bll.GetModel(NewsId);
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