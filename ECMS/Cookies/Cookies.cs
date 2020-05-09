using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ECMS;
namespace ECMS.Cookies
{
    public class Cookies
    {
        public Cookies()
        {
            MasterCookiesName = new string[] {
             "* Name = key         | index - 0 | Cookies = "+_Cookies_Name[0],
             "* Name = Session ID  | index - 1 | Cookies = "+_Cookies_Name[1],
             "* Name = Country     | index - 2 | Cookies = "+_Cookies_Name[2],
             "* Name = Time Zone   | index - 3 | Cookies = "+_Cookies_Name[3],
             "* Name = ip          | index - 4 | Cookies = "+_Cookies_Name[4],
             "* Name = Offset      | index - 5 | Cookies = "+_Cookies_Name[5],
             "* Name = Remember me | index - 6 | Cookies = "+_Cookies_Name[6],
             "* Name = Reg id      | index - 7 | Cookies = "+_Cookies_Name[7],
             "* Name = Login id    | index - 8 | Cookies = "+_Cookies_Name[8],
             "* Name = Active      | index - 9 | Cookies = "+_Cookies_Name[9]
            };
        }

        #region Public Variable
        /// <summary>
        /// Checkbox check the Remember me true or false boolen value.
        /// </summary>
        public bool RememberMe { set { _RememberMe = value; } }
        public string ErrorMessage { get; private set; }
        public string Key { get; set; }     
        public string[] CookiesName { get { return _Cookies_Name; } }
        public string[] CookiesValue { get { return _Cookies_Value; } }
        public string[] CookiesValueEncrypt { get { return _Cookies_Value_Encrypt; } }
        /// <summary>
        /// This is a Session Id for Session[ID] value
        /// </summary>
        public string SessionID { get; private set; }              
        /// <summary>
        /// This is a Cookies sys how to look like cookies
        /// </summary>
        public string[] MasterCookiesName { get; private set; }

