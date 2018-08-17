using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model.SMS
{
    public   class ShortMessage
    {
        #region Model
      

        /// <summary>
        /// 返回状态值：成功返回Success 失败返回：Faild
        /// </summary>
        public string Returnstatus { get; set; }

        /// <summary>
        /// 相关的错误描述
        /// </summary>

        public string Message { get; set; }
        /// <summary>
        /// 返回余额
        /// </summary>

        public string Remainpoint { get; set; }

        /// <summary>
        /// 返回本次任务的序列ID
        /// </summary>
        public string TaskID { get; set; }

        /// <summary>
        /// 成功短信数：当成功后返回提交成功短信数
        /// </summary>
        public string SuccessCounts { get; set; }

        #endregion
    }
}
