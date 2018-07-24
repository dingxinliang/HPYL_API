/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.BLL.QuickReply
*文件名：  QuickReplyBLL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/7/17 15:43:55

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/7/17 15:43:55
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
   public class QuickReplyBLL
    {
        private readonly QuickReplyDAL dal = new QuickReplyDAL();

        public List<QuickReply> QuickReplyList(long userID)
        {
            return dal.QuickReplyList(userID);
        }

        public bool Del(long keyId, long userID)
        {
            return dal.Delete(keyId, userID);
        }

        public bool Change(QuickReply info)
        {
            return dal.Update(info);
        }

        public bool InQuickReply(BaseQuickReply info)
        {
            return dal.Add(info);
        }

        public QuickReply GetModel(long hQR_ID, long userID)
        {
            return dal.GetModel(hQR_ID, userID);
        }
    }
}
