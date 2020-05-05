using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECMS.WebPage
{
    public sealed class Registation
    {
        /*--------------------------------------
         *          Private Section
         *         Operation in Class
         *           Input From Page
         * -------------------------------------*/

        private string FirstName;
        private string SureName;
        private string Email;
        private string UserName;
        private string Password;
        private string Packege;
        private string Mobile;
        public string Key { get; set; }
        // Input From Page Public Section
        public string OTP { get; private set; }
        public string EmailCode { get; private set; }
        public string Input_FirstName
        { set { FirstName = value; } }
        public string Input_SureName
        { set { SureName = value; } }
        public string Input_Email
        { set { Email = value; } }
        public string Input_UserName
        { set { UserName = value; } }
        public string Input_Password
        { set { Password = value; } }
        public string Input_Packege
        { set { Packege = value; } }
        public string Input_Mobile
        { set { Mobile = value; } }

        /*--------------------------------------
         *           Private Section
         *         Operation in Class
         *          Output From Page
         * -------------------------------------*/
        private string Country;
        private string CountryCode;
        private string CountryIcon;
        private string MobileCode;

        // Return Type Value from private Section
        public string Country_Output
        { get { return Country; } }
        public string CountryCode_Output
        { get { return CountryCode; } }
        public string CountryIcon_Output
        { get { return CountryIcon; } }
        public string MobileCode_Output
        { get { return MobileCode; } }
        /*--------------------------------------
         *          Private Section 
         *      Output The Operation in class
         * -------------------------------------*/
       // private bool UserName_Ver;
       // private bool Email_Ver;
       // private bool Mobile_Ver;
       // private string PasswordMessege_Type;

        /*--------------------------------------
         *      Private Security System
         * -------------------------------------*/
        private bool Security_;
        private string Messege_;
        private bool _EmailVerify;
        private bool _MobileVerify;

        public string Message { get { return Messege_; } }
        public bool EmailVerify { get { return _EmailVerify; } }
        public bool MobileVerify { get { return _MobileVerify; } }
        //public bool UserNameAvaiable
        //{ get { return UserName_Ver; } }
        public string UserNameIcon { get; set; }
        public string UserNameMessege { get; set; }
        public string EmailIcon { get; set; }
        public string EmailMessege { get; set; }
        public string MobileIcon { get; set; }
        public string MobileMessege { get; set; }
        public bool PasswordRight { get; set; }
        public string RegID { get; private set; }
        public string LoginID { get; private set; }
        public string Offset { get; private set; }
        Check chk = new Check();
        public bool UserName_Avaiable(string UserName )
        {
            if (chk.int32Check("select count(*) from DeveloperRegistation where UserName='" + UserName + "' ") == 0)
            {
                UserNameIcon = "<i data-feather='check' style='color:forestgreen;'></i>";
                UserNameMessege = "";
                return true;
            }
            else
            {
                UserNameIcon = "<i data-feather='x' style='color:red;'></i>";
                UserNameMessege = "<div class='alert alert-icon-danger' role='alert'><i data-feather='alert-circle'></i>UserName is not Avaiable.</div>";
                return false;
            }
        }
        public bool Email_Avaiable(string Email)
        {
            if (chk.int32Check("select count(*) from DeveloperRegistation where Email='" + Email + "' ") == 0)
            {
                EmailIcon = "<i data-feather='check' style='color:forestgreen;'></i>";
                EmailMessege = "";
                return true;
            }
            else
            {
                EmailIcon = "<i data-feather='x' style='color:red;'></i>";
                EmailMessege = "<div class='alert alert-icon-danger' role='alert'><i data-feather='alert-circle'></i>Email is not Avaiable.</div>";
                return false;
            }
        }
        public bool Mobile_Avaiable(string Mobile)
        {
            if (chk.int32Check("select count(*) from DeveloperRegistation where Mobile='" + Mobile + "' ") == 0)
            {
                MobileIcon = "<i data-feather='check' style='color:forestgreen;'></i>";
                MobileMessege = "";
                return true;
            }
            else
            {
                MobileIcon = "<i data-feather='x' style='color:red;'></i>";
                MobileMessege = "<div class='alert alert-icon-danger' role='alert'><i data-feather='alert-circle'></i>Mobile is Already Registered.</div>";
                return false;
            }
        }
        public string PasswordStrongMessege(string Password)
        {
            AntiInjection ant = new AntiInjection();
            ant.Password = true;
            if (ant.StringData(Password))
            {
                int Minmum = 8;
                int length = Password.Length;
                bool Symbol = false;
                bool Capital = false;
                bool Smaill = false;
                bool Number = false;                
                for (int i=0;i<length;i++)
                {
                    if(Password[i]>=32 && Password[i]<=46 || Password[i] <= 64)
                    {
                        Symbol = true;
                    }
                    if (Password[i] >=48 && Password[i] <= 57)
                    {
                        Number = true;
                    }
                    if (Password[i] >= 65 && Password[i] <= 90)
                    {
                        Capital = true;
                    }
                    if (Password[i] >= 97 && Password[i] <= 122)
                    {
                        Smaill = true;
                    }
                }
                
                if(length>=Minmum)
                {
                    if(Number && Capital && Smaill && Symbol)
                    {
                        PasswordRight = true;
                        return "<strong style='color:green;'>strong</strong>";
                    }
                    else
                    {
                        PasswordRight = false;
                        return "<strong style='color:red;'>week</strong>";
                    }

                }
                else
                {
                    PasswordRight = false;
                    return "<span style='color:red;'>8 to 20 char</span>";
                }               
            }
            else
            {
                PasswordRight = false;
                return "<strong style='color:red;'>Harmful</strong>";
            }
        }
        public void Bind()
        {
            IPFinder __Ip = new IPFinder();
            __Ip.IPDetails();
            Check __Ckh = new Check();
            Country = __Ip.Country;
            CountryCode = __Ip.CountryCode;
            MobileCode = __Ckh.stringCheck("select top 1 MobileCode from Country where Country_Name='"+ __Ip.Country + "'");
            CountryIcon = __Ckh.stringCheck("select top 1 Country_Icon from Country where Country_Name='" + __Ip.Country + "'");
        }
        private bool _Reg()
        {
            AntiInjection ant = new AntiInjection();

            ant.Email = true;
            ant.Password = true;
            ant.Url = true;
            //------------------------------------------
            // anti injection for security purpass
            // it will secure the boolien methord
            //------------------------------------------
            if (ant.StringData(FirstName) &&
                ant.StringData(SureName) &&
                ant.StringData(Email) &&
                ant.StringData(UserName) &&
                ant.StringData(Password) &&
                ant.StringData(Mobile))
            {
                Security_ = true;
                /*---------------------------------
                 *   security is done now the insert and encript process
                 ----------------------------------*/                
                if(UserName_Avaiable(UserName) && Mobile_Avaiable(Mobile) && Email_Avaiable(Email))
                {
                    try
                    {
                        int Max_App = 2;/// Comming from main db settings
                        bool EmailVerify = false;
                        bool MobileVerify = false;
                        //----------------------------------------------
                        Bind();
                        //-----------------------------------------------
                        //-----------------------------------------------
                        StringGenarator __ran = new StringGenarator();
                        __ran.TotalString = 10;/// setting update
                        //-------------------------------------------
                        __ran.Hexadecimal = true;
                        string Encrypt_Key = __ran.RandomStringNumber("DeveloperRegistation", 2, '-');
                        __ran.TotalString = 5;
                        __ran.Number = true;
                        __ran.Hexadecimal = false;
                        __ran.DatabaseEntry = false;
                        string OTP = __ran.RandomStringNumber("OPT");
                        this.OTP = OTP;
                        __ran.TotalString = 20;
                        __ran.Number = true;
                        __ran.ApperCase=true;
                        __ran.DatabaseEntry = false;
                        string EmailCode = __ran.RandomStringNumber("EmailCode");
                        this.EmailCode = EmailCode;
                        //------------------------------------------------
                        //------------------------------------------------
                        Check __Chk = new Check();
                        IPFinder _IPLocation = new IPFinder();
                        //_IPLocation.IPDetails();
                        var Offset = __Chk.stringCheck("select Offset from TimeZone where Time_Zone='" + _IPLocation.TimeZone + "' ");
                        DateTimeZone __Dt = new DateTimeZone(Offset);
                        this.Offset = Offset;
                        bool f1= __Chk.ExcutionNonQuery(string.Format(@"insert into DeveloperRegistation (FastName,LastName,UserName,Email,Mobile,Country,Country_ID,Max_Apps,EmailVerify,MobileVerify,Profileimage,imagebyte,Active,EmailShow,NumberShow,JoinDate,AccountAbility)
                        values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}','{16}')",
                            FirstName,SureName,UserName,Email,Mobile,Country,__Chk.stringCheck("select Country_ID from Country where Country_Name='"+Country+"'"),Max_App, EmailCode, OTP, "image/Profile/noimage.jpg", 24576,"Online","true","true", __Dt.DateTimes(),"true"));
                        string _Registation_id = __Chk.stringCheck("select Reg_ID from DeveloperRegistation where UserName='"+UserName+"'");
                        
                        //randomly add the encrypt key it unique
                        Encrypt __Enc = new Encrypt();
                        __Enc.EncryptCode = Encrypt_Key;
                        Key = Encrypt_Key;
                        // set the encript key to add database 
                        string _UserName = __Enc.HashCode(UserName);
                        string _Password = __Enc.HashCode(Password);
                        bool f2 = __Chk.ExcutionNonQuery(string.Format(@"insert into Login (Reg_ID,UserName,Password,Encrypt_Code) values({0},'{1}','{2}','{3}')", _Registation_id,_UserName,_Password,Encrypt_Key));
                        Messege_ = string.Format(@"<div class='alert alert-icon-success' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   {0}
                             </div> ", "Registation Complete.");
                        _EmailVerify = EmailVerify;
                        _MobileVerify = MobileVerify;

                        RegID = __Chk.stringCheck("select Reg_ID from DeveloperRegistation where UserName='"+UserName+"' ");
                        LoginID = __Chk.stringCheck("select Login_ID from Login where UserName='" + __Enc.HashCode(UserName) + "' ");
                        if (f1 && f2)
                        {
                            return true;
                        }
                        else
                        {
                            Messege_ = string.Format(@"<div class='alert alert-icon-danger' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   {0}
                             </div> ", __Chk.Messege);
                            return false;
                        }
                    }
                    catch(Exception er)
                    {
                        Messege_ = string.Format(@"<div class='alert alert-icon-danger' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   {0}
                             </div> ",er.Message);
                        return false;
                    }
                     
                }
                else
                {
                    Messege_ = @"<div class='alert alert-icon-danger' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   (Verify your Email, UserName, Moble)
                                   If All are not Avaiable. Try again!
                             </div> ";
                    return false;
                }                
            }
            else
            {
                Messege_ = @"<div class='alert alert-icon-danger' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   Security Threat.
                             </div> ";
                return false;
             }
        }
        public bool Reg()
        {
            return _Reg();
        }     

        private bool _EmailVerification(string VeryficationCode, string RegID)
        {
            bool ChkCode = chk.int32Check("select count(*) from DeveloperRegistation where EmailVerify='" + VeryficationCode + "' and Reg_ID=" + RegID) == 1 ? true : false;
            if(ChkCode)
            {
                bool returnVal = chk.ExcutionNonQuery("update DeveloperRegistation set EmailVerify='true' where Reg_ID="+RegID);
                Messege_ = @"<div class='alert alert-icon-danger' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   "+chk.Messege+"</div>";
                return returnVal;
            }
            else
            {
                Messege_ = @"<div class='alert alert-icon-danger' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   Email verification is not valid id.
                             </div>";
                return false;
            }
        }
        public bool EmailVerification(string VeryficationCode, string RegID)
        { return _EmailVerification(VeryficationCode, RegID); }

    }
}
