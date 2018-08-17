using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using XL.Util.Extension;
using XL.Util.WebControl;

namespace HPYL.DAL
{
    /// <summary>
    ///  数据访问类:himall_agreement
    /// </summary>
    public class AgreementDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Agreement GetModel(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,AgreementType,AgreementContent,LastUpdateTime from himall_agreement ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                          new MySqlParameter("@Id", Id)
            };
            DataSet dst = DbHelperMySQL.Query(strSql.ToString(), parameters);

            string sql = "select Id,AgreementType,AgreementContent,LastUpdateTime from himall_agreement   where Id="+Id;
            HPYL.Model.Agreement model = new HPYL.Model.Agreement();
         
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
        public HPYL.Model.Agreement DataRowToModel(DataRow row)
        {
            HPYL.Model.Agreement model = new HPYL.Model.Agreement();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["AgreementType"] != null && row["AgreementType"].ToString() != "")
                {
                    model.AgreementType = int.Parse(row["AgreementType"].ToString());
                }
                if (row["AgreementContent"] != null)
                {
                    model.AgreementContent = row["AgreementContent"].ToString();
                }
                if (row["LastUpdateTime"] != null && row["LastUpdateTime"].ToString() != "")
                {
                    model.LastUpdateTime = DateTime.Parse(row["LastUpdateTime"].ToString());
                }
            }
            return model;
        }

    }
}
