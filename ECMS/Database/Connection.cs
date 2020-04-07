using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;


namespace ECMS
{
    public class Connection
    {
        //
        private string MainDB_DataBaseName= "ERCMSMainDB";
        private string MainDB_UserID = "MainDBuser";
        private string MainDB_Password = "Pi@sh885989";
        private string MainDB_DataSource = "DESKTOP-SUFDOAC";
        /* ---------------------------------------------------
         * that is Default code to Main DB 
         *  --------------------------------------------------*/
        private bool __Encrypt=false;
        private string __Key;

        public string Key { set { __Key = value; } }
        public bool Encrypt { set { __Encrypt = value; } }
        SqlConnection con;
        Decrypt __Dek;
        public string DatabaseName { set { MainDB_DataBaseName = value; } }
        public string UserID { set { MainDB_UserID = value; } }
        public string Password { set { MainDB_Password = value; } }
        public string DataSource { set { MainDB_DataSource = value; } }
        private string ErrorMessage;
        public string ErrorMessageSQL { get { return ErrorMessage; } }
        private bool __SqlConnectionStatus;
        public bool SqlConnectionStatus { get { return __SqlConnectionStatus; } }
        public bool SqlConnectStatus()
        {
            //string ConnetionString = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
            //       MainDB_DataSource,MainDB_DataBaseName,MainDB_UserID,MainDB_Password);
            try
            {
                string DataSource = MainDB_DataSource;
                string DataBaseName = MainDB_DataBaseName;
                string UserID = MainDB_UserID;
                string Password = MainDB_Password;

                if(__Encrypt)
                {
                    __Dek = new Decrypt();
                    __Dek.DecryptCode = __Key;
                    DataSource = __Dek.GetDecryptHashCode(MainDB_DataSource);
                    DataBaseName = __Dek.GetDecryptHashCode(MainDB_DataBaseName);
                    UserID = __Dek.GetDecryptHashCode(MainDB_UserID);
                    Password = __Dek.GetDecryptHashCode(MainDB_Password);
                }
                SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
                //s.Encrypt = true;
                s.DataSource = DataSource;
                s.InitialCatalog = DataBaseName;
                s.UserID = UserID;
                s.Password = Password;
                s.IntegratedSecurity = true;
                con = new SqlConnection(s.ConnectionString);            
                if (con.State == ConnectionState.Closed)
                    { ErrorMessage = "Success"; __SqlConnectionStatus = true; return true; }  
                else
                    { ErrorMessage = "Failed"; __SqlConnectionStatus = false;  return false;  }              
            }
            catch(Exception er)
            {
                ErrorMessage = "Connection/"+er.Message;
                __SqlConnectionStatus = false;
                return false;
            }           
        }
        public SqlConnection Configuration()
        {            
            //--------------------------------------
            // Copy the Encrypt text
            //--------------------------------------
            string DataSource = MainDB_DataSource;
            string DataBaseName = MainDB_DataBaseName;
            string UserID = MainDB_UserID;
            string Password = MainDB_Password;
            if (__Encrypt)// if Encrypt is true that is Decode the program
            {
                __Dek = new Decrypt();
                __Dek.DecryptCode = __Key;
                //------------------------------------------------
                // that is the decrypt code process and __key is a 
                // Decrypt code to plain text.
                //-------------------------------------------------
                DataSource = __Dek.GetDecryptHashCode(MainDB_DataSource);
                DataBaseName = __Dek.GetDecryptHashCode(MainDB_DataBaseName);
                UserID = __Dek.GetDecryptHashCode(MainDB_UserID);
                Password = __Dek.GetDecryptHashCode(MainDB_Password);
            }
            SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
            // s.Encrypt = true;
            s.DataSource = DataSource;
            s.InitialCatalog = DataBaseName;
            s.UserID = UserID;
            s.Password = Password;
            s.IntegratedSecurity = true;
            SqlConnection cc = new SqlConnection(s.ConnectionString);
            //----------------------------------------------------    
            //All are ok then SqlConnection is return to Excutive 
            //----------------------------------------------------          
            return cc;            
        }

    }
}
