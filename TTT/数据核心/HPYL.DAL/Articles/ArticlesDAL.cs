using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using XL.Util.WebControl;

namespace HPYL.DAL
{
    /// <summary>
	/// 数据访问类:himall_articles
	/// </summary>
	public partial class ArticlesDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Articles GetModel(int Id)
        {

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select Id,CategoryId,Title,IconUrl,Content,AddDate,DisplaySequence,Meta_Title,Meta_Description,Meta_Keywords,IsRelease from himall_articles ");
            //strSql.Append(" where Id=@Id");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("@Id", MySqlDbType.UInt64)
            //};
            //parameters[0].Value = Id;
            string sql = "select Id,CategoryId,Title,IconUrl,Content,AddDate,DisplaySequence,Meta_Title,Meta_Description,Meta_Keywords,IsRelease from himall_articles  where Id="+ Id;
            HPYL.Model.Articles model = new HPYL.Model.Articles();
            //DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
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
        public HPYL.Model.Articles DataRowToModel(DataRow row)
        {
            HPYL.Model.Articles model = new HPYL.Model.Articles();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = long.Parse(row["CategoryId"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["IconUrl"] != null)
                {
                    model.IconUrl = row["IconUrl"].ToString();
                }
                if (row["Content"] != null && row["Content"].ToString() != "")
                {
                    model.Content = row["Content"].ToString();
                }
                
                if (row["AddDate"] != null && row["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(row["AddDate"].ToString());
                }
                if (row["DisplaySequence"] != null && row["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = long.Parse(row["DisplaySequence"].ToString());
                }
                if (row["Meta_Title"] != null)
                {
                    model.Meta_Title = row["Meta_Title"].ToString();
                }
                if (row["Meta_Description"] != null)
                {
                    model.Meta_Description = row["Meta_Description"].ToString();
                }
                if (row["Meta_Keywords"] != null)
                {
                    model.Meta_Keywords = row["Meta_Keywords"].ToString();
                }
                if (row["IsRelease"] != null && row["IsRelease"].ToString() != "")
                {
                    model.IsRelease = int.Parse(row["IsRelease"].ToString() == "True" ? "1" : "0");
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
            strSql.Append("select Id,CategoryId,Title,IconUrl,Content,AddDate,DisplaySequence,Meta_Title,Meta_Description,Meta_Keywords,IsRelease ");
            strSql.Append(" FROM himall_articles ");
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
            strSql.Append("select count(1) FROM himall_articles ");
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
            strSql.Append(")AS Row, T.*  from himall_articles T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable GetListPage(Pagination pagination, long NewsClass)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * from himall_articles  WHERE CategoryId=" + NewsClass+"  ");
           
            return new Repository<Articles>().FindTable(strSql.ToString(), pagination);

        }
        
        #endregion  ExtensionMethod
    }
}
