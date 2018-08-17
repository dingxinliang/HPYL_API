using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.DAL
{
    /// <summary>
    /// 医生注册协议 
    /// </summary>
   public  class RecruitPlanDAL
    {
        /// <summary>
        /// 获取单个数据方法
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HPYL.Model.RecruitPlan GetModel(long Id)
        {
            string sql = "select Id,Title,Content from himall_recruitplan   where Id=" + Id;
            HPYL.Model.RecruitPlan model = new HPYL.Model.RecruitPlan();
            DataSet ds = DbHelperMySQL.Query(sql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.RecruitPlan DataRowToModel(DataRow row)
        {
            HPYL.Model.RecruitPlan model = new HPYL.Model.RecruitPlan();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["Title"] != null && row["Title"].ToString() != "")
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Content"] != null && row["Content"].ToString() != "")
                {
                    model.Content = row["Content"].ToString();
                }
            }
            return model;
        }
    }
}
