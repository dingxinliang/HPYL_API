using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
   /// <summary>
   /// 多点执业模型
   /// </summary>
    public class MultipointShops
    {
        /// <summary>
        /// 标识id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 店铺logo
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 区域完整路径
        /// </summary>
        public string RegionFullName { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Remark { get; set; }
       
    }
}
