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
using System.Data;

namespace ECMS.Design
{
    public class Template
    {
        #region Default
        public Template()
        {
            

        }
        public bool IsConnection { get; set; }
        public string TemplateID { get; set; }
        public Template(string TemplateID)
        {
            this.TemplateID = TemplateID;
        }
        public string ConnectionString { get; set; }
        public string GetConnectionString()
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
            SqlConnection Mscon = new SqlConnection();
            MySqlConnection Mycon = new MySqlConnection();
            if (SQLType == "MSSQL" || SQLType == "mssql")
            {
                this.ConnectionString = "Data Source=" + DataSource + ";Initial Catalog=" + Database_Name + ";User id=" + User_ID + ";Password=" + Password + ";Integrated Security=True";
                return this.ConnectionString;
            }
            else
            {
                Port = __dec.Decrypt256bits(Port);
                this.ConnectionString = "server=" + DataSource + ":" + Port + ";uid=" + User_ID + ";pwd=" + Password + ";database=" + Database_Name + ";";
                return this.ConnectionString;
            }
        }
        private Check __CheckTemplate = new Check();
        public string ErrorMessege { get; private set; }
        public string ErrorServerMessege { get; private set; }
        private int IntCheck(string SqlQuery)
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
        private string StringCheck(string SqlQuery)
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
        private bool ExcutionNonQuery(string SqlQuery)
        {
            Check __Check = new Check();
            var DBID = __Check.stringCheck("select DB_ID from System_Template where Template_Id=" + this.TemplateID);
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
                bool x = __CheckTemplate.ExcutionNonQuery(SqlQuery);
                ErrorMessege = __CheckTemplate.Messege;
                ErrorServerMessege = __CheckTemplate.ServerMessage;
                return x;
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
                bool x = __CheckTemplate.ExcutionNonQuery(SqlQuery);
                ErrorMessege = __CheckTemplate.Messege;
                ErrorServerMessege = __CheckTemplate.ServerMessage;
                return x;
            }
        }
        private bool ExcutionNonQuery(string SqlQuery, T_Parameter[] Parameters)
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

                bool re = __CheckTemplate.ExcutionNonQuery(SqlQuery, Parameters);
                ErrorMessege = __CheckTemplate.Messege;
                ErrorServerMessege = __CheckTemplate.ServerMessage;
                return re;
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


                bool re = __CheckTemplate.ExcutionNonQuery(SqlQuery, Parameters);
                ErrorMessege = __CheckTemplate.Messege;
                ErrorServerMessege = __CheckTemplate.ServerMessage;
                return re;
            }
        }
        private DataTable SQLDataTable(string SqlQuery)
        {
            DataTable dt = new DataTable();
            Check __Check = new Check();
            var DBID = __Check.stringCheck("select DB_ID from System_Template where Template_Id=" + this.TemplateID);
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
            IsConnection = false;
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
                SqlDataAdapter da = __CheckTemplate.SqlDataAdapter(SqlQuery);
                da.Fill(dt);
                return dt;
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
                MySqlDataAdapter da = __CheckTemplate.MySqlDataAdapter(SqlQuery);
                da.Fill(dt);
                return dt;
            }
        }
       
        public double Storage()
        {
            Check __Check = new Check();
            var RegID = __Check.stringCheck("select RegID from System_Template where Template_Id=" + this.TemplateID);
            var Size = __Check.stringCheck("select sum(imageSize) from System_Template where RegID=" + RegID);
            double TemplateImageSize = Convert.ToDouble(Size == "" ? "0" : Size);
            Size = __Check.stringCheck("select sum(ImageSize) from Apps_Image where RegID=" + RegID);
            double ApplicationImageSize = Convert.ToDouble(Size == "" ? "0" : Size);
            Size = __Check.stringCheck("select imagebyte from DeveloperRegistation where Reg_ID=" + RegID);
            double ProfileImageSize = Convert.ToDouble(Size == "" ? "0" : Size);
            Size = StringCheck("select sum(FileSize) from Template_FileUpload where RegID=" + RegID);
            double FileSize = Convert.ToDouble(Size == "" ? "0" : Size);

            return (TemplateImageSize + ApplicationImageSize + ProfileImageSize + FileSize);
        }
        public double Storage(string RegID)
        {
            Check __Check = new Check();
            var Size = __Check.stringCheck("select sum(imageSize) from System_Template where RegID=" + RegID);
            double TemplateImageSize = Convert.ToDouble(Size == "" ? "0" : Size);
            Size = __Check.stringCheck("select sum(ImageSize) from Apps_Image where RegID=" + RegID);
            double ApplicationImageSize = Convert.ToDouble(Size == "" ? "0" : Size);
            Size = __Check.stringCheck("select imagebyte from DeveloperRegistation where Reg_ID=" + RegID);
            double ProfileImageSize = Convert.ToDouble(Size == "" ? "0" : Size);
            Size = StringCheck("select sum(FileSize) from Template_FileUpload where RegID=" + RegID);
            double FileSize = Convert.ToDouble(Size == "" ? "0" : Size);

            return (TemplateImageSize + ApplicationImageSize + ProfileImageSize + FileSize);
        }
        public int Alltemplate(string RegID)
        {
            Check __Check = new Check();
            return __Check.int32Check("select count(*) from System_Template where RegID="+ RegID);
        }
        public bool AvaiableStorage()
        {
            Check __Check = new Check();
            var RegID = __Check.stringCheck("select RegID from System_Template where Template_Id=" + this.TemplateID);
            double YourStorage = Storage();
            double MaxStorage = Convert.ToDouble(__Check.stringCheck("select MaxStorage from DeveloperRegistation where Reg_ID=" + RegID));
            return YourStorage < MaxStorage ? true : false;
        }
        public double YourStorage(string RegID)
        {
            double YourStorage = Storage(RegID);
            return YourStorage;
        }
        public double MaxStorage(string RegID)
        {
            Check __Check = new Check();
            double MaxStorage = Convert.ToDouble(__Check.stringCheck("select MaxStorage from DeveloperRegistation where Reg_ID=" + RegID));
            return MaxStorage;
        }
        public bool AvaiableStorage(string RegID)
        {
            Check __Check = new Check();
            double YourStorage = Storage();
            double MaxStorage = Convert.ToDouble(__Check.stringCheck("select MaxStorage from DeveloperRegistation where Reg_ID=" + RegID));
            return YourStorage < MaxStorage ? true : false;
        }

        public List<Files> GetCSS_Files()
        {
            List<Files> li = new List<Files>();
            DataTable dt = SQLDataTable("select * from Template_FileUpload where Template_Id=" + TemplateID);
            foreach (DataRow row in dt.Rows)
            {
                if (Path.GetExtension(row["FileName"].ToString().ToLower()) == ".css")
                {
                    li.Add(new Files() { FileName = row["FileName"].ToString(), ID = row["FileUpload_Id"].ToString(), Path = row["Path"].ToString() });
                }
            }
            return li;
        }
        public List<Files> GetCSS_Files(string TemplateID)
        {
            List<Files> li = new List<Files>();
            DataTable dt = SQLDataTable("select * from Template_FileUpload where Template_Id=" + TemplateID);
            foreach (DataRow row in dt.Rows)
            {
                if (Path.GetExtension(row["FileName"].ToString().ToLower()) == ".css")
                {
                    li.Add(new Files() { FileName = row["FileName"].ToString(), ID = row["FileUpload_Id"].ToString(), Path = row["Path"].ToString() });
                }
            }
            return li;
        }
        public List<Files> GetJS_Files()
        {
            List<Files> li = new List<Files>();
            DataTable dt = SQLDataTable("select * from Template_FileUpload where Template_Id=" + TemplateID);
            foreach (DataRow row in dt.Rows)
            {
                if (Path.GetExtension(row["FileName"].ToString().ToLower()) == ".js")
                {
                    li.Add(new Files() { FileName = row["FileName"].ToString(), ID = row["FileUpload_Id"].ToString(), Path = row["Path"].ToString() });
                }
            }
            return li;
        }
        public List<Files> GetJS_Files(string TemplateID)
        {
            List<Files> li = new List<Files>();
            DataTable dt = SQLDataTable("select * from Template_FileUpload where Template_Id=" + TemplateID);
            foreach (DataRow row in dt.Rows)
            {
                if (Path.GetExtension(row["FileName"].ToString().ToLower()) == ".js")
                {
                    li.Add(new Files() { FileName = row["FileName"].ToString(), ID = row["FileUpload_Id"].ToString(), Path = row["Path"].ToString() });
                }
            }
            return li;
        }

        public string FullPath(string ID)
        {
            return StringCheck("select FullPath from Template_FileUpload where FileUpload_Id=" + ID);
        }

        #endregion

        #region File upload code
        public string TemplateId_to_RegID(string TemplateID)
        {
            Check __Check = new Check();
            return __Check.stringCheck("select RegID from System_Template where Template_Id=" + TemplateID);
        }
        public bool Insert_FileUpload(T_FileUpload Details)
        {
            T_Parameter[] Tp = new T_Parameter[]
            {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@FileName",Details.FileName),
                new T_Parameter("@FileSize",Details.FileSize),
                new T_Parameter("@Path",Details.Path),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@FullPath",Details.FullPath)
            };
            return ExcutionNonQuery(@"insert into Template_FileUpload 
(RegID,Template_Id,FileName,FileSize,Path,DateTime,FullPath) 
values(@RegID,@Template_Id,@FileName,@FileSize,@Path,@DateTime,@FullPath) ", Tp);

        }
        public bool FileChech(string FullPath)
        {
            return IntCheck("select count(*) from Template_FileUpload where FullPath='" + FullPath + "'") == 0 ? true : false;
        }
        public List<T_FileUpload> GetAllFiles(string TemplateID)
        {
            List<T_FileUpload> ListFileUpload = new List<T_FileUpload>();
            DataTable dt = SQLDataTable("select * from Template_FileUpload where Template_Id=" + TemplateID + " order by FileName");
            foreach (DataRow row in dt.Rows)
            {
                T_FileUpload file = new T_FileUpload()
                {
                    Template_Id = row["Template_Id"].ToString(),
                    RegID = row["RegID"].ToString(),
                    DateTime = row["DateTime"].ToString(),
                    FileName = row["FileName"].ToString(),
                    FileSize = Convert.ToDouble(row["FileSize"].ToString()),
                    FullPath = row["FullPath"].ToString(),
                    Path = row["Path"].ToString(),
                    FileUpload_Id = row["FileUpload_Id"].ToString()
                };
                ListFileUpload.Add(file);
            }
            return ListFileUpload;
        }
        public string DeleteFileUpload(string FileUploadID, string RegID)
        {
            if (IntCheck("select count(*) from Template_FileUpload where FileUpload_Id=" + FileUploadID + " and RegID=" + RegID) == 1)
            {
                string returnVal = StringCheck("select FullPath from Template_FileUpload where FileUpload_Id=" + FileUploadID + " and RegID=" + RegID);
                if (ExcutionNonQuery("delete from Template_FileUpload where FileUpload_Id=" + FileUploadID + " and RegID=" + RegID))
                {
                    return returnVal;
                }
                else
                {
                    return "File Delete Error: " + returnVal;
                }
            }
            else
            {
                return "File is Not Found.";
            }
        }
        #endregion

        #region Main Control
        public bool MainHtml(MainControl Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@BodyClass",Details.BodyClass),
                new T_Parameter("@MailHtml",Details.MailHtml),
                new T_Parameter("@CssJs_ID",Details.CssJs_ID),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@UpdateDateTime",Details.UpdateDateTime)
            };

            if (IntCheck("select count(*) from Template_MainControl where Template_Id=" + Details.Template_Id) == 1)
            {
                //string RegID = "RegID="+Details.RegID+"";
                //string Template_Id = ",Template_Id="+Details.Template_Id+"";
                string BodyCss = Details.BodyClass != "" || Details.BodyClass != string.Empty ? ",BodyClass='" + Details.BodyClass + "'" : "";
                string MailHtml = "MailHtml='" + Details.MailHtml + "'";
                string CssJs_ID = Details.CssJs_ID != "" || Details.CssJs_ID != string.Empty ? ",CssJs_ID='" + Details.CssJs_ID + "'" : "";
                string CssJs = Details.CssJs != "" || Details.CssJs != string.Empty ? ",CssJs='" + Details.CssJs + "'" : "";
                string UpdateDateTime = ",UpdateDateTime='" + Details.UpdateDateTime + "'";

                bool ReturnVal = ExcutionNonQuery("update Template_MainControl set " + MailHtml + BodyCss + CssJs_ID + CssJs + " where Template_Id=" + this.TemplateID);
                return ReturnVal;
            }
            else
            {
                bool ReturnVal = ExcutionNonQuery(@"insert into Template_MainControl (RegID,Template_Id,BodyClass,MailHtml,CssJs_ID,CssJs,UpdateDateTime) values(@RegID,@Template_Id,@BodyClass,@MailHtml,@CssJs_ID,@CssJs,@UpdateDateTime) ", Parameter);
                return ReturnVal;
            }


        }
        public MainControl ShowData()
        {
            DataTable dt = SQLDataTable("select * from Template_MainControl where Template_Id=" + TemplateID);
            int i = 0;
            MainControl m = new MainControl();
            foreach (DataRow ds in dt.Rows)
            {
                m.MailHtml = ds["MailHtml"].ToString();
                m.UpdateDateTime = Convert.ToDateTime(ds["UpdateDateTime"].ToString());
                m.Template_Id = ds["Template_Id"].ToString();
                m.RegID = ds["RegID"].ToString();
                m.CssJs_ID = ds["CssJs_ID"].ToString();
                m.CssJs = ds["CssJs"].ToString();
                m.BodyClass = ds["BodyClass"].ToString();
                m.UpdateEnable = true;
                i++;
                break;
            }
            if (i == 0)
            {
                m.UpdateEnable = false;
                return m;
            }
            else
            {
                return m;
            }
        }


        #endregion

        #region Html Design 

        public bool HtmlDesign(HtmlDesign Details)
        {
            //T_Parameter[] Paremeter = new T_Parameter[]
            //{
            //    //new T_Parameter();
            //  new T_Parameter("@RegID", Details.RegID),
            //  new T_Parameter("@TemplateId", Details.Template_Id),
            //  new T_Parameter("@HeaderImageHtmlCode", Details.HeaderImage_HtmlCode),
            //  new T_Parameter("@HeaderImageDDImageLink", Details.HeaderImage_DD_ImageLink),
            //  new T_Parameter("@HeaderImageDDAlternateText", Details.HeaderImage_DD_AlternateText),
            //  new T_Parameter("@HeaderImageDDLink", Details.HeaderImage_DD_Link),
            //  new T_Parameter("@HeaderImageUpdateTime", Details.HeaderImage_UpdateTime),
            //  new T_Parameter("@HeaderSearchHtmlCode", Details.HeaderSearch_HtmlCode),
            //  new T_Parameter("@HeaderSearchUpdateTime", Details.HeaderSearch_UpdateTime),
            //  new T_Parameter("@HeaderNotificationHtmlCode", Details.HeaderNotification_HtmlCode),
            //  new T_Parameter("@HeaderNotificationDDLink", Details.HeaderNotification_DD_Link),
            //  new T_Parameter("@HeaderNotificationDDIcon", Details.HeaderNotification_DD_Icon),
            //  new T_Parameter("@HeaderNotificationDDTitle", Details.HeaderNotification_DD_Title),
            //  new T_Parameter("@HeaderNotificationDDDetailsOrTime", Details.HeaderNotification_DD_DetailsOrTime),
            //  new T_Parameter("@HeaderNotificationUpdateTime", Details.HeaderNotification_UpdateTime),
            //  new T_Parameter("@HeaderMessageHtmlCode", Details.HeaderMessage_HtmlCode),
            //  new T_Parameter("@HeaderMessageDDLink", Details.HeaderMessage_DD_Link),
            //  new T_Parameter("@HeaderMessageDDImageLink", Details.HeaderMessage_DD_ImageLink),
            //  new T_Parameter("@HeaderMessageDDTitle", Details.HeaderMessage_DD_Title),
            //  new T_Parameter("@HeaderMessageDDDetailsOrTime", Details.HeaderMessage_DD_DetailsOrTime),
            //  new T_Parameter("@HeaderMessageUpdateTime", Details.HeaderMessage_UpdateTime),
            //  new T_Parameter("@HeaderProfileHtmlCode1", Details.HeaderProfile_HtmlCode1),
            //  new T_Parameter("@HeaderProfileHtmlCode2", Details.HeaderProfile_HtmlCode2),
            //  new T_Parameter("@HeaderProfileDD1ImageLink", Details.HeaderProfile_DD1_ImageLink),
            //  new T_Parameter("@HeaderProfileDD1Name",Details.HeaderProfile_DD1_Name ),
            //  new T_Parameter("@HeaderProfileDD2Link", Details.HeaderProfile_DD2_Link),
            //  new T_Parameter("@HeaderProfileDD2Name", Details.HeaderProfile_DD2_Name),
            //  new T_Parameter("@HeaderProfileUpdateTime",Details.HeaderProfile_UpdateTime ),
            //  new T_Parameter("@BodyBarHtmlCode1", Details.BodyBar_HtmlCode1),
            //  new T_Parameter("@BodyBarHtmlCode2",Details.BodyBar_HtmlCode2 ),
            //  new T_Parameter("@BodyBarDD1Link", Details.BodyBar_DD1_Link),
            //  new T_Parameter("@BodyBarDD1BarName", Details.BodyBar_DD1_BarName),
            //  new T_Parameter("@BodyBarDD2Link", Details.BodyBar_DD2_Link),
            //  new T_Parameter("@BodyBarDD2BarName", Details.BodyBar_DD2_BarName),
            //  new T_Parameter("@BodyBarUpdateTime", Details.BodyBar_UpdateTime),
            //  new T_Parameter("@FooterHtmlCode", Details.Footer_HtmlCode),
            //  new T_Parameter("@FooterUpdateTime", Details.Footer_UpdateTime)
            //};


            if (IntCheck("select count(*) from Template_HtmlDesign where Template_Id=" + this.TemplateID) == 1)
            {
                string HeaderImage_HtmlCode = Details.HeaderImage_HtmlCode != string.Empty || Details.HeaderImage_HtmlCode != "" ? ",HeaderImage_HtmlCode='" + Details.HeaderImage_HtmlCode + "'" : "";
                string HeaderImage_DD_ImageLink = Details.HeaderImage_DD_ImageLink != string.Empty || Details.HeaderImage_DD_ImageLink != "" ? ",HeaderImage_DD_ImageLink='" + Details.HeaderImage_DD_ImageLink + "'" : "";
                string HeaderImage_DD_AlternateText = Details.HeaderImage_DD_AlternateText != string.Empty || Details.HeaderImage_DD_AlternateText != "" ? ",HeaderImage_DD_AlternateText='" + Details.HeaderImage_DD_AlternateText + "'" : "";
                string HeaderImage_DD_Link = Details.HeaderImage_DD_Link != string.Empty || Details.HeaderImage_DD_Link != "" ? ",HeaderImage_DD_Link='" + Details.HeaderImage_DD_Link + "'" : "";
                string HeaderImage_UpdateTime = Details.HeaderImage_UpdateTime != string.Empty || Details.HeaderImage_UpdateTime != "" ? ",HeaderImage_UpdateTime='" + Details.HeaderImage_UpdateTime + "'" : "";
                string HeaderSearch_HtmlCode = Details.HeaderSearch_HtmlCode != string.Empty || Details.HeaderSearch_HtmlCode != "" ? ",HeaderSearch_HtmlCode='" + Details.HeaderSearch_HtmlCode + "'" : "";
                string HeaderSearch_UpdateTime = Details.HeaderSearch_UpdateTime != string.Empty || Details.HeaderSearch_UpdateTime != "" ? ",HeaderSearch_UpdateTime='" + Details.HeaderSearch_UpdateTime + "'" : "";
                string HeaderNotification_HtmlCode = Details.HeaderNotification_HtmlCode != string.Empty || Details.HeaderNotification_HtmlCode != "" ? ",HeaderNotification_HtmlCode='" + Details.HeaderNotification_HtmlCode + "'" : "";
                string HeaderNotification_HtmlCode2 = Details.HeaderNotification_HtmlCode2 != string.Empty || Details.HeaderNotification_HtmlCode2 != "" ? ",HeaderNotification_HtmlCode2='" + Details.HeaderNotification_HtmlCode2 + "'" : "";
                string HeaderNotification_DD_Link = Details.HeaderNotification_DD_Link != string.Empty || Details.HeaderNotification_DD_Link != "" ? ",HeaderNotification_DD_Link='" + Details.HeaderNotification_DD_Link + "'" : "";
                string HeaderNotification_DD_Icon = Details.HeaderNotification_DD_Icon != string.Empty || Details.HeaderNotification_DD_Icon != "" ? ",HeaderNotification_DD_Icon='" + Details.HeaderNotification_DD_Icon + "'" : "";
                string HeaderNotification_DD_Title = Details.HeaderNotification_DD_Title != string.Empty || Details.HeaderNotification_DD_Title != "" ? ",HeaderNotification_DD_Title='" + Details.HeaderNotification_DD_Title + "'" : "";
                string HeaderNotification_DD_DetailsOrTime = Details.HeaderNotification_DD_DetailsOrTime != string.Empty || Details.HeaderNotification_DD_DetailsOrTime != "" ? ",HeaderNotification_DD_DetailsOrTime='" + Details.HeaderNotification_DD_DetailsOrTime + "'" : "";
                string HeaderNotification_UpdateTime = Details.HeaderNotification_UpdateTime != string.Empty || Details.HeaderNotification_UpdateTime != "" ? ",HeaderNotification_UpdateTime='" + Details.HeaderNotification_UpdateTime + "'" : "";
                string HeaderMessage_HtmlCode = Details.HeaderMessage_HtmlCode != string.Empty || Details.HeaderMessage_HtmlCode != "" ? ",HeaderMessage_HtmlCode='" + Details.HeaderMessage_HtmlCode + "'" : "";
                string HeaderMessage_HtmlCode2 = Details.HeaderMessage_HtmlCode2 != string.Empty || Details.HeaderMessage_HtmlCode2 != "" ? ",HeaderMessage_HtmlCode2='" + Details.HeaderMessage_HtmlCode2 + "'" : "";
                string HeaderMessage_DD_Link = Details.HeaderMessage_DD_Link != string.Empty || Details.HeaderMessage_DD_Link != "" ? ",HeaderMessage_DD_Link='" + Details.HeaderMessage_DD_Link + "'" : "";
                string HeaderMessage_DD_ImageLink = Details.HeaderMessage_DD_ImageLink != string.Empty || Details.HeaderMessage_DD_ImageLink != "" ? ",HeaderMessage_DD_ImageLink='" + Details.HeaderMessage_DD_ImageLink + "'" : "";
                string HeaderMessage_DD_Title = Details.HeaderMessage_DD_Title != string.Empty || Details.HeaderMessage_DD_Title != "" ? ",HeaderMessage_DD_Title='" + Details.HeaderMessage_DD_Title + "'" : "";
                string HeaderMessage_DD_DetailsOrTime = Details.HeaderMessage_DD_DetailsOrTime != string.Empty || Details.HeaderMessage_DD_DetailsOrTime != "" ? ",HeaderMessage_DD_DetailsOrTime='" + Details.HeaderMessage_DD_DetailsOrTime + "'" : "";
                string HeaderMessage_UpdateTime = Details.HeaderMessage_UpdateTime != string.Empty || Details.HeaderMessage_UpdateTime != "" ? ",HeaderMessage_UpdateTime='" + Details.HeaderMessage_UpdateTime + "'" : "";
                string HeaderProfile_HtmlCode1 = Details.HeaderProfile_HtmlCode1 != string.Empty || Details.HeaderProfile_HtmlCode1 != "" ? ",HeaderProfile_HtmlCode1='" + Details.HeaderProfile_HtmlCode1 + "'" : "";
                string HeaderProfile_HtmlCode2 = Details.HeaderProfile_HtmlCode2 != string.Empty || Details.HeaderProfile_HtmlCode2 != "" ? ",HeaderProfile_HtmlCode2='" + Details.HeaderProfile_HtmlCode2 + "'" : "";
                string HeaderProfile_DD1_ImageLink = Details.HeaderProfile_DD1_ImageLink != string.Empty || Details.HeaderProfile_DD1_ImageLink != "" ? ",HeaderProfile_DD1_ImageLink='" + Details.HeaderProfile_DD1_ImageLink + "'" : "";
                string HeaderProfile_DD1_Name = Details.HeaderProfile_DD1_Name != string.Empty || Details.HeaderProfile_DD1_Name != "" ? ",HeaderProfile_DD1_Name='" + Details.HeaderProfile_DD1_Name + "'" : "";
                string HeaderProfile_DD2_Link = Details.HeaderProfile_DD2_Link != string.Empty || Details.HeaderProfile_DD2_Link != "" ? ",HeaderProfile_DD2_Link='" + Details.HeaderProfile_DD2_Link + "'" : "";
                string HeaderProfile_DD2_Name = Details.HeaderProfile_DD2_Name != string.Empty || Details.HeaderProfile_DD2_Name != "" ? ",HeaderProfile_DD2_Name='" + Details.HeaderProfile_DD2_Name + "'" : "";
                string HeaderProfile_UpdateTime = Details.HeaderProfile_UpdateTime != string.Empty || Details.HeaderProfile_UpdateTime != "" ? ",HeaderProfile_UpdateTime='" + Details.HeaderProfile_UpdateTime + "'" : "";
                string BodyBar_HtmlCode1 = Details.BodyBar_HtmlCode1 != string.Empty || Details.BodyBar_HtmlCode1 != "" ? ",BodyBar_HtmlCode1='" + Details.BodyBar_HtmlCode1 + "'" : "";
                string BodyBar_HtmlCode2 = Details.BodyBar_HtmlCode2 != string.Empty || Details.BodyBar_HtmlCode2 != "" ? ",BodyBar_HtmlCode2='" + Details.BodyBar_HtmlCode2 + "'" : "";
                string BodyBar_DD1_Link = Details.BodyBar_DD1_Link != string.Empty || Details.BodyBar_DD1_Link != "" ? ",BodyBar_DD1_Link='" + Details.BodyBar_DD1_Link + "'" : "";
                string BodyBar_DD1_BarName = Details.BodyBar_DD1_BarName != string.Empty || Details.BodyBar_DD1_BarName != "" ? ",BodyBar_DD1_BarName='" + Details.BodyBar_DD1_BarName + "'" : "";
                string BodyBar_DD2_Link = Details.BodyBar_DD2_Link != string.Empty || Details.BodyBar_DD2_Link != "" ? ",BodyBar_DD2_Link='" + Details.BodyBar_DD2_Link + "'" : "";
                string BodyBar_DD2_BarName = Details.BodyBar_DD2_BarName != string.Empty || Details.BodyBar_DD2_BarName != "" ? ",BodyBar_DD2_BarName='" + Details.BodyBar_DD2_BarName + "'" : "";
                string BodyBar_UpdateTime = Details.BodyBar_UpdateTime != string.Empty || Details.BodyBar_UpdateTime != "" ? ",BodyBar_UpdateTime='" + Details.BodyBar_UpdateTime + "'" : "";
                string Footer_HtmlCode = Details.Footer_HtmlCode != string.Empty || Details.Footer_HtmlCode != "" ? ",Footer_HtmlCode='" + Details.Footer_HtmlCode + "'" : "";
                string Footer_UpdateTime = Details.Footer_UpdateTime != string.Empty || Details.Footer_UpdateTime != "" ? ",Footer_UpdateTime='" + Details.Footer_UpdateTime + "'" : "";




                bool xxx = ExcutionNonQuery(@"update Template_HtmlDesign set RegID=" + TemplateId_to_RegID(this.TemplateID) +
                  HeaderImage_HtmlCode +
                  HeaderImage_DD_ImageLink +
                  HeaderImage_DD_AlternateText +
                  HeaderImage_DD_Link +
                  HeaderImage_UpdateTime +
                  HeaderSearch_HtmlCode +
                  HeaderSearch_UpdateTime +
                  HeaderNotification_HtmlCode +
                  HeaderNotification_HtmlCode2 +
                  HeaderNotification_DD_Link +
                  HeaderNotification_DD_Icon +
                  HeaderNotification_DD_Title +
                  HeaderNotification_DD_DetailsOrTime +
                  HeaderNotification_UpdateTime +
                  HeaderMessage_HtmlCode +
                  HeaderMessage_HtmlCode2 +
                  HeaderMessage_DD_Link +
                  HeaderMessage_DD_ImageLink +
                  HeaderMessage_DD_Title +
                  HeaderMessage_DD_DetailsOrTime +
                  HeaderMessage_UpdateTime +
                  HeaderProfile_HtmlCode1 +
                  HeaderProfile_HtmlCode2 +
                  HeaderProfile_DD1_ImageLink +
                  HeaderProfile_DD1_Name +
                  HeaderProfile_DD2_Link +
                  HeaderProfile_DD2_Name +
                  HeaderProfile_UpdateTime +
                  BodyBar_HtmlCode1 +
                  BodyBar_HtmlCode2 +
                  BodyBar_DD1_Link +
                  BodyBar_DD1_BarName +
                  BodyBar_DD2_Link +
                  BodyBar_DD2_BarName +
                  BodyBar_UpdateTime +
                  Footer_HtmlCode +
                  Footer_UpdateTime + " where Template_Id=" + this.TemplateID);
                return xxx;
            }
            else
            {
                bool x = ExcutionNonQuery(string.Format(@"insert into Template_HtmlDesign 
(RegID ,Template_Id ,HeaderImage_HtmlCode ,HeaderImage_DD_ImageLink ,HeaderImage_DD_AlternateText ,HeaderImage_DD_Link ,HeaderImage_UpdateTime ,HeaderSearch_HtmlCode ,HeaderSearch_UpdateTime ,HeaderNotification_HtmlCode
,HeaderNotification_DD_Link ,HeaderNotification_DD_Icon ,HeaderNotification_DD_Title ,HeaderNotification_DD_DetailsOrTime ,HeaderNotification_UpdateTime ,HeaderMessage_HtmlCode ,HeaderMessage_DD_Link ,HeaderMessage_DD_ImageLink
,HeaderMessage_DD_Title ,HeaderMessage_DD_DetailsOrTime ,HeaderMessage_UpdateTime ,HeaderProfile_HtmlCode1 ,HeaderProfile_HtmlCode2 ,HeaderProfile_DD1_ImageLink ,HeaderProfile_DD1_Name ,HeaderProfile_DD2_Link ,HeaderProfile_DD2_Name
,HeaderProfile_UpdateTime ,BodyBar_HtmlCode1 ,BodyBar_HtmlCode2 ,BodyBar_DD1_Link ,BodyBar_DD1_BarName ,BodyBar_DD2_Link ,BodyBar_DD2_BarName ,BodyBar_UpdateTime ,Footer_HtmlCode ,Footer_UpdateTime)

 values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}')
 ", Details.RegID,
    Details.Template_Id,
    Details.HeaderImage_HtmlCode,
    Details.HeaderImage_DD_ImageLink,
    Details.HeaderImage_DD_AlternateText,
    Details.HeaderImage_DD_Link,
    Details.HeaderImage_UpdateTime,
    Details.HeaderSearch_HtmlCode,
    Details.HeaderSearch_UpdateTime,
    Details.HeaderNotification_HtmlCode,
    Details.HeaderNotification_HtmlCode2,
    Details.HeaderNotification_DD_Link,
    Details.HeaderNotification_DD_Icon,
    Details.HeaderNotification_DD_Title,
    Details.HeaderNotification_DD_DetailsOrTime,
    Details.HeaderNotification_UpdateTime,
    Details.HeaderMessage_HtmlCode,
    Details.HeaderMessage_HtmlCode2,
    Details.HeaderMessage_DD_Link,
    Details.HeaderMessage_DD_ImageLink,
    Details.HeaderMessage_DD_Title,
    Details.HeaderMessage_DD_DetailsOrTime,
    Details.HeaderMessage_UpdateTime,
    Details.HeaderProfile_HtmlCode1,
    Details.HeaderProfile_HtmlCode2,
    Details.HeaderProfile_DD1_ImageLink,
    Details.HeaderProfile_DD1_Name,
    Details.HeaderProfile_DD2_Link,
    Details.HeaderProfile_DD2_Name,
    Details.HeaderProfile_UpdateTime,
    Details.BodyBar_HtmlCode1,
    Details.BodyBar_HtmlCode2,
    Details.BodyBar_DD1_Link,
    Details.BodyBar_DD1_BarName,
    Details.BodyBar_DD2_Link,
    Details.BodyBar_DD2_BarName,
    Details.BodyBar_UpdateTime,
    Details.Footer_HtmlCode,
    Details.Footer_UpdateTime));
                return x;
            }


        }
        public HtmlDesign ShowHtmlDesign()
        {
            HtmlDesign Details = new ECMS.Design.HtmlDesign();
            if (IntCheck("select count(*) from Template_HtmlDesign where Template_Id=" + this.TemplateID) == 1)
            {
                DataTable dt = SQLDataTable("select * from Template_HtmlDesign where Template_Id=" + this.TemplateID);
                foreach (DataRow dr in dt.Rows)
                {
                    Details.RegID = dr["RegID"].ToString();
                    Details.Template_Id = dr["Template_Id"].ToString();
                    Details.HeaderImage_HtmlCode = dr["HeaderImage_HtmlCode"].ToString();
                    Details.HeaderImage_DD_ImageLink = dr["HeaderImage_DD_ImageLink"].ToString();
                    Details.HeaderImage_DD_AlternateText = dr["HeaderImage_DD_AlternateText"].ToString();
                    Details.HeaderImage_DD_Link = dr["HeaderImage_DD_Link"].ToString();
                    Details.HeaderImage_UpdateTime = dr["HeaderImage_UpdateTime"].ToString();
                    Details.HeaderSearch_HtmlCode = dr["HeaderSearch_HtmlCode"].ToString();
                    Details.HeaderSearch_UpdateTime = dr["HeaderSearch_UpdateTime"].ToString();
                    Details.HeaderNotification_HtmlCode = dr["HeaderNotification_HtmlCode"].ToString();
                    Details.HeaderNotification_HtmlCode2 = dr["HeaderNotification_HtmlCode2"].ToString();
                    Details.HeaderNotification_DD_Link = dr["HeaderNotification_DD_Link"].ToString();
                    Details.HeaderNotification_DD_Icon = dr["HeaderNotification_DD_Icon"].ToString();
                    Details.HeaderNotification_DD_Title = dr["HeaderNotification_DD_Title"].ToString();
                    Details.HeaderNotification_DD_DetailsOrTime = dr["HeaderNotification_DD_DetailsOrTime"].ToString();
                    Details.HeaderNotification_UpdateTime = dr["HeaderNotification_UpdateTime"].ToString();
                    Details.HeaderMessage_HtmlCode = dr["HeaderMessage_HtmlCode"].ToString();
                    Details.HeaderMessage_HtmlCode2 = dr["HeaderMessage_HtmlCode2"].ToString();
                    Details.HeaderMessage_DD_Link = dr["HeaderMessage_DD_Link"].ToString();
                    Details.HeaderMessage_DD_ImageLink = dr["HeaderMessage_DD_ImageLink"].ToString();
                    Details.HeaderMessage_DD_Title = dr["HeaderMessage_DD_Title"].ToString();
                    Details.HeaderMessage_DD_DetailsOrTime = dr["HeaderMessage_DD_DetailsOrTime"].ToString();
                    Details.HeaderMessage_UpdateTime = dr["HeaderMessage_UpdateTime"].ToString();
                    Details.HeaderProfile_HtmlCode1 = dr["HeaderProfile_HtmlCode1"].ToString();
                    Details.HeaderProfile_HtmlCode2 = dr["HeaderProfile_HtmlCode2"].ToString();
                    Details.HeaderProfile_DD1_ImageLink = dr["HeaderProfile_DD1_ImageLink"].ToString();
                    Details.HeaderProfile_DD1_Name = dr["HeaderProfile_DD1_Name"].ToString();
                    Details.HeaderProfile_DD2_Link = dr["HeaderProfile_DD2_Link"].ToString();
                    Details.HeaderProfile_DD2_Name = dr["HeaderProfile_DD2_Name"].ToString();
                    Details.HeaderProfile_UpdateTime = dr["HeaderProfile_UpdateTime"].ToString();
                    Details.BodyBar_HtmlCode1 = dr["BodyBar_HtmlCode1"].ToString();
                    Details.BodyBar_HtmlCode2 = dr["BodyBar_HtmlCode2"].ToString();
                    Details.BodyBar_DD1_Link = dr["BodyBar_DD1_Link"].ToString();
                    Details.BodyBar_DD1_BarName = dr["BodyBar_DD1_BarName"].ToString();
                    Details.BodyBar_DD2_Link = dr["BodyBar_DD2_Link"].ToString();
                    Details.BodyBar_DD2_BarName = dr["BodyBar_DD2_BarName"].ToString();
                    Details.BodyBar_UpdateTime = dr["BodyBar_UpdateTime"].ToString();
                    Details.Footer_HtmlCode = dr["Footer_HtmlCode"].ToString();
                    Details.Footer_UpdateTime = dr["Footer_UpdateTime"].ToString();
                    break;
                }
                return Details;
            }
            else
            {
                Details.RegID = TemplateId_to_RegID(this.TemplateID);
                Details.Template_Id = TemplateID;
                Details.HeaderImage_HtmlCode = "";
                Details.HeaderImage_DD_ImageLink = "";
                Details.HeaderImage_DD_AlternateText = "";
                Details.HeaderImage_DD_Link = "";
                Details.HeaderImage_UpdateTime = "";
                Details.HeaderSearch_HtmlCode = "";
                Details.HeaderSearch_UpdateTime = "";
                Details.HeaderNotification_HtmlCode = "";
                Details.HeaderNotification_HtmlCode2 = "";
                Details.HeaderNotification_DD_Link = "";
                Details.HeaderNotification_DD_Icon = "";
                Details.HeaderNotification_DD_Title = "";
                Details.HeaderNotification_DD_DetailsOrTime = "";
                Details.HeaderNotification_UpdateTime = "";
                Details.HeaderMessage_HtmlCode = "";
                Details.HeaderMessage_HtmlCode2 = "";
                Details.HeaderMessage_DD_Link = "";
                Details.HeaderMessage_DD_ImageLink = "";
                Details.HeaderMessage_DD_Title = "";
                Details.HeaderMessage_DD_DetailsOrTime = "";
                Details.HeaderMessage_UpdateTime = "";
                Details.HeaderProfile_HtmlCode1 = "";
                Details.HeaderProfile_HtmlCode2 = "";
                Details.HeaderProfile_DD1_ImageLink = "";
                Details.HeaderProfile_DD1_Name = "";
                Details.HeaderProfile_DD2_Link = "";
                Details.HeaderProfile_DD2_Name = "";
                Details.HeaderProfile_UpdateTime = "";
                Details.BodyBar_HtmlCode1 = "";
                Details.BodyBar_HtmlCode2 = "";
                Details.BodyBar_DD1_Link = "";
                Details.BodyBar_DD1_BarName = "";
                Details.BodyBar_DD2_Link = "";
                Details.BodyBar_DD2_BarName = "";
                Details.BodyBar_UpdateTime = "";
                Details.Footer_HtmlCode = "";
                Details.Footer_UpdateTime = "";

                return Details;
            }

        }
        public string CssFiles(string IDs)
        {
            string Output = "";
            foreach (string FileID in ConvertIDs(IDs))
            {
                string FileName = StringCheck("select FullPath from Template_FileUpload where FileUpload_Id=" + FileID);
                if (Path.GetExtension(FileName).ToLower() == ".css")
                {
                    Output += "<link rel=\"stylesheet\" href=\"../../" + FileName + "\"  />\n";
                }
            }
            return Output;
        }
        public string JsFiles(string IDs)
        {
            string Output = "";
            foreach (string FileID in ConvertIDs(IDs))
            {
                string FileName = StringCheck("select FullPath from Template_FileUpload where FileUpload_Id=" + FileID);
                if (Path.GetExtension(FileName).ToLower() == ".js")
                {
                    Output += "<script src=\"../../" + FileName + "\" type=\"text/javascript\" ></script>\n";
                }
            }
            return Output;
        }
        private string[] ConvertIDs(string IDs)
        {
            string[] alIDs = new string[CountIDs(IDs)];
            int index = 0;
            for (int i = 0; i < IDs.Length; i++)
            {
                if (IDs[i] == ',')
                {
                    index++;
                }
                else
                {
                    alIDs[index] += IDs[i];
                }
            }
            return alIDs;
        }
        private int CountIDs(string IDs)
        {
            int count = 0;
            for (int i = 0; i < IDs.Length; i++)
            {
                if (IDs[i] == ',')
                { count++; }
            }
            return count;
        }
        #endregion

        #region Layout
        public List<Files> ShowImages()
        {
            List<Files> file = new List<Files>();
            DataTable dt = SQLDataTable("select * from Template_FileUpload where Template_Id=" + this.TemplateID);
            foreach (DataRow row in dt.Rows)
            {
                var fileName = row["FullPath"].ToString();
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    file.Add(new Files() { Path = fileName, FileName = row["FileName"].ToString(), ID = row["FileUpload_Id"].ToString() });
                }
            }
            return file;
        }
        public bool InsertLayout(Layout Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@FileUpload_Id",Details.FileUpload_Id),
                new T_Parameter("@FullPath",Details.FullPath),
                new T_Parameter("@HTML",Details.HTML),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJs_ID",Details.CssJs_ID),
                new T_Parameter("@TotalCode",Details.TotalCode),
                new T_Parameter("@LayoutName",Details.LayoutName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_Layout (RegID,Template_Id,FileUpload_Id,FullPath,HTML,DateTime,CssJs,CssJs_ID,TotalCode,LayoutName) values(@RegID,@Template_Id,@FileUpload_Id,@FullPath,@HTML,@DateTime,@CssJs,@CssJs_ID,@TotalCode,@LayoutName) ", Parameter);
            return ReturnVal;
        }
        public List<Layout> ShowLayoutData()
        {
            List<Layout> Details = new List<Layout>();
            DataTable dt = SQLDataTable("select * from Template_Layout where Template_Id="+this.TemplateID);
            foreach(DataRow dr in dt.Rows)
            {
                Details.Add(new Layout() {
                    ID=dr["Layout_ID"].ToString(),
                    RegID= dr["RegID"].ToString(),
                    Template_Id= dr["Template_Id"].ToString(),
                    FileUpload_Id= dr["FileUpload_Id"].ToString(),
                    FullPath= dr["FullPath"].ToString(),
                    HTML= dr["HTML"].ToString(),
                    TotalCode = Convert.ToInt32(dr["TotalCode"].ToString()),
                    LayoutName= dr["LayoutName"].ToString()
                });
            }

            return Details;
        }
        public Layout ShowLayoutData(string Layout_ID)
        {
            Layout Details = new Layout();
            DataTable dt = SQLDataTable("select * from Template_Layout where Layout_ID=" + Layout_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details = new Layout()
                {
                    ID = dr["Layout_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    FileUpload_Id = dr["FileUpload_Id"].ToString(),
                    FullPath = dr["FullPath"].ToString(),
                    HTML = dr["HTML"].ToString(),
                    TotalCode = Convert.ToInt32(dr["TotalCode"].ToString()),
                    LayoutName = dr["LayoutName"].ToString()
                };
                break;
            }

            return Details;
        }
        #endregion

        #region DataTable
        public bool InsertDataTable(DataTables Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@HtmlCode1",Details.HtmlCode1),
                new T_Parameter("@HtmlCode2",Details.HtmlCode2),
                new T_Parameter("@HtmlCode3",Details.HtmlCode3),
                new T_Parameter("@RowData",Details.RowData),
                new T_Parameter("@ColoumData",Details.ColoumData),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJsID",Details.CssJsID),
                new T_Parameter("@DataTableName",Details.DataTableName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_DataTable (RegID,Template_Id,HtmlCode1,HtmlCode2,HtmlCode3,RowData,ColoumData,DateTime,CssJs,CssJsID,DataTableName) values(@RegID,@Template_Id,@HtmlCode1,@HtmlCode2,@HtmlCode3,@RowData,@ColoumData,@DateTime,@CssJs,@CssJsID,@DataTableName) ", Parameter);
            return ReturnVal;
        }
        public List<DataTables> ShowDataTable()
        {
            List<DataTables> Details = new List<DataTables>();
            DataTable dt = SQLDataTable("select * from Template_DataTable where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new DataTables()
                {
                    ID = dr["DataTable_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode1 = dr["HtmlCode1"].ToString(),
                    HtmlCode2 = dr["HtmlCode2"].ToString(),
                    HtmlCode3 = dr["HtmlCode3"].ToString(),
                    RowData = dr["RowData"].ToString(),
                    ColoumData = dr["ColoumData"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DataTableName = dr["DataTableName"].ToString()
                });
            }

            return Details;
        }
        public DataTables ShowDataTable(string DataTable_ID)
        {
            DataTables Details = new DataTables();
            DataTable dt = SQLDataTable("select * from Template_DataTable where DataTable_ID=" + DataTable_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details = new DataTables()
                {
                    ID = dr["DataTable_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode1 = dr["HtmlCode1"].ToString(),
                    HtmlCode2 = dr["HtmlCode2"].ToString(),
                    HtmlCode3 = dr["HtmlCode3"].ToString(),
                    RowData = dr["RowData"].ToString(),
                    ColoumData = dr["ColoumData"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DataTableName = dr["DataTableName"].ToString()
                };
                break;            
            }

            return Details;
        }
        #endregion

        #region RadioButtion
        public bool InsertRadioButton(RadioButtons Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@HtmlCode",Details.HtmlCode),
                new T_Parameter("@GroupName",Details.GroupName),
                new T_Parameter("@Checked",Details.Checked),
                new T_Parameter("@Text",Details.Text),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJsID",Details.CssJsID),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@RadioButtonName",Details.RadioButtonName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_RadioButtion (RegID,Template_Id,HtmlCode,GroupName,Text,Checked,CssJs,CssJsID,DateTime,RadioButtonName) values(@RegID,@Template_Id,@HtmlCode,@GroupName,@Text,@Checked,@CssJs,@CssJsID,@DateTime,@RadioButtonName) ", Parameter);
            return ReturnVal;
        }
        public List<RadioButtons> ShowRadioButtons()
        {
            List<RadioButtons> Details = new List<RadioButtons>();
            DataTable dt = SQLDataTable("select * from Template_RadioButtion where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new RadioButtons()
                {
                    ID = dr["RadioButton_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    GroupName = dr["GroupName"].ToString(),
                    Checked = dr["Checked"].ToString(),
                    Text = dr["Text"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    RadioButtonName = dr["RadioButtonName"].ToString()
                });
            }

            return Details;
        }
        public RadioButtons ShowRadioButtons(string RadioButton_ID)
        {
            RadioButtons Details = new RadioButtons();
            DataTable dt = SQLDataTable("select * from Template_RadioButtion where RadioButton_ID=" + RadioButton_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details = new RadioButtons()
                {
                    ID = dr["RadioButton_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    GroupName = dr["GroupName"].ToString(),
                    Checked = dr["Checked"].ToString(),
                    Text = dr["Text"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    RadioButtonName = dr["RadioButtonName"].ToString()
                };
                break;
            }

            return Details;
        }

        #endregion

        #region TextBoxs
        public bool InsertTextBoxs(TextBoxs Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@HtmlCode",Details.HtmlCode),
                new T_Parameter("@PlaceHolder",Details.PlaceHolder),
                new T_Parameter("@Value",Details.Value),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJsID",Details.CssJsID),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@TextBoxName",Details.TextBoxName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_TextBox (RegID,Template_Id,HtmlCode,PlaceHolder,Value,CssJs,CssJsID,DateTime,TextBoxName) values(@RegID,@Template_Id,@HtmlCode,@PlaceHolder,@Value,@CssJs,@CssJsID,@DateTime,@TextBoxName) ", Parameter);
            return ReturnVal;
        }
        public List<TextBoxs> ShowTextBoxs()
        {
            List<TextBoxs> Details = new List<TextBoxs>();
            DataTable dt = SQLDataTable("select * from Template_TextBox where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new TextBoxs()
                {
                    ID = dr["TextBox_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    PlaceHolder = dr["PlaceHolder"].ToString(),
                    Value = dr["Value"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    TextBoxName = dr["TextBoxName"].ToString()
                });

            }

            return Details;
        }
        public TextBoxs ShowTextBoxs(string TextBox_ID)
        {
            TextBoxs Details = new TextBoxs();
            DataTable dt = SQLDataTable("select * from Template_TextBox where TextBox_ID=" + TextBox_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details= new TextBoxs()
                {
                    ID = dr["TextBox_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    PlaceHolder = dr["PlaceHolder"].ToString(),
                    Value = dr["Value"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    TextBoxName = dr["TextBoxName"].ToString()
                };
                break;
            }

            return Details;
        }
        #endregion

        #region CheckBoxs
        public bool InsertCheckBoxs(CheckBoxs Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@HtmlCode",Details.HtmlCode),
                new T_Parameter("@Text",Details.Text),
                new T_Parameter("@Checked",Details.Checked),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJsID",Details.CssJsID),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@CheckBoxName",Details.CheckBoxName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_CheckBox (RegID,Template_Id,HtmlCode,Text,Checked,CssJs,CssJsID,DateTime,CheckBoxName) values(@RegID,@Template_Id,@HtmlCode,@Text,@Checked,@CssJs,@CssJsID,@DateTime,@CheckBoxName) ", Parameter);
            return ReturnVal;
        }
        public List<CheckBoxs> ShowCheckBoxs()
        {
            List<CheckBoxs> Details = new List<CheckBoxs>();
            DataTable dt = SQLDataTable("select * from Template_CheckBox where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new CheckBoxs()
                {
                    ID = dr["CheckBox_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    Text = dr["Text"].ToString(),
                    Checked = dr["Checked"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    CheckBoxName = dr["CheckBoxName"].ToString(),
                });
            }

            return Details;
        }
        public CheckBoxs ShowCheckBoxs(string CheckBox_ID)
        {
            CheckBoxs Details = new CheckBoxs();
            DataTable dt = SQLDataTable("select * from Template_CheckBox where CheckBox_ID=" + CheckBox_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details=new CheckBoxs()
                {
                    ID = dr["CheckBox_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    Text = dr["Text"].ToString(),
                    Checked = dr["Checked"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    CheckBoxName = dr["CheckBoxName"].ToString(),
                };
                break;
            }

            return Details;
        }


        #endregion

        #region Button
        public bool InsertButtons(Buttons Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@HtmlCode",Details.HtmlCode),
                new T_Parameter("@DefaultData1",Details.DefaultData1),
                new T_Parameter("@DefaultData2",Details.DefaultData2),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJsID",Details.CssJsID),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@ButtonName",Details.ButtonName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_Button (RegID,Template_Id,HtmlCode,DefaultData1,DefaultData2,CssJs,CssJsID,DateTime,ButtonName) values(@RegID,@Template_Id,@HtmlCode,@DefaultData1,@DefaultData2,@CssJs,@CssJsID,@DateTime,@ButtonName) ", Parameter);
            return ReturnVal;
        }
        public List<Buttons> ShowButtons()
        {
            List<Buttons> Details = new List<Buttons>();
            DataTable dt = SQLDataTable("select * from Template_Button where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new Buttons()
                {
                    ID = dr["Button_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    DefaultData1 = dr["DefaultData1"].ToString(),
                    DefaultData2 = dr["DefaultData2"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    ButtonName = dr["ButtonName"].ToString()
                });
            }

            return Details;
        }
        public Buttons ShowButtons(string Button_ID)
        {
            Buttons Details = new Buttons();
            DataTable dt = SQLDataTable("select * from Template_Button where Button_ID=" + Button_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details = new Buttons()
                {
                    ID = dr["Button_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    DefaultData1 = dr["DefaultData1"].ToString(),
                    DefaultData2 = dr["DefaultData2"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    ButtonName = dr["ButtonName"].ToString()
                };
                break;
            }

            return Details;
        }

        #endregion

        #region Alert
        public bool InsertAlert(Alert Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@HtmlCode",Details.HtmlCode),
                new T_Parameter("@DefaultData",Details.DefaultData),
                new T_Parameter("@CssJs",Details.CssJs),
                new T_Parameter("@CssJsID",Details.CssJsID),
                new T_Parameter("@DateTime",Details.DateTime),
                new T_Parameter("@AlertName",Details.AlertName)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_Alert (RegID,Template_Id,HtmlCode,DefaultData,CssJs,CssJsID,DateTime,AlertName) values(@RegID,@Template_Id,@HtmlCode,@DefaultData,@CssJs,@CssJsID,@DateTime,@AlertName) ", Parameter);
            return ReturnVal;
        }
        public List<Alert> ShowAlert()
        {
            List<Alert> Details = new List<Alert>();
            DataTable dt = SQLDataTable("select * from Template_Alert where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new Alert()
                {
                    ID = dr["Alert_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    DefaultData = dr["DefaultData"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    AlertName = dr["AlertName"].ToString()
                });
            }

            return Details;
        }
        public Alert ShowAlert(string Alert_ID)
        {
            Alert Details = new Alert();
            DataTable dt = SQLDataTable("select * from Template_Alert where Alert_ID=" + Alert_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details= new Alert()
                {
                    ID = dr["Alert_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    HtmlCode = dr["HtmlCode"].ToString(),
                    DefaultData = dr["DefaultData"].ToString(),
                    CssJs = dr["CssJs"].ToString(),
                    CssJsID = dr["CssJsID"].ToString(),
                    DateTime = dr["DateTime"].ToString(),
                    AlertName = dr["AlertName"].ToString()
                };
            }

            return Details;
        }



        #endregion

        #region DemoPage
        public bool InsertDemoPage(DemoPage Details)
        {
            T_Parameter[] Parameter = new T_Parameter[] {
                new T_Parameter("@RegID",Details.RegID),
                new T_Parameter("@Template_Id",Details.Template_Id),
                new T_Parameter("@Alert_ID",Details.Alert_ID),
                new T_Parameter("@Button_ID",Details.Button_ID),
                new T_Parameter("@CheckBox_ID",Details.CheckBox_ID),
                new T_Parameter("@DataTable_ID",Details.DataTable_ID),
                new T_Parameter("@Layout_ID",Details.Layout_ID),
                new T_Parameter("@RadioButton_ID",Details.RadioButton_ID),
                new T_Parameter("@TextBox_ID",Details.TextBox_ID),
                new T_Parameter("@DateTime",Details.DateTime)
            };

            bool ReturnVal = ExcutionNonQuery(@"insert into Template_DemoPage (RegID,Template_Id,Alert_ID,Button_ID,CheckBox_ID,DataTable_ID,Layout_ID,RadioButton_ID,TextBox_ID,DateTime) values(@RegID,@Template_Id,@Alert_ID,@Button_ID,@CheckBox_ID,@DataTable_ID,@Layout_ID,@RadioButton_ID,@TextBox_ID,@DateTime) ", Parameter);
            return ReturnVal;
        }
        public List<DemoPage> ShowDemoPage()
        {
            List<DemoPage> Details = new List<DemoPage>();
            DataTable dt = SQLDataTable("select * from Template_DemoPage where Template_Id=" + this.TemplateID);
            foreach (DataRow dr in dt.Rows)
            {
                Details.Add(new DemoPage()
                {
                    ID = dr["Alert_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    Alert_ID = dr["Alert_ID"].ToString(),
                    Button_ID = dr["Button_ID"].ToString(),
                    CheckBox_ID = dr["CheckBox_ID"].ToString(),
                    DataTable_ID = dr["DataTable_ID"].ToString(),
                    Layout_ID = dr["Layout_ID"].ToString(),
                    RadioButton_ID = dr["RadioButton_ID"].ToString(),
                    TextBox_ID = dr["TextBox_ID"].ToString(),
                    DateTime = dr["DateTime"].ToString()
                });
            }

            return Details;
        }
        public DemoPage ShowDemoPage(string DemoPage_ID)
        {
            DemoPage Details = new DemoPage();
            DataTable dt = SQLDataTable("select * from Template_DemoPage where DemoPage_ID=" + DemoPage_ID);
            foreach (DataRow dr in dt.Rows)
            {
                Details = new DemoPage()
                {
                    ID = dr["DemoPage_ID"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    Alert_ID = dr["Alert_ID"].ToString(),
                    Button_ID = dr["Button_ID"].ToString(),
                    CheckBox_ID = dr["CheckBox_ID"].ToString(),
                    DataTable_ID = dr["DataTable_ID"].ToString(),
                    Layout_ID = dr["Layout_ID"].ToString(),
                    RadioButton_ID = dr["RadioButton_ID"].ToString(),
                    TextBox_ID = dr["TextBox_ID"].ToString(),
                    DateTime = dr["DateTime"].ToString()
                };
                break;
            }

            return Details;
        }

        #endregion
    }
    public class DemoPage
    {
      public string ID { get; set; }
      public string RegID {get; set;}
      public string Template_Id {get; set;}
      public string Alert_ID {get; set;}
      public string Button_ID {get; set;}
      public string CheckBox_ID {get; set;}
      public string DataTable_ID {get; set;}
      public string Layout_ID {get; set;}
      public string RadioButton_ID {get; set;}
      public string TextBox_ID {get; set;}
      public string DateTime {get; set;}
    }
    public class RadioButtons
    {
      public string ID{get; set;}
      public string RegID{get; set;}
      public string Template_Id{get; set;}
      public string HtmlCode{get; set;}
      public string GroupName{get; set;}
      public string Checked{get; set;}
      public string Text{get; set;}
      public string CssJs{get; set;}
      public string CssJsID{get; set;}
      public string DateTime{get; set;}
        public string RadioButtonName { get; set; }
    }
    public class TextBoxs
    {
        public string ID{get; set;}
      public string RegID{get; set;}
      public string Template_Id{get; set;}
      public string HtmlCode{get; set;}
      public string PlaceHolder{get; set;}
      public string Value{get; set;}
      public string CssJs{get; set;}
      public string CssJsID{get; set;}
      public string DateTime{get; set;}
        public string TextBoxName { get; set; }
    }
    public class CheckBoxs
    {
        public string ID{get; set;}
      public string RegID{get; set;}
      public string Template_Id{get; set;}
      public string HtmlCode{get; set;}
      public string Text{get; set;}
      public string Checked{get; set;}
      public string CssJs{get; set;}
      public string CssJsID{get; set;}
      public string DateTime{get; set;}
        public string CheckBoxName { get; set; }
    }
    public class Buttons
    {
        public string ID{get; set;}
      public string RegID{get; set;}
      public string Template_Id{get; set;}
      public string HtmlCode{get; set;}
      public string DefaultData1{get; set;}
      public string DefaultData2{get; set;}
      public string CssJs{get; set;}
      public string CssJsID{get; set;}
      public string DateTime{get; set;}
        public string ButtonName { get; set; }
    }
    public class Alert
    {
      public string ID{get; set;}
      public string RegID{get; set;}
      public string Template_Id{get; set;}
      public string HtmlCode{get; set;}
      public string DefaultData{get; set;}
      public string CssJs{get; set;}
      public string CssJsID{get; set;}
      public string DateTime{get; set;}
        public string AlertName { get; set; }
    }
    public class DataTables
    {
      public string ID{get; set;}
      public string RegID{get; set;}
      public string Template_Id{get; set;}
      public string HtmlCode1{get; set;}
      public string HtmlCode2{get; set;}
      public string HtmlCode3{get; set;}
      public string RowData{get; set;}
      public string ColoumData{get; set;}
      public string CssJs{get; set;}
      public string CssJsID{get; set;}
      public string DateTime{get; set;}
        public string DataTableName { get; set; }
    }
    public class Layout
    {
        public string ID { get; set; }
        public string RegID { get; set; }
        public string Template_Id { get; set; }
        public string FileUpload_Id{ get; set; }
        public string FullPath{ get; set; }
        public string HTML { get; set; }
        public string DateTime { get; set; }
        public string CssJs { get; set; }
        public string CssJs_ID { get; set; }
        public int TotalCode { get; set; }
        public string LayoutName { get; set; }
    }



    public class Files
    {
        public string FileName { get; set; }
        public string ID { get; set; }
        public string Path { get; set; }
    }
    public class HtmlDesign
    {
      public string ID { get; set; }
      public string RegID {get;set;}
      public string Template_Id{get;set;}
      public string HeaderImage_HtmlCode{get;set;}
      public string HeaderImage_DD_ImageLink{get;set;}
      public string HeaderImage_DD_AlternateText{get;set;}
      public string HeaderImage_DD_Link{get;set;}
      public string HeaderImage_UpdateTime {get;set;}
      public string HeaderSearch_HtmlCode{get;set;}
      public string HeaderSearch_UpdateTime {get;set;}
      public string HeaderNotification_HtmlCode{get;set;}
      public string HeaderNotification_HtmlCode2 { get; set; }
      public string HeaderNotification_DD_Link{get;set;}
      public string HeaderNotification_DD_Icon{get;set;}
      public string HeaderNotification_DD_Title{get;set;}
      public string HeaderNotification_DD_DetailsOrTime{get;set;}
      public string HeaderNotification_UpdateTime {get;set;}
      public string HeaderMessage_HtmlCode{get;set;}
      public string HeaderMessage_HtmlCode2 { get; set; }
      public string HeaderMessage_DD_Link{get;set;}
      public string HeaderMessage_DD_ImageLink{get;set;}
      public string HeaderMessage_DD_Title{get;set;}
      public string HeaderMessage_DD_DetailsOrTime{get;set;}
      public string HeaderMessage_UpdateTime {get;set;}
      public string HeaderProfile_HtmlCode1{get;set;}
      public string HeaderProfile_HtmlCode2{get;set;}
      public string HeaderProfile_DD1_ImageLink{get;set;}
      public string HeaderProfile_DD1_Name{get;set;}
      public string HeaderProfile_DD2_Link{get;set;}
      public string HeaderProfile_DD2_Name{get;set;}
      public string HeaderProfile_UpdateTime {get;set;}
      public string BodyBar_HtmlCode1{get;set;}
      public string BodyBar_HtmlCode2{get;set;}
      public string BodyBar_DD1_Link{get;set;}
      public string BodyBar_DD1_BarName{get;set;}
      public string BodyBar_DD2_Link{get;set;}
      public string BodyBar_DD2_BarName{get;set;}
      public string BodyBar_UpdateTime {get;set;}
      public string Footer_HtmlCode{get;set;}
      public string Footer_UpdateTime {get;set;}
    }
    public class MainControl
    {
        public string RegID { get; set; }
        public string Template_Id { get; set; }
        public string BodyClass { get; set; }
        public string MailHtml { get; set; }
        public string CssJs_ID { get; set; }
        public string CssJs { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public bool UpdateEnable { get; set; }
    }
    public class T_Parameter
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public T_Parameter() { }
        public T_Parameter(string ParameterName,object Value)
        {
            this.ParameterName = ParameterName;
            this.Value = Value;
        }
    }
    public class T_FileUpload
    {
        public string FileUpload_Id { get; set; }
        public string RegID { get; set; }
        public string Template_Id { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public string Path { get; set; }
        public string DateTime { get; set; }
        public string FullPath { get; set; }

    }
}
