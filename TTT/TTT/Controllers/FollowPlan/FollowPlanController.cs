using HPYL.BLL;
using HPYL.Model;
using HPYL_API.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XL.Application.Code;
using XL.Model.Message;
using XL.Util.WebControl;

namespace HPYL_API.Controllers
{

    /// <summary>
    /// 随访计划
    /// </summary>
    [TokenAttribute] //针对当前类验证签名
    public class FollowPlanController : ApiController
    {

        private FollowPlanBLL FBLL = new FollowPlanBLL();//随访计划

        #region 获取数据

        /// <summary>
        /// 获取诊疗项目随访计划模板
        /// </summary>
        /// <param name="HFT_ID">诊疗项目Id</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetFollowTemPlateList(long HFT_ID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetFollowTemPlateList(HFT_ID);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取诊疗项目随访计划模板:", ex);
            }
            return apiResult;

        }


        /// <summary>
        /// 获取新增随访计划内容、默认开始时间，(随访计划名称、医生、患者、提醒方式操作者自己代入)
        /// </summary>
        /// <param name="HTP_ID">模板Id</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetTemPlateContent(long HTP_ID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetTemPlateContent(HTP_ID).OrderBy(t=>t.HFC_Days);
                ReadFollowPlanContent roc = new ReadFollowPlanContent();
                roc.PlanContentList = data.ToList();
                roc.HTP_StartDate = DateTime.Now.ToString("yyyy-MM-dd");
                apiResult.Data = roc;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取新增随访计划内容:", ex);
            }
            return apiResult;

        }

        /// <summary>
        /// 获取单条随访计划信息
        /// </summary>
        /// <param name="HFP_ID">信息标识ID 随访计划列表有返回</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetPlateContent(long HFP_ID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetPlateContent(HFP_ID);
                data.HFP_CreateTime = DateTime.Parse(data.HFP_CreateTime).ToShortDateString();
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取随访计划信息:", ex);
            }
            return apiResult;

        }

        /// <summary>
        /// 我的随访计划信息列表
        /// </summary>
        /// <param name="UserId">当前用户</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult MyFollowPlanList(long UserId, int page = 1, int pagesize = 8)
        {

            CallBackResult apiResult = new CallBackResult();

            if (!string.IsNullOrEmpty("UserId"))
            {
                //日期数组
                List<MyPlanListDate> DateList = new List<MyPlanListDate>();
                try
                {
                    Pagination pagination = new Pagination();
                    pagination.page = page;
                    pagination.rows = pagesize;
                    pagination.sidx = "HFP_CreateTime";
                    pagination.sord = "asc";

                    //分页时间段，根据时间段拿数据
                    var datas = FBLL.GetPageDate(pagination, UserId);

                    foreach (DataRow items in datas.Rows)
                    {
                        //格式化时间表头
                        MyPlanListDate md = new MyPlanListDate();
                        if (DateTime.Now.ToString("yyyy-MM-dd") == DateTime.Parse(items["HFP_StartTime"].ToString()).ToString("yyyy-MM-dd"))
                        {
                            md.DateTitle = "今天";
                        }
                        else
                        {
                            md.DateTitle = DateTime.Parse(items["HFP_StartTime"].ToString()).ToString("yyyy-MM-dd");
                        }
                        //列表
                       
                        var data = FBLL.GetPageInfo(UserId, items["HFP_StartTime"].ToString());
                        md.InfoList = data;
                        DateList.Add(md);
                    }
                    apiResult.Data = DateList;
                    apiResult.Result = 1;
                    apiResult.Message = "加载成功";
                }
                catch (Exception ex)
                {
                    apiResult.Result = 0;
                    apiResult.Message = "加载失败";
                    new CCBException("我的随访计划信息列表:", ex);
                }
            }
            else
            {
                apiResult.Result = 0;
                apiResult.Message = "参数无效";
            }
            return apiResult;
        }


        #endregion

        #region  提交数据

        /// <summary>
        /// 新增随访计划
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult InFollowPlan(BaseFollowPlan info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.InFollowPlan(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功添加随访计划";
                }
                else {
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

        /// <summary>
        /// 更改随访计划,更改前通过GetPlateContent接口先获取原有数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult ChangeFollowPlan(FollowPlan info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                
                if (FBLL.ChangeFollowPlan(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功更改随访计划";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "更改随访计划失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "更改随访计划失败";
                new CCBException(" 更改随访计划", ex);
            }
            return apiResult;
        }


        /// <summary>
        /// 删除模板计划（KeyId为 HFP_ID 列表有返回）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult DelFollowPlan(InfoToUser info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.DelFollowPlan(info.UserID, info.KeyId))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功删除随访计划";
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
                apiResult.Message = "删除随访计划失败";
                new CCBException(" 删除随访计划", ex);
            }
            return apiResult;
        }
        #endregion

    }
}