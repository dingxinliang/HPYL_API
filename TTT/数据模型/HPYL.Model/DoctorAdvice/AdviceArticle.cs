/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model.DoctorAdvice
*文件名：  AdviceArticle
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 14:14:47

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 14:14:47
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 医嘱文章
    /// </summary>
    public class AdviceArticle
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public long HAA_ID { get; set; }
        /// <summary>
        /// 诊所项目类ID
        /// </summary>
        public long HFT_ID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string HAA_Title { get; set; }
        /// <summary>
        /// 文章封面
        /// </summary>
        public string HAA_PicUrl { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string HAA_Content { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int HAA_State { get; set; }
    }
}
