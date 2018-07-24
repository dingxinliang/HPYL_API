/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model.Pub
*文件名：  InfoToUser
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 14:55:01

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 14:55:01
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
    /// 用户信息操作类 如查询 删除
    /// </summary>
   public class InfoToUser
    {
        /// <summary>
        /// 当前登录用户(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少用户ID参数")]
        public long UserID { get; set; }
        /// <summary>
        /// 操作信息标识(必填)
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少操作信息标识参数")]
        public long KeyId { get; set; }
    }
}
