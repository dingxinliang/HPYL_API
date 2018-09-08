/**  版本信息模板在安装目录下，可自行修改。
* orderitems.cs
*
* 功 能： N/A
* 类 名： orderitems
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/4 10:38:43   N/A    初版
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
namespace HPYL.DAL
{
	/// <summary>
	/// 数据访问类:orderitems
	/// </summary>
	public partial class orderitems
	{
		public orderitems()
		{}
		#region  BasicMethod
        
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from himall_orderitems ");
			strSql.Append(" where Id=@Id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int64)
			};
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
			strSql.Append("delete from himall_orderitems ");
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
		public HPYL.Model.orderitems GetModel(long Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,OrderId,ShopId,ProductId,SkuId,SKU,Quantity,ReturnQuantity,CostPrice,SalePrice,DiscountAmount,RealTotalPrice,RefundPrice,ProductName,Color,Size,Version,ThumbnailsUrl,CommisRate,EnabledRefundAmount,IsLimitBuy,DistributionRate,EnabledRefundIntegral,CouponDiscount,FullDiscount from himall_orderitems ");
			strSql.Append(" where Id=@Id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int64)
			};
			parameters[0].Value = Id;

			HPYL.Model.orderitems model=new HPYL.Model.orderitems();
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
		public HPYL.Model.orderitems DataRowToModel(DataRow row)
		{
			HPYL.Model.orderitems model=new HPYL.Model.orderitems();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=long.Parse(row["Id"].ToString());
				}
				if(row["OrderId"]!=null && row["OrderId"].ToString()!="")
				{
					model.OrderId=long.Parse(row["OrderId"].ToString());
				}
				if(row["ShopId"]!=null && row["ShopId"].ToString()!="")
				{
					model.ShopId=long.Parse(row["ShopId"].ToString());
				}
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=long.Parse(row["ProductId"].ToString());
				}
				if(row["SkuId"]!=null)
				{
					model.SkuId=row["SkuId"].ToString();
				}
				if(row["SKU"]!=null)
				{
					model.SKU=row["SKU"].ToString();
				}
				if(row["Quantity"]!=null && row["Quantity"].ToString()!="")
				{
					model.Quantity=long.Parse(row["Quantity"].ToString());
				}
				if(row["ReturnQuantity"]!=null && row["ReturnQuantity"].ToString()!="")
				{
					model.ReturnQuantity=long.Parse(row["ReturnQuantity"].ToString());
				}
				if(row["CostPrice"]!=null && row["CostPrice"].ToString()!="")
				{
					model.CostPrice=decimal.Parse(row["CostPrice"].ToString());
				}
				if(row["SalePrice"]!=null && row["SalePrice"].ToString()!="")
				{
					model.SalePrice=decimal.Parse(row["SalePrice"].ToString());
				}
				if(row["DiscountAmount"]!=null && row["DiscountAmount"].ToString()!="")
				{
					model.DiscountAmount=decimal.Parse(row["DiscountAmount"].ToString());
				}
				if(row["RealTotalPrice"]!=null && row["RealTotalPrice"].ToString()!="")
				{
					model.RealTotalPrice=decimal.Parse(row["RealTotalPrice"].ToString());
				}
				if(row["RefundPrice"]!=null && row["RefundPrice"].ToString()!="")
				{
					model.RefundPrice=decimal.Parse(row["RefundPrice"].ToString());
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["Size"]!=null)
				{
					model.Size=row["Size"].ToString();
				}
				if(row["Version"]!=null)
				{
					model.Version=row["Version"].ToString();
				}
				if(row["ThumbnailsUrl"]!=null)
				{
					model.ThumbnailsUrl=row["ThumbnailsUrl"].ToString();
				}
				if(row["CommisRate"]!=null && row["CommisRate"].ToString()!="")
				{
					model.CommisRate=decimal.Parse(row["CommisRate"].ToString());
				}
				if(row["EnabledRefundAmount"]!=null && row["EnabledRefundAmount"].ToString()!="")
				{
					model.EnabledRefundAmount=decimal.Parse(row["EnabledRefundAmount"].ToString());
				}
				if(row["IsLimitBuy"]!=null && row["IsLimitBuy"].ToString()!="")
				{
					model.IsLimitBuy= int.Parse(row["IsLimitBuy"].ToString() == "True" ? "1" : "0"); 
				}
				if(row["DistributionRate"]!=null && row["DistributionRate"].ToString()!="")
				{
					model.DistributionRate=decimal.Parse(row["DistributionRate"].ToString());
				}
				if(row["EnabledRefundIntegral"]!=null && row["EnabledRefundIntegral"].ToString()!="")
				{
					model.EnabledRefundIntegral=decimal.Parse(row["EnabledRefundIntegral"].ToString());
				}
				if(row["CouponDiscount"]!=null && row["CouponDiscount"].ToString()!="")
				{
					model.CouponDiscount=decimal.Parse(row["CouponDiscount"].ToString());
				}
				if(row["FullDiscount"]!=null && row["FullDiscount"].ToString()!="")
				{
					model.FullDiscount=decimal.Parse(row["FullDiscount"].ToString());
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
			strSql.Append("select Id,OrderId,ShopId,ProductId,SkuId,SKU,Quantity,ReturnQuantity,CostPrice,SalePrice,DiscountAmount,RealTotalPrice,RefundPrice,ProductName,Color,Size,Version,ThumbnailsUrl,CommisRate,EnabledRefundAmount,IsLimitBuy,DistributionRate,EnabledRefundIntegral,CouponDiscount,FullDiscount ");
			strSql.Append(" FROM himall_orderitems ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

