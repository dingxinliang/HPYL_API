using HPYL.Model;
using HPYL_API.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using XL.Application.Code;
using XL.Model.Message;

namespace TTT.Controllers
{

  [TokenAttribute] //针对当前类验证签名
    public class TestAController : ApiController
    {
        [HttpPost]
        [ValidateModel]
        public CallBackResult SaveInfo(MysqlTest info)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                new HPYL.BLL.MysqlTest().Save(info);
                apiResult.Result = 1;
                apiResult.Message = "已提交";
            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "写入失败";
                new CCBException("測試寫入", ex);
            }
            return apiResult;

        }
       
    }
}