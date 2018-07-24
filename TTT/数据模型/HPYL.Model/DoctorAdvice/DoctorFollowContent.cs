/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model.DoctorAdvice
*文件名：  DoctorFollowContent
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 14:35:12

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 14:35:12
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
   public class DoctorFollowContent
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public long HDC_ID { get; set; }
        /// <summary>
        /// 文章ID
        /// </summary>
        public long HAA_ID { get; set; }
        /// <summary>
        /// 随访天数
        /// </summary>
        public int HDC_Days { get; set; }
        /// <summary>
        /// 开始随访时间
        /// </summary>
        public string HDC_StratTime { get; set; }
        /// <summary>
        /// 随访内容
        /// </summary>
        public string HDC_Content { get; set; }

    }
}
