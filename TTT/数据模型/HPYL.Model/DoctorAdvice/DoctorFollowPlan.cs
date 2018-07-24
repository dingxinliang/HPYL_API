/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model.DoctorAdvice
*文件名：  DoctorFollowPlan
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 15:20:10

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 15:20:10
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{


    public class BaseDoctorFollowPlan
    {

        /// <summary>
        /// 模板ID （必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少模板ID参数")]
        public long HAA_ID { set; get; }
        
        /// <summary>
        /// 创建人ID(当前登录人的ID)（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少创建人ID参数")]
        public long? HDP_UserId { set; get; }
        /// <summary>
        /// 提醒方式（0 患者 1 自己 2 全部）（必填）
        /// </summary>
        [Range(0, 2, ErrorMessage = "提醒方式只能是0-2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少提醒方式参数")]
        public int? HDP_Remind { set; get; }

        /// <summary>
        /// 随访医生ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少随访医生ID参数")]
        public long? HDP_DoctorId { set; get; }
        /// <summary>
        /// 患者ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少患者ID参数")]
        public long? HDP_PatientId { set; get; }
    }
    public class DoctorFollowPlan: BaseDoctorFollowPlan
    {
        /// <summary>
        /// 标识列
        /// </summary>
        [Required(ErrorMessage = "HDP_ID不能为空")]
        public long HDP_ID { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Required(ErrorMessage = "开始时间不能为空")]
        public string HDP_CreateTime { get; set; }

        /// <summary>
        /// 随访内容
        /// </summary>
        [StringLength(2500, ErrorMessage = "随访内容的长度不能大于{1}个字")]
        [Required(ErrorMessage = "随访内容不能为空")]
        public string HDP_Content { get; set; }
        /// <summary>
        /// 随访状态,不需要传递
        /// </summary>
        public int HDP_State { get; set; }
    }
}
