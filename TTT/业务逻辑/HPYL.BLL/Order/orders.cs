/**  版本信息模板在安装目录下，可自行修改。
* orders.cs
*
* 功 能： N/A
* 类 名： orders
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/4 10:38:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using HPYL.Model;
using XL.Util.WebControl;

namespace HPYL.BLL
{
	/// <summary>
	/// orders
	/// </summary>
	public partial class orders
	{
		private readonly HPYL.DAL.orders dal=new HPYL.DAL.orders();
        private readonly HPYL.DAL.orderitems dals = new DAL.orderitems();
        public orders()
		{}
		#region  BasicMethod
	

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HPYL.Model.orders GetModel(long Id)
		{
			
			return dal.GetModel(Id);
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
		public List<HPYL.Model.orders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HPYL.Model.orders> DataTableToList(DataTable dt)
		{
			List<HPYL.Model.orders> modelList = new List<HPYL.Model.orders>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HPYL.Model.orders model;
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
        public List<HPYL.Model.OrdersList> GetListPage(Pagination pagination, string strWhere)
        {
            return DataTableToListPage(dal.GetListPage(pagination, strWhere));
        }
        /// <summary>
        /// 订单分页+订单详情
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<HPYL.Model.OrdersList> DataTableToListPage(DataTable dt)
        {
            List<HPYL.Model.OrdersList> modelList = new List<HPYL.Model.OrdersList>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                HPYL.Model.OrdersList model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelList(dt.Rows[n]);
                    DataSet dts = dals.GetList(" OrderId='"+ dt.Rows[n]["id"].ToString() + "'");
                    model.orderitems=new HPYL.BLL.orderitems().DataTableToList(dts.Tables[0]); ;
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

