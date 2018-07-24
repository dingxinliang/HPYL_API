/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.DAL.QuickReply
*文件名：  QuickReplyDAL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 15:44:34

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 15:44:34
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;

namespace HPYL.DAL
{
    public class QuickReplyDAL
    {

        /// <summary>
        /// 获取用户快捷回复
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<QuickReply> QuickReplyList(long userID)
        {
            string strSql = "select HQR_ID,HQR_Content,HQR_UserId,HQR_Time from hpyl_quickreply where HQR_UserId=" + userID + "";
            return new Repository<QuickReply>().FindList(strSql).ToList();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseQuickReply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_quickreply(");
            strSql.Append("HQR_Content,HQR_UserId,HQR_Time)");
            strSql.Append(" values (");
            strSql.Append("@HQR_Content,@HQR_UserId,now())");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HQR_Content", model.HQR_Content),
                    new MySqlParameter("@HQR_UserId",model.HQR_UserId)
                   };
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

        public QuickReply GetModel(long hQR_ID, long userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select HQR_ID,HQR_Content,HQR_UserId,HQR_Time from hpyl_quickreply ");
            strSql.Append(" where HQR_ID=@HQR_ID and HQR_UserId=@HQR_UserId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HQR_ID",hQR_ID),
                    new MySqlParameter("@HQR_UserId",userID)
            };
            QuickReply model = new QuickReply();
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
        public QuickReply DataRowToModel(DataRow row)
        {
            QuickReply model = new QuickReply();
            if (row != null)
            {
                if (row["HQR_ID"] != null && row["HQR_ID"].ToString() != "")
                {
                    model.HQR_ID = long.Parse(row["HQR_ID"].ToString());
                }
                if (row["HQR_Content"] != null)
                {
                    model.HQR_Content = row["HQR_Content"].ToString();
                }
                if (row["HQR_UserId"] != null && row["HQR_UserId"].ToString() != "")
                {
                    model.HQR_UserId = long.Parse(row["HQR_UserId"].ToString());
                }
                if (row["HQR_Time"] != null && row["HQR_Time"].ToString() != "")
                {
                    model.HQR_Time=row["HQR_Time"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(QuickReply model)
        {


            string strSql = "update hpyl_quickreply set HQR_Content='"+model.HQR_Content+ "',HQR_Time=now() where HQR_ID=" + model.HQR_ID+" and HQR_UserId="+model.HQR_UserId+"";
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
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long HQR_ID,long UserId)
        {
            string strSql = "delete from hpyl_quickreply   where HQR_ID=" + HQR_ID + " and HQR_UserId=" + UserId + "";
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
