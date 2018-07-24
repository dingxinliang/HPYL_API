/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.DAL
*文件名：  FollowTypeDAL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/14 21:25:41

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/14 21:25:41
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
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
    public class FollowPlanDAL
    {
        
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <param name="clinicId">诊所ID</param>
        /// <returns></returns>
        public DataTable FollowTypeList(long clinicId)
        {
            string strSql = "select HFT_ID,HFT_Name,HFT_ParentId,HFT_UserId from HPYL_FollowType where HFT_ShopId=@HFT_ShopId and HFT_ParentId=0 and HFT_State=1 and HFT_UserId=0 order by HFT_Layer";
            MySqlParameter[] parameters = {
                        new MySqlParameter("@HFT_ShopId",clinicId)
            };
            return DbHelperMySQL.Query(strSql, parameters).Tables[0];
        }

        public bool InFollowPlan(BaseFollowPlan model)
        {

            //根据模板获取随访内容
            int errorcount = 0;
            List<FollowPlanContent> PlanContent = GetTemPlateContent(model.HTP_ID);
            foreach (FollowPlanContent item in PlanContent)
            {
                FollowPlan pmodel = new FollowPlan();
                pmodel.HFP_Content = item.HFC_Content;
                pmodel.HFP_CreateTime =item.HFC_StartTime;
                pmodel.HFP_DoctorId = model.HFP_DoctorId;
                pmodel.HFP_Name = model.HFP_Name;
                pmodel.HFP_PatientId = model.HFP_PatientId;
                pmodel.HFP_Remind = model.HFP_Remind;
                pmodel.HFP_State = 0;
                pmodel.HFP_UserId = model.HFP_UserId;
                pmodel.HTP_ID = model.HTP_ID;
                if (!AddPlan(pmodel))
                {
                    errorcount++;
                }
            }
            if (errorcount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 删除随访计划
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="hFP_ID"></param>
        /// <returns></returns>
        public bool DelFollowPlan(long userId, long hFP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from hpyl_followplan ");
            strSql.Append(" where HFP_ID="+ hFP_ID +" and HFP_UserId=" + userId + "");
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
        /// 获取时间分页数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetPageDate(Pagination pagination, long userId)
        {
            string strSql = @"SELECT date_format(HFP_CreateTime, '%Y-%m-%d' )HFP_StartTime from hpyl_followplan 
                where  HFP_UserId=" + userId + " group by date_format(HFP_CreateTime, '%Y-%m-%d' )";
            return new Repository<FollowPlanContent>().FindTable(strSql, pagination);

        }


        public List<FollowPlan> GetPageInfo(long userId, string date)
        {
            string strSql = "select HFP_ID, HTP_ID, HFP_Name, date_format(HFP_CreateTime, '%Y-%m-%d' )HFP_CreateTime, HFP_UserId, HFP_Remind, HFP_Content, HFP_DoctorId, HFP_PatientId, HFP_State from hpyl_followplan " +
                "where HFP_UserId=" + userId + " and date_format(HFP_CreateTime, '%Y-%m-%d' )='" + date + "'";
            return new Repository<FollowPlan>().FindList(strSql).ToList();
        }



        #region 得到一个对象实体

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FollowPlan GetModel(long HFP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select HFP_ID,HTP_ID,HFP_Name,HFP_CreateTime,HFP_UserId,HFP_Remind,HFP_Content,HFP_DoctorId,HFP_PatientId,HFP_State from hpyl_followplan ");
            strSql.Append(" where HFP_ID=@HFP_ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HFP_ID", HFP_ID)
            };

            FollowPlan model = new FollowPlan();
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
		public FollowPlan DataRowToModel(DataRow row)
        {
            FollowPlan model = new FollowPlan();
            if (row != null)
            {
                if (row["HFP_ID"] != null && row["HFP_ID"].ToString() != "")
                {
                    model.HFP_ID = long.Parse(row["HFP_ID"].ToString());
                }
                if (row["HTP_ID"] != null && row["HTP_ID"].ToString() != "")
                {
                    model.HTP_ID = long.Parse(row["HTP_ID"].ToString());
                }
                if (row["HFP_Name"] != null)
                {
                    model.HFP_Name = row["HFP_Name"].ToString();
                }
                if (row["HFP_CreateTime"] != null && row["HFP_CreateTime"].ToString() != "")
                {
                    model.HFP_CreateTime =row["HFP_CreateTime"].ToString();
                }
                if (row["HFP_UserId"] != null && row["HFP_UserId"].ToString() != "")
                {
                    model.HFP_UserId = long.Parse(row["HFP_UserId"].ToString());
                }
                if (row["HFP_Remind"] != null && row["HFP_Remind"].ToString() != "")
                {
                    model.HFP_Remind = int.Parse(row["HFP_Remind"].ToString());
                }
                if (row["HFP_Content"] != null)
                {
                    model.HFP_Content = row["HFP_Content"].ToString();
                }
                if (row["HFP_DoctorId"] != null && row["HFP_DoctorId"].ToString() != "")
                {
                    model.HFP_DoctorId = long.Parse(row["HFP_DoctorId"].ToString());
                }
                if (row["HFP_PatientId"] != null && row["HFP_PatientId"].ToString() != "")
                {
                    model.HFP_PatientId = long.Parse(row["HFP_PatientId"].ToString());
                }
                if (row["HFP_State"] != null && row["HFP_State"].ToString() != "")
                {
                    model.HFP_State = int.Parse(row["HFP_State"].ToString());
                }
            }
            return model;
        }
        #endregion
       
        /// <summary>
        /// 新增随访计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool AddPlan(FollowPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_followplan(");
            strSql.Append("HTP_ID,HFP_Name,HFP_CreateTime,HFP_UserId,HFP_Remind,HFP_Content,HFP_DoctorId,HFP_PatientId,HFP_State)");
            strSql.Append(" values (");
            strSql.Append("@HTP_ID,@HFP_Name,@HFP_CreateTime,@HFP_UserId,@HFP_Remind,@HFP_Content,@HFP_DoctorId,@HFP_PatientId,@HFP_State)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HTP_ID", model.HTP_ID),
                    new MySqlParameter("@HFP_Name", model.HFP_Name),
                    new MySqlParameter("@HFP_CreateTime", model.HFP_CreateTime),
                    new MySqlParameter("@HFP_UserId",model.HFP_UserId),
                    new MySqlParameter("@HFP_Remind", model.HFP_Remind),
                    new MySqlParameter("@HFP_Content",model.HFP_Content),
                    new MySqlParameter("@HFP_DoctorId",model.HFP_DoctorId),
                    new MySqlParameter("@HFP_PatientId", model.HFP_PatientId),
                    new MySqlParameter("@HFP_State",model.HFP_State)};
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
        /// 更新随访计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ChangeFollowPlan(FollowPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update hpyl_followplan set ");
            strSql.Append("HTP_ID=@HTP_ID,");
            strSql.Append("HFP_Name=@HFP_Name,");
            strSql.Append("HFP_CreateTime=@HFP_CreateTime,");
            strSql.Append("HFP_UserId=@HFP_UserId,");
            strSql.Append("HFP_Remind=@HFP_Remind,");
            strSql.Append("HFP_Content=@HFP_Content,");
            strSql.Append("HFP_DoctorId=@HFP_DoctorId,");
            strSql.Append("HFP_PatientId=@HFP_PatientId,");
            strSql.Append("HFP_State=0");
            strSql.Append(" where HFP_ID=@HFP_ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HTP_ID", model.HTP_ID),
                    new MySqlParameter("@HFP_Name", model.HFP_Name),
                    new MySqlParameter("@HFP_CreateTime", model.HFP_CreateTime),
                    new MySqlParameter("@HFP_UserId", model.HFP_UserId),
                    new MySqlParameter("@HFP_Remind",  model.HFP_Remind),
                    new MySqlParameter("@HFP_Content",  model.HFP_Content),
                    new MySqlParameter("@HFP_DoctorId",  model.HFP_DoctorId),
                    new MySqlParameter("@HFP_PatientId",  model.HFP_PatientId),
                    new MySqlParameter("@HFP_ID", model.HFP_ID)};
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
        /// 获取一级+二级分类
        /// </summary>
        /// <param name="clinicId">诊所ID</param>
        /// <param name="userId">医生ID</param>
        /// <param name="parentId">父类ID</param>
        /// <returns></returns>
        public DataTable FollowTypeSecondList(long clinicId , long userId, long parentId)
        {
            string strSql = "select HFT_ID,HFT_Name,HFT_ParentId,HFT_UserId from HPYL_FollowType where HFT_ShopId=@HFT_ShopId and HFT_ParentId=@HFT_ParentId and HFT_State=1 and HFT_UserId=@HFT_UserId order by HFT_Layer";
            MySqlParameter[] parameters = {
                        new MySqlParameter("@HFT_ShopId",clinicId),
                        new MySqlParameter("@HFT_ParentId",parentId),
                        new MySqlParameter("@HFT_UserId",userId)
            };
            return DbHelperMySQL.Query(strSql, parameters).Tables[0];
        }

        /// <summary>
        /// 获取对应分类模板列表
        /// </summary>
        /// <param name="clinicId"></param>
        /// <returns></returns>
        public List<BaseFollowTemPlate> GetFollowTemPlateList(long  Id)
        {
            string strSql = "select HTP_ID,HFT_ID,HTP_Name from HPYL_FollowTemPlate where HFT_ID="+Id+" and HTP_State=1";
            return new Repository<BaseFollowTemPlate>().FindList(strSql).ToList();
        } 
        
        /// <summary>
        /// 获取对应模板内容
        /// </summary>
        /// <param name="clinicId"></param>
        /// <returns></returns>
        public List<FollowPlanContent> GetTemPlateContent(long  Id)
        {
            string strSql = "select HTP_ID,HFC_ID,HFC_Days,HFC_Content,date_format(date_add(now(), interval HFC_Days day), '%Y-%m-%d %H:%i:%s' )HFC_StartTime from HPYL_FollowPlanContent where HTP_ID=" + Id+"";
            return new Repository<FollowPlanContent>().FindList(strSql).ToList();
        }

    }
}
 
