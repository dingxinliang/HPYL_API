using HPYL.BLL;
using HPYL.Model;
using HPYL_API.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XL.Application.Code;
using XL.Model.Message;

namespace HPYL_API.Controllers.DoctorAdvice
{
    /// <summary>
    /// 医嘱计划
    /// </summary>
    [TokenAttribute] //针对当前类验证签名
    public class DoctorAdviceController : ApiController
    {

        private DoctorAdviceBLL FBLL = new DoctorAdviceBLL(); 
        #region 获取数据
        /// <summary>
        /// 获取诊疗项目医嘱内容模板列表
        /// </summary>
        /// <param name="HFT_ID">诊疗项目Id</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetAdviceArticleList(long HFT_ID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetAdviceArticleList(HFT_ID);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取诊疗项目医嘱计划模板:", ex);
            }
            return apiResult;

        }
        /// <summary>
        /// 获取单条医嘱内容及计划
        /// </summary>
        /// <param name="HAA_ID">文章ID（内容模板列表返回）</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetDoctorFollowContent(long HAA_ID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetModel(HAA_ID);
                var JsonData = new
                {
                    ArticleInfo = data,
                    FollowList = FBLL.FollowList(HAA_ID)
                };
                apiResult.Data = JsonData;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取单条医嘱内容及计划:", ex);
            }
            return apiResult;

        }
        #endregion

        #region 提交数据


        /// <summary>
        /// 新增医嘱随访计划（如果发送医嘱选择关联随访计划请调用此接口写入）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult InFollowPlan(BaseDoctorFollowPlan info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.InFollowPlan(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功添加随访计划";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "新增随访计划失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "新增随访计划失败";
                new CCBException(" 新增随访计划", ex);
            }
            return apiResult;
        }

        #endregion
    }
}