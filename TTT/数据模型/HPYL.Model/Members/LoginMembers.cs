using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 数据访问类:LoginMembers
    /// </summary>
    public  class LoginMembers : BaseModel
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string LoginPhone { get; set; }
        /// <summary>
        /// 动态密码
        /// </summary>
        public string PhoneCode { get; set; }
    }
}
