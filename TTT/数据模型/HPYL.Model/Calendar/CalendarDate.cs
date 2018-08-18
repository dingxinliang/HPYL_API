#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Model.Calendar
* 项目描述 ：
* 类 名 称 ：CalendarDate
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Model.Calendar
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/7 13:39:41
* 更新时间 ：2018/8/7 13:39:41
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{


    /// <summary>
    /// 日期基础类
    /// </summary>
    public class BaseDate {

        /// <summary>
        /// 标识
        /// </summary>
        public long DateId { get; set; }
        /// <summary>
        /// 诊所ID
        /// </summary>
        public long ClientId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 用户iD
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 周几
        /// </summary>
        public string Week { get; set; }

        /// <summary>
        /// 每天时间段接诊设置
        /// </summary>
        public List<DateTimeList> DateTimeList { get; set; }
    }
    /// <summary>
    /// 排班计划表
    /// </summary>
   public class CalendarDate: BaseDate
    {

        
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }

       
        
    }


    /// <summary>
    /// 时间段设置
    /// </summary>
    public class DateTimeList
    {

        /// <summary>
        /// 标识
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 接诊数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 开启状态
        /// </summary>
        public int State { get; set; }
    }
}
