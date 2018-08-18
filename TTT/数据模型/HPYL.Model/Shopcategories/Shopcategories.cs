using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    /// <summary>
    /// 诊所科室模型
    /// </summary>
   public  class Shopcategories
    {
        #region Model
        private long id;
        private long shopid;
        private long parentcategoryid;
        private string name;
        private long displaysequence;
        private int isshow;
        private int userId;
        /// <summary>
        /// 主键
        /// </summary>
        public long Id
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public long ShopId
        {
            set { shopid = value; }
            get { return shopid; }
        }
        /// <summary>
        /// 上级分类ID 默认顶级 为0
        /// </summary>
        public long ParentCategoryId
        {
            set { parentcategoryid = value; }
            get { return parentcategoryid; }
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public long DisplaySequence
        {
            set { displaysequence = value; }
            get { return displaysequence; }
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsShow
        {
            set { isshow = value; }
            get { return isshow; }
        }
        /// <summary>
        /// 创建者 0 系统 否则为用户ID
        /// </summary>
        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }
        #endregion Model
    }
}
