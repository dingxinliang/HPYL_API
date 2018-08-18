using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
   
    public  class ArticleCategories
    {
        #region Model
        /// <summary>
        /// auto_increment
        /// </summary>
        public long Id { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public long ParentCategoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long DisplaySequence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsDefault { get; set; }
        #endregion Model
    }
}
