using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS
{
    public class DateTimeZone
    {
        private string _Zone;
        private string _Sign;
        private string _tTime_Off_Set;
        public string ErrorMessege { get; private set; }
        DateTimeZone() { }
        public DateTimeZone(string TimeZone)
        {
            _Zone = TimeZone;
        }
        public string UTC_Ofset { set { _Zone = value; } }

        private string _DateTimeZonePV()
        {
            try
            {
                _Sign = _Zone.Substring(0, 1);
                _tTime_Off_Set = _Zone.Substring(1, 5);
                TimeSpan _offset = new TimeSpan();
                _offset = TimeSpan.Parse(_tTime_Off_Set);
                DateTime _utc = DateTime.UtcNow;
                DateTime date;
                if (_Sign == "+")
                { date = _utc + _offset; }
                else if (_Sign == "-")
                { date = _utc - _offset; }
                else
                { date = _utc + _offset; }
                return date.ToString();
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        private string _Date_Time_Zone_PV(string TimeStyle)
        {
            try
            {
                _Sign = _Zone.Substring(0, 1);
                _tTime_Off_Set = _Zone.Substring(1, 5);
                TimeSpan _offset = new TimeSpan();
                _offset = TimeSpan.Parse(_tTime_Off_Set);
                DateTime _utc = DateTime.UtcNow;
                DateTime date;
                if (_Sign == "+")
                { date = _utc + _offset; }
                else if (_Sign == "-")
                { date = _utc - _offset; }
                else
                { date = _utc + _offset; }
                return date.ToString(TimeStyle);
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        private DateTime _DateTime()
        {
            DateTime date = new DateTime();
            try
            {
                _Sign = _Zone.Substring(0, 1);
                _tTime_Off_Set = _Zone.Substring(1, 5);
                TimeSpan _offset = new TimeSpan();
                _offset = TimeSpan.Parse(_tTime_Off_Set);
                DateTime _utc = DateTime.UtcNow;
                
                if (_Sign == "+")
                { date = _utc + _offset; }
                else if (_Sign == "-")
                { date = _utc - _offset; }
                else
                { date = _utc + _offset; }
            }
            catch (Exception err)
            {
                ErrorMessege = err.Message;
            }
            return date;
        }
        public DateTime DateTimes()
        {
            return _DateTime();
        }


        public string DateTimeResult()
        { return _DateTimeZonePV(); }
        public string DateTimeResult(string TimeStyle)
        {
            return _Date_Time_Zone_PV(TimeStyle);
        }

    }
}
