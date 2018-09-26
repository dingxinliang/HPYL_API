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
using XL.Application.Code;

namespace HPYL_API.Controllers
{
    /// <summary>
    /// 诊所控制器
    /// </summary>
    public class ShopsController : ApiController
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="Where"></param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult List(string Where,string Sign, string Ts)
        {
            ///  ShopStatus not in (1,2,4,5)
            CallBackResult apiResult = new CallBackResult();
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            B.ShopsBLL bll = new B.ShopsBLL();
            List<HPYL.Model.Shops> mlist = bll.GetModelList(Where);
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
            B.ShopsBLL bll = new B.ShopsBLL();
            HPYL.Model.Shops model = bll.GetModel(long.Parse(Ids));
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
       /// <summary>
       /// 获取多点执业
       /// </summary>
       /// <param name="CompanyRegionId"></param>
       /// <returns></returns>
        [HttpGet]
        public CallBackResult GetMultipointShosList(string CompanyRegionId)
        {
            CallBackResult apiResult = new CallBackResult();
            apiResult.Result = 2;
            apiResult.Message = "无数据!";
            try
            {
                B.ShopsBLL bll = new B.ShopsBLL();
                List<HPYL.Model.MultipointShops> mlist = bll.GetMultipointShos(long.Parse(CompanyRegionId));
                apiResult.Data = mlist;
                if (apiResult.Data != null && mlist.Count > 0)
                {
                    apiResult.Result = 1;
                    apiResult.Message = "加载成功!";
                }
            }
            catch (Exception ex)
            {
                new CCBException("获取多点执业", ex);
            }
            return apiResult;
        }
        /// <summary>
        /// 获取多点执业详情
        /// </summary>
        /// <param name="ShopId"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetMultipointShosDetl(string ShopId)
        {
            CallBackResult apiResult = new CallBackResult();
            apiResult.Result = 2;
            apiResult.Message = "无数据!";
            try
            {
                B.ShopsBLL bll = new B.ShopsBLL();
                HPYL.Model.MultipointShops mlist = bll.GetMultipointShosDetl(long.Parse(ShopId));
                apiResult.Data = mlist;
                if (apiResult.Data != null)
                {
                    apiResult.Result = 1;
                    apiResult.Message = "加载成功!";
                }
            }
            catch (Exception ex)
            {
                new CCBException("获取多点执业详情", ex);
            }
            return apiResult;
        }
        /// <summary>
        /// 获取诊疗列表（名称+标识）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetListReg()
        {
            CallBackResult apiResult = new CallBackResult();
            apiResult.Result = 2;
            apiResult.Message = "无数据!";
            try
            {
                B.ShopsBLL bll = new B.ShopsBLL();
                List<HPYL.Model.ShopsList> mlist = bll.GetListReg();
                apiResult.Data = mlist;
                if (apiResult.Data != null && mlist.Count > 0)
                {
                    apiResult.Result = 1;
                    apiResult.Message = "加载成功!";
                }
            }
            catch (Exception ex)
            {
                new CCBException("获取诊疗列表（名称+标识）", ex);
            }
            return apiResult;
        }
    }
}