/**  版本信息模板在安装目录下，可自行修改。
* orders.cs
*
* 功 能： N/A
* 类 名： orders
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/4 10:38:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
using XL.Util.WebControl;

namespace HPYL.DAL
{
	/// <summary>
	/// 数据访问类:orders
	/// </summary>
	public partial class orders
	{
		public orders()
		{}
		#region  BasicMethod

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from himall_orders ");
			strSql.Append(" where Id=@Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int64,20)			};
			parameters[0].Value = Id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from himall_orders ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public HPYL.Model.orders GetModel(long Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,OrderStatus,OrderDate,CloseReason,ShopId,ShopName,SellerPhone,SellerAddress,SellerRemark,SellerRemarkFlag,UserId,UserName,UserRemark,ShipTo,CellPhone,TopRegionId,RegionId,RegionFullName,Address,ReceiveLongitude,ReceiveLatitude,ExpressCompanyName,Freight,ShipOrderNumber,ShippingDate,IsPrinted,PaymentTypeName,PaymentTypeGateway,PaymentType,GatewayOrderId,PayRemark,PayDate,InvoiceType,InvoiceTitle,InvoiceCode,Tax,FinishDate,ProductTotalAmount,RefundTotalAmount,CommisTotalAmount,RefundCommisAmount,ActiveType,Platform,DiscountAmount,IntegralDiscount,InvoiceContext,OrderType,ShareUserId,OrderRemarks,LastModifyTime,DeliveryType,ShopBranchId,PickupCode,TotalAmount,ActualPayAmount,FullDiscount,CapitalAmount,RemindType,ReceiveDate,ReceiveStartTime,ReceiveEndTime from himall_orders ");
			strSql.Append(" where Id=@Id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int64,20)			};
			parameters[0].Value = Id;

			HPYL.Model.orders model=new HPYL.Model.orders();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public HPYL.Model.orders DataRowToModel(DataRow row)
		{
			HPYL.Model.orders model=new HPYL.Model.orders();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=long.Parse(row["Id"].ToString());
				}
				if(row["OrderStatus"]!=null && row["OrderStatus"].ToString()!="")
				{
					model.OrderStatus=int.Parse(row["OrderStatus"].ToString());
				}
				if(row["OrderDate"]!=null && row["OrderDate"].ToString()!="")
				{
					model.OrderDate=DateTime.Parse(row["OrderDate"].ToString()).ToString("yyyy-MM-dd HH-mm");
				}
				if(row["CloseReason"]!=null)
				{
					model.CloseReason=row["CloseReason"].ToString();
				}
				if(row["ShopId"]!=null && row["ShopId"].ToString()!="")
				{
					model.ShopId=long.Parse(row["ShopId"].ToString());
				}
				if(row["ShopName"]!=null)
				{
					model.ShopName=row["ShopName"].ToString();
				}
				if(row["SellerPhone"]!=null)
				{
					model.SellerPhone=row["SellerPhone"].ToString();
				}
				if(row["SellerAddress"]!=null)
				{
					model.SellerAddress=row["SellerAddress"].ToString();
				}
				if(row["SellerRemark"]!=null)
				{
					model.SellerRemark=row["SellerRemark"].ToString();
				}
				if(row["SellerRemarkFlag"]!=null && row["SellerRemarkFlag"].ToString()!="")
				{
					model.SellerRemarkFlag=int.Parse(row["SellerRemarkFlag"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=long.Parse(row["UserId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserRemark"]!=null)
				{
					model.UserRemark=row["UserRemark"].ToString();
				}
				if(row["ShipTo"]!=null)
				{
					model.ShipTo=row["ShipTo"].ToString();
				}
				if(row["CellPhone"]!=null)
				{
					model.CellPhone=row["CellPhone"].ToString();
				}
				if(row["TopRegionId"]!=null && row["TopRegionId"].ToString()!="")
				{
					model.TopRegionId=int.Parse(row["TopRegionId"].ToString());
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["RegionFullName"]!=null)
				{
					model.RegionFullName=row["RegionFullName"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["ReceiveLongitude"]!=null && row["ReceiveLongitude"].ToString()!="")
				{
					model.ReceiveLongitude=decimal.Parse(row["ReceiveLongitude"].ToString());
				}
				if(row["ReceiveLatitude"]!=null && row["ReceiveLatitude"].ToString()!="")
				{
					model.ReceiveLatitude=decimal.Parse(row["ReceiveLatitude"].ToString());
				}
				if(row["ExpressCompanyName"]!=null)
				{
					model.ExpressCompanyName=row["ExpressCompanyName"].ToString();
				}
				if(row["Freight"]!=null && row["Freight"].ToString()!="")
				{
					model.Freight=decimal.Parse(row["Freight"].ToString());
				}
				if(row["ShipOrderNumber"]!=null)
				{
					model.ShipOrderNumber=row["ShipOrderNumber"].ToString();
				}
				if(row["ShippingDate"]!=null && row["ShippingDate"].ToString()!="")
				{
					model.ShippingDate=DateTime.Parse(row["ShippingDate"].ToString());
				}
				if(row["IsPrinted"]!=null && row["IsPrinted"].ToString()!="")
				{
					model.IsPrinted=int.Parse(row["IsPrinted"].ToString());
				}
				if(row["PaymentTypeName"]!=null)
				{
					model.PaymentTypeName=row["PaymentTypeName"].ToString();
				}
				if(row["PaymentTypeGateway"]!=null)
				{
					model.PaymentTypeGateway=row["PaymentTypeGateway"].ToString();
				}
				if(row["PaymentType"]!=null && row["PaymentType"].ToString()!="")
				{
					model.PaymentType=int.Parse(row["PaymentType"].ToString());
				}
				if(row["GatewayOrderId"]!=null)
				{
					model.GatewayOrderId=row["GatewayOrderId"].ToString();
				}
				if(row["PayRemark"]!=null)
				{
					model.PayRemark=row["PayRemark"].ToString();
				}
				if(row["PayDate"]!=null && row["PayDate"].ToString()!="")
				{
					model.PayDate=DateTime.Parse(row["PayDate"].ToString());
				}
				if(row["InvoiceType"]!=null && row["InvoiceType"].ToString()!="")
				{
					model.InvoiceType=int.Parse(row["InvoiceType"].ToString());
				}
				if(row["InvoiceTitle"]!=null)
				{
					model.InvoiceTitle=row["InvoiceTitle"].ToString();
				}
				if(row["InvoiceCode"]!=null)
				{
					model.InvoiceCode=row["InvoiceCode"].ToString();
				}
				if(row["Tax"]!=null && row["Tax"].ToString()!="")
				{
					model.Tax=decimal.Parse(row["Tax"].ToString());
				}
				if(row["FinishDate"]!=null && row["FinishDate"].ToString()!="")
				{
					model.FinishDate=DateTime.Parse(row["FinishDate"].ToString());
				}
				if(row["ProductTotalAmount"]!=null && row["ProductTotalAmount"].ToString()!="")
				{
					model.ProductTotalAmount=decimal.Parse(row["ProductTotalAmount"].ToString());
				}
				if(row["RefundTotalAmount"]!=null && row["RefundTotalAmount"].ToString()!="")
				{
					model.RefundTotalAmount=decimal.Parse(row["RefundTotalAmount"].ToString());
				}
				if(row["CommisTotalAmount"]!=null && row["CommisTotalAmount"].ToString()!="")
				{
					model.CommisTotalAmount=decimal.Parse(row["CommisTotalAmount"].ToString());
				}
				if(row["RefundCommisAmount"]!=null && row["RefundCommisAmount"].ToString()!="")
				{
					model.RefundCommisAmount=decimal.Parse(row["RefundCommisAmount"].ToString());
				}
				if(row["ActiveType"]!=null && row["ActiveType"].ToString()!="")
				{
					model.ActiveType=int.Parse(row["ActiveType"].ToString());
				}
				if(row["Platform"]!=null && row["Platform"].ToString()!="")
				{
					model.Platform=int.Parse(row["Platform"].ToString());
				}
				if(row["DiscountAmount"]!=null && row["DiscountAmount"].ToString()!="")
				{
					model.DiscountAmount=decimal.Parse(row["DiscountAmount"].ToString());
				}
				if(row["IntegralDiscount"]!=null && row["IntegralDiscount"].ToString()!="")
				{
					model.IntegralDiscount=decimal.Parse(row["IntegralDiscount"].ToString());
				}
				if(row["InvoiceContext"]!=null)
				{
					model.InvoiceContext=row["InvoiceContext"].ToString();
				}
				if(row["OrderType"]!=null && row["OrderType"].ToString()!="")
				{
					model.OrderType=int.Parse(row["OrderType"].ToString());
				}
				if(row["ShareUserId"]!=null && row["ShareUserId"].ToString()!="")
				{
					model.ShareUserId=long.Parse(row["ShareUserId"].ToString());
				}
				if(row["OrderRemarks"]!=null)
				{
					model.OrderRemarks=row["OrderRemarks"].ToString();
				}
				if(row["LastModifyTime"]!=null && row["LastModifyTime"].ToString()!="")
				{
					model.LastModifyTime=DateTime.Parse(row["LastModifyTime"].ToString());
				}
				if(row["DeliveryType"]!=null && row["DeliveryType"].ToString()!="")
				{
					model.DeliveryType=int.Parse(row["DeliveryType"].ToString());
				}
				if(row["ShopBranchId"]!=null && row["ShopBranchId"].ToString()!="")
				{
					model.ShopBranchId=long.Parse(row["ShopBranchId"].ToString());
				}
				if(row["PickupCode"]!=null)
				{
					model.PickupCode=row["PickupCode"].ToString();
				}
				if(row["TotalAmount"]!=null && row["TotalAmount"].ToString()!="")
				{
					model.TotalAmount=decimal.Parse(row["TotalAmount"].ToString());
				}
				if(row["ActualPayAmount"]!=null && row["ActualPayAmount"].ToString()!="")
				{
					model.ActualPayAmount=decimal.Parse(row["ActualPayAmount"].ToString());
				}
				if(row["FullDiscount"]!=null && row["FullDiscount"].ToString()!="")
				{
					model.FullDiscount=decimal.Parse(row["FullDiscount"].ToString());
				}
				if(row["CapitalAmount"]!=null && row["CapitalAmount"].ToString()!="")
				{
					model.CapitalAmount=decimal.Parse(row["CapitalAmount"].ToString());
				}
				if(row["RemindType"]!=null && row["RemindType"].ToString()!="")
				{
					model.RemindType=int.Parse(row["RemindType"].ToString());
				}
				if(row["ReceiveDate"]!=null && row["ReceiveDate"].ToString()!="")
				{
					model.ReceiveDate=DateTime.Parse(row["ReceiveDate"].ToString()).ToString("yyyy-MM-dd");
				}
				if(row["ReceiveStartTime"]!=null && row["ReceiveStartTime"].ToString()!="")
				{
					model.ReceiveStartTime=DateTime.Parse(row["ReceiveStartTime"].ToString()).ToString("HH-mm");
				}
				if(row["ReceiveEndTime"]!=null && row["ReceiveEndTime"].ToString()!="")
				{
					model.ReceiveEndTime=DateTime.Parse(row["ReceiveEndTime"].ToString()).ToString("HH-mm");
                }
			}
			return model;
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.OrdersList DataRowToModelList(DataRow row)
        {
            HPYL.Model.OrdersList model = new HPYL.Model.OrdersList();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["OrderStatus"] != null && row["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = int.Parse(row["OrderStatus"].ToString());
                }
                if (row["OrderDate"] != null && row["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(row["OrderDate"].ToString()).ToString("yyyy-MM-dd HH:mm");
                }
                if (row["CloseReason"] != null)
                {
                    model.CloseReason = row["CloseReason"].ToString();
                }
                if (row["ShopId"] != null && row["ShopId"].ToString() != "")
                {
                    model.ShopId = long.Parse(row["ShopId"].ToString());
                }
                if (row["ShopName"] != null)
                {
                    model.ShopName = row["ShopName"].ToString();
                }
                if (row["SellerPhone"] != null)
                {
                    model.SellerPhone = row["SellerPhone"].ToString();
                }
                if (row["SellerAddress"] != null)
                {
                    model.SellerAddress = row["SellerAddress"].ToString();
                }
                if (row["SellerRemark"] != null)
                {
                    model.SellerRemark = row["SellerRemark"].ToString();
                }
                if (row["SellerRemarkFlag"] != null && row["SellerRemarkFlag"].ToString() != "")
                {
                    model.SellerRemarkFlag = int.Parse(row["SellerRemarkFlag"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = long.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserRemark"] != null)
                {
                    model.UserRemark = row["UserRemark"].ToString();
                }
                if (row["ShipTo"] != null)
                {
                    model.ShipTo = row["ShipTo"].ToString();
                }
                if (row["CellPhone"] != null)
                {
                    model.CellPhone = row["CellPhone"].ToString();
                }
                if (row["TopRegionId"] != null && row["TopRegionId"].ToString() != "")
                {
                    model.TopRegionId = int.Parse(row["TopRegionId"].ToString());
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["RegionFullName"] != null)
                {
                    model.RegionFullName = row["RegionFullName"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["ReceiveLongitude"] != null && row["ReceiveLongitude"].ToString() != "")
                {
                    model.ReceiveLongitude = decimal.Parse(row["ReceiveLongitude"].ToString());
                }
                if (row["ReceiveLatitude"] != null && row["ReceiveLatitude"].ToString() != "")
                {
                    model.ReceiveLatitude = decimal.Parse(row["ReceiveLatitude"].ToString());
                }
                if (row["ExpressCompanyName"] != null)
                {
                    model.ExpressCompanyName = row["ExpressCompanyName"].ToString();
                }
                if (row["Freight"] != null && row["Freight"].ToString() != "")
                {
                    model.Freight = decimal.Parse(row["Freight"].ToString());
                }
                if (row["ShipOrderNumber"] != null)
                {
                    model.ShipOrderNumber = row["ShipOrderNumber"].ToString();
                }
                if (row["ShippingDate"] != null && row["ShippingDate"].ToString() != "")
                {
                    model.ShippingDate = DateTime.Parse(row["ShippingDate"].ToString());
                }
                if (row["IsPrinted"] != null && row["IsPrinted"].ToString() != "")
                {
                    model.IsPrinted = int.Parse(row["IsPrinted"].ToString() == "True" ? "1" : "0");
                }
                if (row["PaymentTypeName"] != null)
                {
                    model.PaymentTypeName = row["PaymentTypeName"].ToString();
                }
                if (row["PaymentTypeGateway"] != null)
                {
                    model.PaymentTypeGateway = row["PaymentTypeGateway"].ToString();
                }
                if (row["PaymentType"] != null && row["PaymentType"].ToString() != "")
                {
                    model.PaymentType = int.Parse(row["PaymentType"].ToString());
                }
                if (row["GatewayOrderId"] != null)
                {
                    model.GatewayOrderId = row["GatewayOrderId"].ToString();
                }
                if (row["PayRemark"] != null)
                {
                    model.PayRemark = row["PayRemark"].ToString();
                }
                if (row["PayDate"] != null && row["PayDate"].ToString() != "")
                {
                    model.PayDate = DateTime.Parse(row["PayDate"].ToString());
                }
                if (row["InvoiceType"] != null && row["InvoiceType"].ToString() != "")
                {
                    model.InvoiceType = int.Parse(row["InvoiceType"].ToString());
                }
                if (row["InvoiceTitle"] != null)
                {
                    model.InvoiceTitle = row["InvoiceTitle"].ToString();
                }
                if (row["InvoiceCode"] != null)
                {
                    model.InvoiceCode = row["InvoiceCode"].ToString();
                }
                if (row["Tax"] != null && row["Tax"].ToString() != "")
                {
                    model.Tax = decimal.Parse(row["Tax"].ToString());
                }
                if (row["FinishDate"] != null && row["FinishDate"].ToString() != "")
                {
                    model.FinishDate = DateTime.Parse(row["FinishDate"].ToString());
                }
                if (row["ProductTotalAmount"] != null && row["ProductTotalAmount"].ToString() != "")
                {
                    model.ProductTotalAmount = decimal.Parse(row["ProductTotalAmount"].ToString());
                }
                if (row["RefundTotalAmount"] != null && row["RefundTotalAmount"].ToString() != "")
                {
                    model.RefundTotalAmount = decimal.Parse(row["RefundTotalAmount"].ToString());
                }
                if (row["CommisTotalAmount"] != null && row["CommisTotalAmount"].ToString() != "")
                {
                    model.CommisTotalAmount = decimal.Parse(row["CommisTotalAmount"].ToString());
                }
                if (row["RefundCommisAmount"] != null && row["RefundCommisAmount"].ToString() != "")
                {
                    model.RefundCommisAmount = decimal.Parse(row["RefundCommisAmount"].ToString());
                }
                if (row["ActiveType"] != null && row["ActiveType"].ToString() != "")
                {
                    model.ActiveType = int.Parse(row["ActiveType"].ToString());
                }
                if (row["Platform"] != null && row["Platform"].ToString() != "")
                {
                    model.Platform = int.Parse(row["Platform"].ToString());
                }
                if (row["DiscountAmount"] != null && row["DiscountAmount"].ToString() != "")
                {
                    model.DiscountAmount = decimal.Parse(row["DiscountAmount"].ToString());
                }
                if (row["IntegralDiscount"] != null && row["IntegralDiscount"].ToString() != "")
                {
                    model.IntegralDiscount = decimal.Parse(row["IntegralDiscount"].ToString());
                }
                if (row["InvoiceContext"] != null)
                {
                    model.InvoiceContext = row["InvoiceContext"].ToString();
                }
                if (row["OrderType"] != null && row["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(row["OrderType"].ToString());
                }
                if (row["ShareUserId"] != null && row["ShareUserId"].ToString() != "")
                {
                    model.ShareUserId = long.Parse(row["ShareUserId"].ToString());
                }
                if (row["OrderRemarks"] != null)
                {
                    model.OrderRemarks = row["OrderRemarks"].ToString();
                }
                if (row["LastModifyTime"] != null && row["LastModifyTime"].ToString() != "")
                {
                    model.LastModifyTime = DateTime.Parse(row["LastModifyTime"].ToString());
                }
                if (row["DeliveryType"] != null && row["DeliveryType"].ToString() != "")
                {
                    model.DeliveryType = int.Parse(row["DeliveryType"].ToString());
                }
                if (row["ShopBranchId"] != null && row["ShopBranchId"].ToString() != "")
                {
                    model.ShopBranchId = long.Parse(row["ShopBranchId"].ToString());
                }
                if (row["PickupCode"] != null)
                {
                    model.PickupCode = row["PickupCode"].ToString();
                }
                if (row["TotalAmount"] != null && row["TotalAmount"].ToString() != "")
                {
                    model.TotalAmount = decimal.Parse(row["TotalAmount"].ToString());
                }
                if (row["ActualPayAmount"] != null && row["ActualPayAmount"].ToString() != "")
                {
                    model.ActualPayAmount = decimal.Parse(row["ActualPayAmount"].ToString());
                }
                if (row["FullDiscount"] != null && row["FullDiscount"].ToString() != "")
                {
                    model.FullDiscount = decimal.Parse(row["FullDiscount"].ToString());
                }
                if (row["CapitalAmount"] != null && row["CapitalAmount"].ToString() != "")
                {
                    model.CapitalAmount = decimal.Parse(row["CapitalAmount"].ToString());
                }
                if (row["RemindType"] != null && row["RemindType"].ToString() != "")
                {
                    model.RemindType = int.Parse(row["RemindType"].ToString());
                }
                if (row["ReceiveDate"] != null && row["ReceiveDate"].ToString() != "")
                {
                    model.ReceiveDate = DateTime.Parse(row["ReceiveDate"].ToString()).ToString("yyyy-MM-dd");
                }
                if (row["ReceiveStartTime"] != null && row["ReceiveStartTime"].ToString() != "")
                {
                    model.ReceiveStartTime = DateTime.Parse(row["ReceiveStartTime"].ToString()).ToString("HH:mm");
                }
                if (row["ReceiveEndTime"] != null && row["ReceiveEndTime"].ToString() != "")
                {
                    model.ReceiveEndTime = DateTime.Parse(row["ReceiveEndTime"].ToString()).ToString("HH:mm");
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,OrderStatus,OrderDate,CloseReason,ShopId,ShopName,SellerPhone,SellerAddress,SellerRemark,SellerRemarkFlag,UserId,UserName,UserRemark,ShipTo,CellPhone,TopRegionId,RegionId,RegionFullName,Address,ReceiveLongitude,ReceiveLatitude,ExpressCompanyName,Freight,ShipOrderNumber,ShippingDate,IsPrinted,PaymentTypeName,PaymentTypeGateway,PaymentType,GatewayOrderId,PayRemark,PayDate,InvoiceType,InvoiceTitle,InvoiceCode,Tax,FinishDate,ProductTotalAmount,RefundTotalAmount,CommisTotalAmount,RefundCommisAmount,ActiveType,Platform,DiscountAmount,IntegralDiscount,InvoiceContext,OrderType,ShareUserId,OrderRemarks,LastModifyTime,DeliveryType,ShopBranchId,PickupCode,TotalAmount,ActualPayAmount,FullDiscount,CapitalAmount,RemindType,ReceiveDate,ReceiveStartTime,ReceiveEndTime ");
			strSql.Append(" FROM himall_orders ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListPage(Pagination pagination, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,OrderStatus,OrderDate,CloseReason,ShopId,ShopName,SellerPhone,SellerAddress,SellerRemark,SellerRemarkFlag,UserId,UserName,UserRemark,ShipTo,CellPhone,TopRegionId,RegionId,RegionFullName,Address,ReceiveLongitude,ReceiveLatitude,ExpressCompanyName,Freight,ShipOrderNumber,ShippingDate,IsPrinted,PaymentTypeName,PaymentTypeGateway,PaymentType,GatewayOrderId,PayRemark,PayDate,InvoiceType,InvoiceTitle,InvoiceCode,Tax,FinishDate,ProductTotalAmount,RefundTotalAmount,CommisTotalAmount,RefundCommisAmount,ActiveType,Platform,DiscountAmount,IntegralDiscount,InvoiceContext,OrderType,ShareUserId,OrderRemarks,LastModifyTime,DeliveryType,ShopBranchId,PickupCode,TotalAmount,ActualPayAmount,FullDiscount,CapitalAmount,RemindType,ReceiveDate,ReceiveStartTime,ReceiveEndTime ");
            strSql.Append(" FROM himall_orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new Repository<orders>().FindTable(strSql.ToString(), pagination);

        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

