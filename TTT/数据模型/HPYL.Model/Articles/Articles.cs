using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    
    public  class Articles
    {
        #region Model 
        /// <summary>
        /// auto_increment
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IconUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long DisplaySequence { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Meta_Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Meta_Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Meta_Keywords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsRelease { get; set; }
        #endregion Model

    }
}