        #region Check Cookies get; Value and private set; Value
        /// <summary>
        /// CheckCookies() Function get; the Country data
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; the TimeZone data
        /// </summary>
        public string TimeZone { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; the IpAddress data
        /// </summary>
        public string IpAddress { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; the Offset data
        /// </summary>
        public string Offset { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; the Rememberme data
        /// </summary>
        public bool Rememberme { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; the RegID data
        /// </summary>
        public string RegID { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; the LoginID data
        /// </summary>
        public string LoginID { get; private set; }
        //----------------------------------------------------------
        /// <summary>
        /// CheckCookies() Function get; FirstName data view from database
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; LastName data view from database
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Email data view from database
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; MobileNumber data view from database
        /// </summary>
        public string MobileNumber { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Max_Apps data view from database
        /// </summary>
        public int Max_Apps { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; EmailVerify data view from database Value(true/True or string value [code] )
        /// </summary>
        public string EmailVerify { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; MobileVerify data view from database Value(true/True or string value [code] )
        /// </summary>
        public string MobileVerify { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Profileimage data view from database
        /// </summary>
        public string Profileimage { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Active data view from database
        /// </summary>
        public string Active { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Discription data view from database
        /// </summary>
        public string Discription { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Website data view from database
        /// </summary>
        public string Website { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; EmailShow data view from database
        /// </summary>
        public bool EmailShow { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; NumberShow data view from database
        /// </summary>
        public bool NumberShow { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; JoinDate data view from database
        /// </summary>
        public string JoinDate { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; Region data view from database
        /// </summary>
        public string Region { get; private set; }
        /// <summary>
        /// CheckCookies() Function get; AccountAbility data view from database
        /// </summary>
        public bool AccountAbility { get; private set; }

        #endregion
        #endregion

        #region Private Variable
        private bool _RememberMe = false;
        /*-----------------------------
         * key          in - 0
         * Session ID   in - 1
         * Country      in - 2
         * Time Zone    in - 3
         * ip           in - 4
         * Offset       in - 5    
         * Remember me  in - 6
         * Reg id       in - 7
         * Login id     in - 8  
         * Active       in - 9    
         ------------------------------*/
        private string[] _Cookies_Name = new string[] {
            "_e_ke_p",    // key          in - 0
            "_id_e",      // Session ID   in - 1            
            "_cnty_e",    // Country      in - 2
            "_tZ_e",      // Time Zone    in - 3
            "_i_e",       // ip           in - 4
            "_offset_e",  // Offset       in - 5    
            "_rm_e",      // Remember me  in - 6
            "_r_id_e",    // Reg id       in - 7
            "_l_id_e",    // Login id     in - 8 
            "_active_e"   // Active       in - 9     
        };
        private string[] _Cookies_Value;
        private string[] _Cookies_Value_Encrypt;
        #endregion

        #region Public Class Calling Methord
        StringGenarator _Random = new StringGenarator();
        IPFinder __IPFinder = new IPFinder();
        Check __Check = new Check();
        Encrypt __Encrypt = new Encrypt();
        Decrypt __Decrypt = new Decrypt();
        List<HttpCookie> _Cookies = new List<HttpCookie>();
        #endregion
        private List<HttpCookie> _Add(string Log_id,string Reg_id,string Device)
        {
            __IPFinder.IPDetails();
            var Country = __IPFinder.Country;
            var TimeZone = __IPFinder.TimeZone;
            var IP = __IPFinder.IP;
            var Offset = __Check.stringCheck("select Offset from TimeZone where Time_Zone='"+ TimeZone + "' ");
            int RememberMax = 7;
            _Random.DatabaseEntry = false;
            _Random.ApperCase = true;
            _Random.Number = true;
            _Random.TotalString = 15;
            var Key = _Random.RandomStringNumber("Cookies_Key");
            __Encrypt.EncryptCode = Key;
            _Random.DatabaseEntry = true;
            _Random.ApperCase = false;
            _Random.Number = false;
            _Random.Hexadecimal = true;
            _Random.TotalString = 10;
            var SessionID = _Random.RandomStringNumber("Sesion_ID");
            var RememberMe = _RememberMe == true ? "true" : "false";
            /*-----------------------------
             * key          in - 0
             * Session ID   in - 1
             * Active       in - 2
             * Country      in - 3
             * Time Zone    in - 4
             * ip           in - 5
             * Offset       in - 6    
             * Remember me  in - 7
             * Reg id       in - 8
             * Login id     in - 9      
             ------------------------------*/
            _Cookies_Value_Encrypt = new string[] {
                Key,
                __Encrypt.HashCode(SessionID),                
                __Encrypt.HashCode(Country),
                __Encrypt.HashCode(TimeZone),
                __Encrypt.HashCode(IP),
                __Encrypt.HashCode(Offset),
                __Encrypt.HashCode(RememberMe),
                __Encrypt.HashCode(Reg_id),
                __Encrypt.HashCode(Log_id),
                __Encrypt.HashCode("true")

            };
            _Cookies_Value = new string[] {
                Key,
                SessionID,                
                Country,
                TimeZone,
                IP,
                Offset,
                RememberMe,
                Reg_id,
                Log_id,
                "true",
            };
            DateTimeZone __DateTime = new DateTimeZone(Offset);
            DateTimeZone __BD_DateTime_Zone = new DateTimeZone("+06:00");
            this.SessionID = SessionID;
            var UserCurrentDate = __DateTime.DateTimeResult("MM/dd/yyyy hh:mm:ss:fff tt");
            bool updateActive = __Check.ExcutionNonQuery("update System_Session set Active='false' where Reg_ID='" + Reg_id + "' ");
            bool chkExcute = __Check.ExcutionNonQuery(string.Format(@"insert into System_Session 
      (Session_id
      ,Active
      ,Country
      ,TimeZone
      ,IP
      ,Offset
      ,Rememberme
      ,Reg_ID
      ,Login_ID
      ,Decrypt_Key
      ,Machine_DateTime
      ,User_DateTime
      ,BD_DateTime
      ,ExpireDateTime
      ,Device
      ,DeviceFullDetails)
      
 values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}')
", SessionID,"true",Country,TimeZone,IP,Offset,RememberMe,Reg_id,Log_id,Key,
DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss:fff tt"), UserCurrentDate,
__BD_DateTime_Zone.DateTimeResult("MM/dd/yyyy hh:mm:ss:fff tt"),_RememberMe==true?__DateTime.DateTimes().AddDays(7).ToString("MM/dd/yyyy hh:mm:ss:fff tt"): UserCurrentDate,
CurrentDevice(Device), Device));
            int i = 0;
            foreach(string Name in _Cookies_Name)
            {
                HttpCookie Cookiess = new HttpCookie(Name,_Cookies_Value_Encrypt[i]);
                if (_RememberMe)
                { Cookiess.Expires = __DateTime.DateTimes().AddDays(RememberMax); }
                _Cookies.Add(Cookiess);
                
                i++;
            }
            if (!chkExcute)
                ErrorMessage = "Excute Error: "+__Check.Messege;
            if (!updateActive)
                ErrorMessage += "update Error: " + __Check.Messege;

            return _Cookies;
        }
        private string CurrentDevice(string fullDeviceCode)
        {
            int start = 0, end = 0, length = 0; bool lengths = false;
            string version = fullDeviceCode;
            for (int i = 0; i < version.Length; i++)
            {
                if (version[i] == '(')
                { start = i + 1; lengths = true; }
                if (version[i] == ')')
                { lengths = false; end = i; break; }
                if (lengths) { length++; }
            }
            return version.Substring(start, length - 1);
        }

        /// <summary>
        /// Add your hole list System.Web.HttpCookie to Response.
        /// </summary>
        /// <param name="Log_id">Login ID for user login system.</param>
        /// <param name="Reg_id">Registation ID for Developer Registation System.</param>
        /// <param name="Device">This is a browser or cookies or windows version for device details.</param>
        /// <returns>Return the value is list<System.Web.HttpCookie> Values.</returns>
        public List<HttpCookie> Add(string Log_id, string Reg_id,string Device)
        { return _Add(Log_id, Reg_id,Device); }        
        private bool _CheckCookies(string[]CookiesValues)
        {
            if (CookiesValues.Length==_Cookies_Name.Length)
            {
                var Key = CookiesValues[0];
                __Decrypt.DecryptCode = Key;
                string[] Decrypt_CookiesValues = new string[CookiesValues.Length];
                for (int i = 1; i < CookiesValues.Length; i++)
                { Decrypt_CookiesValues[i] = __Decrypt.GetDecryptHashCode(CookiesValues[i]);}
                //------- Decrypt Coding for value
                var SessionID = Decrypt_CookiesValues[1];
                if (__Check.int32Check("select count(*) from System_Session where Session_id='" + SessionID + "' and Active='true' ") == 1)
                {
                    Country = Decrypt_CookiesValues[2];
                    TimeZone = Decrypt_CookiesValues[3];
                    IpAddress = Decrypt_CookiesValues[4];
                    Offset = Decrypt_CookiesValues[5];
                    Rememberme = Decrypt_CookiesValues[6] == "true" || Decrypt_CookiesValues[6] == "True" ? true : false;
                    RegID = Decrypt_CookiesValues[7];
                    LoginID = Decrypt_CookiesValues[8];
                    var st = " from DeveloperRegistation where Reg_ID='"+RegID+"' ";
                    FirstName = __Check.stringCheck("select FastName "+st);
                    LastName = __Check.stringCheck("select LastName " + st);
                    Email = __Check.stringCheck("select Email " + st);
                    Max_Apps = __Check.int32Check("select Max_Apps " + st);
                    EmailVerify = __Check.stringCheck("select EmailVerify " + st);
                    MobileVerify = __Check.stringCheck("select MobileVerify " + st);
                    Profileimage = __Check.stringCheck("select Profileimage " + st);
                    Active = __Check.stringCheck("select Active " + st);
                    Discription = __Check.stringCheck("select Discription " + st);
                    MobileNumber = __Check.stringCheck("select Mobile " + st);
                    Website = __Check.stringCheck("select Website " + st);
                    EmailShow = __Check.stringCheck("select EmailShow " + st) == "true" || __Check.stringCheck("select EmailShow " + st) == "True" || __Check.stringCheck("select EmailShow " + st) == "TRUE" ? true : false;
                    NumberShow = __Check.stringCheck("select NumberShow " + st) == "true" || __Check.stringCheck("select NumberShow " + st) == "True" || __Check.stringCheck("select NumberShow " + st) == "TRUE" ? true : false;
                    JoinDate = __Check.stringCheck("select JoinDate " + st);
                    Region = __Check.stringCheck("select Region " + st);
                    AccountAbility = __Check.stringCheck("select AccountAbility " + st) == "true" || __Check.stringCheck("select AccountAbility " + st) == "True" || __Check.stringCheck("select AccountAbility " + st) == "TRUE" ? true : false;


                    return true;
                }
                else
                {
                    ErrorMessage = "<Code:150 | Page:Cookies> Error: Hurmful! Session ID /Active are Not Match.";
                    return false;
                }
            }
            else
            {
                ErrorMessage = "<Code:151 | Page:Cookies> Error: Hurmful! Cookies length not equal.";
                return false;
            }             
        }
        /// <summary>
        /// Cookies Check and if it ok then send cookies data and extra Registation data also
        /// </summary>
        /// <param name="CookiesValues">This is All Avaiable cookies in string array format.</param>
        /// <returns></returns>
        public bool CheckCookies(string[] CookiesValues)
        { return _CheckCookies(CookiesValues); }
        private bool _logoutClear(string[] CookiesValues)
        {
            if (CookiesValues.Length == _Cookies_Name.Length)
            {
                var Key = CookiesValues[0];
                __Decrypt.DecryptCode = Key;
                string[] Decrypt_CookiesValues = new string[CookiesValues.Length];
                for (int i = 1; i < CookiesValues.Length; i++)
                { Decrypt_CookiesValues[i] = __Decrypt.GetDecryptHashCode(CookiesValues[i]); }
                //------- Decrypt Coding for value
                var SessionID = Decrypt_CookiesValues[1];//session id
                var RegID = Decrypt_CookiesValues[7];//reg id
                if (__Check.int32Check("select count(*) from System_Session where Session_id='" + SessionID + "' and Active='true' ") == 1)
                {
                    bool updateActive = __Check.ExcutionNonQuery("update System_Session set Active='false' where Reg_ID='" + RegID + "' and Session_id='"+SessionID+"' ");
                    ErrorMessage = "<Code:154 | Page:Cookies > Error: " + __Check.Messege;
                    return true;
                }
                 else
                {
                    ErrorMessage = "<Code:153 | Page:Cookies > Error: "+ __Check.Messege;
                    return false;
                }
            }
            else
            {
                ErrorMessage = "<Code:152 | Page:Cookies> Error: Cookies Length issues.";
                return false;
            }
        }
        public bool loginClear(string[] CookiesValues)
        { return _logoutClear(CookiesValues); }

    }
}
