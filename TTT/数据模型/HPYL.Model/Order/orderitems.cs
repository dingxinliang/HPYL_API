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
namespace HPYL.Model
{
	
	public  class orderitems
	{
		
		#region Model
		
		/// <summary>
		/// auto_increment
		/// </summary>
		public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ShopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SkuId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ReturnQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal RealTotalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal RefundPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailsUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CommisRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? EnabledRefundAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsLimitBuy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DistributionRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? EnabledRefundIntegral { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CouponDiscount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FullDiscount { get; set; }
        #endregion Model

    }
}

