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

namespace HPYL_API.Controllers.QuickReply
{
    /// <summary>
    /// 快捷回复
    /// </summary>
    [TokenAttribute] //针对当前类验证签名
    public class QuickReplyController : ApiController
    {
        private QuickReplyBLL FBLL = new QuickReplyBLL();//快捷回复

        #region 获取数据

        /// <summary>
        /// 获取快捷回复
        /// </summary>
        /// <param name="UserID">当前登录用户</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult QuickReplyList(long UserID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                 
                var data = FBLL.QuickReplyList(UserID);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取快捷回复:", ex);
            }
            return apiResult;

        }
        /// <summary>
        /// 获取快捷回复对象
        /// </summary>
        /// <param name="HQR_ID">标识列 列表有返回</param>
        /// <param name="UserId">当前登录用户</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetModel(long HQR_ID,long UserId)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {

                var data = FBLL.GetModel(HQR_ID, UserId);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取快捷回复:", ex);
            }
            return apiResult;

        }

        #endregion

        #region 提交数据


        /// <summary>
        /// 新增快捷回复
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult InQuickReply(HPYL.Model.BaseQuickReply info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.InQuickReply(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功添加快捷回复";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "新增快捷回复失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "新增快捷回复失败";
                new CCBException(" 新增快捷回复", ex);
            }
            return apiResult;
        }

        /// <summary>
        /// 更改快捷回复,更改前通过GetModel接口先获取原有数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult Change(HPYL.Model.QuickReply info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {

                if (FBLL.Change(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功更改快捷回复";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "更改快捷回复失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "更改快捷回复失败";
                new CCBException(" 更改快捷回复", ex);
            }
            return apiResult;
        }


        /// <summary>
        /// 删除快捷回复（KeyId为 HQR_ID 列表有返回）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult Del(InfoToUser info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.Del(info.KeyId, info.UserID))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功删除";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "未找到要删除的记录";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "删除快捷回复失败";
                new CCBException(" 删除快捷回复", ex);
            }
            return apiResult;
        }

        #endregion

    }
}