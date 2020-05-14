using ECMS.WebPage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using MySql;
using MySql.Data.MySqlClient;
using System.IO;

namespace ECMS.Design
{
    public class Template
    {
        public string TemplateID { get; set; }
        public Template(string TemplateID)
        {
            this.TemplateID = TemplateID;
        }
        public Template() { }
        private Check __CheckTemplate = new Check();
        public string ErrorMessege { get; private set; }
        public int IntCheck(string SqlQuery)
        {
            int ReturnValue = -1;
            Check __Check = new Check();
            var DBID = __Check.stringCheck("select DB_ID from System_Template where Template_Id=" + TemplateID);
            var st = " from System_Database where DB_ID=" + DBID;
            var DataSource = __Check.stringCheck("select Data_Source " + st);
            var Database_Name = __Check.stringCheck("select Initial_Catalog " + st);
            var User_ID = __Check.stringCheck("select User_ID " + st);
            var Password = __Check.stringCheck("select Password " + st);
            var Port = __Check.stringCheck("select Port " + st);
            var SQLType = __Check.stringCheck("select SQLType" + st);
            var Key = __Check.stringCheck("select Encrypt_Code " + st);
            var DI_Key = __Check.int32Check("select DI_Key" + st);
            Decrypt __dec = new Decrypt();
            __dec.Key = Key;
            __dec.SetDerivationIterations = DI_Key;
            DataSource = __dec.Decrypt256bits(DataSource);
            Database_Name = __dec.Decrypt256bits(Database_Name);
            User_ID = __dec.Decrypt256bits(User_ID);
            Password = __dec.Decrypt256bits(Password);
            SQLType = __dec.Decrypt256bits(SQLType);
            bool IsConnection = false;
            SqlConnection Mscon = new SqlConnection();
            MySqlConnection Mycon = new MySqlConnection();
            if (SQLType == "MSSQL" || SQLType == "mssql")
            {
                Sqlconnection Connection = new Sqlconnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserID = User_ID;
                Connection.Password = Password;
                IsConnection = Connection.SqlConnectStatus();
                Mscon = Connection.Configuration();
                __CheckTemplate.IsConnected = true;
                __CheckTemplate.Conected = Mscon;
                return __CheckTemplate.int32Check(SqlQuery);
            }
            else
            {
                Port = __dec.Decrypt256bits(Port);
                MysqlConnection Connection = new MysqlConnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserName = User_ID;
                Connection.Password = Password;
                Connection.Port = Port;
                IsConnection = Connection.MySqlConnectionStatus();
                Mycon = Connection.Configuration();
                __CheckTemplate.IsMySqlConnected = true;
                __CheckTemplate.MySqlEnable = true;
                __CheckTemplate.MyConnected = Mycon;
                return __CheckTemplate.int32Check(SqlQuery);
            }           
        }
        public string StringCheck(string SqlQuery)
        {
            Check __Check = new Check();
            var DBID = __Check.stringCheck("select DB_ID from System_Template where Template_Id=" + TemplateID);
            var st = " from System_Database where DB_ID=" + DBID;
            var DataSource = __Check.stringCheck("select Data_Source " + st);
            var Database_Name = __Check.stringCheck("select Initial_Catalog " + st);
            var User_ID = __Check.stringCheck("select User_ID " + st);
            var Password = __Check.stringCheck("select Password " + st);
            var Port = __Check.stringCheck("select Port " + st);
            var SQLType = __Check.stringCheck("select SQLType" + st);
            var Key = __Check.stringCheck("select Encrypt_Code " + st);
            var DI_Key = __Check.int32Check("select DI_Key" + st);
            Decrypt __dec = new Decrypt();
            __dec.Key = Key;
            __dec.SetDerivationIterations = DI_Key;
            DataSource = __dec.Decrypt256bits(DataSource);
            Database_Name = __dec.Decrypt256bits(Database_Name);
            User_ID = __dec.Decrypt256bits(User_ID);
            Password = __dec.Decrypt256bits(Password);
            SQLType = __dec.Decrypt256bits(SQLType);
            bool IsConnection = false;
            SqlConnection Mscon = new SqlConnection();
            MySqlConnection Mycon = new MySqlConnection();
            if (SQLType == "MSSQL" || SQLType == "mssql")
            {
                Sqlconnection Connection = new Sqlconnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserID = User_ID;
                Connection.Password = Password;
                IsConnection = Connection.SqlConnectStatus();
                Mscon = Connection.Configuration();
                __CheckTemplate.IsConnected = true;
                __CheckTemplate.Conected = Mscon;
                return __CheckTemplate.stringCheck(SqlQuery);
            }
            else
            {
                Port = __dec.Decrypt256bits(Port);
                MysqlConnection Connection = new MysqlConnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserName = User_ID;
                Connection.Password = Password;
                Connection.Port = Port;
                IsConnection = Connection.MySqlConnectionStatus();
                Mycon = Connection.Configuration();
                __CheckTemplate.IsMySqlConnected = true;
                __CheckTemplate.MySqlEnable = true;
                __CheckTemplate.MyConnected = Mycon;
                return __CheckTemplate.stringCheck(SqlQuery);
            }
        }    
        public bool ExcutionNonQuery(string SqlQuery)
        {
            

            Check __Check = new Check();
            var DBID = __Check.stringCheck("select DB_ID from System_Template where Template_Id=" + TemplateID);
            var st = " from System_Database where DB_ID=" + DBID;
            var DataSource = __Check.stringCheck("select Data_Source " + st);
            var Database_Name = __Check.stringCheck("select Initial_Catalog " + st);
            var User_ID = __Check.stringCheck("select User_ID " + st);
            var Password = __Check.stringCheck("select Password " + st);
            var Port = __Check.stringCheck("select Port " + st);
            var SQLType = __Check.stringCheck("select SQLType" + st);
            var Key = __Check.stringCheck("select Encrypt_Code " + st);
            var DI_Key = __Check.int32Check("select DI_Key" + st);
            Decrypt __dec = new Decrypt();
            __dec.Key = Key;
            __dec.SetDerivationIterations = DI_Key;
            DataSource = __dec.Decrypt256bits(DataSource);
            Database_Name = __dec.Decrypt256bits(Database_Name);
            User_ID = __dec.Decrypt256bits(User_ID);
            Password = __dec.Decrypt256bits(Password);
            SQLType = __dec.Decrypt256bits(SQLType);
            bool IsConnection = false;
            SqlConnection Mscon = new SqlConnection();
            MySqlConnection Mycon = new MySqlConnection();
            if (SQLType == "MSSQL" || SQLType == "mssql")
            {
                Sqlconnection Connection = new Sqlconnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserID = User_ID;
                Connection.Password = Password;
                IsConnection = Connection.SqlConnectStatus();
                Mscon = Connection.Configuration();
                __CheckTemplate.IsConnected = true;
                __CheckTemplate.Conected = Mscon;
                ErrorMessege = __CheckTemplate.Messege;
                return __CheckTemplate.ExcutionNonQuery(SqlQuery);
            }
            else
            {
                Port = __dec.Decrypt256bits(Port);
                MysqlConnection Connection = new MysqlConnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserName = User_ID;
                Connection.Password = Password;
                Connection.Port = Port;
                IsConnection = Connection.MySqlConnectionStatus();
                Mycon = Connection.Configuration();
                __CheckTemplate.IsMySqlConnected = true;
                __CheckTemplate.MySqlEnable = true;
                __CheckTemplate.MyConnected = Mycon;
                ErrorMessege = __CheckTemplate.Messege;
                return __CheckTemplate.ExcutionNonQuery(SqlQuery);
            }
        }
        public bool ExcutionNonQuery(string SqlQuery,T_Parameter[] Parameters)
        {
            Check __Check = new Check();
            var DBID = __Check.stringCheck("select DB_ID from System_Template where Template_Id=" + TemplateID);
            var st = " from System_Database where DB_ID=" + DBID;
            var DataSource = __Check.stringCheck("select Data_Source " + st);
            var Database_Name = __Check.stringCheck("select Initial_Catalog " + st);
            var User_ID = __Check.stringCheck("select User_ID " + st);
            var Password = __Check.stringCheck("select Password " + st);
            var Port = __Check.stringCheck("select Port " + st);
            var SQLType = __Check.stringCheck("select SQLType" + st);
            var Key = __Check.stringCheck("select Encrypt_Code " + st);
            var DI_Key = __Check.int32Check("select DI_Key" + st);
            Decrypt __dec = new Decrypt();
            __dec.Key = Key;
            __dec.SetDerivationIterations = DI_Key;
            DataSource = __dec.Decrypt256bits(DataSource);
            Database_Name = __dec.Decrypt256bits(Database_Name);
            User_ID = __dec.Decrypt256bits(User_ID);
            Password = __dec.Decrypt256bits(Password);
            SQLType = __dec.Decrypt256bits(SQLType);
            bool IsConnection = false;
            SqlConnection Mscon = new SqlConnection();
            MySqlConnection Mycon = new MySqlConnection();
            if (SQLType == "MSSQL" || SQLType == "mssql")
            {
                Sqlconnection Connection = new Sqlconnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserID = User_ID;
                Connection.Password = Password;
                IsConnection = Connection.SqlConnectStatus();
                Mscon = Connection.Configuration();
                __CheckTemplate.IsConnected = true;
                __CheckTemplate.Conected = Mscon;
                ErrorMessege = __CheckTemplate.Messege;
                SqlParameter[] SqlParameters = T_Parameter_to_SqlParameter(Parameters);
                return __CheckTemplate.ExcutionNonQuery(SqlQuery, SqlParameters);
            }
            else
            {
                Port = __dec.Decrypt256bits(Port);
                MysqlConnection Connection = new MysqlConnection();
                Connection.DatabaseName = Database_Name;
                Connection.DataSource = DataSource;
                Connection.UserName = User_ID;
                Connection.Password = Password;
                Connection.Port = Port;
                IsConnection = Connection.MySqlConnectionStatus();
                Mycon = Connection.Configuration();
                __CheckTemplate.IsMySqlConnected = true;
                __CheckTemplate.MySqlEnable = true;
                __CheckTemplate.MyConnected = Mycon;
                ErrorMessege = __CheckTemplate.Messege;
                MySqlParameter[] SqlParameters = T_Parameter_to_MySqlParameter(Parameters);
                return __CheckTemplate.ExcutionNonQuery(SqlQuery, SqlParameters);
            }
        }
        private SqlParameter[] T_Parameter_to_SqlParameter(T_Parameter[] Parameter)
        {            
            SqlParameter[] pp = new SqlParameter[Parameter.Length];int i = 0;
            foreach (T_Parameter p in Parameter)
            {
                pp[i].ParameterName = p.ParameterName;
                pp[i].Value = p.Value;
                i++;
            }
            return pp;
        }
        private MySqlParameter[] T_Parameter_to_MySqlParameter(T_Parameter[] Parameter)
        {
            MySqlParameter[] pp = new MySqlParameter[Parameter.Length]; int i = 0;
            foreach (T_Parameter p in Parameter)
            {
                pp[i].ParameterName = p.ParameterName;
                pp[i].Value = p.Value;
                i++;
            }
            return pp;
        }
        

    }
    public class T_Parameter
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public T_Parameter(string ParameterName,object Value)
        {
            this.ParameterName = ParameterName;
            this.Value = Value;
        }
    }
    public class T_FileUpload
    {
        public string RegID { get; set; }
        public string Template_Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string DateTime { get; set; }
        public string FullPath { get; set; }
    }
}
