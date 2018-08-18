using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model.SMS
{
   /// <summary>
   /// 发送短信模型
   /// </summary>
   public  class MSMS : BaseModel
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 发送消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 发送验证码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 发送类型
        /// </summary>
        public string sigin { get; set; }
    }
}
