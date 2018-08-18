#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Model.Calendar
* 项目描述 ：
* 类 名 称 ：Calendar
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Model.Calendar
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/5 11:42:56
* 更新时间 ：2018/8/5 11:42:56
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{

    /// <summary>
    /// 日历
    /// </summary>
   public class BaseCalendar
    {
        /// <summary>
        /// 年份
        /// </summary>
        public string year { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public string month { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        public string day { get; set; }
        /// <summary>
        /// 可接诊人数
        /// </summary>
        public int totalnum { get; set; }

        /// <summary>
        /// 已预约人数
        /// </summary>
        public int receivenum { get; set; }

    }

    /// <summary>
    /// 固定排班
    /// </summary>
    public class GDCalendar
    {
        /// <summary>
        /// 周几
        /// </summary>
        public string week { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 接诊数量
        /// </summary>
        public int total { get; set; }
    }
    /// <summary>
    /// 自定义排班
    /// </summary>
    public class ZDYCalendar
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 接诊数量
        /// </summary>
        public int total { get; set; }
    }



    /// <summary>
    /// 预约时间段
    /// </summary>
    public class BookingTime {

        /// <summary>
        /// 开始时间
        /// </summary>
        public string startTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime { get; set; }

    }

    /// <summary>
    /// 预约列表
    /// </summary>
    public class BookingList {

        /// <summary>
        /// 组合标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 待确认数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 预约用户列表
        /// </summary>
        public List<BookingUser> BookingUser { get; set; }

    }

    /// <summary>
    /// 预约用户信息
    /// </summary>
    public class BookingUser {

        /// <summary>
        /// 预约单ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string bookingtime { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string userhead { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 诊所名称
        /// </summary>
        public string ClinicName { get; set; }
        /// <summary>
        /// 就诊地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 就诊项目
        /// </summary>
        public List<Project> project { get; set; }

        /// <summary>
        /// 预约状态
        /// </summary>
        public string state { get; set; }

    }

    /// <summary>
    /// 就诊项目
    /// </summary>
    public class Project {

        /// <summary>
        /// 项ID
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// 就诊项
        /// </summary>
        public string Name { get; set; }

    }

    /// <summary>
    /// 预约单状态
    /// </summary>
    public enum OrderState
    {
        [Description("待付款")]
        WaitPay = 1,
        [Description("待就诊")]
        WaitVisit = 2,
        [Description("待结算")]
        WaitFinish = 3,
        [Description("已关闭")]
        Close = 4,
        [Description("已完成")]
        Finish = 5,
        [Description("待确认")]
        WaitOk =6
    }
}
