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

namespace HPYL_API.Controllers
{
    /// <summary>
    /// 日程
    /// </summary>
    [TokenAttribute] //针对当前类验证签名
    public class CalendarController : ApiController
    {


        private CalendarBLL FBLL = new CalendarBLL();//日程安排

        #region 获取数据

        /// <summary>
        /// 获取每月接诊数(日程日历每日数据统计)
        /// </summary>
        /// <param name="year">当前选择年份 格式如2018</param>
        /// <param name="month">当前选择月份 格式如1</param>
        /// <param name="userid">当前登录医生ID</param>
        /// <param name="clientId">当前诊所ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetCalendarList(int year = 1, int month = 1, long userid = 0, long clientId = 0)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetCalendarList(year, month, userid, clientId);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取每月日程接诊数:", ex);
            }
            return apiResult;

        }

        /// <summary>
        /// 获取选择日期预约时间段的统计情况 
        /// </summary>
        /// <param name="year">当前选择的年份 如2018</param>
        /// <param name="month">当前选择的月份 如01</param>
        /// <param name="day">当前选择的日 如11</param>
        /// <param name="userid">当前医生ID</param>
        /// <param name="clientId">当前诊所ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetDayTimeList(int year = 1, int month = 1, int day = 1, long userid = 0, long clientId = 0)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetDayTimeList(year, month, day, userid, clientId);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取每天具体预约时间段的情况:", ex);
            }
            return apiResult;

        }

        /// <summary>
        /// 获取选择日期的预约用户列表
        /// </summary>
        /// <param name="year">当前选择的年份 如2018</param>
        /// <param name="month">当前选择的月份 如01</param>
        /// <param name="day">当前选择的日 如11</param>
        /// <param name="userid">当前医生ID</param>
        /// <param name="clientId">当前诊所ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetDayBookingList(int year = 1, int month = 1, int day = 1, long userid = 0, long clientId = 0)

        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                var data = FBLL.GetDayBookingList(year, month, day, userid, clientId);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取当天预约用户列表:", ex);
            }
            return apiResult;

        }

        /// <summary>
        /// 获取用户【日期】接诊设置（周排班上面功能模块）,可以任选一天进来设置接诊
        /// </summary>
        /// <param name="year">当前选择的年份 如2018</param>
        /// <param name="month">当前选择的月份 如01</param>
        /// <param name="day">当前选择的日 如11</param>
        /// <param name="userid">当前医生ID</param>
        /// <param name="clientId">当前诊所ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetCustomDay(int year = 1, int month = 1, int day = 1, long userid = 0, long clientId = 0)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {


                var data = FBLL.GetCustomDay(year, month, day, userid, clientId);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取用户自定义每天的接诊设置:", ex);
            }
            return apiResult;

        }


        /// <summary>
        /// 获取用户【周模板】接诊设置 ,周一至周日
        /// </summary>
        /// <param name="userid">当前医生ID</param>
        /// <param name="clientId">当前诊所ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetSystemWeek(long userid = 0, long clientId = 0)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {


                var data = FBLL.GetSystemWeek(userid, clientId);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("每周固定的接诊设置:", ex);
            }
            return apiResult;

        }

        /// <summary>
        /// 获取预约单详情
        /// </summary>
        /// <param name="userid">当前登录医生ID</param>
        /// <param name="orderid">当前订单ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult GetOrderView(long userid = 0, long orderid = 0)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {


                var data = FBLL.GetOrderModel(userid, orderid);
                apiResult.Data = data;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("每周固定的接诊设置:", ex);
            }
            return apiResult;

        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 修改【日期】接诊状态(针对某年某月某日的设置)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult SaveState(PostDateState info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.SaveState(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功更改状态";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "状态操作失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "开启/关闭日期状态失败";
                new CCBException(" 开启/关闭日期状态失败", ex);
            }
            return apiResult;
        }

        /// <summary>
        /// 修改【日期】排班接诊数量(针对某年某月某日的设置)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult SaveDateNum(PostDateTime info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.SaveDateNum(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功修改接诊数量";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "修改失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "修改失败";
                new CCBException(" 修改日期排班接诊数量", ex);
            }
            return apiResult;
        }

        /// <summary>
        /// 修改【周模板】接诊数量 （针对周一至周日的设置）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult SaveWeekNum(PostWeekNum info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.SaveWeekNum(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功修改接诊数量";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "修改失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "修改失败";
                new CCBException(" 修改周模板接诊数量", ex);
            }
            return apiResult;
        }

        /// <summary>
        /// 修改【周模板】接诊状态 （针对周一至周日的设置）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult SaveWeekState(PostWeekState info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.SaveWeekState(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "已成功修改接诊状态";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "修改失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "修改失败";
                new CCBException(" 修改周模板接诊状态", ex);
            }
            return apiResult;
        }


        /// <summary>
        /// 添加预约单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult InOrder(OrderModel info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.InOrder(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "预约成功";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "预约失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "预约失败";
                new CCBException(" 添加预约单", ex);
            }
            return apiResult;
        }


      



        /// <summary>
        /// 取消预约单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public CallBackResult CancelOrder(InfoToUser info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                if (FBLL.CancelOrder(info))
                {
                    apiResult.Result = 1;
                    apiResult.Message = "预约已取消";
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "取消失败";
                }

            }
            catch (Exception ex)
            {

                apiResult.Result = 0;
                apiResult.Message = "取消失败";
                new CCBException(" 取消预约单", ex);
            }
            return apiResult;
        }
        #endregion

    }
}