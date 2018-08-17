using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    public class BaseFollowPlan {

        /// <summary>
        /// 模板ID （必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少模板ID参数")]
        public long HTP_ID { set; get; }
        /// <summary>
        /// 随方名称（必填）
        /// </summary>
        [StringLength(60, ErrorMessage = "随方名称的长度不能大于{1}个字")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少随方名称参数")]
        public string HFP_Name { set; get; }
        /// <summary>
        /// 创建人ID(当前登录人的ID)（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少创建人ID参数")]
        public long? HFP_UserId { set; get; }
        /// <summary>
        /// 提醒方式（0 患者 1 自己 2 全部）（必填）
        /// </summary>
        [Range(0, 2, ErrorMessage = "提醒方式只能是0-2")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少提醒方式参数")]
        public int? HFP_Remind { set; get; }

        /// <summary>
        /// 随访医生ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少随访医生ID参数")]
        public long? HFP_DoctorId { set; get; }
        /// <summary>
        /// 患者ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少患者ID参数")]
        public long? HFP_PatientId { set; get; }
    }
    /// <summary>
    /// 随访计划
    /// </summary>
    public class FollowPlan:BaseFollowPlan
    {
        /// <summary>
        /// 标识（删除更新时必填）
        /// </summary>
        [Required(ErrorMessage = "HFP_ID不能为空")]
        public long HFP_ID{set; get;}
        /// <summary>
        /// 开始时间 格式如：2018-01-27（必填）
        /// </summary>
         [Required(ErrorMessage = "开始时间不能为空")]
        public string  HFP_CreateTime { set; get; }
        /// <summary>
        ///随访内容（必填）
        /// </summary>
        [StringLength(2500, ErrorMessage = "随访内容的长度不能大于{1}个字")]
        [Required(ErrorMessage = "随访内容不能为空")]
        public string HFP_Content { set; get; }
        /// <summary>
        /// 随访状态，不需要传递
        /// </summary>
        public int HFP_State { set; get; }
    }


    /// <summary>
    /// 我的随访计划计划 时间列表
    /// </summary>
    public class MyPlanListDate {
        //表头显示
        public string DateTitle { get; set; }
        //信息列表
        public List<FollowPlan> InfoList { get; set; }
    }

    
}
