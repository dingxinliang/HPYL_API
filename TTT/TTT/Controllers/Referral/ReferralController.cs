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

namespace HPYL_API.Controllers.Referral
{
    /// <summary>
    /// 转诊
    /// </summary>
    [TokenAttribute] //针对当前类验证签名
    public class ReferralController : ApiController
    {
        private ReferralBLL FBLL = new ReferralBLL();//诊疗科目

        #region 提交数据


        /// <summary>
        /// 新增转诊
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult InReferral(BaseReferrallog info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.InReferral(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功添加转诊";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "新增转诊失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "新增转诊失败";
                new CCBException(" 新增转诊", ex);
            }
            return apiResult;
        }
         
        #endregion
    }
}