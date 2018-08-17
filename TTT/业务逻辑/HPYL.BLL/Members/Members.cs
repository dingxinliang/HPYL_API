using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Model;


namespace HPYL.BLL
{
    /// <summary>
	/// himall_members
	/// </summary>
    public partial class Members
    {
        private readonly HPYL.DAL.MembersDAL dal = new DAL.MembersDAL();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Id)
        {
            return dal.Exists(Id);
        }
        /// <summary>
        /// 验证用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool ExistsUser(string UserName)
        {
            return dal.ExistsUser(UserName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HPYL.Model.Members model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HPYL.Model.Members model)
        {
            return dal.Update(model);
        }

      
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Members GetModel(long Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public HPYL.Model.Members GetModelByCache(long Id)
        //{

        //    string CacheKey = "himall_membersModel-" + Id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (HPYL.Model.Members)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HPYL.Model.Members> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HPYL.Model.Members> DataTableToList(DataTable dt)
        {
            List<HPYL.Model.Members> modelList = new List<HPYL.Model.Members>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HPYL.Model.Members model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region 登录
        /// <summary>
        /// 手机动态码登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public HPYL.Model.MLoginMember GetLoginPhoneCode(string phone, string code)
        {
            return dal.GetLoginPhoneCode(phone, code);
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Register(Model.MRegister model)
        {
            return dal.Register(model);
        }
        #endregion
        #region 验证码
        public int AddPhoneMsg(string Phone, string code, string contents, string sigin)
        {
            return dal.AddPhoneMsg(Phone, code, contents, sigin);
        }
        /// <summary>
        /// 验证次数
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public bool CodeV(string phone, string sign)
        {
            return dal.CodeV(phone, sign);
        }
        //验证验证码
        public int CodeValidate(string phone, string code, string sigin)
        {
            return dal.CodeValidate(phone, code, sigin);
        }
        /// <summary>
        /// 手机验证码验证
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">验证码</param>
        /// <param name="sigin">标示</param>
        /// <returns></returns>
        public bool Checkcode(string phone, string code, string sigin)
        {
            return dal.Checkcode(phone, code, sigin);
        }
        #endregion
        #region 新建患者
        /// <summary>
        /// 新建患者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPatient(Model.MPatient model)
        {
            return dal.AddPatient(model);
        }
        #endregion
        #region 我的名片
        /// <summary>
        /// 我的名片
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.MemberCard GetMemberCard(long userid)
        {
            return dal.GetMemberCard(userid);
        }
            #endregion
        }
}
