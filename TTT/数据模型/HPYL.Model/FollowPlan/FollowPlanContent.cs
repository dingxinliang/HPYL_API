/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model
*文件名：  FollowPlanContent
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/14 21:12:05

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/14 21:12:05
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
    /// 随访计划内容新增返回结果
    /// </summary>
    public class ReadFollowPlanContent
    {
 
        /// <summary>
        /// 开始时间
        /// </summary>
        public string  HTP_StartDate { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        public List<FollowPlanContent> PlanContentList { get; set; }

    }
    /// <summary>
    /// 随访计划内容
    /// </summary>
    public class FollowPlanContent
    {
        /// <summary>
        /// 标识
        /// </summary>
        public long HFC_ID { get; set; }
        /// <summary>
        /// 随访时间（天）
        /// </summary>
        public int HFC_Days { get; set; }
        /// <summary>
        /// 提醒时间
        /// </summary>
        public string HFC_StartTime { get; set; }
        /// <summary>
        /// 随访内容
        /// </summary>
        public string HFC_Content { get; set; }
    }
}
