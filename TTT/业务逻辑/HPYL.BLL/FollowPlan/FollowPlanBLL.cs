/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.BLL
*文件名：  FollowTypeBLL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/14 21:21:33

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/14 21:21:33
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using HPYL.DAL;
using HPYL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XL.Util.WebControl;

namespace HPYL.BLL
{
    public class FollowPlanBLL
    {
        private readonly FollowPlanDAL dal = new FollowPlanDAL();


        public DataTable FollowTypeList(long clinicId)
        {
            return dal.FollowTypeList(clinicId);
        }

        public DataTable FollowTypeSecondList(long clinicId, long uID, long parentId)
        {
            return dal.FollowTypeSecondList(clinicId, uID, parentId);
        }
        public List<BaseFollowTemPlate> GetFollowTemPlateList(long clinicId)
        {
            return dal.GetFollowTemPlateList(clinicId);
        }

        public List<FollowPlanContent> GetTemPlateContent(long hTP_ID)
        {
            return dal.GetTemPlateContent(hTP_ID);
        }

        public bool InFollowPlan(BaseFollowPlan info)
        {
            return  dal.InFollowPlan(info);
        }
        public bool ChangeFollowPlan(FollowPlan info)
        {
            return dal.ChangeFollowPlan(info);
        }

        public FollowPlan GetPlateContent(long hFP_ID)
        {
            return dal.GetPlateContent(hFP_ID);
        }

        public DataTable GetPageDate(Pagination pagination, long userId)
        {
            return dal.GetPageDate(pagination, userId);
        }
        public List<FollowPlan> GetPageInfo(long userId, string date)
        {
            return dal.GetPageInfo(userId, date);
        }

        public bool DelFollowPlan(long userId, long hFP_ID)
        {
            return dal.DelFollowPlan(userId, hFP_ID);
        }
        public bool AddProject(ProjectPost model)
        {
            return dal.AddProject(model);
        }
        
    }
}
