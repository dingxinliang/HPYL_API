/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model
*文件名：  FollowType
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/14 21:00:15

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/14 21:00:15
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
    /// 诊疗科目
    /// </summary>
    /// 
    public class BaseFollowType
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public string HFT_ID { set; get; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string HFT_Name { set; get; }
    }
    /// <summary>
    /// 一级分类
    /// </summary>
    public class GetFollowType: BaseFollowType
    {
        public List <SecondList> SecondList{ get; set; }
    }
      /// <summary>
      /// 二级分类
      /// </summary>
    public class SecondList: BaseFollowType
    {

    }
    /// <summary>
    /// 诊疗科目
    /// </summary>
   public class FollowType
    {
        /// <summary>
		/// 标识
		/// </summary>
		public long HFT_ID { set; get; }
        /// <summary>
        /// 诊所Id（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "诊所Id参数无效")]
        public long HFT_ShopId { set; get; }
        /// <summary>
        /// 父类ID（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "父类ID参数无效")]
        public long HFT_ParentId { set; get; }
        /// <summary>
        /// 项目名称（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "项目名称参数无效")]
        [StringLength(20, MinimumLength =2, ErrorMessage = "项目名称的长度必须大于{2}个字并小于{1}个字")]
        public string HFT_Name { set; get; }
        /// <summary>
        /// 创建人Id（必填）
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "创建人Id参数无效")]
        public long HFT_UserId { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        
        public DateTime? HFT_CreateTime { set; get; }
        /// <summary>
        /// 启用状态(0 未启用 1启用)
        /// </summary>
        public int? HFT_State { set; get; }
        /// <summary>
        /// 层级
        /// </summary>
        public int? HFT_Layer { set; get; }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void Create()
        {
            this.HFT_CreateTime = DateTime.Now;
            this.HFT_State =1;
            this.HFT_Layer =2;
        }
    }
}
