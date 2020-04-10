using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMS
{
    public class Registation
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

        // Input From Page Public Section
        
        public string FirstName_Input
        { set { FirstName = value; } }
        public string SureName_Input
        { set { SureName = value; } }
        public string Email_Input
        { set { Email = value; } }
        public string UserName_Input
        { set { UserName = value; } }
        public string Password_Input
        { set { Password = value; } }
        public string Packege_Input
        { set { Packege = value; } }
        public string Mobile_Input
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
            if (chk.int32Check("select count(*) from DeveloperRegistation where Email='" + Email + "' ") == 0)
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

        public bool Reg()
        {
            AntiInjection ant = new AntiInjection();
            ant.FullName = true;
            ant.Email = true;
            ant.Password = true;
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
                        Check __Chk = new Check();
                        __Chk.ExcutionNonQuery(string.Format(@"insert into DeveloperRegistation (FastName,LastName,UserName,Email,Mobile,Country,Country_ID,Max_Apps,EmailVerify,MobileVerify)",
                            FirstName,SureName,UserName,Email,Mobile,Country,__Chk.stringCheck("select Country_ID from Country where Country_Name='"+Country+"'"),Max_App,EmailVerify.ToString(),MobileVerify.ToString()));
                        string _Registation_id = __Chk.stringCheck("select Reg_ID from DeveloperRegistation where UserName='"+UserName+"'");
                        StringGenarator __ran = new StringGenarator();
                        __ran.TotalString = 10;/// setting update
                        //-------------------------------------------
                        __ran.Hexadecimal = true;
                        string Encrypt_Key = __ran.RandomStringNumber("DeveloperRegistation", 2,'-');
                        //randomly add the encrypt key it unique
                        Encrypt __Enc = new Encrypt();
                        __Enc.EncryptCode = Encrypt_Key;
                        // set the encript key to add database 
                        string _UserName = __Enc.HashCode(UserName);
                        string _Password = __Enc.HashCode(Password);
                        __Chk.ExcutionNonQuery(string.Format(@"insert into Login (Reg_ID,UserName,Password,Encrypt_Code)", _Registation_id,_UserName,_Password,Encrypt_Key));
                        Messege_ = string.Format(@"<div class='alert alert-icon-success' role='alert'>
                                <i data-feather='alert-circle'></i>
                                   {0}
                             </div> ", "");
                        _EmailVerify = EmailVerify;
                        _MobileVerify = MobileVerify;
                        return true;
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

    }
}
