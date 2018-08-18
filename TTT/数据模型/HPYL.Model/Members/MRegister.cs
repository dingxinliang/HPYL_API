using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 注册模型
    /// </summary>
   public  class MRegister:BaseModel
    {
        #region Model 
        /// <summary>
        ///用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime DateBirth { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        public long TopRegionId { get; set; }
        /// <summary>
        /// 省市区ID
        /// </summary>
        public long RegionId { get; set; }
        /// <summary>
        /// 诊所ID
        /// </summary>
        public long ShopUserId { get; set; }
        /// <summary>
        /// 诊所科室ID
        /// </summary>
        public long ShopCategorId { get; set; }
        /// <summary>
        /// 职称ID
        /// </summary>
        public long JodId { get; set; }
        /// <summary>
        /// 专业ID
        /// </summary>
        public long ZyId { get; set; }
        /// <summary>
        /// 执业年限ID
        /// </summary>
        public long PracticeYID { get; set; }
        /// <summary>
        /// 资格证书1
        /// </summary>
        public string LicenseCert1 { get; set; }
        /// <summary>
        /// 资格证书2
        /// </summary>
        public string LicenseCert2 { get; set; }
        /// <summary>
        /// 身份证1
        /// </summary>
        public string IDCardUrl1 { get; set; }
        /// <summary>
        /// 身份证2
        /// </summary>
        public string IDCardUrl2 { get; set; }
        /// <summary>
        /// 本人工作证明1
        /// </summary>
        public string WorkUrl1 { get; set; }
        /// <summary>
        /// 本人工作证明2
        /// </summary>
        public string WorkUrl2 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
      
        #endregion Model

    }
}
