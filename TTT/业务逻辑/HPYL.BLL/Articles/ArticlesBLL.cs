using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XL.Util.WebControl;

namespace HPYL.BLL
{
    /// <summary>
	/// himall_articles
	/// </summary>
	public partial class ArticlesBLL
    {
        private readonly HPYL.DAL.ArticlesDAL dal = new DAL.ArticlesDAL();
        
        #region  BasicMethod
       


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.Articles GetModel(string Id)
        {
            return dal.GetModel(int.Parse(Id));
        }
        

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
        public List<HPYL.Model.Articles> GetModelList(string strNewsClass)
        {
            string strWhere = " CategoryId = " + strNewsClass;
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HPYL.Model.Articles> DataTableToList(DataTable dt)
        {
            List<HPYL.Model.Articles> modelList = new List<HPYL.Model.Articles>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HPYL.Model.Articles model;
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
        public DataSet GetAllList(string strWhere)
        {
            return GetList(strWhere);
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


        #endregion  BasicMethod
        #region  ExtensionMethod
        public List<HPYL.Model.Articles> GetListPage(Pagination pagination, long NewsClass)
        {
            return DataTableToList(dal.GetListPage(pagination, NewsClass));
        }
        #endregion  ExtensionMethod
    }
}
