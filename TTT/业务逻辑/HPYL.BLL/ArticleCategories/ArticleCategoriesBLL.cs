using HPYL.DAL;
using HPYL.DAL.ArticleCategories;
using HPYL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.BLL
{
    /// <summary>
	/// himall_articlecategories
	/// </summary>
	public partial class ArticleCategoriesBLL
    {
        private readonly ArticleCategoriesDAL dal = new ArticleCategoriesDAL();
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HPYL.Model.ArticleCategories GetModel(string Id)
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
        public List<HPYL.Model.ArticleCategories> GetModelList(string strNewsClass)
        {
            string strWhere = " ParentCategoryId = " + strNewsClass;
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HPYL.Model.ArticleCategories> DataTableToList(DataTable dt)
        {
            List<HPYL.Model.ArticleCategories> modelList = new List<HPYL.Model.ArticleCategories>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HPYL.Model.ArticleCategories model;
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
        /// <param name="Id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
