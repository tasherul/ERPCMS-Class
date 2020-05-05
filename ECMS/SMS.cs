using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS
{
    public class SMS
    {
        /// <summary>
        /// This is your mobile number. Note: full mobile number requid.
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// This is your sending message.
        /// </summary>
        public string Message { get; set; }
        public string ErrorMessege { get; private set; }
        private Check __Check = new Check();
        private bool _SendSMS()
        {
            bool returnVal = __Check.ExcutionNonQuery("insert into from MySmsServer (MobileNumber,Messege,ReciveDateTime) value('" + Number + "','" + Message + "','" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss:fff tt") + "' ) ");
            ErrorMessege = __Check.Messege;
            return returnVal;
        }
        /// <summary>
        /// This methord is working as a Sending sms to mobile. this is just a add a data into a database it would be need a apps to sending sms.
        /// </summary>
        /// <returns>Return this boolean variable to add to database.</returns>
        public bool SendSMS()
        { return _SendSMS(); }
        private bool _SendSMS(string Number,string Message)
        {
            bool returnVal= __Check.ExcutionNonQuery("insert into MySmsServer (MobileNumber,Messege,ReciveDateTime) values('" + Number + "','" + Message + "','" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss:fff tt") + "' ) ");
            ErrorMessege = __Check.Messege;
            return returnVal;
        }
        /// <summary>
        /// This methord is working as a Sending sms to mobile. this is just a add a data into a database it would be need a apps to sending sms.
        /// </summary>
        /// <param name="Number">This is a number parameter need full number. example: +880 xxxxxxxx need your utc code and full number. </param>
        /// <param name="Message">This is your messege to send sms to another mobile.</param>
        /// <returns>Return this boolean variable to add to database.</returns>
        public bool SendSMS(string Number, string Message)
        { return _SendSMS(Number, Message); }
        private bool _OtpSet(string OTP,string RegID)
        {
            bool ReturnVal = __Check.ExcutionNonQuery("update DeveloperRegistation set MobileVerify='" + OTP+ "' where Reg_ID="+RegID);
            ErrorMessege = __Check.Messege;
            return ReturnVal;
        }
        /// <summary>
        /// OTP code is set in Developer database system to check this otp code.
        /// </summary>
        /// <param name="OTP">This your OTP code upto 5 numbers</param>
        /// <param name="RegID">This is your Registation Id to set this value</param>
        /// <returns>return the boolen value if it excution correctly.</returns>
        public bool OtpSet(string OTP, string RegID)
        { return _OtpSet(OTP, RegID); }
        private bool _OtpDone(string RegID)
        {
            bool ReturnVal = __Check.ExcutionNonQuery("update DeveloperRegistation set MobileVerify='true' where Reg_ID=" + RegID);
            ErrorMessege = __Check.Messege;
            return ReturnVal;
        }
        /// <summary>
        /// OTP code when match this function will set the OTP verification is true
        /// </summary>
        /// <param name="RegID">Valid Registation ID</param>
        /// <returns>return the excution value it ok or not.</returns>
        public bool OtpDone(string RegID)
        { return _OtpDone(RegID); }

    }
}
