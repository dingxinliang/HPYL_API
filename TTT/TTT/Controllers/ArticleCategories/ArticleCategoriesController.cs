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
    /// 资讯分类控制器
    /// </summary>
    public class ArticleCategoriesController : ApiController
    {
        /// <summary>
        /// 资讯分类列表
        /// </summary>
        /// <param name="NewsClass">1	患者知识 2	职称分类 3 专业分类 4 年限分类</param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult List(string NewsClass, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.ArticleCategoriesBLL bll = new B.ArticleCategoriesBLL();
            List<HPYL.Model.ArticleCategories> mlist = bll.GetModelList(NewsClass);
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
        /// 分类详情
        /// </summary>
        /// <param name="ClassId"></param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult Detail(string ClassId, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.ArticleCategoriesBLL bll = new B.ArticleCategoriesBLL();
            HPYL.Model.ArticleCategories model = bll.GetModel(ClassId);
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