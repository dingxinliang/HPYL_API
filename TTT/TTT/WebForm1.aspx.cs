using HPYL.BLL;
using HPYL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPYL_API
{

    public enum OrderState
    {
        [Description("待付款")]
        WaitPay = 1,
        [Description("待就诊")]
        WaitVisit = 2,
        [Description("待结算")]
        WaitFinish = 3,
        [Description("已关闭")]
        Close = 4,
        [Description("已完成")]
        Finish = 5,
        [Description("待确认")]
        WaitOk = 6
    }
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write((OrderState)1);
            //Response.Write(EnumHelper.GetEnumDescription((OrderState)1));


        }

        public void getc(int year, int month)
        {
            DateHelper date = new DateHelper();
            int day = ChinaDate.GetDaysByMonth(year, month);
            string DateParse = "";
            for (int i = 1; i <= day; i++)
            {
                //日期组合
                DateParse = DateTime.Parse(year + "-" + month + "-" + i).ToString("yyyy-MM-dd");

                //查询是否自定义

                //没有的话 查询对应设置
                ChineseCalendar cdata = new ChineseCalendar(DateTime.Parse(DateParse));
                Response.Write(DateParse + "-" + cdata.WeekDayStr + "</br>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Write(new CalendarBLL().InitialiseCalendatr(400, 2));
        }
    }
}