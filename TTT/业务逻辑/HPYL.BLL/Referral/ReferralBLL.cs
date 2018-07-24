/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.BLL.Referral
*文件名：  ReferralBLL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 22:54:48

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 22:54:48
*修改人： 
*版本号： V1.0.0.0
*描述：
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
   public class ReferralBLL
    {
        private readonly ReferralDAL dal = new ReferralDAL();

        public bool InReferral(BaseReferrallog info)
        {
            return dal.InReferral(info);
        }
    }
}
