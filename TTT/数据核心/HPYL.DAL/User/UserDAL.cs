using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;

namespace HPYL.DAL.User
{
    public class UserDAL
    {
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool ExistsRegisterPhone(string UserName)
        {
            string strSql = "select UserName from himall_members where UserName='"+ UserName + "'";
            int rows = DbHelperMySQL.ExecuteSql(strSql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
