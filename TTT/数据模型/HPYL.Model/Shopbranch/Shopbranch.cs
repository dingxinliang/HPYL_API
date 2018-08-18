using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// Shopbranch门店表
    /// </summary>
   public  class Shopbranch
    {
        #region Model
        private long id;
        private long shopid;
        private string shopbranchname;
        private int addressid;
        private string addresspath;
        private string addressdetail;
        private string contactuser;
        private string contactphone;
        private int status;
        private DateTime createdate;
        private int serveradius;
        private decimal longitude;
        private decimal latitude;
        private string shopimages;
        private bool isstoredelive = false;
        private bool isaboveself = false;
        private DateTime storeopenstarttime = Convert.ToDateTime("08:00:00");
        private DateTime storeopenendtime = Convert.ToDateTime("20:00:00");
        private bool isrecommend = false;
        private long recommendsequence = 0;
        private int delivefee = 0;
        private int delivetotalfee = 0;
        private int freemailfee = 0;
        /// <summary>
        /// auto_increment
        /// </summary>
        public long Id
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ShopId
        {
            set { shopid = value; }
            get { return shopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShopBranchName
        {
            set { shopbranchname = value; }
            get { return shopbranchname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AddressId
        {
            set { addressid = value; }
            get { return addressid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddressPath
        {
            set { addresspath = value; }
            get { return addresspath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddressDetail
        {
            set { addressdetail = value; }
            get { return addressdetail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactUser
        {
            set { contactuser = value; }
            get { return contactuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactPhone
        {
            set { contactphone = value; }
            get { return contactphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { status = value; }
            get { return status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { createdate = value; }
            get { return createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ServeRadius
        {
            set { serveradius = value; }
            get { return serveradius; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Longitude
        {
            set { longitude = value; }
            get { return longitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Latitude
        {
            set { latitude = value; }
            get { return latitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShopImages
        {
            set { shopimages = value; }
            get { return shopimages; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsStoreDelive
        {
            set { isstoredelive = value; }
            get { return isstoredelive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAboveSelf
        {
            set { isaboveself = value; }
            get { return isaboveself; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StoreOpenStartTime
        {
            set { storeopenstarttime = value; }
            get { return storeopenstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StoreOpenEndTime
        {
            set { storeopenendtime = value; }
            get { return storeopenendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRecommend
        {
            set { isrecommend = value; }
            get { return isrecommend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long RecommendSequence
        {
            set { recommendsequence = value; }
            get { return recommendsequence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeliveFee
        {
            set { delivefee = value; }
            get { return delivefee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeliveTotalFee
        {
            set { delivetotalfee = value; }
            get { return delivetotalfee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FreeMailFee
        {
            set { freemailfee = value; }
            get { return freemailfee; }
        }
        #endregion Model
    }
}
