#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.DAL.Calendar
* 项目描述 ：
* 类 名 称 ：OrderService
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.DAL.Calendar
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/17 14:39:26
* 更新时间 ：2018/8/17 14:39:26
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using HPYL.Model;
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
   public class OrderService
    {

        private static object obj = new object();
        /// <summary>
        ///  生成订单号
        /// </summary>
        public long GenerateOrderNumber()
        {
            lock (obj)
            {
                int rand;
                char code;
                string orderId = string.Empty;
                Random random = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
                for (int i = 0; i < 5; i++)
                {
                    rand = random.Next();
                    code = (char)('0' + (char)(rand % 10));
                    orderId += code.ToString();
                }
                return long.Parse(DateTime.Now.ToString("yyyyMMddfff") + orderId);
            }
        }

        #region 创建订单相关  done
        /// <summary>
        /// 添加预约单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InOrder(OrderModel info)
        {
            //暂时不开启发票保存
            //Himall_InvoiceTitle.Add("biaoti", "用户ID");
            //获取店铺信息
            string sql = "select ShopName,CompanyPhone from Himall_Shops where Id=" + info.ClientId + "";
            var shop = DbHelperMySQL.Query(sql).Tables[0];
            var shopname = "";
            var CompanyPhone = "";//公司电话
            if (shop.Rows.Count != 0)
            {
                shopname = shop.Rows[0][0].ToString();
                CompanyPhone = shop.Rows[0][1].ToString();
            }
            //获取用户信息
            var UserName = "";
            var ShipTo = "";
            var CellPhone = "";
            string sqlunion = "select UserName,Nick,CellPhone,RealName  from himall_members  where Id=" + info.PatientId + "";

            DataTable dtu = DbHelperMySQL.Query(sqlunion).Tables[0];
            foreach (DataRow item in dtu.Rows)
            {
                UserName = item["UserName"].ToString();
                ShipTo = item["RealName"].ToString(); ;
                CellPhone = item["CellPhone"].ToString(); ;
            }


            //订单号
            var Orderno =GenerateOrderNumber();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into himall_orders(");
            strSql.Append("Id,OrderStatus,OrderDate,CloseReason,ShopId,ShopName,SellerPhone,SellerAddress,SellerRemark,SellerRemarkFlag,UserId,UserName,UserRemark,ShipTo,CellPhone,TopRegionId,RegionId,RegionFullName,Address,ReceiveLongitude,ReceiveLatitude,ExpressCompanyName,Freight,ShipOrderNumber,ShippingDate,IsPrinted,PaymentTypeName,PaymentTypeGateway,PaymentType,GatewayOrderId,PayRemark,PayDate,InvoiceType,InvoiceTitle,InvoiceCode,Tax,FinishDate,ProductTotalAmount,RefundTotalAmount,CommisTotalAmount,RefundCommisAmount,ActiveType,Platform,DiscountAmount,IntegralDiscount,InvoiceContext,OrderType,ShareUserId,OrderRemarks,LastModifyTime,DeliveryType,ShopBranchId,PickupCode,TotalAmount,ActualPayAmount,FullDiscount,CapitalAmount,RemindType,ReceiveDate,ReceiveStartTime,ReceiveEndTime)");
            strSql.Append(" values (");
            strSql.Append("@Id,@OrderStatus,@OrderDate,@CloseReason,@ShopId,@ShopName,@SellerPhone,@SellerAddress,@SellerRemark,@SellerRemarkFlag,@UserId,@UserName,@UserRemark,@ShipTo,@CellPhone,@TopRegionId,@RegionId,@RegionFullName,@Address,@ReceiveLongitude,@ReceiveLatitude,@ExpressCompanyName,@Freight,@ShipOrderNumber,@ShippingDate,@IsPrinted,@PaymentTypeName,@PaymentTypeGateway,@PaymentType,@GatewayOrderId,@PayRemark,@PayDate,@InvoiceType,@InvoiceTitle,@InvoiceCode,@Tax,@FinishDate,@ProductTotalAmount,@RefundTotalAmount,@CommisTotalAmount,@RefundCommisAmount,@ActiveType,@Platform,@DiscountAmount,@IntegralDiscount,@InvoiceContext,@OrderType,@ShareUserId,@OrderRemarks,@LastModifyTime,@DeliveryType,@ShopBranchId,@PickupCode,@TotalAmount,@ActualPayAmount,@FullDiscount,@CapitalAmount,@RemindType,@ReceiveDate,@ReceiveStartTime,@ReceiveEndTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id",Orderno),
                    new MySqlParameter("@OrderStatus", "1"),
                    new MySqlParameter("@OrderDate", DateTime.Now),
                    new MySqlParameter("@CloseReason", ""),
                    new MySqlParameter("@ShopId", info.ClientId),
                    new MySqlParameter("@ShopName",shopname),
                    new MySqlParameter("@SellerPhone",CompanyPhone),
                    new MySqlParameter("@SellerAddress",info.Address),
                    new MySqlParameter("@SellerRemark",info.Content),
                    new MySqlParameter("@SellerRemarkFlag", "0"),
                    new MySqlParameter("@UserId",info.PatientId),
                    new MySqlParameter("@UserName",UserName),
                    new MySqlParameter("@UserRemark", info.Content),
                    new MySqlParameter("@ShipTo",ShipTo),
                    new MySqlParameter("@CellPhone",CellPhone),
                    new MySqlParameter("@TopRegionId",  "1"),
                    new MySqlParameter("@RegionId","3653"),
                    new MySqlParameter("@RegionFullName", ""),
                    new MySqlParameter("@Address", ""),
                    new MySqlParameter("@ReceiveLongitude", "0"),
                    new MySqlParameter("@ReceiveLatitude",  "0"),
                    new MySqlParameter("@ExpressCompanyName", shopname),
                    new MySqlParameter("@Freight", "0"),
                    new MySqlParameter("@ShipOrderNumber", "1111"),
                    new MySqlParameter("@ShippingDate",DateTime.Now),
                    new MySqlParameter("@IsPrinted",1),
                    new MySqlParameter("@PaymentTypeName", ""),
                    new MySqlParameter("@PaymentTypeGateway",""),
                    new MySqlParameter("@PaymentType",  "0"),
                    new MySqlParameter("@GatewayOrderId", ""),
                    new MySqlParameter("@PayRemark", ""),
                    new MySqlParameter("@PayDate", DateTime.Now),
                    new MySqlParameter("@InvoiceType", "0"),
                    new MySqlParameter("@InvoiceTitle", ""),
                    new MySqlParameter("@InvoiceCode", ""),
                    new MySqlParameter("@Tax",  "0"),
                    new MySqlParameter("@FinishDate", DateTime.Now),
                    new MySqlParameter("@ProductTotalAmount", "0"),
                    new MySqlParameter("@RefundTotalAmount", "0"),
                    new MySqlParameter("@CommisTotalAmount",  "0"),
                    new MySqlParameter("@RefundCommisAmount",  "0"),
                    new MySqlParameter("@ActiveType",  "0"),
                    new MySqlParameter("@Platform",  "0"),
                    new MySqlParameter("@DiscountAmount",  "0"),
                    new MySqlParameter("@IntegralDiscount", "0"),
                    new MySqlParameter("@InvoiceContext", ""),
                    new MySqlParameter("@OrderType", "0"),
                    new MySqlParameter("@ShareUserId", info.DoctorId),
                    new MySqlParameter("@OrderRemarks",info.Content),
                    new MySqlParameter("@LastModifyTime",DateTime.Now),
                    new MySqlParameter("@DeliveryType", "0"),
                    new MySqlParameter("@ShopBranchId", info.AddressId),
                    new MySqlParameter("@PickupCode", "YS"),
                    new MySqlParameter("@TotalAmount",  "0"),
                    new MySqlParameter("@ActualPayAmount",  "0"),
                    new MySqlParameter("@FullDiscount",  "0"),
                    new MySqlParameter("@CapitalAmount",  "0"),
                    new MySqlParameter("@RemindType", info.Remind),
                    new MySqlParameter("@ReceiveDate", info.Date),
                    new MySqlParameter("@ReceiveStartTime",info.StartTime),
                    new MySqlParameter("@ReceiveEndTime",info.EndTime)};

            if (DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0)
            {
                decimal OrderTotal = 0;//订单总额
                string sqlp = "select Id,ProductName Name,MinSalePrice Price from Himall_Products  where Id in(" + info.ProjectIdList.Replace("，", ",").TrimEnd(',') + ") ";
                var ProductList = new Repository<ProductItem>().FindList(sqlp).ToList();
                if (ProductList.Count() > 0)
                {
                    foreach (ProductItem item in ProductList)
                    {
                        OrderProduct pmode = new OrderProduct();
                        pmode.OrderId = Orderno;
                        pmode.ShopId = info.ClientId;
                        pmode.ProductId = item.Id;
                        pmode.ProductName = item.Name;
                        pmode.SalePrice = item.Price;
                        pmode.SkuId = "" + item.Id + "_0_0_0";
                        pmode.RealTotalPrice = pmode.SalePrice * 1;
                        OrderTotal += pmode.RealTotalPrice;
                        AddProduct(pmode);
                    }
                }
                UPorderPrice(Orderno, OrderTotal, info.DoctorId, info.ClientId);
                return true;
            }
            else {
                return false;
            }
            
            
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="UserId">当前医生ID</param>
        /// <param name="OrderId">订单id</param>
        /// <returns></returns>
        public OrderInfo GetOrder(long UserId,long OrderId)
        {

            
            string sqluser ="SELECT a.Id OrderId, a.ShopId ClientId, a.ShareUserId DoctorId, c.RealName DoctorName, a.UserId PatientId, b.RealName PatientName," +
                " date_format(Receivedate, '%Y-%m-%d') Date,date_format(a.ReceiveStartTime, '%H:%i') StartTime," +
                "date_format(a.ReceiveEndTime, '%H:%i')EndTime," +
                "a.SellerAddress address," +
                "ShopBranchId AddressId," +
                "  RemindType Remind," +
                " UserRemark Content, " +
                "TIMESTAMPDIFF(MINUTE, now(), CONCAT(date_format(Receivedate, '%Y-%m-%d'), ' ', date_format(a.ReceiveStartTime, '%H:%i'))) IsCannel" +
                " FROM himall_orders a left JOIN Himall_Members b ON a.UserId = b.Id " +
                " left JOIN Himall_Members c ON a.ShareUserId = c.Id " +
                " WHERE a.ShareUserId = "+UserId+" AND a.id = "+OrderId+"";
            OrderInfo model = new OrderInfo();
            DataTable dt = DbHelperMySQL.Query(sqluser).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
               


                model.Address = item["address"].ToString();
                model.AddressId =long.Parse(item["AddressId"].ToString());
                model.ClientId = long.Parse(item["ClientId"].ToString());
                model.Content = item["Content"].ToString();
                model.Date = item["Date"].ToString();
                model.DoctorId= long.Parse(item["DoctorId"].ToString());
                model.DoctorName = item["DoctorName"].ToString();
                model.PatientId = long.Parse(item["PatientId"].ToString());
                model.PatientName = item["PatientName"].ToString();
                model.OrderId= long.Parse(item["OrderId"].ToString());
                model.Remind = int.Parse(item["Remind"].ToString());
                model.StartTime = item["StartTime"].ToString();
                model.EndTime = item["EndTime"].ToString();
                model.IsCannel=(int.Parse(item["IsCannel"].ToString())>=30?0:-1);

                string sqlproject = "select a.Id,CONCAT(IFNULL(d.NAME, ''), '[', a.ProductName, ']')Name from himall_orderitems a " +
                    " INNER JOIN himall_orders b ON a.OrderId=b.Id " +
                    " left JOIN Himall_Products c ON c.Id=a.ProductId " +
                    " LEFT JOIN  himall_shopcategories d on c.CategoryId=d.Id  " +
                    " where  a.OrderId =" + model.OrderId + "";
                model.project = new Repository<Project>().FindList(sqlproject).ToList();
                
            }
           
            return model;
        }

        /// <summary>
        /// 取消预约单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrder(InfoToUser info)
        {
            string sqls = "update himall_orders set OrderStatus=4 where ShareUserId=" + info.UserID + " and  Id=" + info.KeyId + "";
            if (DbHelperMySQL.ExecuteSql(sqls) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新订单金额
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="Price"></param>
        /// <param name="userId"></param>
        /// <param name="ClientId"></param>
        /// <param name="ybl">佣金比例</param>
        /// <returns></returns>
        public bool UPorderPrice(long OrderId, decimal Price, long userId, long ClientId)
        {
            decimal ybl = commisFloat(userId, ClientId);
            string sqls = "update himall_orders set ProductTotalAmount=" + Price + ",CommisTotalAmount=" + (Price * ybl) + " where ShareUserId=" + userId + " and SHopId=" + ClientId + " and Id=" + OrderId + "";
            if (DbHelperMySQL.ExecuteSql(sqls) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 订单商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddProduct(OrderProduct model)
        {
            model.Create();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into himall_orderitems(");
            strSql.Append("OrderId,ShopId,ProductId,SkuId,SKU,Quantity,ReturnQuantity,CostPrice,SalePrice,DiscountAmount,RealTotalPrice,RefundPrice,ProductName,Color,Size,Version,ThumbnailsUrl,CommisRate,EnabledRefundAmount,IsLimitBuy,DistributionRate,EnabledRefundIntegral,CouponDiscount,FullDiscount)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@ShopId,@ProductId,@SkuId,@SKU,@Quantity,@ReturnQuantity,@CostPrice,@SalePrice,@DiscountAmount,@RealTotalPrice,@RefundPrice,@ProductName,@Color,@Size,@Version,@ThumbnailsUrl,@CommisRate,@EnabledRefundAmount,@IsLimitBuy,@DistributionRate,@EnabledRefundIntegral,@CouponDiscount,@FullDiscount)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@OrderId", model.OrderId),
                    new MySqlParameter("@ShopId", model.ShopId),
                    new MySqlParameter("@ProductId",model.ProductId),
                    new MySqlParameter("@SkuId",model.SkuId),
                    new MySqlParameter("@SKU", model.SKU),
                    new MySqlParameter("@Quantity",model.Quantity),
                    new MySqlParameter("@ReturnQuantity", model.ReturnQuantity),
                    new MySqlParameter("@CostPrice", model.CostPrice),
                    new MySqlParameter("@SalePrice",model.SalePrice),
                    new MySqlParameter("@DiscountAmount", model.DiscountAmount),
                    new MySqlParameter("@RealTotalPrice", model.RealTotalPrice),
                    new MySqlParameter("@RefundPrice",model.RefundPrice),
                    new MySqlParameter("@ProductName",model.ProductName),
                    new MySqlParameter("@Color",model.Color),
                    new MySqlParameter("@Size", model.Size),
                    new MySqlParameter("@Version",model.Version),
                    new MySqlParameter("@ThumbnailsUrl",model.ThumbnailsUrl),
                    new MySqlParameter("@CommisRate",model.CommisRate),
                    new MySqlParameter("@EnabledRefundAmount",model.EnabledRefundAmount),
                    new MySqlParameter("@IsLimitBuy",model.IsLimitBuy),
                    new MySqlParameter("@DistributionRate",model.DistributionRate),
                    new MySqlParameter("@EnabledRefundIntegral", model.EnabledRefundIntegral),
                    new MySqlParameter("@CouponDiscount", model.CouponDiscount),
                    new MySqlParameter("@FullDiscount", model.FullDiscount)};


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

        #endregion 创建订单相关  done


        /// <summary>
        /// 获取佣金比例
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public decimal commisFloat(long userid,long shopId)
        {
            decimal res = 0;
            string sql = "select Commis from hpyl_usercommis where UserId=" + userid + " and ShopId="+shopId+"";
            DataTable dt = DbHelperMySQL.Query(sql).Tables[0];
            if (dt.Rows.Count != 0)
            {

                res = decimal.Parse(dt.Rows[0][0].ToString());
            }
            return res;
        }
    }
}
