/****************************************************************************
*Copyright (c) 2018 Microsoft All Rights Reserved.
*CLR版本： 4.0.30319.42000
*公司名称：Microsoft
*命名空间：HPYL.DAL.Calendar
*文件名：  CalendarDAL
*版本号：  V1.0.0.0
*当前的用户域：QH-20160830FLFX
*创建人：丁新亮
*创建时间：2018/8/3 16:38:56

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/8/3 16:38:56
*修改人： 
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPYL.Common;
using HPYL.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;

namespace HPYL.DAL
{
    public class CalendarDAL
    {
        #region 获取日程

        public Adderess ShopAddress(long shopid)
        {
            Adderess addmodel = new Adderess();
            string sql = "select CompanyRegionId from himall_shops where Id="+shopid+"";
            addmodel.addresId = int.Parse(DbHelperMySQL.GetSingle(sql).ToString());
            addmodel.address = new RegionService().GetFullName((long)addmodel.addresId);
            return addmodel;
        }
        public List<BaseCalendar> GetCalendarList(int year, int month, long userid, long shopid)
        {
            DateHelper date = new DateHelper();
            int day = ChinaDate.GetDaysByMonth(year, month);
            string DateParse = "";
            string DateTag = year.ToString() + month.ToString().PadLeft(2, '0');
            List<BaseCalendar> blsit = new List<BaseCalendar>();


            //优化查询速度,改为先查自定义
            string strSqlzdy = "select HLD_State state,HLD_Date date ,(SELECT IFNULL(sum(HDT_Num),0) num from HPYL_CalendarDateTime where HPYL_CalendarDateTime.HLD_ID=a.HLD_ID and HDT_State=1 ) total" +
                " from HPYL_CalendarDate a where HLD_UserId=" + userid + "  and HLD_ClientId=" + shopid + " and HLD_Tag='" + DateTag + "'";
            List<ZDYCalendar> ZDYCalendarList = new Repository<ZDYCalendar>().FindList(strSqlzdy).ToList();

            //查询 每周排班固定设置
            string strSqlGd = "select HCW_State state ,HCW_Week week," +
                "(SELECT IFNULL(sum(HCD_Num), 0) num FROM HPYL_CalendarTime  where HPYL_CalendarTime.HCW_ID = a.HCW_ID and HCD_State = 1)total " +
                "from HPYL_CalendarWeek a where HCW_UserId = " + userid + " and HCW_ClientId = " + shopid + " order by HCW_ID";
            List<GDCalendar> GDCalendarList = new Repository<GDCalendar>().FindList(strSqlGd).ToList();
            //循环本月设置
            for (int i = 1; i <= day; i++)
            {
                //日期组合
                DateParse = DateTime.Parse(year + "-" + month + "-" + i).ToString("yyyy-MM-dd");
                int totalnum = 0; //可接诊数
                int receivenum = 0;//已预约数
                BaseCalendar bmodel = new BaseCalendar();

                //是否存在自定义
                if (ZDYCalendarList.Count() > 0)
                {
                    var zdy = ZDYCalendarList.Where(t => t.date == DateParse);
                    if (zdy.Count() > 0)
                    {
                        var zdymodel = zdy.First();
                        if (zdymodel.state == 1)
                            totalnum = zdymodel.total;
                    }
                    else
                    {
                        //不存在 走固定
                        ChineseCalendar cdata = new ChineseCalendar(DateTime.Parse(DateParse));
                        var gd = GDCalendarList.Where(t => t.week == cdata.WeekDayStr);
                        if (gd.Count() > 0)
                        {
                            var gdymodel = gd.First();
                            if (gdymodel.state == 1)
                                totalnum = gdymodel.total;
                        }
                    }

                }
                else
                {
                    //不存在 走固定
                    ChineseCalendar cdata = new ChineseCalendar(DateTime.Parse(DateParse));
                    var gd = GDCalendarList.Where(t => t.week == cdata.WeekDayStr);
                    if (gd.Count() > 0)
                    {
                        var gdymodel = gd.First();
                        if (gdymodel.state == 1)
                            totalnum = gdymodel.total;
                    }
                }
                //获取已接诊人数
                string sqlorder = "select count(1) ordercount from himall_orders where ShareUserId=" + userid + " and ShopId=" + shopid + " " +
                    " and OrderStatus!=4 and date_format(ReceiveDate, '%Y-%m-%d' )='" + DateParse + "'";
                receivenum = int.Parse(DbHelperMySQL.GetSingle(sqlorder).ToString());
                bmodel.year = year.ToString();
                bmodel.month = month.ToString().PadLeft(2, '0'); ;
                bmodel.day = i.ToString().PadLeft(2, '0');
                bmodel.totalnum = totalnum;
                bmodel.receivenum = receivenum;
                blsit.Add(bmodel);
            }
            return blsit;
        }

        /// <summary>
        /// 获取预约单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OrderInfo GetOrderModel(long Userid,long orderId)
        {
            return new OrderService().GetOrder(Userid, orderId);
        }

        /// <summary>
        /// 取消预约到哪
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrder(InfoToUser info)
        {
            return new OrderService().CancelOrder(info);
        }

        /// <summary>
        /// 写入预约单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InOrder(OrderModel info)
        {
            return new OrderService().InOrder(info);
        }
        /// <summary>
        /// 周接诊状态设置
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SaveWeekState(PostWeekState info)
        {
            bool result = false;
            string sql = "";
            //关闭全天及详细
            if (info.Flag.ToUpper() == "D")
            {
                sql = "update HPYL_CalendarWeek set HCW_State=" + info.State + " where HCW_UserId=" + info.UserId + "  and HCW_ClientId=" + info.ClinetId + " and HCW_ID='" + info.DateId + "'" +
                    " ;update HPYL_CalendarTime set HCD_State=" + info.State + " where  HCW_ID=" + info.DateId + " ";

            }
            else {
                //如果主关 更改子开  则主自动开
                if (info.State == 1)
                {
                    sql = "update HPYL_CalendarWeek set HCW_State=" + info.State + " where HCW_UserId=" + info.UserId + "  and HCW_ClientId=" + info.ClinetId + " and HCW_ID='" + info.DateId + "'" +
                         ";update HPYL_CalendarTime set HCD_State=" + info.State + " where  HCW_ID=" + info.DateId + " and HCD_Tag='" + info.Flag + "' ";
                }
                else 
                {
                    //如果主开，更改子全部关闭 则主自动关闭
                    string sqlz = "update HPYL_CalendarTime set HCD_State=" + info.State + " where  HCW_ID=" + info.DateId + " and HCD_Tag='" + info.Flag + "'";
                    DbHelperMySQL.ExecuteSql(sqlz);
                    string scount = "select count(1) from HPYL_CalendarTime where  HCW_ID=" + info.DateId + " and HCD_State=1";
                    if (DbHelperMySQL.GetSingle(scount).ToString() == "0")
                    {
                        sql = "update HPYL_CalendarWeek set HCW_State=" + info.State + " where HCW_UserId=" + info.UserId + "  and HCW_ClientId=" + info.ClinetId + " and HCW_ID='" + info.DateId + "'";
                    }

                }
            }

            if (!string.IsNullOrEmpty(sql))
            {
                if (DbHelperMySQL.ExecuteSql(sql) > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 周接诊数量设置
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SaveWeekNum(PostWeekNum info)
        {
            bool result = false;
            string strsql = "select HCW_ID from hpyl_calendarweek where HCW_UserId=" + info.UserId + "  and HCW_ClientId=" + info.ClinetId + " and HCW_ID=" + info.DateId + "";
            DataTable dt = DbHelperMySQL.Query(strsql).Tables[0];
            if (dt.Rows.Count != 0)
            {
                string sql = "update HPYL_CalendarTime set HCD_Num=" + info.Num + " where  HCW_ID=" + info.DateId + " and HCD_Tag='" + info.Tag + "'";
                if (DbHelperMySQL.ExecuteSql(sql) > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 更新日期接诊数量
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SaveDateNum(PostDateTime info)
        {
            bool result = false;
            string DateParse = DateTime.Parse(info.Year + "-" + info.Month + "-" + info.Day).ToString("yyyy-MM-dd");//日期
            string DateTag = info.Year.ToString() + info.Month.ToString().PadLeft(2, '0');//标识
            var week = new ChineseCalendar(DateTime.Parse(DateParse)).WeekDayStr;//周几
             //1. 查询是否存在，存在即更新 否则写入

            string strSqlzdy = "select HLD_ID from HPYL_CalendarDate where HLD_UserId=" + info.UserId + "  and HLD_ClientId=" + info.ClinetId + " and HLD_Date='" + DateParse + "'";
            DataTable dt = DbHelperMySQL.Query(strSqlzdy).Tables[0];
            if (dt.Rows.Count != 0)
            {
                string sql = "update HPYL_CalendarDateTime set HDT_Num="+info.Num+ " where  HLD_ID=" + dt.Rows[0]["HLD_ID"] + " and HDT_Tag='"+info.Tag+"'";
                if (DbHelperMySQL.ExecuteSql(sql) > 0)
                {
                    result=true;
                }

            }
            else {
                //查找固定配置写入
                string strSqlGd = "select HCW_State,HCW_Week,HCW_ID  from HPYL_CalendarWeek  where HCW_Week='" + week + "' and HCW_UserId = " + info.UserId + " and HCW_ClientId = " + info.ClinetId + "";
                DataTable dtgd = DbHelperMySQL.Query(strSqlGd).Tables[0];
                if (dtgd.Rows.Count != 0)
                {
                    string sql = "select HCD_Name Name,HCD_Tag Tag,HCD_Num Num,HCD_State State from HPYL_CalendarTime where HCW_ID=" + dtgd.Rows[0]["HCW_ID"] + "";
                    var TimeList = new Repository<DateTimeList>().FindList(sql).ToList();
                    if (TimeList.Count() > 0)
                    {  //写入主表信息
                       int HLD_Id= Add(info);
                        foreach (DateTimeList item in TimeList)
                        {
                            //写入详情信息
                            
                            string sqlin = "INSERT INTO hpyl_calendardatetime ( `HLD_ID`, `HDT_Name`, `HDT_Tag`, `HDT_Num`, `HDT_State`) VALUES ("+ HLD_Id + ", '"+item.Name+"', '"+item.Tag+"', "+((item.Tag==info.Tag)?info.Num: item.Num) +", "+item.State+")";
                            DbHelperMySQL.ExecuteSql(sqlin);
                            result = true;
                        }
                    }
                  
                   
                }
                 
            }
            return result;
        }

        /// <summary>
        /// 更新日期开启关闭状态
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool SaveState(PostDateState info)
        {
            bool result = false;
            string DateParse = DateTime.Parse(info.Year + "-" + info.Month + "-" + info.Day).ToString("yyyy-MM-dd");//日期
            string DateTag = info.Year.ToString() + info.Month.ToString().PadLeft(2, '0');//标识
            var week = new ChineseCalendar(DateTime.Parse(DateParse)).WeekDayStr;//周几
                                                                                 //1. 查询是否存在，存在即更新 否则写入

            string strSqlzdy = "select HLD_ID,HLD_State from HPYL_CalendarDate where HLD_UserId=" + info.UserId + "  and HLD_ClientId=" + info.ClinetId + " and HLD_Date='" + DateParse + "'";
            DataTable dt = DbHelperMySQL.Query(strSqlzdy).Tables[0];
            if (dt.Rows.Count != 0)
            {
                string sql = "";
                //关闭全天及详细
                if (info.Flag.ToUpper() == "D")
                {
                    sql = "update HPYL_CalendarDate set HLD_State="+info.State+" where HLD_UserId=" + info.UserId + "  and HLD_ClientId=" + info.ClinetId + " and HLD_Date='" + DateParse + "'" +
                        " ;update HPYL_CalendarDateTime set HDT_State="+info.State+" where  HLD_ID=" + dt.Rows[0]["HLD_ID"] + " ";

                }
                else {
                    //如果主关 更改子开  则主自动开
                    if (info.State == 1)
                    {
                        sql = "update HPYL_CalendarDate set HLD_State=" + info.State + " where HLD_UserId=" + info.UserId + "  and HLD_ClientId=" + info.ClinetId + " and HLD_Date='" + DateParse + "'" +
                              ";update HPYL_CalendarDateTime set HDT_State=" + info.State + " where  HLD_ID=" + dt.Rows[0]["HLD_ID"] + " and HDT_Tag='" + info.Flag + "' ";
                    }
                    else
                    {
                        //如果主开，更改子全部关闭 则主自动关闭
                        string sqlz = "update HPYL_CalendarDateTime set HDT_State=" + info.State + " where  HLD_ID=" + dt.Rows[0]["HLD_ID"] + " and HDT_Tag='" + info.Flag + "'";
                        DbHelperMySQL.ExecuteSql(sqlz);
                        string scount = "select count(1) from HPYL_CalendarDateTime where  HLD_ID=" + dt.Rows[0]["HLD_ID"] + " and HDT_State=1";
                        if (DbHelperMySQL.GetSingle(scount).ToString()=="0")
                        {
                            sql = "update HPYL_CalendarDate set HLD_State=" + info.State + " where HLD_UserId=" + info.UserId + "  and HLD_ClientId=" + info.ClinetId + " and HLD_Date='" + DateParse + "'";
                        }
                        
                    }

                }
                if (!string.IsNullOrEmpty(sql))
                {
                    if (DbHelperMySQL.ExecuteSql(sql) > 0)
                    {
                        result = true;
                    }
                }
              

            }
            else
            {
                //查找固定配置写入
                string strSqlGd = "select HCW_State,HCW_Week,HCW_ID  from HPYL_CalendarWeek  where HCW_Week='" + week + "' and HCW_UserId = " + info.UserId + " and HCW_ClientId = " + info.ClinetId + "";
                DataTable dtgd = DbHelperMySQL.Query(strSqlGd).Tables[0];
                if (dtgd.Rows.Count != 0)
                {
                    string sql = "select HCD_Name Name,HCD_Tag Tag,HCD_Num Num,HCD_State State from HPYL_CalendarTime where HCW_ID=" + dtgd.Rows[0]["HCW_ID"] + "";
                    var TimeList = new Repository<DateTimeList>().FindList(sql).ToList();
                    if (TimeList.Count() > 0)
                    {  //写入主表信息
                        int HLD_Id = Add(info);
                        foreach (DateTimeList item in TimeList)
                        {
                            //写入详情信息

                            string sqlin = "INSERT INTO hpyl_calendardatetime ( `HLD_ID`, `HDT_Name`, `HDT_Tag`, `HDT_Num`, `HDT_State`) VALUES (" + HLD_Id + ", '" + item.Name + "', '" + item.Tag+ "', " +item.Num + ", " + ((item.Tag == info.Flag.ToString()) ? info.State: item.State) + ")";
                            DbHelperMySQL.ExecuteSql(sqlin);
                            result = true;
                        }
                    }


                }

            }
            return result;
        }




        /// <summary>
        /// 获取自定义设置
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="userid"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public CalendarDate GetCustomDay(int year, int month, int day, long userid, long clientId)
        {
            string DateTag = DateTime.Parse(year + "-" + month + "-" + day).ToString("yyyy-MM-dd");
            ChineseCalendar cdata = new ChineseCalendar(DateTime.Parse(DateTag));
            CalendarDate dmodel = new CalendarDate();
            dmodel.Date = DateTag;
            dmodel.UserId = userid;
            dmodel.ClientId = clientId;
            dmodel.Year = year;
            dmodel.Month = month;
            dmodel.Day = day;
            dmodel.Week = cdata.WeekDayStr;
            string strSqlzdy = "select HLD_State,HLD_ID from HPYL_CalendarDate where HLD_UserId=" + userid + "  and HLD_ClientId=" + clientId + " and HLD_Date='" + DateTag + "'";
            DataTable dt = DbHelperMySQL.Query(strSqlzdy).Tables[0];
            if (dt.Rows.Count != 0)
            {
                string sql = "select HDT_Name Name,HDT_Tag Tag,HDT_Num Num,HDT_State State from HPYL_CalendarDateTime where HLD_ID=" + dt.Rows[0]["HLD_ID"] + "";
                dmodel.DateTimeList = new Repository<DateTimeList>().FindList(sql).ToList();
                dmodel.State = int.Parse(dt.Rows[0]["HLD_State"].ToString());
            }
            else
            {
                //自定义没有 查找固定设置
                string strSqlGd = "select HCW_State,HCW_Week,HCW_ID  from HPYL_CalendarWeek  where HCW_Week='" + dmodel.Week + "' and HCW_UserId = " + userid + " and HCW_ClientId = " + clientId + "";
                DataTable dtgd = DbHelperMySQL.Query(strSqlGd).Tables[0];
               
                if (dtgd.Rows.Count != 0)
                {
                    string sql = "select HCD_Name Name,HCD_Tag Tag,HCD_Num Num,HCD_State State from HPYL_CalendarTime where HCW_ID=" + dtgd.Rows[0]["HCW_ID"] + "";
                    dmodel.DateTimeList = new Repository<DateTimeList>().FindList(sql).ToList();
                    dmodel.State = int.Parse(dtgd.Rows[0]["HCW_State"].ToString());
                }
            }
            return dmodel;

        }

        /// <summary>
        /// 获取固定每周设置
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="userid"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public List<BaseDate> GetSystemWeek(long userid, long clientId)
        {

            List<BaseDate> clist = new List<BaseDate>();
            string strSqlGd = "select HCW_ID DateId, HCW_State,HCW_Week,HCW_ID  from HPYL_CalendarWeek  where   HCW_UserId = " + userid + " and HCW_ClientId = " + clientId + " order by HCW_ID";
            DataTable dt = DbHelperMySQL.Query(strSqlGd).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                BaseDate dmodel = new BaseDate();
                dmodel.State = int.Parse(item["HCW_State"].ToString());
                dmodel.UserId = userid;
                dmodel.ClientId = clientId;
                dmodel.DateId = long.Parse(item["DateId"].ToString());
                dmodel.Week =item["HCW_Week"].ToString();
                string sql = "select HCD_ID Id, HCD_Name Name,HCD_Tag Tag,HCD_Num Num,HCD_State State from HPYL_CalendarTime where HCW_ID=" + item["HCW_ID"] + "";
                dmodel.DateTimeList = new Repository<DateTimeList>().FindList(sql).ToList();

                clist.Add(dmodel);
            }
            return clist;
        }

        public BookingList GetDayBookingList(int year, int month, int day, long userid, long clientId)
        {
            //日期组合
            dynamic DateParse = DateTime.Parse(year + "-" + month + "-" + day).ToString("yyyy-MM-dd");
            ChineseCalendar cdata = new ChineseCalendar(DateTime.Parse(DateParse));
            BookingList Bmodel = new BookingList();

            string sql = "select count(1) ordercount from himall_orders where ShareUserId=" + userid + " and ShopId=" + clientId + " " +
                    " and OrderStatus=6 and date_format(ReceiveDate, '%Y-%m-%d' )='" + DateParse + "'";
            Bmodel.Title = month + "月" + day.ToString().PadLeft(2, '0') + "日";
            Bmodel.total = int.Parse(DbHelperMySQL.GetSingle(sql).ToString());

            //获取预约用户
            List<BookingUser> buserlist = new List<BookingUser>();
            string sqluser = "select a.Id, b.Photo userhead,a.SellerAddress address,a.ShopName ClinicName ,a.ShipTo username,a.OrderStatus state," +
                "CONCAT(date_format(a.ReceiveStartTime, '%H:%i' ),'~',date_format(a.ReceiveEndTime, '%H:%i' ))bookingtime" +
                "  from himall_orders a INNER JOIN Himall_Members b ON a.UserId=b.Id  " +
                " where a.ShareUserId=" + userid + " and ShopId=" + clientId + " " +
                    "  and date_format(ReceiveDate, '%Y-%m-%d' )='" + DateParse + "' ";

            DataTable dt = DbHelperMySQL.Query(sqluser).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                BookingUser busermodel = new BookingUser();
                busermodel.address = item["address"].ToString();
                busermodel.Id = item["Id"].ToString();
                busermodel.bookingtime = item["bookingtime"].ToString();
                busermodel.ClinicName = item["ClinicName"].ToString();
                busermodel.state = EnumHelper.GetEnumDescription((OrderState)int.Parse(item["state"].ToString()));
                busermodel.userhead = item["userhead"].ToString();
                busermodel.username = item["username"].ToString();
                string sqlproject = "select a.Id,CONCAT(IFNULL(d.NAME, ''), '[', a.ProductName, ']')Name from himall_orderitems a " +
                    " INNER JOIN himall_orders b ON a.OrderId=b.Id " +
                    " left JOIN Himall_Products c ON c.Id=a.ProductId " +
                    " LEFT JOIN  himall_shopcategories d on c.CategoryId=d.Id  " +
                    " where  a.OrderId =" + item["Id"].ToString() + "";
                busermodel.project = new Repository<Project>().FindList(sqlproject).ToList();
                buserlist.Add(busermodel);
            }
            Bmodel.BookingUser = buserlist;

            return Bmodel;
        }

        public List<BookingTime> GetDayTimeList(int year, int month, int day, long userid, long clientId)
        {
            dynamic DateParse = DateTime.Parse(year + "-" + month + "-" + day).ToString("yyyy-MM-dd");
            string sql = "select  date_format(ReceiveStartTime, '%H:%i' ) startTime, date_format(ReceiveEndTime, '%H:%i' ) endTime from himall_orders where  ShareUserId=" + userid + " and ShopId=" + clientId + "" +
                " and OrderStatus!=4 and date_format(ReceiveDate, '%Y-%m-%d' )='" + DateParse + "' ";
            return new Repository<BookingTime>().FindList(sql).ToList();
        }


        /// <summary>
        /// 增加日期一条数据
        /// </summary>
        public int Add(PostDateTime info)
        {
            string DateParse = DateTime.Parse(info.Year + "-" + info.Month + "-" + info.Day).ToString("yyyy-MM-dd");//日期
            string DateTag = info.Year.ToString() + info.Month.ToString().PadLeft(2, '0');//标识
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_calendardate(");
            strSql.Append("HLD_Date,HLD_UserId,HLD_ClientId,HLD_State,HLD_Tag)");
            strSql.Append(" values (");
            strSql.Append("@HLD_Date,@HLD_UserId,@HLD_ClientId,@HLD_State,@HLD_Tag)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HLD_Date", DateParse),
                    new MySqlParameter("@HLD_UserId", info.UserId),
                    new MySqlParameter("@HLD_ClientId", info.ClinetId),
                    new MySqlParameter("@HLD_State",1),
                    new MySqlParameter("@HLD_Tag", DateTag)};
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public int Add(PostDateState info)
        {
            string DateParse = DateTime.Parse(info.Year + "-" + info.Month + "-" + info.Day).ToString("yyyy-MM-dd");//日期
            string DateTag = info.Year.ToString() + info.Month.ToString().PadLeft(2, '0');//标识
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_calendardate(");
            strSql.Append("HLD_Date,HLD_UserId,HLD_ClientId,HLD_State,HLD_Tag)");
            strSql.Append(" values (");
            strSql.Append("@HLD_Date,@HLD_UserId,@HLD_ClientId,@HLD_State,@HLD_Tag)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HLD_Date", DateParse),
                    new MySqlParameter("@HLD_UserId", info.UserId),
                    new MySqlParameter("@HLD_ClientId", info.ClinetId),
                    new MySqlParameter("@HLD_State",info.State),
                    new MySqlParameter("@HLD_Tag", DateTag)};
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

         
        /// <summary>
        /// 初始化用户日程模板
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ClientId"></param>
        /// <returns></returns>

        public bool InitialiseCalendatr(long userid, long ClientId)
        {
            bool result = false;
            string sql = "";
            
                string[] week = "星期一,星期二,星期三,星期四,星期五,星期六,星期日".Split(',');
                for (int i = 0; i < week.Length; i++)
                {
                    sql = "INSERT INTO  hpyl_calendarweek ( `HCW_Week`, `HCW_UserId`, `HCW_ClientId`, `HCW_State`) VALUES ( '" + week[i] + "', '" + userid + "', '" + ClientId + "', '1');select @@IDENTITY";
                    object obj = DbHelperMySQL.GetSingle(sql);
                    string[] Weektime = "上午8:00-12:00,下午12:00-18:00,晚上18:00-24:00".Split(',');
                    string[] WeekTag = "M,A,N".Split(',');
                    for (int j = 0; j < Weektime.Length; j++)
                    {
                        HPYL_CalendarTime timemodel = new HPYL_CalendarTime();
                        timemodel.HCD_Name = Weektime[j];
                        timemodel.HCD_Num = 10;
                        timemodel.HCD_State = 1;
                        timemodel.HCD_Tag = WeekTag[j];
                        timemodel.HCW_ID = (obj == null ? 0 : Convert.ToInt32(obj));
                        result = AddTime(timemodel);
                    }


                }
             
            return result;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddTime(HPYL_CalendarTime model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into hpyl_calendartime(");
            strSql.Append("HCW_ID,HCD_Name,HCD_Tag,HCD_Num,HCD_State)");
            strSql.Append(" values (");
            strSql.Append("@HCW_ID,@HCD_Name,@HCD_Tag,@HCD_Num,@HCD_State)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@HCW_ID", MySqlDbType.Int64,20),
                    new MySqlParameter("@HCD_Name", MySqlDbType.VarChar,50),
                    new MySqlParameter("@HCD_Tag", MySqlDbType.VarChar,10),
                    new MySqlParameter("@HCD_Num", MySqlDbType.Int32,11),
                    new MySqlParameter("@HCD_State", MySqlDbType.Int32,11)};
            parameters[0].Value = model.HCW_ID;
            parameters[1].Value = model.HCD_Name;
            parameters[2].Value = model.HCD_Tag;
            parameters[3].Value = model.HCD_Num;
            parameters[4].Value = model.HCD_State;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
