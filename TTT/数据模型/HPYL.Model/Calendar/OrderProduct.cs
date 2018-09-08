#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Model.Calendar
* 项目描述 ：
* 类 名 称 ：OrderProduct
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Model.Calendar
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/17 17:11:20
* 更新时间 ：2018/8/17 17:11:20
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{

    public class ProductItem {

        /// <summary>
        /// 商品ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string  Name { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal Price { get; set; }

    }
       
   public class OrderProduct
    {

       
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 诊所ID
        /// </summary>
        public long ShopId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// SkuId
        /// </summary>
        public string SkuId { get; set; }
        /// <summary>
        /// SKU 可为空
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public long Quantity { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public long ReturnQuantity { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal DiscountAmount { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        public decimal RealTotalPrice { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundPrice { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// sku颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// sku尺寸
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// sku版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbnailsUrl { get; set; }
        /// <summary>
        /// CommisRate
        /// </summary>
        public decimal CommisRate { get; set; }
        /// <summary>
        /// 可退金额
        /// </summary>
        public decimal EnabledRefundAmount { get; set; }
        /// <summary>
        /// 是否为限时购商
        /// </summary>
        public int IsLimitBuy { get; set; }
        /// <summary>
        /// 分销毙了
        /// </summary>
        public decimal DistributionRate { get; set; }
        /// <summary>
        /// 可退积分抵扣金额
        /// </summary>
        public decimal EnabledRefundIntegral { get; set; }
        /// <summary>
        /// 满减平坦
        /// </summary>
        public decimal CouponDiscount { get; set; }
        /// <summary>
        /// 优惠
        /// </summary>
        public decimal FullDiscount { get; set; }


        public void Create()
        {
            this.Color = "";
            this.CommisRate =0;

            this.CouponDiscount =0;
            this.DiscountAmount =0;
            //this.DistributionRate =0;
            this.EnabledRefundAmount = 0;
            this.EnabledRefundIntegral =0;
            this.FullDiscount =0;
            this.IsLimitBuy =0;
            this.Quantity =1;
            this.RefundPrice =0;
            this.ReturnQuantity =0;
            this.Size = "";
            this.SKU = "";
            this.ThumbnailsUrl = "";
            this.Version = "";
           
        }
    }
}
