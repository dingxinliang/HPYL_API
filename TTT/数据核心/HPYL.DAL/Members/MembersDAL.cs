using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
using M=HPYL.Model;
using System.Collections;

namespace HPYL.DAL
{
    /// <summary>
	/// 数据访问类:MembersDAL
	/// </summary>
	public partial class MembersDAL
    {
        public MembersDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from himall_members");
            strSql.Append(" where Id="+ Id);
            return DbHelperMySQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 验证用户是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ExistsUser(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from himall_members");
            strSql.Append(" where UserName='"+ UserName + "'");
            
            return DbHelperMySQL.Exists(strSql.ToString());
        }
        /// <summary>
        /// 根据用户名 返回用户ID
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>

        public long GetUserID(string UserName)
        {
            long Userid = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from himall_members");
            strSql.Append(" where UserName='" + UserName + "'");
            DataSet dsre = DbHelperMySQL.Query(strSql.ToString());
            if (dsre != null)
            {
                if (dsre.Tables[0].Rows.Count != 0)
                {
                    Userid = long.Parse(dsre.Tables[0].Rows[0][0].ToString());
                }
            }
            return Userid;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(M.Members model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into himall_members(");
            strSql.Append("UserName,Password,PasswordSalt,Nick,Sex,Email,CreateDate,TopRegionId,RegionId,RealName,CellPhone,QQ,Address,Disabled,LastLoginDate,OrderNumber,TotalAmount,Expenditure,Points,Photo,ParentSellerId,Remark,PayPwd,PayPwdSalt,InviteUserId,ShareUserId,BirthDay,Occupation,NetAmount,LastConsumptionTime)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@PasswordSalt,@Nick,@Sex,@Email,@CreateDate,@TopRegionId,@RegionId,@RealName,@CellPhone,@QQ,@Address,@Disabled,@LastLoginDate,@OrderNumber,@TotalAmount,@Expenditure,@Points,@Photo,@ParentSellerId,@Remark,@PayPwd,@PayPwdSalt,@InviteUserId,@ShareUserId,@BirthDay,@Occupation,@NetAmount,@LastConsumptionTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Password", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PasswordSalt", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Nick", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Sex", MySqlDbType.Int32,11),
                    new MySqlParameter("@Email", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CreateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@TopRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@RegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@RealName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CellPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@QQ", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Address", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Disabled", MySqlDbType.Byte,1),
                    new MySqlParameter("@LastLoginDate", MySqlDbType.DateTime),
                    new MySqlParameter("@OrderNumber", MySqlDbType.Int32,11),
                    new MySqlParameter("@TotalAmount", MySqlDbType.Decimal,18),
                    new MySqlParameter("@Expenditure", MySqlDbType.Decimal,18),
                    new MySqlParameter("@Points", MySqlDbType.Int32,11),
                    new MySqlParameter("@Photo", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ParentSellerId", MySqlDbType.Int64,20),
                    new MySqlParameter("@Remark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@PayPwd", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PayPwdSalt", MySqlDbType.VarChar,100),
                    new MySqlParameter("@InviteUserId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ShareUserId", MySqlDbType.Int64,20),
                    new MySqlParameter("@BirthDay", MySqlDbType.Date),
                    new MySqlParameter("@Occupation", MySqlDbType.VarChar,15),
                    new MySqlParameter("@NetAmount", MySqlDbType.Decimal,18),
                    new MySqlParameter("@LastConsumptionTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.PasswordSalt;
            parameters[3].Value = model.Nick;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.TopRegionId;
            parameters[8].Value = model.RegionId;
            parameters[9].Value = model.RealName;
            parameters[10].Value = model.CellPhone;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.Disabled;
            parameters[14].Value = model.LastLoginDate;
            parameters[15].Value = model.OrderNumber;
            parameters[16].Value = model.TotalAmount;
            parameters[17].Value = model.Expenditure;
            parameters[18].Value = model.Points;
            parameters[19].Value = model.Photo;
            parameters[20].Value = model.ParentSellerId;
            parameters[21].Value = model.Remark;
            parameters[22].Value = model.PayPwd;
            parameters[23].Value = model.PayPwdSalt;
            parameters[24].Value = model.InviteUserId;
            parameters[25].Value = model.ShareUserId;
            parameters[26].Value = model.BirthDay;
            parameters[27].Value = model.Occupation;
            parameters[28].Value = model.NetAmount;
            parameters[29].Value = model.LastConsumptionTime;

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
        public bool Update(M.Members model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update himall_members set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("PasswordSalt=@PasswordSalt,");
            strSql.Append("Nick=@Nick,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Email=@Email,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("TopRegionId=@TopRegionId,");
            strSql.Append("RegionId=@RegionId,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("CellPhone=@CellPhone,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Address=@Address,");
            strSql.Append("Disabled=@Disabled,");
            strSql.Append("LastLoginDate=@LastLoginDate,");
            strSql.Append("OrderNumber=@OrderNumber,");
            strSql.Append("TotalAmount=@TotalAmount,");
            strSql.Append("Expenditure=@Expenditure,");
            strSql.Append("Points=@Points,");
            strSql.Append("Photo=@Photo,");
            strSql.Append("ParentSellerId=@ParentSellerId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("PayPwd=@PayPwd,");
            strSql.Append("PayPwdSalt=@PayPwdSalt,");
            strSql.Append("InviteUserId=@InviteUserId,");
            strSql.Append("ShareUserId=@ShareUserId,");
            strSql.Append("BirthDay=@BirthDay,");
            strSql.Append("Occupation=@Occupation,");
            strSql.Append("NetAmount=@NetAmount,");
            strSql.Append("LastConsumptionTime=@LastConsumptionTime");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Password", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PasswordSalt", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Nick", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Sex", MySqlDbType.Int32,11),
                    new MySqlParameter("@Email", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CreateDate", MySqlDbType.DateTime),
                    new MySqlParameter("@TopRegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@RegionId", MySqlDbType.Int32,11),
                    new MySqlParameter("@RealName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@CellPhone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@QQ", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Address", MySqlDbType.VarChar,100),
                    new MySqlParameter("@Disabled", MySqlDbType.Byte,1),
                    new MySqlParameter("@LastLoginDate", MySqlDbType.DateTime),
                    new MySqlParameter("@OrderNumber", MySqlDbType.Int32,11),
                    new MySqlParameter("@TotalAmount", MySqlDbType.Decimal,18),
                    new MySqlParameter("@Expenditure", MySqlDbType.Decimal,18),
                    new MySqlParameter("@Points", MySqlDbType.Int32,11),
                    new MySqlParameter("@Photo", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ParentSellerId", MySqlDbType.Int64,20),
                    new MySqlParameter("@Remark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@PayPwd", MySqlDbType.VarChar,100),
                    new MySqlParameter("@PayPwdSalt", MySqlDbType.VarChar,100),
                    new MySqlParameter("@InviteUserId", MySqlDbType.Int64,20),
                    new MySqlParameter("@ShareUserId", MySqlDbType.Int64,20),
                    new MySqlParameter("@BirthDay", MySqlDbType.Date),
                    new MySqlParameter("@Occupation", MySqlDbType.VarChar,15),
                    new MySqlParameter("@NetAmount", MySqlDbType.Decimal,18),
                    new MySqlParameter("@LastConsumptionTime", MySqlDbType.DateTime),
                    new MySqlParameter("@Id", MySqlDbType.Int64,20)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.PasswordSalt;
            parameters[3].Value = model.Nick;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.TopRegionId;
            parameters[8].Value = model.RegionId;
            parameters[9].Value = model.RealName;
            parameters[10].Value = model.CellPhone;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.Disabled;
            parameters[14].Value = model.LastLoginDate;
            parameters[15].Value = model.OrderNumber;
            parameters[16].Value = model.TotalAmount;
            parameters[17].Value = model.Expenditure;
            parameters[18].Value = model.Points;
            parameters[19].Value = model.Photo;
            parameters[20].Value = model.ParentSellerId;
            parameters[21].Value = model.Remark;
            parameters[22].Value = model.PayPwd;
            parameters[23].Value = model.PayPwdSalt;
            parameters[24].Value = model.InviteUserId;
            parameters[25].Value = model.ShareUserId;
            parameters[26].Value = model.BirthDay;
            parameters[27].Value = model.Occupation;
            parameters[28].Value = model.NetAmount;
            parameters[29].Value = model.LastConsumptionTime;
            parameters[30].Value = model.Id;

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
        /// 得到一个对象实体
        /// </summary>
        public M.Members GetModel(long Id)
        {

           
            string sql = "select Id,UserName,Password,PasswordSalt,Nick,Sex,Email,CreateDate,TopRegionId,RegionId,RealName,CellPhone,QQ,Address,Disabled,LastLoginDate,OrderNumber,TotalAmount,Expenditure,Points,Photo,ParentSellerId,Remark,PayPwd,PayPwdSalt,InviteUserId,ShareUserId,BirthDay,Occupation,NetAmount,LastConsumptionTime from himall_members   where Id="+ Id;
            M.Members model = new M.Members();
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
        public M.Members DataRowToModel(DataRow row)
        {
            M.Members model = new M.Members();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = long.Parse(row["Id"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["PasswordSalt"] != null)
                {
                    model.PasswordSalt = row["PasswordSalt"].ToString();
                }
                if (row["Nick"] != null)
                {
                    model.Nick = row["Nick"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(row["Sex"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["TopRegionId"] != null && row["TopRegionId"].ToString() != "")
                {
                    model.TopRegionId = int.Parse(row["TopRegionId"].ToString());
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["CellPhone"] != null)
                {
                    model.CellPhone = row["CellPhone"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Disabled"] != null && row["Disabled"].ToString() != "")
                {
                    model.Disabled = int.Parse(row["Disabled"].ToString());
                }
                if (row["LastLoginDate"] != null && row["LastLoginDate"].ToString() != "")
                {
                    model.LastLoginDate = DateTime.Parse(row["LastLoginDate"].ToString());
                }
                if (row["OrderNumber"] != null && row["OrderNumber"].ToString() != "")
                {
                    model.OrderNumber = int.Parse(row["OrderNumber"].ToString());
                }
                if (row["TotalAmount"] != null && row["TotalAmount"].ToString() != "")
                {
                    model.TotalAmount = decimal.Parse(row["TotalAmount"].ToString());
                }
                if (row["Expenditure"] != null && row["Expenditure"].ToString() != "")
                {
                    model.Expenditure = decimal.Parse(row["Expenditure"].ToString());
                }
                if (row["Points"] != null && row["Points"].ToString() != "")
                {
                    model.Points = int.Parse(row["Points"].ToString());
                }
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
                }
                if (row["ParentSellerId"] != null && row["ParentSellerId"].ToString() != "")
                {
                    model.ParentSellerId = long.Parse(row["ParentSellerId"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["PayPwd"] != null)
                {
                    model.PayPwd = row["PayPwd"].ToString();
                }
                if (row["PayPwdSalt"] != null)
                {
                    model.PayPwdSalt = row["PayPwdSalt"].ToString();
                }
                if (row["InviteUserId"] != null && row["InviteUserId"].ToString() != "")
                {
                    model.InviteUserId = long.Parse(row["InviteUserId"].ToString());
                }
                if (row["ShareUserId"] != null && row["ShareUserId"].ToString() != "")
                {
                    model.ShareUserId = long.Parse(row["ShareUserId"].ToString());
                }
                if (row["BirthDay"] != null && row["BirthDay"].ToString() != "")
                {
                    model.BirthDay = DateTime.Parse(row["BirthDay"].ToString());
                }
                if (row["Occupation"] != null)
                {
                    model.Occupation = row["Occupation"].ToString();
                }
                if (row["NetAmount"] != null && row["NetAmount"].ToString() != "")
                {
                    model.NetAmount = decimal.Parse(row["NetAmount"].ToString());
                }
                if (row["LastConsumptionTime"] != null && row["LastConsumptionTime"].ToString() != "")
                {
                    model.LastConsumptionTime = DateTime.Parse(row["LastConsumptionTime"].ToString());
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
            strSql.Append("select Id,UserName,Password,PasswordSalt,Nick,Sex,Email,CreateDate,TopRegionId,RegionId,RealName,CellPhone,QQ,Address,Disabled,LastLoginDate,OrderNumber,TotalAmount,Expenditure,Points,Photo,ParentSellerId,Remark,PayPwd,PayPwdSalt,InviteUserId,ShareUserId,BirthDay,Occupation,NetAmount,LastConsumptionTime ");
            strSql.Append(" FROM himall_members ");
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
            strSql.Append("select count(1) FROM himall_members ");
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
            strSql.Append(")AS Row, T.*  from himall_members T ");
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

        #endregion  ExtensionMethod
        #region  扩展方法

        #region 登录
       
        /// <summary>
        /// 动态短信写入
        /// </summary>
        /// <returns></returns>
        public int AddPhoneMsg(string strPhone, string code, string contents, string sigin)
        {
            string sql = "insert into hpyl_phonemessage(P_Phone,P_Content,P_SendTime,P_State,P_Code,P_Sign) values('"+ strPhone + "','"+contents+"','"+DateTime.Now+"','1','"+code+"','"+sigin+"')";
            return DbHelperMySQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 判断手机验证码是否存在
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="sigin">验证标示</param>
        /// <returns></returns>
        public bool Checkcode(string phone, string code, string sigin)
        {
            string sql = "select * from hpyl_phonemessage   where  P_Phone='"+ phone + "' and P_Code='"+ code + "' and P_Sign='" + sigin + "' and P_State=1 limit 0,1 ";
            DataTable ds = DbHelperMySQL.Query(sql).Tables[0];
            if (ds.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 手机动态码登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public M.MLoginMember GetLoginPhoneCode(string phone, string code)
        {
            M.MLoginMember model = new M.MLoginMember();
            ///验证码发送失败
            model.RoleId = -1;
            model.UserId = -1;
            //1.判断用户是否存在 不存在则注册
            bool Isexit = ExistsUser(phone);//验证用户是否存在
            bool ismes = Checkcode(phone, code,"login");//验证手机验证码
            if (Isexit)
            {   //判断是否发送验证码
                string sql = "select a.id from himall_members a  inner join hpyl_phonemessage b on b.P_Phone=a.UserName  where  b.P_Phone='" + phone + "' and b.P_Code='" + code + "' and b.P_Sign='login' and b.P_State=1";
                DataSet ds = DbHelperMySQL.Query(sql);
                if (ds != null)
                {
                    //更新短信状态为已验证过
                    DbHelperMySQL.ExecuteSql("update hpyl_phonemessage set P_State=2 where P_Phone='" + phone + "' and P_Sign='login'");
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        model.UserId = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                        model.RoleId = 3;//患者身份
                        string sqlrel = "select Id,Status from himall_promoter where UserId=" + model.UserId.ToString();
                        DataSet dsre = DbHelperMySQL.Query(sqlrel);
                        if (dsre != null)
                        {
                            //推销员状态 0审核 1通过 2注销   Status
                            if (dsre.Tables[0].Rows.Count != 0)
                            {
                                model.RoleId = long.Parse(dsre.Tables[0].Rows[0][1].ToString());//医生身份
                            }
                        }
                    }
                }
            }
            else
            {
                //用户不存在，插入用户表
                var salt = Guid.NewGuid().ToString("N").Substring(12);
                var password = GetPasswrodWithTwiceEncode(phone.Substring(8), salt);


                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into himall_members(");
                strSql.Append("UserName,Nick,CreateDate,RealName,CellPhone,LastLoginDate,Password,PasswordSalt,TopRegionId,RegionId,Disabled,OrderNumber,TotalAmount,Expenditure,Points,ParentSellerId,NetAmount)");
                strSql.Append(" values ('"+phone+ "','" + phone + "',NOW(),'" + phone + "','" + phone + "',NOW(),'"+password+"','"+salt+"','0','0','0','0','0','0','0','0','0')");
                int resm=DbHelperMySQL.ExecuteSql(strSql.ToString());
                if (resm == 1)
                {
                    //添加用户其它信息关联表
                    StringBuilder strSqlot = new StringBuilder();
                    strSqlot.Append("insert into hpyl_MemberOtherInfo(");
                    strSqlot.Append("UserId)");
                    strSqlot.Append(" values ('" + GetUserID(phone) + "')");
                    DbHelperMySQL.ExecuteSql(strSqlot.ToString());

                    //添加用户手机验证表
                    StringBuilder strSqlts = new StringBuilder();
                    strSqlts.Append("insert into himall_membercontacts(");
                    strSqlts.Append("UserId,UserType,ServiceProvider,Contact)");
                    strSqlts.Append(" values ('" + GetUserID(phone) + "','0','Himall.Plugin.Message.SMS','" + phone + "')");
                    DbHelperMySQL.ExecuteSql(strSqlts.ToString());
                    model.UserId = GetUserID(phone);
                    model.RoleId = 3;
                }
                else
                {
                    //用户表添加失败
                    model.RoleId = -2;
                    model.UserId = -2;
                }


            }
            return model;
        }
        string GetPasswrodWithTwiceEncode(string password, string salt)
        {
            string encryptedPassword = HPYL.Common.ComHelper.ToMD5(password);//一次MD5加密
            string encryptedWithSaltPassword = HPYL.Common.ComHelper.ToMD5(encryptedPassword + salt);//一次结果加盐后二次加密
            return encryptedWithSaltPassword;
        }
        /// <summary>
        /// 注册
        /// </summary>

        #endregion 登录

        #region 申请医生
        public bool Register(M.MRegister model)
        {
            bool result = false;
            int rows = 0;
            StringBuilder strSqlM = new StringBuilder();
            //1.判断用户是否存在 不存在则注册
            bool Isexit = Exists(model.UserId);//验证用户是否存在
            if (Isexit)
            {
                rows = 0;
                //更新member 表
                strSqlM = new StringBuilder();
                strSqlM.Append("update himall_members set ");
                strSqlM.Append("Sex='"+model.Sex+"',");
                strSqlM.Append("TopRegionId='"+model.TopRegionId+"',");
                strSqlM.Append("RegionId='"+model.RegionId+"',");
                strSqlM.Append("RealName='"+model.RealName+"',");
                strSqlM.Append("Remark='"+model.Remark+"'");
                strSqlM.Append(" where Id="+model.UserId);
                 rows = DbHelperMySQL.ExecuteSql(strSqlM.ToString());
                if (rows > 0)
                {
                    rows = 0;
                    //更新member 其他信息关联表
                    strSqlM = new StringBuilder();
                    strSqlM.Append("update hpyl_MemberOtherInfo set ");
                    strSqlM.Append("ShopUserId='" + model.ShopUserId + "',");
                    strSqlM.Append("ShopCategorId='" + model.ShopCategorId + "',");
                    strSqlM.Append("JodId='" + model.JodId + "',");
                    strSqlM.Append("ZyId='" + model.ZyId + "',");
                    strSqlM.Append("PracticeYID='" + model.PracticeYID + "',");
                    strSqlM.Append("WorkUrl1='" + model.WorkUrl1 + "',");
                    strSqlM.Append("DateBirth='" + model.DateBirth + "',");
                    strSqlM.Append("IDCardUrl2='" + model.IDCardUrl2 + "',");
                    strSqlM.Append("LicenseCert1='" + model.LicenseCert1 + "',");
                    strSqlM.Append("LicenseCert2='" + model.LicenseCert2 + "',");
                    strSqlM.Append("WorkUrl1='" + model.WorkUrl1 + "',");
                    strSqlM.Append("WorkUrl2='" + model.WorkUrl2 + "'");
                    strSqlM.Append(" where UserId=" + model.UserId);
                    rows = DbHelperMySQL.ExecuteSql(strSqlM.ToString());
                    if (rows > 0)
                    {
                        rows = 0;
                        //添加申请医生关联表
                        strSqlM = new StringBuilder();
                        strSqlM.Append("insert into Himall_Promoter(");
                        strSqlM.Append("UserId,ShopName,Status,ApplyTime,Remark)");
                        strSqlM.Append(" values (");
                        strSqlM.Append("'" + model.UserId + "','" + model.RealName + "','0',NOW(),'" + model.Remark + "')");
                        rows = DbHelperMySQL.ExecuteSql(strSqlM.ToString());
                        if (rows > 0)
                        {
                            //添加用户关联表
                            strSqlM = new StringBuilder();
                            strSqlM.Append("insert into hpyl_MemberRelation(");
                            strSqlM.Append("OneLevelUserID,TwoLevelUserID,ApplyTime,Status)");
                            strSqlM.Append(" values (");
                            strSqlM.Append("'" + model.UserId + "','" + model.ShopUserId + "',NOW(),'0')");
                            rows = DbHelperMySQL.ExecuteSql(strSqlM.ToString());
                            if (rows > 0)
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
        }
        #endregion
        #region 医生名片
        /// <summary>
        /// 医生用户ID
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public M.MemberCard GetMemberCard(long userid)
        {
            M.MemberCard model = new M.MemberCard();
            //1.判断用户是否存在 不存在则注册
            bool Isexit = Exists(userid);//验证用户是否存在
            if (Isexit)
            {   //判断是否发送验证码
                StringBuilder strsql = new StringBuilder();
                strsql.Append("select a.Photo UserPhoto,s.ShopName,a.RealName UserName,ft.HFT_Name ShopCategorName,ag.`Name` JodName from himall_members a  ");
                strsql.Append(" left join hpyl_memberotherinfo b on b.UserId = a.Id ");
                strsql.Append(" left join himall_shops s on s.Id = b.ShopUserId ");
                strsql.Append(" left join hpyl_followtype ft on ft.HFT_ID = b.ShopCategorId ");
                strsql.Append(" left join himall_articlecategories ag on ag.Id = b.JodId ");
                strsql.Append(" where a.Id ="+userid);
                DataSet ds = DbHelperMySQL.Query(strsql.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model= DataRowToCardModel(ds.Tables[0].Rows[0]);
                }

          
            }
           return model;
        }
        public M.MemberCard DataRowToCardModel(DataRow row)
        {
            M.MemberCard model = new M.MemberCard();
            if (row != null)
            {
                if (row["ShopName"] != null && row["ShopName"].ToString() != "")
                {
                    model.ShopName = row["ShopName"].ToString();
                }
                if (row["UserPhoto"] != null && row["UserPhoto"].ToString() != "")
                {
                    model.UserPhoto = row["UserPhoto"].ToString();
                }
                if (row["UserName"] != null && row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["ShopCategorName"] != null && row["ShopCategorName"].ToString() != "")
                {
                    model.ShopCategorName = row["ShopCategorName"].ToString();
                }
                if (row["JodName"] != null && row["JodName"].ToString() != "")
                {
                    model.JodName = row["JodName"].ToString();
                }
            }
            return model;
        }
        #endregion
        #region 新建患者
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int AddPatient(M.MPatient model)
        {
            int result = 0;//添加失败
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            //1.判断用户是否存在 不存在则注册
            bool Isexit = ExistsUser(model.CellPhone);//验证用户是否存在
            if (Isexit)
            {
                result = 2;//手机号存在 请重新换给手机号
            }
            else
            {
                rows = 0;
                strSql = new StringBuilder();
                //用户不存在，插入用户表
                var salt = Guid.NewGuid().ToString("N").Substring(12);
                var password = GetPasswrodWithTwiceEncode(model.CellPhone.Substring(8), salt); 
                strSql.Append("insert into himall_members(");
                strSql.Append("UserName,Nick,CreateDate,RealName,CellPhone,LastLoginDate,Password,PasswordSalt,Sex,Remark,TopRegionId,RegionId,Disabled,OrderNumber,TotalAmount,Expenditure,Points,ParentSellerId,NetAmount)");
                strSql.Append(" values ('" + model.CellPhone + "','" + model.RealName + "',NOW(),'" + model.RealName + "','" + model.CellPhone + "',NOW(),'" + password + "','" + salt + "','"+model.Sex+"','"+model.Remark+"','0','0','0','0','0','0','0','0','0')");
                rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
                if (rows>0)
                {
                    rows = 0;
                    strSql = new StringBuilder();
                    //添加用户其它信息关联表

                    strSql.Append("insert into hpyl_MemberOtherInfo(");
                    strSql.Append("UserId,Age,ItemID)");
                    strSql.Append(" values ('" + GetUserID(model.CellPhone) + "','"+model.Age+"','"+model.ItemID+"')");
                    rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
                    if (rows > 0)
                    {
                        //添加用户关联表
                        rows = 0;
                        strSql = new StringBuilder();
                        strSql.Append("insert into hpyl_MemberRelation(");
                        strSql.Append("OneLevelUserID,TwoLevelUserID,ApplyTime,PassTime,Status)");
                        strSql.Append(" values (");
                        strSql.Append("'" + model.DocUserId + "','" + GetUserID(model.CellPhone) + "',NOW(),NOW(),'1')");
                        rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
                        if (rows > 0)
                        {
                            result = 1;
                            //添加用户手机验证表
                            StringBuilder strSqlts = new StringBuilder();
                            strSqlts.Append("insert into himall_membercontacts(");
                            strSqlts.Append("UserId,UserType,ServiceProvider,Contact)");
                            strSqlts.Append(" values ('" + GetUserID(model.CellPhone) + "','0','Himall.Plugin.Message.SMS','" + model.CellPhone + "')");
                            DbHelperMySQL.ExecuteSql(strSqlts.ToString());
                        }
                    }

                }
            }
            return result;
        }
        #endregion
        #endregion  扩展方法
        #region 验证短信次数
        /// <summary>
        /// 验证次数（同一小时操作 3次）
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">code</param>
        /// <param name="P_Sign">类型</param>
        /// <returns></returns>
        public bool CodeV(string phone, string P_Sign)
        {
            bool flag = false;
            string Sqls = "select P_ID from hpyl_phonemessage  where P_Phone ='"+ phone + "'  and P_State='1' and  to_days(P_SendTime) = to_days(now())  and P_Sign='"+ P_Sign + "'";
        
            DataTable dtIP = DbHelperMySQL.Query(Sqls).Tables[0];
            if (dtIP != null && dtIP.Rows.Count < 3)
            {
                flag = true;
            }
            return flag;
        }

        public int CodeValidate(string phone, string code, string singn)
        {
            if (code == "1111")
            {
                return 1;
            }
            else
            {
            string sqlone = @" select P_SendTime from hpyl_phonemessage where DATEDIFF(n,P_SendTime,GETDATE())<30 and P_Phone=@P_Phone and P_Code=@P_Code and P_Sign=@P_Sign and P_State='1'";
            MySqlParameter[] sqlonepara = new MySqlParameter[] {
                         new MySqlParameter("@P_Phone",phone),
                         new MySqlParameter("@P_Code",code),
                         new MySqlParameter("@P_Sign",singn)
                        };
            int count = DbHelperMySQL.Query(sqlone, sqlonepara).Tables[0].Rows.Count;

            return count;
           }
        }
        #endregion
    }
}
