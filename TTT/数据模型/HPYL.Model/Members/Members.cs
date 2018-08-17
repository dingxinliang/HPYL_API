using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    public  class Members
    {
        /// <summary>
        /// 
        /// </summary>
        
        #region Model
      
        /// auto_increment
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TopRegionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Disabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Expenditure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ParentSellerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayPwd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayPwdSalt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long InviteUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ShareUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Occupation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal NetAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastConsumptionTime { get; set; }
        #endregion Model

    }
}
