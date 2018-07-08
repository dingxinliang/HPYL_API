using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.BLL
{
    #region << 版 本 注 释 >>
    /*----------------------------------------------------------------
    * 项目名称 ：HPYL.BLL
    * 项目描述 ：
    * 类 名 称 ：MysqlTest
    * 类 描 述 ：
    * 命名空间 ：HPYL.BLL
    * CLR 版本 ：4.0.30319.42000
    * 作    者 ：丁新亮
    * 创建时间 ：2018-07-08 10:11:56
    * 更新时间 ：2018-07-08 10:11:56
    * 版 本 号 ：v1.0.0.0
    *******************************************************************
    * Copyright @ DXL 2018. All rights reserved.
    *******************************************************************
    //----------------------------------------------------------------*/
    #endregion
    public class MysqlTest
    {
        private readonly HPYL.DAL.MysqlTest dal = new DAL.MysqlTest();
        public bool Save(HPYL.Model.MysqlTest info)
        {
          return dal.Add(info);
        }
    }
}
