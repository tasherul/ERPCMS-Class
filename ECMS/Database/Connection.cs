﻿using System;
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
        private string MainDB_UserID = "MainDBusers";
        private string MainDB_Password = "Pi@sh885989";
        private string MainDB_DataSource = "DESKTOP-FOOHGE0";
        
        
        public bool ConnectionStringEnable { private get; set; }
        public string ConnectionString;

        /* ---------------------------------------------------
         * that is Default code to Main DB 
         *  --------------------------------------------------*/
        private bool __Encrypt=false;
        private string __Key= "P!@sH05";

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
            return _SqlConnectStatus();
        }
        private bool _SqlConnectStatus()
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
                if (ConnectionStringEnable)
                { con = new SqlConnection(ConnectionString); }
                else
                {
                    s.DataSource = DataSource;
                    s.InitialCatalog = DataBaseName;
                    s.UserID = UserID;
                    s.Password = Password;
                    s.IntegratedSecurity = true;
                    string ConncetionString = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", DataSource, DataBaseName, UserID, Password);
                    con = new SqlConnection(ConncetionString);
                }
                con.Open();
                if (con.State == ConnectionState.Open)
                    { ErrorMessage = "Success"; __SqlConnectionStatus = true; con.Close(); return true; }  
                else
                    { ErrorMessage = "Failed"; __SqlConnectionStatus = false; con.Close(); return false;  }              
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
            if (ConnectionStringEnable)
            {
                SqlConnection cc = new SqlConnection(ConnectionString);
                return cc;
            }
            else
            {
                s.DataSource = DataSource;
                s.InitialCatalog = DataBaseName;
                s.UserID = UserID;
                s.Password = Password;
                s.IntegratedSecurity = true;
                string ConncetionString = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", DataSource, DataBaseName, UserID, Password);
                SqlConnection cc = new SqlConnection(ConncetionString);
                return cc;
            }
            
            //----------------------------------------------------    
            //All are ok then SqlConnection is return to Excutive 
            //----------------------------------------------------          
                      
        }

    }
}
