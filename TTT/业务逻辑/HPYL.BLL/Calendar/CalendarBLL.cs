/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.BLL.Calendar
*文件名：  CalendarBLL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/8/3 16:37:58

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/8/3 16:37:58
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
    public class CalendarBLL
    {

        private readonly CalendarDAL dal = new CalendarDAL();
        public List<BaseCalendar> GetCalendarList(int year, int month,long userid,long shopid)
        {
            return dal.GetCalendarList(year, month, userid,shopid);
        }

        public List<BookingTime> GetDayTimeList(int year, int month, int day, long userid, long clientId)
        {
            return dal.GetDayTimeList(year, month, day, userid, clientId);
        }

        public BookingList GetDayBookingList(int year, int month, int day, long userid, long clientId)
        {
            return dal.GetDayBookingList(year, month, day, userid, clientId);
        }

        public CalendarDate GetCustomDay(int year, int month, int day, long userid, long clientId)
        {
            return dal.GetCustomDay(year, month, day, userid, clientId);
        }

        public List<BaseDate>  GetSystemWeek( long userid, long clientId)
        {
            return dal.GetSystemWeek( userid, clientId);
        }

        public bool SaveState(PostDateState info)
        {
            return dal.SaveState(info);
        }

        public bool SaveDateNum(PostDateTime info)
        {
            return dal.SaveDateNum(info);
        }

        public Adderess ShopAddress(long clientId)
        {
            return dal.ShopAddress(clientId);
        }

        public bool SaveWeekNum(PostWeekNum info)
        {
            return dal.SaveWeekNum(info);
        }

        public bool SaveWeekState(PostWeekState info)
        {
            return dal.SaveWeekState(info);
        }

        /// <summary>
        /// 初始化时间
        /// </summary>
        /// <param name="userid">医生ID</param>
        /// <param name="clinetid">诊所ID</param>
        /// <returns></returns>
        public bool InitialiseCalendatr(long userid ,long clinetid)
        {
            return dal.InitialiseCalendatr(userid,clinetid);
        }

        public bool InOrder(OrderModel info)
        {
            return dal.InOrder(info);
        }

        public bool CancelOrder(InfoToUser info)
        {
            return dal.CancelOrder(info);
        }

        public OrderInfo GetOrderModel(long Userid, long orderId) 
        {
            return dal.GetOrderModel(Userid, orderId);
        }
    }
}
