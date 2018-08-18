using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model.User
{
    /// <summary>
    /// 登录模型传入
    /// </summary>
    public class LoginUser : BaseModel
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
