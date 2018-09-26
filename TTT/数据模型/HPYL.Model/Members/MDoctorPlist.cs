using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 医生 关联患者模型
    /// </summary>
    public  class MDoctorPlist
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
    }
}
