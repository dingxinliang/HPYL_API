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
    public class ShopbranchDAL
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from himall_shopbranch");
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
        public bool Add(HPYL.Model.Shopbranch model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into himall_shopbranch(");
            strSql.Append("ShopId,ShopBranchName,AddressId,AddressPath,AddressDetail,ContactUser,ContactPhone,Status,CreateDate,ServeRadius,Longitude,Latitude,ShopImages,IsStoreDelive,IsAboveSelf,StoreOpenStartTime,StoreOpenEndTime,IsRecommend,RecommendSequence,DeliveFee,DeliveTotalFee,FreeMailFee)");
            strSql.Append(" values (");
            strSql.Append("@ShopId,@ShopBranchName,@AddressId,@AddressPath,@AddressDetail,@ContactUser,@ContactPhone,@Status,@CreateDate,@ServeRadius,@Longitude,@Latitude,@ShopImages,@IsStoreDelive,@IsAboveSelf,@StoreOpenStartTime,@StoreOpenEndTime,@IsRecommend,@RecommendSequence,@DeliveFee,@DeliveTotalFee,@FreeMailFee)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ShopId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ShopBranchName", MySqlDbType.VarChar,30),
                    new MySqlParameter("@AddressId", MySqlDbType.Int32,11),
                    new MySqlParameter("@AddressPath", MySqlDbType.VarChar,50),
                    new MySqlParameter("@AddressDetail", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ContactUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ContactPhone", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Status", MySqlDbType.Int32,11),
                    new MySqlParameter("@CreateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@ServeRadius", MySqlDbType.Int32,11),
                    new MySqlParameter("@Longitude", MySqlDbType.Float),
                    new MySqlParameter("@Latitude", MySqlDbType.Float),
                    new MySqlParameter("@ShopImages", MySqlDbType.VarChar,500),
                    new MySqlParameter("@IsStoreDelive", MySqlDbType.Bit),
                    new MySqlParameter("@IsAboveSelf", MySqlDbType.Bit),
                    new MySqlParameter("@StoreOpenStartTime", MySqlDbType.Time),
                    new MySqlParameter("@StoreOpenEndTime", MySqlDbType.Time),
                    new MySqlParameter("@IsRecommend", MySqlDbType.Bit),
                    new MySqlParameter("@RecommendSequence", MySqlDbType.Int64,20),
                    new MySqlParameter("@DeliveFee", MySqlDbType.Int32,11),
                    new MySqlParameter("@DeliveTotalFee", MySqlDbType.Int32,11),
                    new MySqlParameter("@FreeMailFee", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ShopId;
            parameters[1].Value = model.ShopBranchName;
            parameters[2].Value = model.AddressId;
            parameters[3].Value = model.AddressPath;
            parameters[4].Value = model.AddressDetail;
            parameters[5].Value = model.ContactUser;
            parameters[6].Value = model.ContactPhone;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.ServeRadius;
            parameters[10].Value = model.Longitude;
            parameters[11].Value = model.Latitude;
            parameters[12].Value = model.ShopImages;
            parameters[13].Value = model.IsStoreDelive;
            parameters[14].Value = model.IsAboveSelf;
            parameters[15].Value = model.StoreOpenStartTime;
            parameters[16].Value = model.StoreOpenEndTime;
            parameters[17].Value = model.IsRecommend;
            parameters[18].Value = model.RecommendSequence;
            parameters[19].Value = model.DeliveFee;
            parameters[20].Value = model.DeliveTotalFee;
            parameters[21].Value = model.FreeMailFee;

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
        public bool Update(HPYL.Model.Shopbranch model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update himall_shopbranch set ");
            strSql.Append("ShopId=@ShopId,");
            strSql.Append("ShopBranchName=@ShopBranchName,");
            strSql.Append("AddressId=@AddressId,");
            strSql.Append("AddressPath=@AddressPath,");
            strSql.Append("AddressDetail=@AddressDetail,");
            strSql.Append("ContactUser=@ContactUser,");
            strSql.Append("ContactPhone=@ContactPhone,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("ServeRadius=@ServeRadius,");
            strSql.Append("Longitude=@Longitude,");
            strSql.Append("Latitude=@Latitude,");
            strSql.Append("ShopImages=@ShopImages,");
            strSql.Append("IsStoreDelive=@IsStoreDelive,");
            strSql.Append("IsAboveSelf=@IsAboveSelf,");
            strSql.Append("StoreOpenStartTime=@StoreOpenStartTime,");
            strSql.Append("StoreOpenEndTime=@StoreOpenEndTime,");
            strSql.Append("IsRecommend=@IsRecommend,");
            strSql.Append("RecommendSequence=@RecommendSequence,");
            strSql.Append("DeliveFee=@DeliveFee,");
            strSql.Append("DeliveTotalFee=@DeliveTotalFee,");
            strSql.Append("FreeMailFee=@FreeMailFee");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ShopId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ShopBranchName", MySqlDbType.VarChar,30),
                    new MySqlParameter("@AddressId", MySqlDbType.Int32,11),
                    new MySqlParameter("@AddressPath", MySqlDbType.VarChar,50),
                    new MySqlParameter("@AddressDetail", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ContactUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ContactPhone", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Status", MySqlDbType.Int32,11),
                    new MySqlParameter("@CreateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@ServeRadius", MySqlDbType.Int32,11),
                    new MySqlParameter("@Longitude", MySqlDbType.Float),
                    new MySqlParameter("@Latitude", MySqlDbType.Float),
                    new MySqlParameter("@ShopImages", MySqlDbType.VarChar,500),
                    new MySqlParameter("@IsStoreDelive", MySqlDbType.Bit),
                    new MySqlParameter("@IsAboveSelf", MySqlDbType.Bit),
                    new MySqlParameter("@StoreOpenStartTime", MySqlDbType.Time),
                    new MySqlParameter("@StoreOpenEndTime", MySqlDbType.Time),
                    new MySqlParameter("@IsRecommend", MySqlDbType.Bit),
                    new MySqlParameter("@RecommendSequence", MySqlDbType.Int64,20),
                    new MySqlParameter("@DeliveFee", MySqlDbType.Int32,11),
                    new MySqlParameter("@DeliveTotalFee", MySqlDbType.Int32,11),
                    new MySqlParameter("@FreeMailFee", MySqlDbType.Int32,11),
                    new MySqlParameter("@Id", MySqlDbType.Int64,20)};
            parameters[0].Value = model.ShopId;
            parameters[1].Value = model.ShopBranchName;
            parameters[2].Value = model.AddressId;
            parameters[3].Value = model.AddressPath;
            parameters[4].Value = model.AddressDetail;
            parameters[5].Value = model.ContactUser;
            parameters[6].Value = model.ContactPhone;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.ServeRadius;
            parameters[10].Value = model.Longitude;
            parameters[11].Value = model.Latitude;
            parameters[12].Value = model.ShopImages;
            parameters[13].Value = model.IsStoreDelive;
            parameters[14].Value = model.IsAboveSelf;
            parameters[15].Value = model.StoreOpenStartTime;
            parameters[16].Value = model.StoreOpenEndTime;
            parameters[17].Value = model.IsRecommend;
            parameters[18].Value = model.RecommendSequence;
            parameters[19].Value = model.DeliveFee;
            parameters[20].Value = model.DeliveTotalFee;
            parameters[21].Value = model.FreeMailFee;
            parameters[22].Value = model.Id;

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
            strSql.Append("delete from himall_shopbranch ");
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
            strSql.Append("delete from himall_shopbranch ");
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
        public HPYL.Model.Shopbranch GetModel(long Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,ShopId,ShopBranchName,AddressId,AddressPath,AddressDetail,ContactUser,ContactPhone,Status,CreateDate,ServeRadius,Longitude,Latitude,ShopImages,IsStoreDelive,IsAboveSelf,StoreOpenStartTime,StoreOpenEndTime,IsRecommend,RecommendSequence,DeliveFee,DeliveTotalFee,FreeMailFee from himall_shopbranch ");
            strSql.Append(" where Id="+Id);
         
            HPYL.Model.Shopbranch model = new HPYL.Model.Shopbranch();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
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
        public HPYL.Model.Shopbranch DataRowToModel(DataRow row)
        {
            HPYL.Model.Shopbranch model = new HPYL.Model.Shopbranch();
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
                if (row["ShopBranchName"] != null)
                {
                    model.ShopBranchName = row["ShopBranchName"].ToString();
                }
                if (row["AddressId"] != null && row["AddressId"].ToString() != "")
                {
                    model.AddressId = int.Parse(row["AddressId"].ToString());
                }
                if (row["AddressPath"] != null)
                {
                    model.AddressPath = row["AddressPath"].ToString();
                }
                if (row["AddressDetail"] != null)
                {
                    model.AddressDetail = row["AddressDetail"].ToString();
                }
                if (row["ContactUser"] != null)
                {
                    model.ContactUser = row["ContactUser"].ToString();
                }
                if (row["ContactPhone"] != null)
                {
                    model.ContactPhone = row["ContactPhone"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["ServeRadius"] != null && row["ServeRadius"].ToString() != "")
                {
                    model.ServeRadius = int.Parse(row["ServeRadius"].ToString());
                }
                if (row["Longitude"] != null && row["Longitude"].ToString() != "")
                {
                    model.Longitude = decimal.Parse(row["Longitude"].ToString());
                }
                if (row["Latitude"] != null && row["Latitude"].ToString() != "")
                {
                    model.Latitude = decimal.Parse(row["Latitude"].ToString());
                }
                if (row["ShopImages"] != null)
                {
                    model.ShopImages = row["ShopImages"].ToString();
                }
                if (row["IsStoreDelive"] != null && row["IsStoreDelive"].ToString() != "")
                {
                    if ((row["IsStoreDelive"].ToString() == "1") || (row["IsStoreDelive"].ToString().ToLower() == "true"))
                    {
                        model.IsStoreDelive = true;
                    }
                    else
                    {
                        model.IsStoreDelive = false;
                    }
                }
                if (row["IsAboveSelf"] != null && row["IsAboveSelf"].ToString() != "")
                {
                    if ((row["IsAboveSelf"].ToString() == "1") || (row["IsAboveSelf"].ToString().ToLower() == "true"))
                    {
                        model.IsAboveSelf = true;
                    }
                    else
                    {
                        model.IsAboveSelf = false;
                    }
                }
                if (row["StoreOpenStartTime"] != null && row["StoreOpenStartTime"].ToString() != "")
                {
                    model.StoreOpenStartTime = DateTime.Parse(row["StoreOpenStartTime"].ToString());
                }
                if (row["StoreOpenEndTime"] != null && row["StoreOpenEndTime"].ToString() != "")
                {
                    model.StoreOpenEndTime = DateTime.Parse(row["StoreOpenEndTime"].ToString());
                }
                if (row["IsRecommend"] != null && row["IsRecommend"].ToString() != "")
                {
                    if ((row["IsRecommend"].ToString() == "1") || (row["IsRecommend"].ToString().ToLower() == "true"))
                    {
                        model.IsRecommend = true;
                    }
                    else
                    {
                        model.IsRecommend = false;
                    }
                }
                if (row["RecommendSequence"] != null && row["RecommendSequence"].ToString() != "")
                {
                    model.RecommendSequence = long.Parse(row["RecommendSequence"].ToString());
                }
                if (row["DeliveFee"] != null && row["DeliveFee"].ToString() != "")
                {
                    model.DeliveFee = int.Parse(row["DeliveFee"].ToString());
                }
                if (row["DeliveTotalFee"] != null && row["DeliveTotalFee"].ToString() != "")
                {
                    model.DeliveTotalFee = int.Parse(row["DeliveTotalFee"].ToString());
                }
                if (row["FreeMailFee"] != null && row["FreeMailFee"].ToString() != "")
                {
                    model.FreeMailFee = int.Parse(row["FreeMailFee"].ToString());
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
            strSql.Append("select Id,ShopId,ShopBranchName,AddressId,AddressPath,AddressDetail,ContactUser,ContactPhone,Status,CreateDate,ServeRadius,Longitude,Latitude,ShopImages,IsStoreDelive,IsAboveSelf,StoreOpenStartTime,StoreOpenEndTime,IsRecommend,RecommendSequence,DeliveFee,DeliveTotalFee,FreeMailFee ");
            strSql.Append(" FROM himall_shopbranch ");
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
            strSql.Append("select count(1) FROM himall_shopbranch ");
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
            strSql.Append(")AS Row, T.*  from himall_shopbranch T ");
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
			parameters[0].Value = "himall_shopbranch";
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
