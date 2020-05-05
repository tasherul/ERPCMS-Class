using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECMS.WebPage
{
    public class Notification
    {
        Check __Check = new Check();

        public string Link { get; set; }
        public IconDataFeather Icon { get; set; }
        public string Title { get; set; }
        public string Offset { get; set; }
        public string RegID { get; set; }

        public string ErrorMessage { get; private set; }
        private bool _AddNotification()
        {
            DateTimeZone __DateTimeZone = new DateTimeZone(Offset);
            bool returnVal = __Check.ExcutionNonQuery(string.Format(@"insert into System_Notifications 
            (Reg_ID,Title,Icon,Link,DateTime)  values({0},'{1}','{2}','{3}','{4}')",
            RegID,Title, Icon.ToString().Replace("_", "-"), Link, __DateTimeZone.DateTimes()));
            ErrorMessage = __Check.Messege;
            return returnVal;
        }
        private bool _AddNotification(string Title,string Link, IconDataFeather Icon,string Offset,string RegID)
        {
            DateTimeZone __DateTimeZone = new DateTimeZone(Offset);
            bool returnVal = __Check.ExcutionNonQuery(string.Format(@"insert into System_Notifications 
            (Reg_ID,Title,Icon,Link,DateTime)  values({0},'{1}','{2}','{3}','{4}')",
            RegID, Title, Icon.ToString().Replace("_","-"), Link, __DateTimeZone.DateTimes()));
            ErrorMessage = __Check.Messege;
            return returnVal;
        }
        private string _timeago(string PastDateTime, string NowDateTime)
        {
            var OTime = Convert.ToDateTime(PastDateTime);
            var NTime = Convert.ToDateTime(NowDateTime);
            var ts = new TimeSpan(NTime.Ticks - OTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
        private string _timeago(DateTime PastDateTime, DateTime NowDateTime)
        {
            var OTime = PastDateTime;
            var NTime = NowDateTime;
            var ts = new TimeSpan(NTime.Ticks - OTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
        private string _timeago(string PastDateTime, string Offset,bool AditionalCountry)
        {
            DateTimeZone __date = new DateTimeZone(Offset);
            var OTime = Convert.ToDateTime(PastDateTime);
            var NTime = __date.DateTimes();
            var ts = new TimeSpan(NTime.Ticks - OTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
        private string _timeago(string PastDateTime)
        {
            var OTime = Convert.ToDateTime(PastDateTime);
            var NTime = DateTime.Now;
            var ts = new TimeSpan(NTime.Ticks - OTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }

        /// <summary>
        /// This is a timeago function to set the datetine and past datetime and find how many time ago posting.
        /// </summary>
        /// <param name="PastDateTime">This is a string value use (MM/dd/yyyy hh:mm:ss:fff tt) fromate</param>
        /// <param name="Offset">This is a country offset code to add what time to send (+06:00) BD time set.</param>
        /// <param name="AditionalCountry">It's not necessary but using true or false it's finding this function.</param>
        /// <returns></returns>
        public string timeago(string PastDateTime, string Offset, bool AditionalCountry)
        { return _timeago(PastDateTime, Offset, AditionalCountry); }
        /// <summary>
        /// This is a timeago function to set the datetine and past datetime and find how many time ago posting.
        /// </summary>
        /// <param name="PastDateTime">This is a System.DateTime value to set this function and need past datetime.</param>
        /// <param name="NowDateTime">This is a System.DateTime value to set this function and need present datetime.</param>
        /// <returns></returns>
        public string timeago(DateTime PastDateTime, DateTime NowDateTime)
        { return _timeago(PastDateTime, NowDateTime); }
        /// <summary>
        /// This is a timeago function to set the datetine and past datetime and find how many time ago posting.
        /// </summary>
        /// <param name="PastDateTime">This is a string value use (MM/dd/yyyy hh:mm:ss:fff tt) fromate.</param>
        /// <param name="NowDateTime">This is a string value use (MM/dd/yyyy hh:mm:ss:fff tt) fromate.</param>
        /// <returns></returns>
        public string timeago(string PastDateTime, string NowDateTime)
        { return _timeago(PastDateTime, NowDateTime); }
        /// <summary>
        /// This is a timeago function to set the datetine and past datetime and find how many time ago posting.
        /// this function is using new System.DateTime function to using now dateTime.
        /// </summary>
        /// <param name="PastDateTime">This is a Past DateTime string value use (MM/dd/yyyy hh:mm:ss:fff tt) fromate.</param>
        /// <returns></returns>
        public string timeago(string PastDateTime)
        { return _timeago(PastDateTime); }
        /// <summary>
        /// This is a Adding a notification in class puclic variable value will need this value.
        /// </summary>
        /// <returns>return the boolen value true or false to add or not.</returns>
        public bool AddNotification()
        {
            return _AddNotification();
        }
        /// <summary>
        /// this function is also adding notification but it not need the public class variable it already set the variable please set and get result.
        /// </summary>
        /// <param name="Title">Type your Notification title. Note! please type short look good.</param>
        /// <param name="Link">This is a link to send to other page. if not nessery press #</param>
        /// <param name="Icon">Data Feather icon is ECMS.IconDataFeather icon to auto genareat icon.</param>
        /// <param name="Offset">Offset is set the which country are now.</param>
        /// <param name="RegID">this is a registation id whose notification it.</param>
        /// <returns></returns>
        public bool AddNotification(string Title, string Link, IconDataFeather Icon, string Offset, string RegID)
        { return _AddNotification(Title,Link,Icon,Offset,RegID); }


    }
}
