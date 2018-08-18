using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.DAL;
using HPYL.Model;

namespace HPYL.BLL
{
    public  class AgreementBLL
    {
        private readonly HPYL.DAL.AgreementDAL dal = new DAL.AgreementDAL();
     
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Agreement GetModel(string AgID)
        {
            return dal.GetModel(long.Parse(AgID));
        }

    }
}
