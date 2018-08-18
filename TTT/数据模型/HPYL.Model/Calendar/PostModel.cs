#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Model.Calendar
* 项目描述 ：
* 类 名 称 ：PostModel
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Model.Calendar
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/7 16:44:12
* 更新时间 ：2018/8/7 16:44:12
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model 
{

    /// <summary>
    ///  全局基础类
    /// </summary>
    public class BaseGlobalDate {
        /// <summary>
        /// 当前医生ID （必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少当前医生ID参数")]
        public long UserId { get; set; }
        /// <summary>
        /// 诊所ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少诊所ID参数")]
        public long ClinetId { get; set; }

    }
    /// <summary>
    /// 日期基础类
    /// </summary>
    public class BasePostDate: BaseGlobalDate
    {
        /// <summary>
        /// 年（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Year参数")]
        public int Year { get; set; }
        /// <summary>
        /// 月（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Month参数")]
        public int Month { get; set; }
        /// <summary>
        /// 日（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Day参数")]
        public int Day { get; set; }

    }
    /// <summary>
    /// 日期接诊数量数据提交类
    /// </summary>
    public class PostDateTime: BasePostDate
    {
        /// <summary>
        ///时间标识 M 上午,A 下午,N 晚上 （必填）
        /// </summary>
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少时间标识参数")]
        [StringLength(1, ErrorMessage = "字符长度应为一个字符")]
        public string Tag { get; set; }
        /// <summary>
        /// 接诊患者数量（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少接诊患者数量参数")]
        public int Num { get; set; }

      
    }

    /// <summary>
    /// 日期接诊 状态开启关闭
    /// </summary>
    public class PostDateState: BasePostDate
    {
        /// <summary>
        /// 开启/关闭的标识  M 上午,A 下午,N 晚上,D全天 （必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Flag参数")]
        public string Flag { get; set; }

        /// <summary>
        /// 开启/关闭状态  0 关闭 1 开启
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少state参数")]
        [Range(0, 1, ErrorMessage = "状态只能是0或1")]
        public int State { get; set; }

    }

    /// <summary>
    /// 周接诊数量设置
    /// </summary>
    public class PostWeekNum: BaseGlobalDate
    {
        /// <summary>
        /// 信息ID（接口api/Calendar/GetSystemWeek返回数据取得DateId（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少DateId参数")]
        public long DateId { get; set; }
        /// <summary>
        ///时间标识 M 上午,A 下午,N 晚上 （必填）
        /// </summary>

        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少时间标识参数")]
        [StringLength(1, ErrorMessage = "字符长度应为一个字符")]
        public string Tag { get; set; }
        /// <summary>
        /// 接诊患者数量（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少接诊患者数量参数")]
        public int Num { get; set; }
    }

    /// <summary>
    /// 周接诊状态设置
    /// </summary>
    public class PostWeekState : BaseGlobalDate
    {
        /// <summary>
        /// 信息ID（接口api/Calendar/GetSystemWeek返回数据取得DateId（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少DateId参数")]
        public long DateId { get; set; }
        /// <summary>
        ///时间标识 M 上午,A 下午,N 晚上,D全天  （必填）
        /// </summary>

        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少Flag参数")]
        [StringLength(1, ErrorMessage = "字符长度应为一个字符")]
        public string Flag { get; set; }
        /// <summary>
        /// 接诊患者数量（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少state参数")]
        [Range(0, 1, ErrorMessage = "状态只能是0或1")]
        public int State { get; set; }
    }

    public class HPYL_CalendarTime
    {
        
        /// <summary>
        /// 周期主键
        /// </summary>
        public long HCW_ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string HCD_Name { get; set; }
        /// <summary>
        /// 标识 M 上午,A 下午,N 晚上
        /// </summary>
        public string HCD_Tag { get; set; }
        /// <summary>
        /// 接诊数量
        /// </summary>
        public int HCD_Num { get; set; }
        /// <summary>
        /// 开启状态
        /// </summary>
        public int HCD_State { get; set; }
    } 
}
