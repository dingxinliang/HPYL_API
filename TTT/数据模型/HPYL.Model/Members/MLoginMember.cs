using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 登录验证 返回模型
    /// </summary>
    public class MLoginMember
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户角色 0 患者 1 医生 2 医生未审核角色
        /// </summary>
        public long RoleId { get; set; }
    }
}
