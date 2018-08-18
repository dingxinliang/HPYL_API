using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 医生的名片
    /// </summary>
   public  class MemberCard
    {
        /// <summary>
        /// 诊所名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 医生头像
        /// </summary>
        public string UserPhoto { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 所在科室
        /// </summary>
        public string ShopCategorName { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string JodName { get; set; }

    }
}
