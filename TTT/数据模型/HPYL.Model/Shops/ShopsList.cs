using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 获取诊所列表模型
    /// </summary>
    public class ShopsList
    {
        /// <summary>
        /// 标识ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 诊所名称
        /// </summary>
        public string ShopName { get; set; }
    }
}
