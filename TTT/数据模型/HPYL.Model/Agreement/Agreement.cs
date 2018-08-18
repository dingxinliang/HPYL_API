using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 注册协议表
    /// </summary>
    public class Agreement
    {
        #region Model
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int AgreementType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string AgreementContent { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }



        #endregion Model
    }
}
