/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model.Referral
*文件名：  Class1
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 22:24:19

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 22:24:19
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

    /// <summary>
    /// 转诊基础类
    /// </summary>
    public class BaseReferrallog
    {
        /// <summary>
        /// 患者ID(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少患者ID参数")]
        public long HRL_PatientId { get; set; }
        /// <summary>
        /// 患者主诉信息 (必填)
        /// </summary>
        [StringLength(250, ErrorMessage = "患者主诉信息的长度不能大于{1}个字")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少患者主诉信息")]
        public string HRL_Info { get; set; }
        /// <summary>
        /// 接诊医生(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少接诊医生ID参数")]
        public long HRL_DoctorId { get; set; }
        /// <summary>
        /// 分成比例(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少分成比例")]
        public decimal HRL_Commission { get; set; }
        /// <summary>
        /// 当前登录医生ID(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少当前登录医生ID")]
        public long HRL_UserID { get; set; }
        /// <summary>
        /// 给医生的备注 (非必填)
        /// </summary>
        public string HRL_Remark { get; set; }
    }
   public class Referrallog: BaseReferrallog
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public long HRL_ID { get; set; }
        /// <summary>
        /// 转诊状态(0 待接诊 1 已接诊 2 已完诊)
        /// </summary>
        public int HRL_State { get; set; }
        /// <summary>
        /// 转诊时间
        /// </summary>
        public int HRL_CreateTime { get; set; }
        /// <summary>
        /// 接诊时间
        /// </summary>
        public int HRL_ReceiveTime { get; set; }

    }
}
