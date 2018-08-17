/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.DAL.DoctorAdvice
*文件名：  DoctorAdviceDAL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 14:12:41

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 14:12:41
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
    public class DoctorAdviceDAL
    {

        /// <summary>
        /// 获取内容类表
        /// </summary>
        /// <param name="hFT_ID"></param>
        /// <returns></returns>
        public List<AdviceArticle> GetAdviceArticleList(long hFT_ID)
        {
            string strSql = "select HAA_ID,HFT_ID,HAA_Title,HAA_PicUrl,HAA_Content,HAA_State from hpyl_advicearticle where HFT_ID=" + hFT_ID + " and HAA_State=1";
            return new Repository<AdviceArticle>().FindList(strSql).ToList();
        }

        /// <summary>
        /// 关联后写入随访计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InFollowPlan(BaseDoctorFollowPlan model)
        {

            //根据模板获取随访内容
            int errorcount = 0;
            List<DoctorFollowContent> PlanContent = FollowList(model.HAA_ID);
            foreach (DoctorFollowContent item in PlanContent)
            {
                DoctorFollowPlan pmodel = new DoctorFollowPlan();
                pmodel.HDP_Content = item.HDC_Content;
                pmodel.HDP_CreateTime = item.HDC_StratTime;
                pmodel.HDP_DoctorId = model.HDP_DoctorId;
                pmodel.HDP_PatientId = model.HDP_PatientId;
                pmodel.HDP_Remind = model.HDP_Remind;
                pmodel.HDP_State = 0;
                pmodel.HDP_UserId = model.HDP_UserId;
                pmodel.HAA_ID = model.HAA_ID;
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
        /// 新增随访计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool AddPlan(DoctorFollowPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_doctorfollowplan(");
            strSql.Append("HAA_ID,HDP_CreateTime,HDP_UserId,HDP_Remind,HDP_Content,HDP_DoctorId,HDP_PatientId,HDP_State)");
            strSql.Append(" values (");
            strSql.Append("@HAA_ID,@HDP_CreateTime,@HDP_UserId,@HDP_Remind,@HDP_Content,@HDP_DoctorId,@HDP_PatientId,@HDP_State)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HAA_ID",  model.HAA_ID),
                    new MySqlParameter("@HDP_CreateTime", model.HDP_CreateTime),
                    new MySqlParameter("@HDP_UserId", model.HDP_UserId),
                    new MySqlParameter("@HDP_Remind",  model.HDP_Remind),
                    new MySqlParameter("@HDP_Content", model.HDP_Content),
                    new MySqlParameter("@HDP_DoctorId",  model.HDP_DoctorId),
                    new MySqlParameter("@HDP_PatientId", model.HDP_PatientId),
                    new MySqlParameter("@HDP_State",model.HDP_State)};

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
        /// 获取内容随访计划列表
        /// </summary>
        /// <param name="hAA_ID"></param>
        /// <returns></returns>
        public List<DoctorFollowContent> FollowList(long hAA_ID)
        {
            string strSql = "select HDC_ID,HAA_ID,HDC_Days,HDC_Content,date_format(date_add(now(), interval HDC_Days day), '%Y-%m-%d %H:%i:%s' )HDC_StratTime from hpyl_doctorfollowcontent where HAA_ID=" + hAA_ID + "";
            return new Repository<DoctorFollowContent>().FindList(strSql).ToList();
        }

        #region  获取实体

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AdviceArticle GetModel(long HAA_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select HAA_ID,HFT_ID,HAA_Title,HAA_PicUrl,HAA_Content,HAA_State from hpyl_advicearticle ");
            strSql.Append(" where HAA_ID=@HAA_ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HAA_ID", HAA_ID)
            };
            parameters[0].Value = HAA_ID;
            AdviceArticle model = new AdviceArticle();
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
        public AdviceArticle DataRowToModel(DataRow row)
        {
            AdviceArticle model = new AdviceArticle();
            if (row != null)
            {
                if (row["HAA_ID"] != null && row["HAA_ID"].ToString() != "")
                {
                    model.HAA_ID = long.Parse(row["HAA_ID"].ToString());
                }
                if (row["HFT_ID"] != null && row["HFT_ID"].ToString() != "")
                {
                    model.HFT_ID = long.Parse(row["HFT_ID"].ToString());
                }
                if (row["HAA_Title"] != null)
                {
                    model.HAA_Title = row["HAA_Title"].ToString();
                }
                if (row["HAA_PicUrl"] != null)
                {
                    model.HAA_PicUrl = row["HAA_PicUrl"].ToString();
                }
                if (row["HAA_Content"] != null)
                {
                    model.HAA_Content = row["HAA_Content"].ToString();
                }
                if (row["HAA_State"] != null && row["HAA_State"].ToString() != "")
                {
                    model.HAA_State = int.Parse(row["HAA_State"].ToString());
                }
            }
            return model;
        }
        #endregion 
    }
}
