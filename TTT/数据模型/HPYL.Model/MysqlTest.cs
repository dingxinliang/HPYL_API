using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.Model
{
    #region << 版 本 注 释 >>
    /*----------------------------------------------------------------
    * 项目名称 ：HPYL.Model
    * 项目描述 ：
    * 类 名 称 ：MysqlTest
    * 类 描 述 ：
    * 命名空间 ：HPYL.Model
    * CLR 版本 ：4.0.30319.42000
    * 作    者 ：丁新亮
    * 创建时间 ：2018-07-08 10:10:54
    * 更新时间 ：2018-07-08 10:10:54
    * 版 本 号 ：v1.0.0.0
    *******************************************************************
    * Copyright @ DXL 2018. All rights reserved.
    *******************************************************************
    //----------------------------------------------------------------*/
    #endregion
    /// <summary>
    /// utest:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public partial class MysqlTest
    {
        public MysqlTest()
        { }
        #region Model
        /// auto_increment
        /// </summary>
        public int Id
        {
            get;set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Required(AllowEmptyStrings = false, ErrorMessage = "請填寫名字")]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "最少2个字且不能超过{1}字")]

        public string Name
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        [Range(1, 2, ErrorMessage = "無效的性別類型")]
        public int? Sex
        {
            get; set;
        }
        #endregion Model

    }
}
