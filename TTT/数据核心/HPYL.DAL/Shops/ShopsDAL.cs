using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.DAL
{
    public class ShopsDAL
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from himall_shops");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", Id)
            };
            parameters[0].Value = Id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HPYL.Model.Shops model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into himall_shops(");
            strSql.Append("GradeId,ShopName,Logo,SubDomains,Theme,IsSelf,ShopStatus,RefuseReason,CreateDate,EndDate,CompanyName,CompanyRegionId,CompanyAddress,CompanyPhone,CompanyEmployeeCount,CompanyRegisteredCapital,ContactsName,ContactsPhone,ContactsEmail,BusinessLicenceNumber,BusinessLicenceNumberPhoto,BusinessLicenceRegionId,BusinessLicenceStart,BusinessLicenceEnd,BusinessSphere,OrganizationCode,OrganizationCodePhoto,GeneralTaxpayerPhot,BankAccountName,BankAccountNumber,BankName,BankCode,BankRegionId,BankPhoto,TaxRegistrationCertificate,TaxpayerId,TaxRegistrationCertificatePhoto,PayPhoto,PayRemark,SenderName,SenderAddress,SenderPhone,Freight,FreeFreight,Stage,SenderRegionId,BusinessLicenseCert,ProductCert,OtherCert,legalPerson,CompanyFoundingDate,BusinessType,IDCard,IDCardUrl,IDCardUrl2,WeiXinNickName,WeiXinSex,WeiXinAddress,WeiXinTrueName,WeiXinOpenId,WeiXinImg,AutoAllotOrder,ProvideInvoice)");
            strSql.Append(" values (");
            strSql.Append("@GradeId,@ShopName,@Logo,@SubDomains,@Theme,@IsSelf,@ShopStatus,@RefuseReason,@CreateDate,@EndDate,@CompanyName,@CompanyRegionId,@CompanyAddress,@CompanyPhone,@CompanyEmployeeCount,@CompanyRegisteredCapital,@ContactsName,@ContactsPhone,@ContactsEmail,@BusinessLicenceNumber,@BusinessLicenceNumberPhoto,@BusinessLicenceRegionId,@BusinessLicenceStart,@BusinessLicenceEnd,@BusinessSphere,@OrganizationCode,@OrganizationCodePhoto,@GeneralTaxpayerPhot,@BankAccountName,@BankAccountNumber,@BankName,@BankCode,@BankRegionId,@BankPhoto,@TaxRegistrationCertificate,@TaxpayerId,@TaxRegistrationCertificatePhoto,@PayPhoto,@PayRemark,@SenderName,@SenderAddress,@SenderPhone,@Freight,@FreeFreight,@Stage,@SenderRegionId,@BusinessLicenseCert,@ProductCert,@OtherCert,@legalPerson,@CompanyFoundingDate,@BusinessType,@IDCard,@IDCardUrl,@IDCardUrl2,@WeiXinNickName,@WeiXinSex,@WeiXinAddress,@WeiXinTrueName,@WeiXinOpenId,@WeiXinImg,@AutoAllotOrder,@ProvideInvoice)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@GradeId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ShopName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Logo", MySqlDbType.VarChar,100),
                    new MySqlParameter("@SubDomains", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Theme", MySqlDbType.VarChar,100),
                    new MySqlParameter("@IsSelf", MySqlDbType.Byte,1),
                    new MySqlParameter("@ShopStatus", MySqlDbType.Int32,11),
                    new MySqlParameter("@RefuseReason", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@CreateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@EndDate", MySqlDbType.DateTime),
                    new MySqlParameter("@CompanyName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CompanyRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@CompanyAddress", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CompanyPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CompanyEmployeeCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@CompanyRegisteredCapital", MySqlDbType.Decimal,18),
                    new MySqlParameter("@ContactsName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ContactsPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ContactsEmail", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BusinessLicenceNumber", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BusinessLicenceNumberPhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BusinessLicenceRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@BusinessLicenceStart", MySqlDbType.DateTime),
                    new MySqlParameter("@BusinessLicenceEnd", MySqlDbType.DateTime),
                    new MySqlParameter("@BusinessSphere", MySqlDbType.VarChar,100),
                    new MySqlParameter("@OrganizationCode", MySqlDbType.VarChar,100),
                    new MySqlParameter("@OrganizationCodePhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@GeneralTaxpayerPhot", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankAccountName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankAccountNumber", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankCode", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@BankPhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@TaxRegistrationCertificate", MySqlDbType.VarChar,100),
                    new MySqlParameter("@TaxpayerId", MySqlDbType.VarChar,100),
                    new MySqlParameter("@TaxRegistrationCertificatePhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PayPhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PayRemark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@SenderName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@SenderAddress", MySqlDbType.VarChar,100),
                    new MySqlParameter("@SenderPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Freight", MySqlDbType.Decimal,18),
                    new MySqlParameter("@FreeFreight", MySqlDbType.Decimal,18),
                    new MySqlParameter("@Stage", MySqlDbType.Int32,11),
                    new MySqlParameter("@SenderRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@BusinessLicenseCert", MySqlDbType.VarChar,120),
                    new MySqlParameter("@ProductCert", MySqlDbType.VarChar,120),
                    new MySqlParameter("@OtherCert", MySqlDbType.VarChar,120),
                    new MySqlParameter("@legalPerson", MySqlDbType.VarChar,50),
                    new MySqlParameter("@CompanyFoundingDate", MySqlDbType.DateTime),
                    new MySqlParameter("@BusinessType", MySqlDbType.Int32,11),
                    new MySqlParameter("@IDCard", MySqlDbType.VarChar,50),
                    new MySqlParameter("@IDCardUrl", MySqlDbType.VarChar,200),
                    new MySqlParameter("@IDCardUrl2", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinNickName", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinSex", MySqlDbType.Int32,11),
                    new MySqlParameter("@WeiXinAddress", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinTrueName", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinOpenId", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinImg", MySqlDbType.VarChar,200),
                    new MySqlParameter("@AutoAllotOrder", MySqlDbType.Byte,1),
                    new MySqlParameter("@ProvideInvoice", MySqlDbType.Byte,1)};
            parameters[0].Value = model.GradeId;
            parameters[1].Value = model.ShopName;
            parameters[2].Value = model.Logo;
            parameters[3].Value = model.SubDomains;
            parameters[4].Value = model.Theme;
            parameters[5].Value = model.IsSelf;
            parameters[6].Value = model.ShopStatus;
            parameters[7].Value = model.RefuseReason;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.EndDate;
            parameters[10].Value = model.CompanyName;
            parameters[11].Value = model.CompanyRegionId;
            parameters[12].Value = model.CompanyAddress;
            parameters[13].Value = model.CompanyPhone;
            parameters[14].Value = model.CompanyEmployeeCount;
            parameters[15].Value = model.CompanyRegisteredCapital;
            parameters[16].Value = model.ContactsName;
            parameters[17].Value = model.ContactsPhone;
            parameters[18].Value = model.ContactsEmail;
            parameters[19].Value = model.BusinessLicenceNumber;
            parameters[20].Value = model.BusinessLicenceNumberPhoto;
            parameters[21].Value = model.BusinessLicenceRegionId;
            parameters[22].Value = model.BusinessLicenceStart;
            parameters[23].Value = model.BusinessLicenceEnd;
            parameters[24].Value = model.BusinessSphere;
            parameters[25].Value = model.OrganizationCode;
            parameters[26].Value = model.OrganizationCodePhoto;
            parameters[27].Value = model.GeneralTaxpayerPhot;
            parameters[28].Value = model.BankAccountName;
            parameters[29].Value = model.BankAccountNumber;
            parameters[30].Value = model.BankName;
            parameters[31].Value = model.BankCode;
            parameters[32].Value = model.BankRegionId;
            parameters[33].Value = model.BankPhoto;
            parameters[34].Value = model.TaxRegistrationCertificate;
            parameters[35].Value = model.TaxpayerId;
            parameters[36].Value = model.TaxRegistrationCertificatePhoto;
            parameters[37].Value = model.PayPhoto;
            parameters[38].Value = model.PayRemark;
            parameters[39].Value = model.SenderName;
            parameters[40].Value = model.SenderAddress;
            parameters[41].Value = model.SenderPhone;
            parameters[42].Value = model.Freight;
            parameters[43].Value = model.FreeFreight;
            parameters[44].Value = model.Stage;
            parameters[45].Value = model.SenderRegionId;
            parameters[46].Value = model.BusinessLicenseCert;
            parameters[47].Value = model.ProductCert;
            parameters[48].Value = model.OtherCert;
            parameters[49].Value = model.legalPerson;
            parameters[50].Value = model.CompanyFoundingDate;
            parameters[51].Value = model.BusinessType;
            parameters[52].Value = model.IDCard;
            parameters[53].Value = model.IDCardUrl;
            parameters[54].Value = model.IDCardUrl2;
            parameters[55].Value = model.WeiXinNickName;
            parameters[56].Value = model.WeiXinSex;
            parameters[57].Value = model.WeiXinAddress;
            parameters[58].Value = model.WeiXinTrueName;
            parameters[59].Value = model.WeiXinOpenId;
            parameters[60].Value = model.WeiXinImg;
            parameters[61].Value = model.AutoAllotOrder;
            parameters[62].Value = model.ProvideInvoice;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HPYL.Model.Shops model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update himall_shops set ");
            strSql.Append("GradeId=@GradeId,");
            strSql.Append("ShopName=@ShopName,");
            strSql.Append("Logo=@Logo,");
            strSql.Append("SubDomains=@SubDomains,");
            strSql.Append("Theme=@Theme,");
            strSql.Append("IsSelf=@IsSelf,");
            strSql.Append("ShopStatus=@ShopStatus,");
            strSql.Append("RefuseReason=@RefuseReason,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("CompanyRegionId=@CompanyRegionId,");
            strSql.Append("CompanyAddress=@CompanyAddress,");
            strSql.Append("CompanyPhone=@CompanyPhone,");
            strSql.Append("CompanyEmployeeCount=@CompanyEmployeeCount,");
            strSql.Append("CompanyRegisteredCapital=@CompanyRegisteredCapital,");
            strSql.Append("ContactsName=@ContactsName,");
            strSql.Append("ContactsPhone=@ContactsPhone,");
            strSql.Append("ContactsEmail=@ContactsEmail,");
            strSql.Append("BusinessLicenceNumber=@BusinessLicenceNumber,");
            strSql.Append("BusinessLicenceNumberPhoto=@BusinessLicenceNumberPhoto,");
            strSql.Append("BusinessLicenceRegionId=@BusinessLicenceRegionId,");
            strSql.Append("BusinessLicenceStart=@BusinessLicenceStart,");
            strSql.Append("BusinessLicenceEnd=@BusinessLicenceEnd,");
            strSql.Append("BusinessSphere=@BusinessSphere,");
            strSql.Append("OrganizationCode=@OrganizationCode,");
            strSql.Append("OrganizationCodePhoto=@OrganizationCodePhoto,");
            strSql.Append("GeneralTaxpayerPhot=@GeneralTaxpayerPhot,");
            strSql.Append("BankAccountName=@BankAccountName,");
            strSql.Append("BankAccountNumber=@BankAccountNumber,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankCode=@BankCode,");
            strSql.Append("BankRegionId=@BankRegionId,");
            strSql.Append("BankPhoto=@BankPhoto,");
            strSql.Append("TaxRegistrationCertificate=@TaxRegistrationCertificate,");
            strSql.Append("TaxpayerId=@TaxpayerId,");
            strSql.Append("TaxRegistrationCertificatePhoto=@TaxRegistrationCertificatePhoto,");
            strSql.Append("PayPhoto=@PayPhoto,");
            strSql.Append("PayRemark=@PayRemark,");
            strSql.Append("SenderName=@SenderName,");
            strSql.Append("SenderAddress=@SenderAddress,");
            strSql.Append("SenderPhone=@SenderPhone,");
            strSql.Append("Freight=@Freight,");
            strSql.Append("FreeFreight=@FreeFreight,");
            strSql.Append("Stage=@Stage,");
            strSql.Append("SenderRegionId=@SenderRegionId,");
            strSql.Append("BusinessLicenseCert=@BusinessLicenseCert,");
            strSql.Append("ProductCert=@ProductCert,");
            strSql.Append("OtherCert=@OtherCert,");
            strSql.Append("legalPerson=@legalPerson,");
            strSql.Append("CompanyFoundingDate=@CompanyFoundingDate,");
            strSql.Append("BusinessType=@BusinessType,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("IDCardUrl=@IDCardUrl,");
            strSql.Append("IDCardUrl2=@IDCardUrl2,");
            strSql.Append("WeiXinNickName=@WeiXinNickName,");
            strSql.Append("WeiXinSex=@WeiXinSex,");
            strSql.Append("WeiXinAddress=@WeiXinAddress,");
            strSql.Append("WeiXinTrueName=@WeiXinTrueName,");
            strSql.Append("WeiXinOpenId=@WeiXinOpenId,");
            strSql.Append("WeiXinImg=@WeiXinImg,");
            strSql.Append("AutoAllotOrder=@AutoAllotOrder,");
            strSql.Append("ProvideInvoice=@ProvideInvoice");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@GradeId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ShopName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Logo", MySqlDbType.VarChar,100),
                    new MySqlParameter("@SubDomains", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Theme", MySqlDbType.VarChar,100),
                    new MySqlParameter("@IsSelf", MySqlDbType.Byte,1),
                    new MySqlParameter("@ShopStatus", MySqlDbType.Int32,11),
                    new MySqlParameter("@RefuseReason", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@CreateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@EndDate", MySqlDbType.DateTime),
                    new MySqlParameter("@CompanyName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CompanyRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@CompanyAddress", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CompanyPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CompanyEmployeeCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@CompanyRegisteredCapital", MySqlDbType.Decimal,18),
                    new MySqlParameter("@ContactsName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ContactsPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ContactsEmail", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BusinessLicenceNumber", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BusinessLicenceNumberPhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BusinessLicenceRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@BusinessLicenceStart", MySqlDbType.DateTime),
                    new MySqlParameter("@BusinessLicenceEnd", MySqlDbType.DateTime),
                    new MySqlParameter("@BusinessSphere", MySqlDbType.VarChar,100),
                    new MySqlParameter("@OrganizationCode", MySqlDbType.VarChar,100),
                    new MySqlParameter("@OrganizationCodePhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@GeneralTaxpayerPhot", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankAccountName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankAccountNumber", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankCode", MySqlDbType.VarChar,100),
                    new MySqlParameter("@BankRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@BankPhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@TaxRegistrationCertificate", MySqlDbType.VarChar,100),
                    new MySqlParameter("@TaxpayerId", MySqlDbType.VarChar,100),
                    new MySqlParameter("@TaxRegistrationCertificatePhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PayPhoto", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PayRemark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@SenderName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@SenderAddress", MySqlDbType.VarChar,100),
                    new MySqlParameter("@SenderPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Freight", MySqlDbType.Decimal,18),
                    new MySqlParameter("@FreeFreight", MySqlDbType.Decimal,18),
                    new MySqlParameter("@Stage", MySqlDbType.Int32,11),
                    new MySqlParameter("@SenderRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@BusinessLicenseCert", MySqlDbType.VarChar,120),
                    new MySqlParameter("@ProductCert", MySqlDbType.VarChar,120),
                    new MySqlParameter("@OtherCert", MySqlDbType.VarChar,120),
                    new MySqlParameter("@legalPerson", MySqlDbType.VarChar,50),
                    new MySqlParameter("@CompanyFoundingDate", MySqlDbType.DateTime),
                    new MySqlParameter("@BusinessType", MySqlDbType.Int32,11),
                    new MySqlParameter("@IDCard", MySqlDbType.VarChar,50),
                    new MySqlParameter("@IDCardUrl", MySqlDbType.VarChar,200),
                    new MySqlParameter("@IDCardUrl2", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinNickName", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinSex", MySqlDbType.Int32,11),
                    new MySqlParameter("@WeiXinAddress", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinTrueName", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinOpenId", MySqlDbType.VarChar,200),
                    new MySqlParameter("@WeiXinImg", MySqlDbType.VarChar,200),
                    new MySqlParameter("@AutoAllotOrder", MySqlDbType.Byte,1),
                    new MySqlParameter("@ProvideInvoice", MySqlDbType.Byte,1),
                    new MySqlParameter("@Id", MySqlDbType.Int64,20)};
            parameters[0].Value = model.GradeId;
            parameters[1].Value = model.ShopName;
            parameters[2].Value = model.Logo;
            parameters[3].Value = model.SubDomains;
            parameters[4].Value = model.Theme;
            parameters[5].Value = model.IsSelf;
            parameters[6].Value = model.ShopStatus;
            parameters[7].Value = model.RefuseReason;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.EndDate;
            parameters[10].Value = model.CompanyName;
            parameters[11].Value = model.CompanyRegionId;
            parameters[12].Value = model.CompanyAddress;
            parameters[13].Value = model.CompanyPhone;
            parameters[14].Value = model.CompanyEmployeeCount;
            parameters[15].Value = model.CompanyRegisteredCapital;
            parameters[16].Value = model.ContactsName;
            parameters[17].Value = model.ContactsPhone;
            parameters[18].Value = model.ContactsEmail;
            parameters[19].Value = model.BusinessLicenceNumber;
            parameters[20].Value = model.BusinessLicenceNumberPhoto;
            parameters[21].Value = model.BusinessLicenceRegionId;
            parameters[22].Value = model.BusinessLicenceStart;
            parameters[23].Value = model.BusinessLicenceEnd;
            parameters[24].Value = model.BusinessSphere;
            parameters[25].Value = model.OrganizationCode;
            parameters[26].Value = model.OrganizationCodePhoto;
            parameters[27].Value = model.GeneralTaxpayerPhot;
            parameters[28].Value = model.BankAccountName;
            parameters[29].Value = model.BankAccountNumber;
            parameters[30].Value = model.BankName;
            parameters[31].Value = model.BankCode;
            parameters[32].Value = model.BankRegionId;
            parameters[33].Value = model.BankPhoto;
            parameters[34].Value = model.TaxRegistrationCertificate;
            parameters[35].Value = model.TaxpayerId;
            parameters[36].Value = model.TaxRegistrationCertificatePhoto;
            parameters[37].Value = model.PayPhoto;
            parameters[38].Value = model.PayRemark;
            parameters[39].Value = model.SenderName;
            parameters[40].Value = model.SenderAddress;
            parameters[41].Value = model.SenderPhone;
            parameters[42].Value = model.Freight;
            parameters[43].Value = model.FreeFreight;
            parameters[44].Value = model.Stage;
            parameters[45].Value = model.SenderRegionId;
            parameters[46].Value = model.BusinessLicenseCert;
            parameters[47].Value = model.ProductCert;
            parameters[48].Value = model.OtherCert;
            parameters[49].Value = model.legalPerson;
            parameters[50].Value = model.CompanyFoundingDate;
            parameters[51].Value = model.BusinessType;
            parameters[52].Value = model.IDCard;
            parameters[53].Value = model.IDCardUrl;
            parameters[54].Value = model.IDCardUrl2;
            parameters[55].Value = model.WeiXinNickName;
            parameters[56].Value = model.WeiXinSex;
            parameters[57].Value = model.WeiXinAddress;
            parameters[58].Value = model.WeiXinTrueName;
            parameters[59].Value = model.WeiXinOpenId;
            parameters[60].Value = model.WeiXinImg;
            parameters[61].Value = model.AutoAllotOrder;
            parameters[62].Value = model.ProvideInvoice;
            parameters[63].Value = model.Id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from himall_shops ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int64)
            };
            parameters[0].Value = Id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from himall_shops ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Shops GetModel(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,GradeId,ShopName,Logo,SubDomains,Theme,IsSelf,ShopStatus,RefuseReason,CreateDate,EndDate,CompanyName,CompanyRegionId,CompanyAddress,CompanyPhone,CompanyEmployeeCount,CompanyRegisteredCapital,ContactsName,ContactsPhone,ContactsEmail,BusinessLicenceNumber,BusinessLicenceNumberPhoto,BusinessLicenceRegionId,BusinessLicenceStart,BusinessLicenceEnd,BusinessSphere,OrganizationCode,OrganizationCodePhoto,GeneralTaxpayerPhot,BankAccountName,BankAccountNumber,BankName,BankCode,BankRegionId,BankPhoto,TaxRegistrationCertificate,TaxpayerId,TaxRegistrationCertificatePhoto,PayPhoto,PayRemark,SenderName,SenderAddress,SenderPhone,Freight,FreeFreight,Stage,SenderRegionId,BusinessLicenseCert,ProductCert,OtherCert,legalPerson,CompanyFoundingDate,BusinessType,IDCard,IDCardUrl,IDCardUrl2,WeiXinNickName,WeiXinSex,WeiXinAddress,WeiXinTrueName,WeiXinOpenId,WeiXinImg,AutoAllotOrder,ProvideInvoice from himall_shops ");
            strSql.Append(" where Id ="+Id);
         
            HPYL.Model.Shops model = new HPYL.Model.Shops();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Shops DataRowToModel(DataRow row)
        {
            HPYL.Model.Shops model = new HPYL.Model.Shops();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["GradeId"] != null && row["GradeId"].ToString() != "")
                {
                    model.GradeId = long.Parse(row["GradeId"].ToString());
                }
                if (row["ShopName"] != null)
                {
                    model.ShopName = row["ShopName"].ToString();
                }
                if (row["Logo"] != null)
                {
                    model.Logo = row["Logo"].ToString();
                }
                if (row["SubDomains"] != null)
                {
                    model.SubDomains = row["SubDomains"].ToString();
                }
                if (row["Theme"] != null)
                {
                    model.Theme = row["Theme"].ToString();
                }
                if (row["IsSelf"] != null && row["IsSelf"].ToString() != "")
                {
                    try
                    {
                    model.IsSelf = int.Parse(row["IsSelf"].ToString());
                    }
                    catch (Exception)
                    {
                    }
                }
                if (row["ShopStatus"] != null && row["ShopStatus"].ToString() != "")
                {
                    model.ShopStatus = int.Parse(row["ShopStatus"].ToString());
                }
                if (row["RefuseReason"] != null)
                {
                    model.RefuseReason = row["RefuseReason"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["CompanyName"] != null)
                {
                    model.CompanyName = row["CompanyName"].ToString();
                }
                if (row["CompanyRegionId"] != null && row["CompanyRegionId"].ToString() != "")
                {
                    model.CompanyRegionId = int.Parse(row["CompanyRegionId"].ToString());
                }
                   if (row["CompanyAddress"] != null)
                 {
                    model.CompanyAddress = row["CompanyAddress"].ToString();
                }
                if (row["CompanyPhone"] != null)
                {
                    model.CompanyPhone = row["CompanyPhone"].ToString();
                }
                if (row["CompanyEmployeeCount"] != null && row["CompanyEmployeeCount"].ToString() != "")
                {
                    model.CompanyEmployeeCount = int.Parse(row["CompanyEmployeeCount"].ToString());
                }
                if (row["CompanyRegisteredCapital"] != null && row["CompanyRegisteredCapital"].ToString() != "")
                {
                    model.CompanyRegisteredCapital = decimal.Parse(row["CompanyRegisteredCapital"].ToString());
                }
                if (row["ContactsName"] != null)
                {
                    model.ContactsName = row["ContactsName"].ToString();
                }
                if (row["ContactsPhone"] != null)
                {
                    model.ContactsPhone = row["ContactsPhone"].ToString();
                }
                if (row["ContactsEmail"] != null)
                {
                    model.ContactsEmail = row["ContactsEmail"].ToString();
                }
                if (row["BusinessLicenceNumber"] != null)
                {
                    model.BusinessLicenceNumber = row["BusinessLicenceNumber"].ToString();
                }
                if (row["BusinessLicenceNumberPhoto"] != null)
                {
                    model.BusinessLicenceNumberPhoto = row["BusinessLicenceNumberPhoto"].ToString();
                }
                if (row["BusinessLicenceRegionId"] != null && row["BusinessLicenceRegionId"].ToString() != "")
                {
                    model.BusinessLicenceRegionId = int.Parse(row["BusinessLicenceRegionId"].ToString());
                }
                if (row["BusinessLicenceStart"] != null && row["BusinessLicenceStart"].ToString() != "")
                {
                    model.BusinessLicenceStart = DateTime.Parse(row["BusinessLicenceStart"].ToString());
                }
                if (row["BusinessLicenceEnd"] != null && row["BusinessLicenceEnd"].ToString() != "")
                {
                    model.BusinessLicenceEnd = DateTime.Parse(row["BusinessLicenceEnd"].ToString());
                }
                if (row["BusinessSphere"] != null)
                {
                    model.BusinessSphere = row["BusinessSphere"].ToString();
                }
                if (row["OrganizationCode"] != null)
                {
                    model.OrganizationCode = row["OrganizationCode"].ToString();
                }
                if (row["OrganizationCodePhoto"] != null)
                {
                    model.OrganizationCodePhoto = row["OrganizationCodePhoto"].ToString();
                }
                if (row["GeneralTaxpayerPhot"] != null)
                {
                    model.GeneralTaxpayerPhot = row["GeneralTaxpayerPhot"].ToString();
                }
                if (row["BankAccountName"] != null)
                {
                    model.BankAccountName = row["BankAccountName"].ToString();
                }
                if (row["BankAccountNumber"] != null)
                {
                    model.BankAccountNumber = row["BankAccountNumber"].ToString();
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["BankCode"] != null)
                {
                    model.BankCode = row["BankCode"].ToString();
                }
                if (row["BankRegionId"] != null && row["BankRegionId"].ToString() != "")
                {
                    model.BankRegionId = int.Parse(row["BankRegionId"].ToString());
                }
                if (row["BankPhoto"] != null)
                {
                    model.BankPhoto = row["BankPhoto"].ToString();
                }
                if (row["TaxRegistrationCertificate"] != null)
                {
                    model.TaxRegistrationCertificate = row["TaxRegistrationCertificate"].ToString();
                }
                if (row["TaxpayerId"] != null)
                {
                    model.TaxpayerId = row["TaxpayerId"].ToString();
                }
                if (row["TaxRegistrationCertificatePhoto"] != null)
                {
                    model.TaxRegistrationCertificatePhoto = row["TaxRegistrationCertificatePhoto"].ToString();
                }
                if (row["PayPhoto"] != null)
                {
                    model.PayPhoto = row["PayPhoto"].ToString();
                }
                if (row["PayRemark"] != null)
                {
                    model.PayRemark = row["PayRemark"].ToString();
                }
                if (row["SenderName"] != null)
                {
                    model.SenderName = row["SenderName"].ToString();
                }
                if (row["SenderAddress"] != null)
                {
                    model.SenderAddress = row["SenderAddress"].ToString();
                }
                if (row["SenderPhone"] != null)
                {
                    model.SenderPhone = row["SenderPhone"].ToString();
                }
                if (row["Freight"] != null && row["Freight"].ToString() != "")
                {
                    model.Freight = decimal.Parse(row["Freight"].ToString());
                }
                if (row["FreeFreight"] != null && row["FreeFreight"].ToString() != "")
                {
                    model.FreeFreight = decimal.Parse(row["FreeFreight"].ToString());
                }
                if (row["Stage"] != null && row["Stage"].ToString() != "")
                {
                    model.Stage = int.Parse(row["Stage"].ToString());
                }
                if (row["SenderRegionId"] != null && row["SenderRegionId"].ToString() != "")
                {
                    model.SenderRegionId = int.Parse(row["SenderRegionId"].ToString());
                }
                if (row["BusinessLicenseCert"] != null)
                {
                    model.BusinessLicenseCert = row["BusinessLicenseCert"].ToString();
                }
                if (row["ProductCert"] != null)
                {
                    model.ProductCert = row["ProductCert"].ToString();
                }
                if (row["OtherCert"] != null)
                {
                    model.OtherCert = row["OtherCert"].ToString();
                }
                if (row["legalPerson"] != null)
                {
                    model.legalPerson = row["legalPerson"].ToString();
                }
                if (row["CompanyFoundingDate"] != null && row["CompanyFoundingDate"].ToString() != "")
                {
                    model.CompanyFoundingDate = DateTime.Parse(row["CompanyFoundingDate"].ToString());
                }
                if (row["BusinessType"] != null && row["BusinessType"].ToString() != "")
                {
                    model.BusinessType = int.Parse(row["BusinessType"].ToString());
                }
                if (row["IDCard"] != null)
                {
                    model.IDCard = row["IDCard"].ToString();
                }
                if (row["IDCardUrl"] != null)
                {
                    model.IDCardUrl = row["IDCardUrl"].ToString();
                }
                if (row["IDCardUrl2"] != null)
                {
                    model.IDCardUrl2 = row["IDCardUrl2"].ToString();
                }
                if (row["WeiXinNickName"] != null)
                {
                    model.WeiXinNickName = row["WeiXinNickName"].ToString();
                }
                if (row["WeiXinSex"] != null && row["WeiXinSex"].ToString() != "")
                {
                    model.WeiXinSex = int.Parse(row["WeiXinSex"].ToString());
                }
                if (row["WeiXinAddress"] != null)
                {
                    model.WeiXinAddress = row["WeiXinAddress"].ToString();
                }
                if (row["WeiXinTrueName"] != null)
                {
                    model.WeiXinTrueName = row["WeiXinTrueName"].ToString();
                }
                if (row["WeiXinOpenId"] != null)
                {
                    model.WeiXinOpenId = row["WeiXinOpenId"].ToString();
                }
                if (row["WeiXinImg"] != null)
                {
                    model.WeiXinImg = row["WeiXinImg"].ToString();
                }
                if (row["AutoAllotOrder"] != null && row["AutoAllotOrder"].ToString() != "")
                {
                    model.AutoAllotOrder = int.Parse(row["AutoAllotOrder"].ToString());
                }
                if (row["ProvideInvoice"] != null && row["ProvideInvoice"].ToString() != "")
                {
                    model.ProvideInvoice = int.Parse(row["ProvideInvoice"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,GradeId,ShopName,Logo,SubDomains,Theme,IsSelf,ShopStatus,RefuseReason,CreateDate,EndDate,CompanyName,CompanyRegionId,CompanyAddress,CompanyPhone,CompanyEmployeeCount,CompanyRegisteredCapital,ContactsName,ContactsPhone,ContactsEmail,BusinessLicenceNumber,BusinessLicenceNumberPhoto,BusinessLicenceRegionId,BusinessLicenceStart,BusinessLicenceEnd,BusinessSphere,OrganizationCode,OrganizationCodePhoto,GeneralTaxpayerPhot,BankAccountName,BankAccountNumber,BankName,BankCode,BankRegionId,BankPhoto,TaxRegistrationCertificate,TaxpayerId,TaxRegistrationCertificatePhoto,PayPhoto,PayRemark,SenderName,SenderAddress,SenderPhone,Freight,FreeFreight,Stage,SenderRegionId,BusinessLicenseCert,ProductCert,OtherCert,legalPerson,CompanyFoundingDate,BusinessType,IDCard,IDCardUrl,IDCardUrl2,WeiXinNickName,WeiXinSex,WeiXinAddress,WeiXinTrueName,WeiXinOpenId,WeiXinImg,AutoAllotOrder,ProvideInvoice ");
            strSql.Append(" FROM himall_shops ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM himall_shops ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from himall_shops T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "himall_shops";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
