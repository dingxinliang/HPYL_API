using HPYL_API.App_Start.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XL.Util.Token;

namespace TTT.Controllers
{
    
    public class HomeController : Controller
    {
        private string timestamp = TokenHelper.GenerateTimeStamp(DateTime.Now);
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult APItest()
        {

 
        SortedDictionary<string, string> PostData = new SortedDictionary<string, string>();
        PostData.Add("ClientId", "1");
             PostData.Add("DoctorId", "580");
            PostData.Add("PatientId", "590");
            PostData.Add("Date", "2018-08-18");
             PostData.Add("StartTime", "17:20");
             PostData.Add("EndTime", "18:20");
             PostData.Add("AddressId", "1");
             PostData.Add("Address", "sdsddssdsdsd");
             PostData.Add("ProjectIdList", "749,750,753,");
             PostData.Add("Remind", "1");
             PostData.Add("Content", "实打实的士大夫士大夫");
            //PostData.Add("Ts", timestamp);
            //ViewBag.Sign = TokenHelper.GetResponseMysign(PostData);//获取签名
            //PostData.Add("Sign", ViewBag.Sign);
            //PostData.Remove("Key");
            ViewBag.json = JsonConvert.SerializeObject(PostData);//生成post数据
            return View();
        }

    }
}
