/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.Model
*文件名：  FollowType
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/14 20:54:49

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/14 20:54:49
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
    /// APP随访计划模板表
    /// </summary>
    public class BaseFollowTemPlate {

        /// <summary>
        /// 标识
        /// </summary>
        public long HTP_ID { set; get; }
        /// <summary>
        /// 诊疗项目ID 
        /// </summary>

        public long HFT_ID { set; get; }
        /// <summary>
        /// 随方名称
        /// </summary>
        public string HTP_Name { set; get; }
    }
    /// <summary>
    /// 随访计划模板表
    /// </summary>
    public class FollowTemPlate: BaseFollowTemPlate
    {
         
        /// <summary>
        /// 启用状态（0 未启用 1 启用）
        /// </summary>
        public int HTP_State { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime HTP_CreateTime { set; get; }
        /// <summary>
        /// 创建用户ID
        /// </summary>
        public long HTP_UserId { set; get; }
    }
}
