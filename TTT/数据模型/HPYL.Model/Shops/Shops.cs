using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    ///  shops:店铺表
    /// </summary>
    public class Shops
    {
        #region Model
       
        /// <summary>
        /// auto_increment
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long GradeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SubDomains { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Theme { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsSelf { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ShopStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RefuseReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyRegionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyEmployeeCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyRegisteredCapital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactsName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactsPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactsEmail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessLicenceNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessLicenceNumberPhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BusinessLicenceRegionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BusinessLicenceStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BusinessLicenceEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessSphere { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrganizationCodePhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralTaxpayerPhot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BankRegionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankPhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaxRegistrationCertificate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaxpayerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TaxRegistrationCertificatePhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayPhoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SenderAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SenderPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FreeFreight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Stage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SenderRegionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessLicenseCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OtherCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string legalPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CompanyFoundingDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BusinessType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IDCardUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IDCardUrl2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeiXinNickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WeiXinSex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeiXinAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeiXinTrueName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeiXinOpenId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeiXinImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AutoAllotOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ProvideInvoice { get; set; }
        #endregion Model

    }
}
