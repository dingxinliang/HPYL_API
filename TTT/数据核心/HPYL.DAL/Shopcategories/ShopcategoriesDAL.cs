using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.DAL
{
    /// <summary>
    /// 诊所科室分类DAL
    /// </summary>
    public class ShopcategoriesDAL
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from himall_shopcategories");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int64)
            };
            parameters[0].Value = Id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HPYL.Model.Shopcategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into himall_shopcategories(");
            strSql.Append("ShopId,ParentCategoryId,Name,DisplaySequence,IsShow)");
            strSql.Append(" values (");
            strSql.Append("@ShopId,@ParentCategoryId,@Name,@DisplaySequence,@IsShow)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ShopId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ParentCategoryId", MySqlDbType.Int64,20),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,100),
                    new MySqlParameter("@DisplaySequence", MySqlDbType.Int64,20),
                    new MySqlParameter("@IsShow", MySqlDbType.Byte,1)};
            parameters[0].Value = model.ShopId;
            parameters[1].Value = model.ParentCategoryId;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.DisplaySequence;
            parameters[4].Value = model.IsShow;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HPYL.Model.Shopcategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update himall_shopcategories set ");
            strSql.Append("ShopId=@ShopId,");
            strSql.Append("ParentCategoryId=@ParentCategoryId,");
            strSql.Append("Name=@Name,");
            strSql.Append("DisplaySequence=@DisplaySequence,");
            strSql.Append("IsShow=@IsShow,");
            strSql.Append("UserId=@UserId");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ShopId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ParentCategoryId", MySqlDbType.Int64,20),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,100),
                    new MySqlParameter("@DisplaySequence", MySqlDbType.Int64,20),
                    new MySqlParameter("@IsShow", MySqlDbType.Byte,1),
                    new MySqlParameter("@Id", MySqlDbType.Int64,20)};
            parameters[0].Value = model.ShopId;
            parameters[1].Value = model.ParentCategoryId;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.DisplaySequence;
            parameters[4].Value = model.IsShow;
            parameters[5].Value = model.Id;
            parameters[6].Value = model.UserId;
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from himall_shopcategories ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int64)
            };
            parameters[0].Value = Id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from himall_shopcategories ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Shopcategories GetModel(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ShopId,ParentCategoryId,Name,DisplaySequence,IsShow,UserId from himall_shopcategories ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int64)
            };
            parameters[0].Value = Id;

            HPYL.Model.Shopcategories model = new HPYL.Model.Shopcategories();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
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
        public HPYL.Model.Shopcategories DataRowToModel(DataRow row)
        {
            HPYL.Model.Shopcategories model = new HPYL.Model.Shopcategories();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["ShopId"] != null && row["ShopId"].ToString() != "")
                {
                    model.ShopId = long.Parse(row["ShopId"].ToString());
                }
                if (row["ParentCategoryId"] != null && row["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = long.Parse(row["ParentCategoryId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["DisplaySequence"] != null && row["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = long.Parse(row["DisplaySequence"].ToString());
                }
                if (row["IsShow"] != null && row["IsShow"].ToString() != "")
                {
                    if ((row["IsShow"].ToString() == "1") || (row["IsShow"].ToString().ToLower() == "true"))
                    {
                        model.IsShow = 1;
                    }
                    else
                    {
                        model.IsShow = 0;
                    }
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ShopId,ParentCategoryId,Name,DisplaySequence,IsShow,UserId ");
            strSql.Append(" FROM himall_shopcategories ");
            if (strWhere.Trim() != "" && strWhere != "0")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM himall_shopcategories ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from himall_shopcategories T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "himall_shopcategories";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
