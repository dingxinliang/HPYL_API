/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.BLL.DoctorAdvice
*文件名：  DoctorAdviceBLL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 14:11:58

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 14:11:58
*修改人： 
*版本号： V1.0.0.0
*描述：医嘱计划类
*
*****************************************************************************/
using HPYL.DAL;
using HPYL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPYL.BLL
{
    public class DoctorAdviceBLL
    {
        private readonly DoctorAdviceDAL dal = new DoctorAdviceDAL();
        public List<AdviceArticle> GetAdviceArticleList(long hFT_ID)
        {
            return dal.GetAdviceArticleList(hFT_ID);
        }

        public List<DoctorFollowContent> FollowList(long hAA_ID)
        {
            return dal.FollowList(hAA_ID);
        }

        public AdviceArticle GetModel(long hAA_ID)
        {
            return dal.GetModel(hAA_ID);
        }

        public bool InFollowPlan(BaseDoctorFollowPlan info)
        {
            return dal.InFollowPlan(info);
        }
    }
}
