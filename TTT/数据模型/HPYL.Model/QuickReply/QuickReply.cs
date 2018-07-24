/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model.QuickReply
*文件名：  QuickReply
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 15:44:54

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 15:44:54
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


    public class BaseQuickReply
    {  /// <summary>
       /// 快捷回复内容(必填)
       /// </summary>
        [StringLength(100, ErrorMessage = "随方名称的长度不能大于{1}个字")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少内容参数")]
        public string HQR_Content { get; set; }
        /// <summary>
        /// 创建者(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少用户ID参数")]
        public long HQR_UserId { get; set; }
  
       
    }
    /// <summary>
    /// 快捷回复
    /// </summary>
    public class QuickReply: BaseQuickReply
    {
        /// <summary>
        /// 标识列 (必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少信息ID参数")]
        public long HQR_ID { get; set; }
        /// <summary>
        /// 创建时间 非必填
        /// </summary>
        public string HQR_Time { get; set; }
    }
}
