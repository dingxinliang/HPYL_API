using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.DAL;
using HPYL.Model;

namespace HPYL.BLL
{
    /// <summary>
    /// 医生注册协议 逻辑处理
    /// </summary>
    public class RecruitPlanBLL
    {
        private readonly HPYL.DAL.RecruitPlanDAL dal = new DAL.RecruitPlanDAL();

        /// <summary>
        /// 得到一个对象实体 
        /// </summary>
        public RecruitPlan GetModel(long id)
        {
            return dal.GetModel(id);
        }
    }
}
