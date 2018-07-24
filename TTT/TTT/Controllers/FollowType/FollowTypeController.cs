using HPYL.BLL;
using HPYL.Model;
using HPYL_API.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XL.Application.Code;
using XL.Model.Message;

namespace HPYL_API.Controllers.FollowType
{ 
    
    /// <summary>
  /// 诊所项目类
  /// </summary>
    [TokenAttribute] //针对当前类验证签名
    public class FollowTypeController : ApiController
    {
        private FollowPlanBLL FBLL = new FollowPlanBLL();//诊疗科目

        #region 获取数据

        /// <summary>
        /// 获取诊疗项目一级分类+二级用户分类
        /// </summary>
        /// <param name="ClinicId">诊所ID</param>
        /// <param name="UID">当前登录用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult FollowTypeJoinList(long ClinicId, long UID)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {

                List<GetFollowType> TypeList = new List<GetFollowType>();
                List<SecondList> SecondList = new List<SecondList>();
                //获取一级分类
                var data = FBLL.FollowTypeList(ClinicId);
                foreach (DataRow item in data.Rows)
                {
                    GetFollowType cmo = new GetFollowType();
                    cmo.HFT_ID = item["HFT_ID"].ToString();
                    cmo.HFT_Name = item["HFT_Name"].ToString();
                    //获取二级分类
                    var datasecond = FBLL.FollowTypeSecondList(ClinicId, UID, long.Parse(item["HFT_ID"].ToString()));

                    foreach (DataRow sitem in datasecond.Rows)
                    {
                        SecondList cms = new SecondList();
                        cms.HFT_ID = sitem["HFT_ID"].ToString();
                        cms.HFT_Name = sitem["HFT_Name"].ToString();
                        SecondList.Add(cms);
                    }
                    cmo.SecondList = SecondList;
                    TypeList.Add(cmo);
                }
                apiResult.Data = TypeList;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取诊疗项目一级分类+二级用户分类:", ex);
            }
            return apiResult;

        }


        /// <summary>
        /// 获取诊疗项目一级分类(ClinicId 诊所ID)
        /// </summary>
        /// <param name="ClinicId">诊所ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult FollowTypeList(long ClinicId)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                List<BaseFollowType> TypeList = new List<BaseFollowType>();
                var data = FBLL.FollowTypeList(ClinicId);
                foreach (DataRow item in data.Rows)
                {
                    BaseFollowType cmo = new BaseFollowType();
                    cmo.HFT_ID = item["HFT_ID"].ToString();
                    cmo.HFT_Name = item["HFT_Name"].ToString();
                    TypeList.Add(cmo);
                }
                apiResult.Data = TypeList;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取诊疗项目分类:", ex);
            }
            return apiResult;

        }


        /// <summary>
        /// 获取诊疗项目2级分类
        /// </summary>
        /// <param name="ClinicId">诊所ID</param>
        /// <param name="UID">当前登录用户ID</param>
        /// <param name="ParentId">父类ID</param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult FollowTypeList(long ClinicId, long UID, long ParentId)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                List<BaseFollowType> TypeList = new List<BaseFollowType>();
                var data = FBLL.FollowTypeSecondList(ClinicId, UID, ParentId);
                foreach (DataRow item in data.Rows)
                {
                    BaseFollowType cmo = new BaseFollowType();
                    cmo.HFT_ID = item["HFT_ID"].ToString();
                    cmo.HFT_Name = item["HFT_Name"].ToString();
                    TypeList.Add(cmo);
                }
                apiResult.Data = TypeList;
                apiResult.Result = 1;
                apiResult.Message = "加载成功";

            }
            catch (Exception ex)
            {
                apiResult.Result = 0;
                apiResult.Message = "加载失败";
                new CCBException("获取诊疗项目2级分类:", ex);
            }
            return apiResult;

        }

  

        #endregion

    }
}