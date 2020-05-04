using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECMS;

namespace ECMS.WebPage
{
    /// <summary>
    /// This class is made by @B-ERP-CMS
    /// </summary>
    public class Login
    {
        public Login() { }
        /// <summary>
        /// This is a ECMS.WebPage.Login Overload (+1) funtion to less your code. type the parameter.
        /// </summary>
        /// <param name="UserName">Your UserName/ Email Address</param>
        /// <param name="Password">Your Password.</param>
        public Login(string UserName, string Password) { LoginResult = _LoginCheck(UserName, Password); }
        #region Call the public class
        private AntiInjection __AntiInjection = new AntiInjection();
        private Check __Check = new Check();
        private Encrypt __Encrypt = new Encrypt();
        #endregion
        /// <summary>
        /// Set your login UserName (Email address)
        /// </summary>
        public string UserName { private get; set; }
        /// <summary>
        /// Set your login Password
        /// </summary>
        public string Password { private get; set; }
        /// <summary>
        /// Login result is a struct bool value to return Loging true or false.
        /// </summary>
        public bool LoginResult { get; private set; }
        /// <summary>
        /// This is your any type of login Error messege with code
        /// </summary>    
        public string ErrorCodeMessege { get; private set; }
        /// <summary>
        /// This is your any type of login only Error messege
        /// </summary>
        public string ErrorMessage { get; private set; }
        /// <summary>
        /// Registation ID for Session or Cookies
        /// </summary>
        public string RegID { get; private set; }
        /// <summary>
        /// Login ID for Session or Cookies
        /// </summary>
        public string LoginID { get; private set; }
        #region private function to call class public class to output
        private bool _LoginCheck()
        {
            
            __AntiInjection.Password = true;
            __AntiInjection.Email = true;
            if (__AntiInjection.StringData(UserName) && __AntiInjection.StringData(Password))
            {
                var st_d = "from DeveloperRegistation where UserName='"+UserName+"' or Email='"+ UserName + "' ";
                if(__Check.int32Check("select count(*) "+st_d)==1)
                {
                    var RegID = __Check.stringCheck("select Reg_ID "+st_d);
                    var LoginID = __Check.stringCheck("Select Login_ID from Login where Reg_ID='" + RegID + "' ");
                    var Key = __Check.stringCheck("Select Encrypt_Code from Login where Reg_ID='" + RegID + "' ");
                    __Encrypt.EncryptCode = Key;
                    if (__Check.int32Check("select count(*) from Login where Password='"+__Encrypt.HashCode(Password)+"' ")==1)
                    {
                        if (__Check.stringCheck("select AccountAbility " + st_d) == "true" || __Check.stringCheck("select AccountAbility " + st_d) == "True" || __Check.stringCheck("select AccountAbility " + st_d) == "TRUE" ? true : false)
                        {
                            this.RegID = RegID;
                            this.LoginID = LoginID;
                            LoginResult = true;
                            return true;
                        }
                        else
                        {
                            ErrorCodeMessege = "<Code:113 | Page:Login> Error: Account Suspended.";
                            ErrorMessage = "Your Account is Suspended! Contact us";
                            LoginResult = false;
                            return false;
                        }
                    }
                    else
                    {
                        ErrorCodeMessege = "<Code:112 | Page:Login> Error: Password/Key is Not Match in Login.";
                        ErrorMessage = "Invaild Username/Password";
                        LoginResult = false;
                        return false;
                    }
                }
                else
                {
                    ErrorCodeMessege = "<Code:111 | Page:Login> Error: UserName is Not Match in Registation.";
                    ErrorMessage = "Invaild Username/Password";
                    LoginResult = false;
                    return false;
                }
            }
            else
            {
                ErrorCodeMessege = "<Code:110 | Page:Login> Error: Hurmful String! Security Reason";
                ErrorMessage = "Hurmful String! Security Reason";
                LoginResult = false;
                return false;
            }
        }
        private bool _LoginCheck(string UserName, string Password)
        {

            __AntiInjection.Password = true;
            __AntiInjection.Email = true;
            if (__AntiInjection.StringData(UserName) && __AntiInjection.StringData(Password))
            {
                var st_d = "from DeveloperRegistation where UserName='" + UserName + "' or Email='" + UserName + "' ";
                if (__Check.int32Check("select count(*) " + st_d) == 1)
                {
                    var RegID = __Check.stringCheck("select Reg_ID " + st_d);
                    var LoginID = __Check.stringCheck("Select Login_ID from Login where Reg_ID='" + RegID + "' ");
                    var Key = __Check.stringCheck("Select Encrypt_Code from Login where Reg_ID='" + RegID + "' ");
                    __Encrypt.EncryptCode = Key;
                    if (__Check.int32Check("select count(*) from Login where Password='" + __Encrypt.HashCode(Password) + "' ") == 1)
                    {
                        this.RegID = RegID;
                        this.LoginID = LoginID;
                        LoginResult = true;
                        return true;
                    }
                    else
                    {
                        ErrorCodeMessege = "<Code:112 | Page:Login> Error: Password/Key is Not Match in Login.";
                        ErrorMessage = "Invaild Username/Password";
                        LoginResult = false;
                        return false;
                    }
                }
                else
                {
                    ErrorCodeMessege = "<Code:111 | Page:Login> Error: UserName is Not Match in Registation.";
                    ErrorMessage = "Invaild Username/Password";
                    LoginResult = false;
                    return false;
                }
            }
            else
            {
                ErrorCodeMessege = "<Code:110 | Page:Login> Error: Hurmful String! Security Reason";
                ErrorMessage = "Hurmful String! Security Reason";
                LoginResult = false;
                return false;
            }
        }
        #endregion
        /// <summary>
        /// Check you login Username and password.
        /// Must be declare ECMC.WebPage.Login.UserName and ECMC.WebPage.Login.Password
        /// </summary>
        /// <returns>return the boolen value to check.</returns>
        public bool LoginCheck()
        { return _LoginCheck(); }    
        /// <summary>
        /// This overload (+1) function is same as LoginCheck. This Function has two parameters.
        /// </summary>
        /// <param name="UserName">Type Your UserName/Email Address.</param>
        /// <param name="Password">Type Your Password.</param>
        /// <returns></returns>
        public bool LoginCheck(string UserName, string Password)
        { return _LoginCheck(UserName, Password); }

    }
}
