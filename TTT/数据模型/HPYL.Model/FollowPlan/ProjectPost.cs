#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：HPYL.Model.FollowPlan
* 项目描述 ：
* 类 名 称 ：ProjectPost
* 类 描 述 ：
* 所在的域 ：QH-20160830FLFX
* 命名空间 ：HPYL.Model.FollowPlan
* 机器名称 ：QH-20160830FLFX 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：丁新亮
* 创建时间 ：2018/8/17 11:56:56
* 更新时间 ：2018/8/17 11:56:56
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ Administrator 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{

    public class ProjectPost {
        /// <summary>
        /// 诊所ID
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少ShopId参数")]
        public long ShopId { get; set; }
        /// <summary>
        /// 当前医生ID
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少UserId参数")]
        public int UserId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少ProjectName参数")]
        [StringLength(40, ErrorMessage = "名称的长度不能大于{1}个字")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 所属一级类别Id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "缺少ShopCategoryId参数")]
        public long ShopCategoryId { get; set; }

    }

    public class ProjectBase
    {


   
      
        /// <summary>
        /// 平台分类ID
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// 分类标识
        /// </summary>
        public string CategoryPath { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public long TypeId { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public long BrandId { get; set; }
        
        /// <summary>
        /// 项目代码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 广告词
        /// </summary>
        public string ShortDescription { get; set; }
        /// <summary>
        /// 销售状态
        /// </summary>
        public int SaleStatus { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int AuditStatus { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddedDate { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public long DisplaySequence { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 最低销售价
        /// </summary>
        public decimal MinSalePrice { get; set; }
        /// <summary>
        /// 是否有SKU
        /// </summary>
        public int HasSKU { get; set; }
        /// <summary>
        /// 浏览器次数
        /// </summary>
        public long VistiCounts { get; set; }
        /// <summary>
        /// 销售量
        /// </summary>
        public long SaleCounts { get; set; }
        /// <summary>
        /// 运费末班
        /// </summary>
        public long FreightTemplateId { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 体积
        /// </summary>
        public decimal Volume { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string MeasureUnit { get; set; }
        /// <summary>
        /// 修改状态 0 正常 1己修改 2待审核 3 己修改并待审核
        /// </summary>
        public int EditStatus { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 最大购买量
        /// </summary>
        public int MaxBuyCount { get; set; }
      

        public void Create()
        {
            this.CategoryId = 159;
            this.CategoryPath = "151|158|159";
            this.TypeId = 95;
            this.BrandId = 0;
            this.ProductCode = "ys";
            this.ShortDescription = "ys";
            this.SaleStatus = 1;
            this.AuditStatus = 2;
            this.AddedDate = DateTime.Now;
            this.DisplaySequence = 1;
            this.ImagePath ="";
            this.MaxBuyCount = 1;
            this.MinSalePrice = 159;
            this.MarketPrice = 159;
            this.HasSKU = 0;
            this.VistiCounts = 0;
            this.SaleCounts = 0;
            this.FreightTemplateId = 0;
            this.Weight = 0;
            this.Quantity = 0;
            this.Volume = 0;
            this.MeasureUnit ="";
            this.EditStatus = 0;
            this.IsDeleted =false;
            this.MaxBuyCount = 10;
            
            

        }
    }

}
