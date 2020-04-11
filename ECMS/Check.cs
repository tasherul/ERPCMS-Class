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
using MySql.Data.MySqlClient;
using MySql;
namespace ECMS
{
    public class Check
    {
        private int _Count;
        //private string ConfigName = "DoctorDBCS";
        //public void ConnectionString(string ConnectionStringName)
        //{
        //    ConfigName = ConnectionStringName;
        //}
        Connection Sql = new Connection();
        MysqlConnection MySql = new MysqlConnection();
        public bool IsConnected { private get; set; }
        public SqlConnection Conected { private get; set; }
        public bool IsMySqlConnected { private get; set; }
        public MySqlConnection MyConnected { private get; set; }
        private bool _MySqlEnable = false;
        public bool MySqlEnable {set { _MySqlEnable = value; } }
        public Exception ExMessege { get; private set; }       
        public string Messege { get; private set; }
        public int CommandTimeout { get; set; }
        public int BoolCount
        {
            get { return _Count; }
            set { _Count = value; }
        }
        private int int_Check_PV(string CommandText)
        {
            int ReturnValue=-1;
            // the return value is fixed;
            //-----------------------------------------------------
            if (_MySqlEnable)
            {
                MySqlConnection __Conn = new MySqlConnection();
                MySqlCommand __Cmd = new MySqlCommand();
                //-----------------------------------------------
                // set the mysql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsMySqlConnected)
                    __Conn = MyConnected;
                else
                    __Conn = MySql.Configuration();
                //-----------------------------------------------
                try
                {
                    __Cmd.Connection = __Conn;
                    __Cmd.CommandText = CommandText;    
                    __Conn.Open();
                    ReturnValue = Convert.ToInt32(__Cmd.ExecuteScalar().ToString());
                    __Conn.Close();
                }
                catch (Exception er)
                {
                    ExMessege = er;
                    Messege = er.Message;
                }               
            }
            else
            {
                SqlConnection Conn = new SqlConnection();
                SqlCommand newCmd = new SqlCommand();
                //-----------------------------------------------
                // set the sql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsConnected)
                    Conn = Conected;
                else
                    Conn = Sql.Configuration();

                try
                {
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CommandText;
                    Conn.Open();
                    ReturnValue = Convert.ToInt32(newCmd.ExecuteScalar().ToString());
                    Conn.Close();
                }
                catch (Exception er)
                {
                    ExMessege = er;
                    Messege =er.Message;
                }
            }
            
            return ReturnValue; 
        }
        public int int32Check(string CommandText)
        {
            return int_Check_PV(CommandText);
        }
        private string string_Check_PV(string CommandText)
        {
            string ReturnValue=string.Empty;
            // the return value is fixed;
            //-----------------------------------------------------
            if (_MySqlEnable)
            {
                MySqlConnection __Conn = new MySqlConnection();
                MySqlCommand __Cmd = new MySqlCommand();
                //-----------------------------------------------
                // set the mysql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsMySqlConnected)
                    __Conn = MyConnected;
                else
                    __Conn = MySql.Configuration();
                //-----------------------------------------------
                try
                {
                    __Cmd.Connection = __Conn;
                    __Cmd.CommandText = CommandText;
                    __Conn.Open();
                    ReturnValue = __Cmd.ExecuteScalar().ToString();
                    __Conn.Close();
                    Messege = "Success";
                }
                catch (Exception er)
                {
                    ReturnValue = er.Message;
                    ExMessege = er;
                    Messege = er.Message;
                }
            }
            else
            {
                SqlConnection Conn = new SqlConnection();
                SqlCommand newCmd = new SqlCommand();
                //-----------------------------------------------
                // set the sql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsConnected)
                    Conn = Conected;
                else
                    Conn = Sql.Configuration();

                try
                {
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CommandText;
                    Conn.Open();
                    ReturnValue = newCmd.ExecuteScalar().ToString();
                    Conn.Close();
                    Messege = "Success";
                }
                catch (Exception er)
                {
                    ReturnValue = er.Message;
                    ExMessege = er;
                    Messege = er.Message;
                }
            }
            return ReturnValue;

        }
        public string stringCheck(string CommandText)
        {
            return string_Check_PV(CommandText);
        }
        private bool _bool_Check(string CommandText)
        {
            bool ReturnValue;
            // the return value is fixed;
            //-----------------------------------------------------
            if (_MySqlEnable)
            {
                MySqlConnection __Conn = new MySqlConnection();
                MySqlCommand __Cmd = new MySqlCommand();
                //-----------------------------------------------
                // set the mysql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsMySqlConnected)
                    __Conn = MyConnected;
                else
                    __Conn = MySql.Configuration();
                //-----------------------------------------------
                try
                {
                    __Cmd.Connection = __Conn;
                    __Cmd.CommandText = CommandText;
                    __Conn.Open();
                    int count = Convert.ToInt32(__Cmd.ExecuteScalar().ToString());
                    __Conn.Close();
                    Messege = "Success";
                    if (count == BoolCount)
                        ReturnValue = true;
                    else
                        ReturnValue = false;
                }
                catch (Exception er)
                {
                    ExMessege = er;
                    Messege = er.Message;
                    ReturnValue = false;
                }
            }
            else
            {
                SqlConnection Conn = new SqlConnection();
                SqlCommand newCmd = new SqlCommand();
                //-----------------------------------------------
                // set the sql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsConnected)
                    Conn = Conected;
                else
                    Conn = Sql.Configuration();

                try
                {
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CommandText;
                    Conn.Open();
                    int count = Convert.ToInt32(newCmd.ExecuteScalar().ToString());
                    Conn.Close(); Messege = "Success";
                    if (count == BoolCount)
                        ReturnValue = true;
                    else
                        ReturnValue = false;
                }
                catch (Exception er)
                {
                    ExMessege = er;
                    Messege = er.Message;
                    ReturnValue = false;
                }
            }
            return ReturnValue;

        }
        public bool ExcutionNonQuery(string Command)
        {
            return _ExcutionNonQuery(Command);
        }    
        private bool _ExcutionNonQuery(string CommandText)
        {
            bool ReturnValue;
            // the return value is fixed;
            //-----------------------------------------------------
            if (_MySqlEnable)
            {
                MySqlConnection __Conn = new MySqlConnection();
                MySqlCommand __Cmd = new MySqlCommand();
                //-----------------------------------------------
                // set the mysql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsMySqlConnected)
                    __Conn = MyConnected;
                else
                    __Conn = MySql.Configuration();
                //-----------------------------------------------
                try
                {
                    __Cmd.Connection = __Conn;
                    __Cmd.CommandText = CommandText;
                    __Conn.Open();
                    __Cmd.ExecuteNonQuery().ToString();
                    __Conn.Close();
                    Messege = "Success";
                    ReturnValue = true;
                }
                catch (Exception er)
                {
                    ExMessege = er;
                    Messege = er.Message;
                    ReturnValue = false;
                }
            }
            else
            {
                SqlConnection Conn = new SqlConnection();
                SqlCommand newCmd = new SqlCommand();
                //-----------------------------------------------
                // set the sql connection fix configratioin or set configaration
                //------------------------------------------------
                if (IsConnected)
                    Conn = Conected;
                else
                    Conn = Sql.Configuration();

                try
                {
                    newCmd.Connection = Conn;
                    newCmd.CommandText = CommandText;
                    Conn.Open();
                    newCmd.ExecuteNonQuery().ToString();
                    Conn.Close();
                    Messege = "Success";
                    ReturnValue = true;
                }
                catch (Exception er)
                {
                    ExMessege = er;
                    Messege = er.Message;
                    ReturnValue = false;
                }
            }
            return ReturnValue;

        }
        public bool boolCheck(string CommandText)
        {
            return _bool_Check(CommandText);
        }
        public SqlDataReader SqlDataReader(string CommandText)
        {
            SqlConnection Conn = new SqlConnection();
            SqlCommand newCmd = new SqlCommand();
            //-----------------------------------------------
            // set the sql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsConnected)
                Conn = Conected;
            else
                Conn = Sql.Configuration();

            try
            {
                newCmd.Connection = Conn;
                newCmd.CommandText = CommandText;
                Conn.Open();
                SqlDataReader _Sql = newCmd.ExecuteReader();
                Conn.Close();
                Messege = "Success";
                return _Sql;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                SqlDataReader _empty = null;
                return _empty;
            }
            

        }
        public MySqlDataReader MySqlDataReader(string CommandText)
        {
            MySqlConnection __Conn = new MySqlConnection();
            MySqlCommand __Cmd = new MySqlCommand();
            //-----------------------------------------------
            // set the mysql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsMySqlConnected)
                __Conn = MyConnected;
            else
                __Conn = MySql.Configuration();
            //-----------------------------------------------
            try
            {
                __Cmd.Connection = __Conn;
                __Cmd.CommandText = CommandText;
                __Conn.Open();
                MySqlDataReader _Return = __Cmd.ExecuteReader();
                __Conn.Close();
                Messege = "Success";
                return _Return;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                MySqlDataReader _empty = null;
                return _empty;
            }
        }        
        public SqlDataAdapter SqlDataAdapter(string CommandText)
        {
            SqlConnection Conn = new SqlConnection();
            //-----------------------------------------------
            // set the sql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsConnected)
                Conn = Conected;
            else
                Conn = Sql.Configuration();

            try
            {
                Conn.Open();
                SqlDataAdapter _SqlAdaper = new System.Data.SqlClient.SqlDataAdapter(CommandText, Conn);
                //_SqlAdaper.SelectCommand = new SqlCommand(CommandText,Conn);
                Conn.Close();
                Messege = "Success";
                return _SqlAdaper;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                SqlDataAdapter _empty = null;
                return _empty;
            }

        }
        public SqlDataAdapter SqlDataAdapter(string StoredProcedureName, bool storedProcedure)
        {
            SqlConnection Conn = new SqlConnection();
            //-----------------------------------------------
            // set the sql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsConnected)
                Conn = Conected;
            else
                Conn = Sql.Configuration();

            try
            {
                Conn.Open();
                SqlDataAdapter _SqlAdaper = new System.Data.SqlClient.SqlDataAdapter(StoredProcedureName, Conn);
                _SqlAdaper.SelectCommand.CommandType = CommandType.StoredProcedure;
                Conn.Close();
                Messege = "Success";
                return _SqlAdaper;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                SqlDataAdapter _empty = null;
                return _empty;
            }
        }
        public MySqlDataAdapter MySqlDataAdapter(string CommandText)
        {
            MySqlConnection __Conn = new MySqlConnection();           
            //-----------------------------------------------
            // set the mysql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsMySqlConnected)
                __Conn = MyConnected;
            else
                __Conn = MySql.Configuration();
            //-----------------------------------------------
            try
            {
                __Conn.Open();
                MySqlDataAdapter _MysqlDataAdaper = new MySql.Data.MySqlClient.MySqlDataAdapter(CommandText,__Conn);
                __Conn.Close();
                Messege = "Success";
                return _MysqlDataAdaper;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                MySqlDataAdapter _empty = null;
                return _empty;
            }
        }
        public MySqlDataAdapter MySqlDataAdapter(string StoredProcedureName, bool storedProcedure)
        {
            MySqlConnection __Conn = new MySqlConnection();
            //-----------------------------------------------
            // set the mysql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsMySqlConnected)
                __Conn = MyConnected;
            else
                __Conn = MySql.Configuration();
            //-----------------------------------------------
            try
            {
                __Conn.Open();
                MySqlDataAdapter _MysqlDataAdaper = new MySql.Data.MySqlClient.MySqlDataAdapter(StoredProcedureName, __Conn);
                _MysqlDataAdaper.SelectCommand.CommandType = CommandType.StoredProcedure;
                __Conn.Close();
                Messege = "Success";
                return _MysqlDataAdaper;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                MySqlDataAdapter _empty = null;
                return _empty;
            }
        }
        public DataSet SqlDataSet(string CommandText)
        {
            SqlConnection Conn = new SqlConnection();
            DataSet _dt = new DataSet();
            //-----------------------------------------------
            // set the sql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsConnected)
                Conn = Conected;
            else
                Conn = Sql.Configuration();

            try
            {
                Conn.Open();
                SqlDataAdapter _SqlAdaper = new System.Data.SqlClient.SqlDataAdapter(CommandText, Conn);
                //_SqlAdaper.SelectCommand = new SqlCommand(CommandText,Conn);
                _SqlAdaper.Fill(_dt);
                Conn.Close();
                Messege = "Success";
                return _dt;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                return _dt;
            }
        }
        public DataSet SqlDataSet(string StoredProcedureName, bool storedProcedure)
        {
            SqlConnection Conn = new SqlConnection();
            DataSet _dt = new DataSet();
            //-----------------------------------------------
            // set the sql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsConnected)
                Conn = Conected;
            else
                Conn = Sql.Configuration();

            try
            {
                Conn.Open();
                SqlDataAdapter _SqlAdaper = new System.Data.SqlClient.SqlDataAdapter(StoredProcedureName, Conn);
                _SqlAdaper.SelectCommand.CommandType = CommandType.StoredProcedure;
                _SqlAdaper.Fill(_dt);
                Conn.Close();
                Messege = "Success";
                return _dt;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                return _dt;
            }
        }
        public DataSet MySqlDataSet(string CommandText)
        {
            MySqlConnection __Conn = new MySqlConnection();
            DataSet _dt = new DataSet();
            //-----------------------------------------------
            // set the mysql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsMySqlConnected)
                __Conn = MyConnected;
            else
                __Conn = MySql.Configuration();
            //-----------------------------------------------
            try
            {
                __Conn.Open();
                MySqlDataAdapter _MysqlDataAdaper = new MySql.Data.MySqlClient.MySqlDataAdapter(CommandText, __Conn);
                _MysqlDataAdaper.Fill(_dt);
                __Conn.Close();
                Messege = "Success";
                return _dt;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;    
                return _dt;
            }
        }
        public DataSet MySqlDataSet(string StoredProcedureName, bool storedProcedure)
        {
            MySqlConnection __Conn = new MySqlConnection();
            DataSet _dt = new DataSet();
            //-----------------------------------------------
            // set the mysql connection fix configratioin or set configaration
            //------------------------------------------------
            if (IsMySqlConnected)
                __Conn = MyConnected;
            else
                __Conn = MySql.Configuration();
            //-----------------------------------------------
            try
            {
                __Conn.Open();
                MySqlDataAdapter _MysqlDataAdaper = new MySql.Data.MySqlClient.MySqlDataAdapter(StoredProcedureName, __Conn);
                _MysqlDataAdaper.SelectCommand.CommandType = CommandType.StoredProcedure;
                _MysqlDataAdaper.Fill(_dt);
                __Conn.Close();
                Messege = "Success";
                return _dt;
            }
            catch (Exception er)
            {
                ExMessege = er;
                Messege = er.Message;
                return _dt;
            }
        }


    }
}
