using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;

namespace HPYL.DAL.ArticleCategories
{
    /// <summary>
    /// 数据访问类:himall_articlecategories
    /// </summary>
    public partial class ArticleCategoriesDAL
    {
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.ArticleCategories GetModel(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ParentCategoryId,Name,DisplaySequence,IsDefault from himall_articlecategories ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int64)
            };
            parameters[0].Value = Id;
            // string sql = "select Id,ParentCategoryId,Name,DisplaySequence,IsDefault from himall_articlecategories  where Id="+Id;
            // HPYL.Model.ArticleCategories model = new HPYL.Model.ArticleCategories();
             DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
           // DataSet ds = DbHelperMySQL.Query(sql.ToString());
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
        public HPYL.Model.ArticleCategories DataRowToModel(DataRow row)
        {
            HPYL.Model.ArticleCategories model = new Model.ArticleCategories();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
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
                if (row["IsDefault"] != null && row["IsDefault"].ToString() != "")
                {
                    bool IsDefaults = Convert.ToBoolean(row["IsDefault"].ToString());
                    model.IsDefault = IsDefaults ? 1 : 0;
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
            strSql.Append("select Id,ParentCategoryId,Name,DisplaySequence,IsDefault ");
            strSql.Append(" FROM himall_articlecategories ");
            if (strWhere.Trim() != "")
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
            strSql.Append("select count(1) FROM himall_articlecategories ");
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
            strSql.Append(")AS Row, T.*  from himall_articlecategories T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
    }
}
