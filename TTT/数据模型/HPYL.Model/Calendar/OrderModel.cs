#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Model.Calendar
* 项目描述 ：
* 类 名 称 ：OrderModel
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Model.Calendar
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/13 13:52:30
* 更新时间 ：2018/8/13 13:52:30
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    public class OrderModel
    {

        /// <summary>
        /// 诊所id（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少ClientId参数")]
        public long ClientId { get; set; }

        /// <summary>
        /// 当前医生ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少DoctorId参数")]
        public long DoctorId { set; get; }
        /// <summary>
        /// 患者ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少PatientId参数")]
        public long PatientId { get; set; }
        /// <summary>
        /// 就诊日期（格式如 2018-08-13）（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Date参数")]
        public string Date { get; set; }
        /// <summary>
        /// 就诊开始时间 (格式如 15:20)（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少StartTime参数")]
        public string StartTime { get; set; }

        /// <summary>
        /// 就诊结束时间 (格式如 15:20)（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少EndTime参数")]
        public string EndTime { get; set; }
        /// <summary>
        /// 就诊地点ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少AddressId参数")]
        public long AddressId { get; set; }
        /// <summary>
        /// 接诊地址（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Address参数")]
        public string Address { get; set; }



        /// <summary>
        /// 就诊项目Id 列表字符串（多个项目","拼接隔开 如"1,2,3,4,5"）（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少ProjectIdList参数")]
        public string ProjectIdList { get; set; }

        /// <summary>
        /// 提醒方式（0 患者 1 自己 2 全部）（必填）
        /// </summary>
        [Range(0, 2, ErrorMessage = "提醒方式只能是0-2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少提醒方式参数")]
        public int Remind { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100, ErrorMessage = "内容的长度不能大于{1}个字")]
        public string Content { get; set; }
    }
 

    /// <summary>
    /// 预约单详情
    /// </summary>
    public class OrderInfo:OrderModel{


        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 是否可以取消预约（目前提前30分钟可以取消） -1 不可以 0 可以 
        /// </summary>
        public int IsCannel { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 就诊科目
        /// </summary>
        public List<Project> project { get; set; }



    }

}
