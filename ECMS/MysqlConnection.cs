using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ECMS
{
    public class MysqlConnection
    {
        private string _DataSource = "127.0.0.1";
        private string _Port = "3306";
        private string _UserName = "root";
        private string _Password = "";
        private string _DatabaseName = "test";
        private bool __Encrypt = false;
        private string __Key= "P!@sH05";

        public string DataSource { set { _DataSource = value; } }
        public string Port { set { _Port = value; } }
        public string UserName { set { _UserName = value; } }
        public string Password { set { _Password = value; } }
        public string DatabaseName { set { _DatabaseName = value; } }
        public string Key { set { __Key = value; } }
        public bool Encrypt { set { __Encrypt = value; } }
        public Exception ExMessage { get; private set; }
        public string Message { get; private set; }
        public bool ConncetionStringEnable { private get; set; }
        public string ConnectionString;
        Decrypt __Dek;
        MySqlConnection __Connection;
       // MySqlCommand __Command;
        public bool MySqlConnectionStatus()
        {
           
            return _MySqlConnectionStatus();
        }
        private bool _MySqlConnectionStatus()
        {
            try
            {
                string DataSource = _DataSource;
                string Port = _Port;
                string UserName = _UserName;
                string Password = _Password;
                string DatabaseName = _DatabaseName;

                if(__Encrypt)
                {
                    __Dek = new Decrypt();
                    __Dek.DecryptCode = __Key;
                    DataSource = __Dek.GetDecryptHashCode(_DataSource);
                    Port = __Dek.GetDecryptHashCode(_Port);
                    UserName = __Dek.GetDecryptHashCode(_UserName);
                    Password = __Dek.GetDecryptHashCode(_Password);
                    DatabaseName = __Dek.GetDecryptHashCode(_DatabaseName);
                }
                if(ConncetionStringEnable)
                {
                    __Connection = new MySqlConnection(ConnectionString);
                }
                else
                {
                    string MySqlConnectionString = string.Format(@"datasource={0};port={1};username={2};password={3};database={4}",
                       DataSource, Port, UserName, Password, DatabaseName);   
                    __Connection = new MySqlConnection(MySqlConnectionString);
                }
                __Connection.Open();
                if(__Connection.State == System.Data.ConnectionState.Open)
                {
                    Message = "Success";
                    __Connection.Close();
                    return true;
                }
                else
                {
                    Message = "Failed";
                    __Connection.Close();
                    return false;
                }
                
            }
            catch(Exception er)
            {
                ExMessage = er;
                Message = er.Message;
                return false;
            }
        }
        public MySqlConnection Configuration()
        {
            return _Configuration();
        }
        private MySqlConnection _Configuration()
        {
            try
            {
                string DataSource = _DataSource;
                string Port = _Port;
                string UserName = _UserName;
                string Password = _Password;
                string DatabaseName = _DatabaseName;

                if (__Encrypt)
                {
                    __Dek = new Decrypt();
                    __Dek.DecryptCode = __Key;
                    DataSource = __Dek.GetDecryptHashCode(_DataSource);
                    Port = __Dek.GetDecryptHashCode(_Port);
                    UserName = __Dek.GetDecryptHashCode(_UserName);
                    Password = __Dek.GetDecryptHashCode(_Password);
                    DatabaseName = __Dek.GetDecryptHashCode(_DatabaseName);
                }
                if (ConncetionStringEnable)
                {
                    __Connection = new MySqlConnection(ConnectionString);
                }
                else
                {
                    string MySqlConnectionString = string.Format(@"datasource={0};port={1};username={2};password={3};database={4}",
                       DataSource, Port, UserName, Password, DatabaseName);
                    __Connection = new MySqlConnection(MySqlConnectionString);
                }
                Message = "Success";
            }
            catch (Exception er)
            {
                ExMessage = er;
                Message = er.Message;
            }
            return __Connection;
        }

    }
}
