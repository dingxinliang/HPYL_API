using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 新建患者模型
    /// </summary>
   public  class MPatient : BaseModel
    {
        /// <summary>
        ///医生用户ID
        /// </summary>
        public long DocUserId { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public long Age { get; set; }
        /// <summary>
        /// 治疗项目ID
        /// </summary>
        public string ItemID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
