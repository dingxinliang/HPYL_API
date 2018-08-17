using HPYL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XL.Model.Message;
using C = HPYL.Common;
using B = HPYL.BLL;
using M = HPYL.Model;

namespace HPYL_API.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class MembersController : ApiController
    {
        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Sign"></param>
        /// <param name="Ts"></param>
        /// <returns></returns>
        [HttpGet]
        public CallBackResult ExistsUser(string UserName, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            //检查请求 签名和时间戳不符合即返回
            if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }

            B.Members bll = new B.Members();
            bool isTrue = bll.ExistsUser(UserName);
            if (isTrue)
            {
                apiResult.Result = 1;
                apiResult.Message = "用户已存在!";
            }
            else
            {
                apiResult.Result = 2;
                apiResult.Message = "用户不存在!";
            }
            return apiResult;
        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="obj">RoleId 0未审核 1已通过 2已注销 3 患者身份</param>
        /// <returns></returns>
        [HttpPost]
        public CallBackResult MembersLogin([FromBody]LoginMembers obj)
        {
            CallBackResult apiResult = new CallBackResult();
            try
            {
                //检查请求 签名和时间戳不符合即返回
                if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
                {
                    return apiResult;
                }
                B.Members bll = new B.Members();
                //验证验证码
                if (bll.Checkcode(obj.LoginPhone, obj.PhoneCode, "login"))
                {
                    MLoginMember loginM = bll.GetLoginPhoneCode(obj.LoginPhone, obj.PhoneCode);
                    if (loginM != null)
                    {
                        apiResult.Data = loginM;
                        apiResult.Result = 1;
                        apiResult.Message = "登陆成功!";
                        if (loginM.RoleId == -1)
                        {
                            apiResult.Result =-1;
                            apiResult.Message = "验证码发送失败!";
                        }
                        if (loginM.RoleId == -2)
                        {
                            apiResult.Result = -2;
                            apiResult.Message = "服务器通信失败!";
                        }
                    }
                }
                else
                {
                    apiResult.Result = 0;
                    apiResult.Message = "验证码不存在或已失效!";

                }
            }
            catch (Exception ex)
            {
                apiResult.Result = -3;
                apiResult.Message = "服务器通信失败";
                C.Log.Debug("登录", ex.Message);

            }
            return apiResult;
        }
        /// <summary>
        /// 申请成为医生
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Result 1 成功  2失败</returns>
        [HttpPost]
        public CallBackResult Register([FromBody]MRegister obj)
        {
            CallBackResult apiResult = new CallBackResult();
            //检查请求 签名和时间戳不符合即返回
            if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            //Register
            B.Members bll = new B.Members();
            bool isTrue = bll.Register(obj);
            if (isTrue)
            {
                apiResult.Result = 1;
                apiResult.Message = "申请成功!";
            }
            else
            {
                apiResult.Result = 2;
                apiResult.Message = "申请失败";
            }
            return apiResult;
        }
      /// <summary>
      /// 我的名片
      /// </summary>
      /// <param name="UserId">用户ID</param>
      /// <param name="Sign"></param>
      /// <param name="Ts"></param>
      /// <returns></returns>
        [HttpGet]
        public CallBackResult GetMemberCard(string UserId, string Sign, string Ts)
        {
            CallBackResult apiResult = new CallBackResult();
            apiResult.Result = 2;
            apiResult.Message = "加载失败!";
            try
            {
                //检查请求 签名和时间戳不符合即返回
                if (!C.ComHelper.CheckRequest(Sign, Ts, out apiResult.Result, out apiResult.Message))
                {
                    return apiResult;
                }
                B.Members bll = new B.Members();
                M.MemberCard model = new MemberCard();
                model = bll.GetMemberCard(long.Parse(UserId));
                if (model != null)
                {
                    apiResult.Data = model;
                    apiResult.Result = 1;
                    apiResult.Message = "加载成功!";

                }
            }
            catch (Exception ex)
            {
                apiResult.Result = -3;
                apiResult.Message = "服务器通信失败";
                C.Log.Debug("我的名片", ex.Message);
            }
            return apiResult;
        }
        /// <summary>
        /// 新建患者
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Result 0 失败 1 成功  2手机号存在</returns>
        [HttpPost]
        public CallBackResult AddPatient([FromBody]MPatient obj)
        {
            CallBackResult apiResult = new CallBackResult();
            //检查请求 签名和时间戳不符合即返回
            if (!C.ComHelper.CheckRequest(obj, out apiResult.Result, out apiResult.Message))
            {
                return apiResult;
            }
            //Register
            B.Members bll = new B.Members();
            int isTrue = bll.AddPatient(obj);
            apiResult.Result = isTrue;
            var remsg = "添加成功";
            if (isTrue==0)
            {
                remsg = "添加失败";
            }
            if (isTrue == 2)
            {
                remsg = "手机号存在";
            }
            apiResult.Message = remsg;
            return apiResult;
        }

    }
}