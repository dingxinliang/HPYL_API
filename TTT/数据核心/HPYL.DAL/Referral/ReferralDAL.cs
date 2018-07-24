/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.DAL.Referral
*文件名：  ReferralDAL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 22:55:34

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 22:55:34
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;

namespace HPYL.DAL
{
    public class ReferralDAL
    {
        #region  新增转诊
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool InReferral(BaseReferrallog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_referrallog(");
            strSql.Append("HRL_PatientId,HRL_Info,HRL_DoctorId,HRL_Commission,HRL_UserID,HRL_Remark)");
            strSql.Append(" values (");
            strSql.Append("@HRL_PatientId,@HRL_Info,@HRL_DoctorId,@HRL_Commission,@HRL_UserID,@HRL_Remark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HRL_PatientId", model.HRL_PatientId),
                    new MySqlParameter("@HRL_Info", model.HRL_Info),
                    new MySqlParameter("@HRL_DoctorId", model.HRL_DoctorId),
                    new MySqlParameter("@HRL_Commission", model.HRL_Commission),
                    new MySqlParameter("@HRL_UserID", model.HRL_UserID),
                    new MySqlParameter("@HRL_Remark", model.HRL_Remark)};

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
        #endregion
    }
}
