using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    public class OrdersList
    {
        #region Model
        private long _id;
        private int _orderstatus;
        private string _orderdate;
        private string _closereason;
        private long _shopid;
        private string _shopname;
        private string _sellerphone;
        private string _selleraddress;
        private string _sellerremark;
        private int? _sellerremarkflag;
        private long _userid;
        private string _username;
        private string _userremark;
        private string _shipto;
        private string _cellphone;
        private int _topregionid;
        private int _regionid;
        private string _regionfullname;
        private string _address;
        private decimal _receivelongitude = 0M;
        private decimal _receivelatitude = 0M;
        private string _expresscompanyname;
        private decimal _freight;
        private string _shipordernumber;
        private DateTime? _shippingdate;
        private int _isprinted;
        private string _paymenttypename;
        private string _paymenttypegateway;
        private int _paymenttype;
        private string _gatewayorderid;
        private string _payremark;
        private DateTime? _paydate;
        private int _invoicetype;
        private string _invoicetitle;
        private string _invoicecode;
        private decimal _tax;
        private DateTime? _finishdate;
        private decimal _producttotalamount;
        private decimal _refundtotalamount;
        private decimal _commistotalamount;
        private decimal _refundcommisamount;
        private int _activetype = 0;
        private int _platform = 0;
        private decimal _discountamount = 0.00M;
        private decimal _integraldiscount;
        private string _invoicecontext;
        private int? _ordertype;
        private long? _shareuserid;
        private string _orderremarks;
        private DateTime? _lastmodifytime;
        private int _deliverytype;
        private long? _shopbranchid;
        private string _pickupcode;
        private decimal _totalamount = 0.00M;
        private decimal _actualpayamount = 0.00M;
        private decimal _fulldiscount = 0.00M;
        private decimal _capitalamount = 0.00M;
        private int? _remindtype;
        private string _receivedate;
        private string _receivestarttime;
        private string _receiveendtime;
        /// <summary>
        /// 
        /// </summary>
        public long Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CloseReason
        {
            set { _closereason = value; }
            get { return _closereason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ShopId
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShopName
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SellerPhone
        {
            set { _sellerphone = value; }
            get { return _sellerphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SellerAddress
        {
            set { _selleraddress = value; }
            get { return _selleraddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SellerRemark
        {
            set { _sellerremark = value; }
            get { return _sellerremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SellerRemarkFlag
        {
            set { _sellerremarkflag = value; }
            get { return _sellerremarkflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserRemark
        {
            set { _userremark = value; }
            get { return _userremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShipTo
        {
            set { _shipto = value; }
            get { return _shipto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CellPhone
        {
            set { _cellphone = value; }
            get { return _cellphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TopRegionId
        {
            set { _topregionid = value; }
            get { return _topregionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RegionId
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegionFullName
        {
            set { _regionfullname = value; }
            get { return _regionfullname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ReceiveLongitude
        {
            set { _receivelongitude = value; }
            get { return _receivelongitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ReceiveLatitude
        {
            set { _receivelatitude = value; }
            get { return _receivelatitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressCompanyName
        {
            set { _expresscompanyname = value; }
            get { return _expresscompanyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Freight
        {
            set { _freight = value; }
            get { return _freight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShipOrderNumber
        {
            set { _shipordernumber = value; }
            get { return _shipordernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ShippingDate
        {
            set { _shippingdate = value; }
            get { return _shippingdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsPrinted
        {
            set { _isprinted = value; }
            get { return _isprinted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentTypeName
        {
            set { _paymenttypename = value; }
            get { return _paymenttypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentTypeGateway
        {
            set { _paymenttypegateway = value; }
            get { return _paymenttypegateway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PaymentType
        {
            set { _paymenttype = value; }
            get { return _paymenttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GatewayOrderId
        {
            set { _gatewayorderid = value; }
            get { return _gatewayorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayRemark
        {
            set { _payremark = value; }
            get { return _payremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PayDate
        {
            set { _paydate = value; }
            get { return _paydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InvoiceType
        {
            set { _invoicetype = value; }
            get { return _invoicetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceTitle
        {
            set { _invoicetitle = value; }
            get { return _invoicetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceCode
        {
            set { _invoicecode = value; }
            get { return _invoicecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Tax
        {
            set { _tax = value; }
            get { return _tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FinishDate
        {
            set { _finishdate = value; }
            get { return _finishdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ProductTotalAmount
        {
            set { _producttotalamount = value; }
            get { return _producttotalamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RefundTotalAmount
        {
            set { _refundtotalamount = value; }
            get { return _refundtotalamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CommisTotalAmount
        {
            set { _commistotalamount = value; }
            get { return _commistotalamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RefundCommisAmount
        {
            set { _refundcommisamount = value; }
            get { return _refundcommisamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ActiveType
        {
            set { _activetype = value; }
            get { return _activetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Platform
        {
            set { _platform = value; }
            get { return _platform; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountAmount
        {
            set { _discountamount = value; }
            get { return _discountamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal IntegralDiscount
        {
            set { _integraldiscount = value; }
            get { return _integraldiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceContext
        {
            set { _invoicecontext = value; }
            get { return _invoicecontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ShareUserId
        {
            set { _shareuserid = value; }
            get { return _shareuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderRemarks
        {
            set { _orderremarks = value; }
            get { return _orderremarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModifyTime
        {
            set { _lastmodifytime = value; }
            get { return _lastmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeliveryType
        {
            set { _deliverytype = value; }
            get { return _deliverytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ShopBranchId
        {
            set { _shopbranchid = value; }
            get { return _shopbranchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PickupCode
        {
            set { _pickupcode = value; }
            get { return _pickupcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalAmount
        {
            set { _totalamount = value; }
            get { return _totalamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ActualPayAmount
        {
            set { _actualpayamount = value; }
            get { return _actualpayamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FullDiscount
        {
            set { _fulldiscount = value; }
            get { return _fulldiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalAmount
        {
            set { _capitalamount = value; }
            get { return _capitalamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RemindType
        {
            set { _remindtype = value; }
            get { return _remindtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveDate
        {
            set { _receivedate = value; }
            get { return _receivedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveStartTime
        {
            set { _receivestarttime = value; }
            get { return _receivestarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveEndTime
        {
            set { _receiveendtime = value; }
            get { return _receiveendtime; }
        }
        /// <summary>
        /// 订单详情
        /// </summary>
        public List<HPYL.Model.orderitems> orderitems { get; set; }
        #endregion Model
    }
}
