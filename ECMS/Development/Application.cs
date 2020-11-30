using ECMS.WebPage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.UI.WebControls;
using ECMS.Design;

namespace ECMS
{
    public class Application
    {
        Design.Design design = new Design.Design();
        private Check __Check = new Check();
        private Settings __Settings = new Settings();
        public string ErrorMessege { get; set; }
        public string ErrorServerMessege { get; set; }
        public string App_ID { get; set; }
        public string AppID_to_RegID(string AppID)
        {
            return __Check.stringCheck("select RegID  from System_Apps where App_Id="+AppID);
        }
        public List<ListItem> UserTemplate(string RegID)
        {
            List<ListItem> l = new List<ListItem>();
            SqlDataReader dr = __Check.SqlDataReader("select * from System_Template where RegID=" + RegID);
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Title"].ToString();
                li.Value = dr["Template_Id"].ToString();
                l.Add(li);
            }
            ErrorMessege = __Check.Messege;
            return l;
        }

        public bool DeleteApplication(string APP_ID)
        {
            string Image = __Check.stringCheck("select imgaePath from System_Apps where App_Id=" + APP_ID);
            ImagePath_forDelete = Image;
            bool returnVal = __Check.ExcutionNonQuery("delete from System_Apps where App_Id=" + APP_ID);
            ErrorMessege = __Check.Messege;
            return returnVal;
        }
        public string AppID_to_TemplateID(string AppID)
        {
            string ret = __Check.stringCheck("select Template_Id from System_Apps where App_Id="+AppID);
            return ret;
        }
        public string AppID_to_TemplateID()
        {
            string ret = __Check.stringCheck("select Template_Id from System_Apps where App_Id=" + App_ID);
            return ret;
        }
        public bool Insert_Development(Apps_Development Design)
        {
            if (design.AppsPermision(Design.RegID))
            {
                StringGenarator _Random = new StringGenarator();
                _Random.Number = true;
                _Random.ApperCase = true;
                _Random.TotalString = __Settings.Get_InValue_Settings(10002);//hou much number
                var aid = _Random.RandomStringNumber("aid");
                DateTimeZone __datetime = new DateTimeZone(Design.Offset);
                SqlParameter[] Parameter = new SqlParameter[] {
                new SqlParameter("@aid",aid),
                new SqlParameter("@RegID",Design.RegID),
                new SqlParameter("@Template_Id",Design.Template_Id),
                new SqlParameter("@Title",Design.Title),                
                new SqlParameter("@Discription",Design.Discription),
                new SqlParameter("@App_Category_Id",Design.App_Category_Id),
                new SqlParameter("@CategoryName",Design.CategoryName),
                new SqlParameter("@Tag",Design.Tag),
                new SqlParameter("@Price",Design.Price),
                new SqlParameter("@DatabaseOwn","true"),
                new SqlParameter("@DB_ID",__Settings.Get_InValue_Settings(3)),
                new SqlParameter("@YoutubeVideoEnable",Design.YoutubeVideoEnable.ToString().ToLower()),
                new SqlParameter("@YoutubeVideoLink",Design.YoutubeVideoLink),
                new SqlParameter("@OpenDate",__datetime.DateTimes()),
                new SqlParameter("@PublishDate",""),
                new SqlParameter("@EncryptionEnable",""),
                new SqlParameter("@EncryptionKey",""),
                new SqlParameter("@Antiinjection",""),
                new SqlParameter("@SEO",Design.SEO.ToString().ToLower()),
                new SqlParameter("@VersionUpgrade",Design.VersionUpgrade.ToString().ToLower()),
                new SqlParameter("@SpeedOptimization",Design.SpeedOptimization.ToString().ToLower()),
                new SqlParameter("@Testing",Design.Testing.ToString().ToLower()),
                new SqlParameter("@Support",Design.Support.ToString().ToLower()),
                new SqlParameter("@Published","false"),
                new SqlParameter("@EditAccess","true"),                
                new SqlParameter("@version",""),
                new SqlParameter("@versionDetails",""),
                new SqlParameter("@imgaePath",Design.imgaePath),
                new SqlParameter("@imageSize",Design.imageSize),
                new SqlParameter("@PublicMode",Design.PublicMode.ToString().ToLower())
            };
                bool returnValue = __Check.ExcutionNonQuery(@"insert into System_Apps (aid ,RegID,Template_Id,Title,Discription,App_Category_Id,CategoryName,Tag,Price,DatabaseOwn,DB_ID,YoutubeVideoEnable,YoutubeVideoLink,OpenDate,PublishDate,EncryptionEnable,EncryptionKey,Antiinjection,SEO,VersionUpgrade,SpeedOptimization,Testing,Support,Published,EditAccess,version,versionDetails,imgaePath,imageSize,PublicMode) 
            values(@aid ,@RegID,@Template_Id,@Title,@Discription,@App_Category_Id,@CategoryName,@Tag,@Price,@DatabaseOwn,@DB_ID,@YoutubeVideoEnable,@YoutubeVideoLink,@OpenDate,@PublishDate,@EncryptionEnable,@EncryptionKey,@Antiinjection,@SEO,@VersionUpgrade,@SpeedOptimization,@Testing,@Support,@Published,@EditAccess,@version,@versionDetails,@imgaePath,@imageSize,@PublicMode)", Parameter);
                App_ID = __Check.stringCheck("select App_Id from System_Apps where aid='" + aid + "'");
                ErrorMessege = __Check.Messege;
                return returnValue;
            }
            else
            {
                ErrorMessege = "Your are create your maximam application now you can't create. please buy creadit!";
                return false;
            }
        }

        public List<Apps_Development> GetDevelopmentData(string RegID)
        {
            List<Apps_Development> Details = new List<Apps_Development>();
            SqlDataReader dr = __Check.SqlDataReader("select * from System_Apps where RegID=" + RegID);
            while (dr.Read())
            {
                Apps_Development design = new Apps_Development()
                {
                    Antiinjection = dr["Antiinjection"].ToString(),
                    App_Category_Id = dr["App_Category_Id"].ToString(),
                    aid = dr["aid"].ToString(),
                    App_Id = dr["App_Id"].ToString(),
                    EditAccess = dr["EditAccess"].ToString().ToLower()=="true"?true:false,
                    CategoryName = dr["CategoryName"].ToString(),
                    SEO = dr["SEO"].ToString().ToLower() == "true" ? true : false,
                    SpeedOptimization = dr["SpeedOptimization"].ToString().ToLower() == "true" ? true : false,
                    DatabaseOwn = dr["DatabaseOwn"].ToString(),
                    Support = dr["Support"].ToString().ToLower() == "true" ? true : false,
                    imgaePath = dr["imgaePath"].ToString(),
                    imageSize = Convert.ToDouble(dr["imageSize"].ToString()),
                    DB_ID = dr["DB_ID"].ToString(),
                    Discription = dr["Discription"].ToString(),
                    EncryptionEnable = dr["EncryptionEnable"].ToString().ToLower() == "true" ? true : false,
                    EncryptionKey = dr["EncryptionKey"].ToString(),
                    //Offset = dr["Offset"].ToString(),
                    OpenDate = dr["OpenDate"].ToString(),
                    Price = Convert.ToDouble(dr["Price"].ToString()),
                    PublicMode = dr["PublicMode"].ToString().ToLower() == "true" ? true : false,
                    PublishDate = dr["PublishDate"].ToString(),
                    Published = dr["Published"].ToString().ToLower() == "true" ? true : false,
                    RegID = dr["RegID"].ToString(),
                    Tag = dr["Tag"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    Testing = dr["Testing"].ToString().ToLower() == "true" ? true : false,
                    Title = dr["Title"].ToString(),
                    version = dr["version"].ToString(),
                    versionDetails = dr["versionDetails"].ToString(),
                    VersionUpgrade = dr["VersionUpgrade"].ToString().ToLower() == "true" ? true : false,
                    YoutubeVideoEnable = dr["YoutubeVideoEnable"].ToString().ToLower() == "true" ? true : false,
                    YoutubeVideoLink = dr["YoutubeVideoLink"].ToString()
                };
                Details.Add(design);
            }

            return Details;
        }
        
        public bool AvaiabDevelop(string App_Id)
        {
            return __Check.int32Check("select count(*) from System_Apps where App_Id=" + App_Id) == 1 ? true : false;
        }
        public int Allapps(string RegID)
        {
            return __Check.int32Check("select count(*) from System_Apps where RegID=" + RegID);
        }
        public string ImagePath_forDelete { get; private set; }
        public bool DeleteTemplate(string App_Id)
        {
            string Image = __Check.stringCheck("select imgaePath from System_Apps where App_Id=" + App_Id);
            ImagePath_forDelete = Image;
            bool returnVal = __Check.ExcutionNonQuery("delete from System_Apps where App_Id=" + App_Id);
            ErrorMessege = __Check.Messege;
            return returnVal;
        }
        public Apps_Development GetSignleDevelopmentData(string App_ID)
        {
            Apps_Development design = new Apps_Development();
            SqlDataReader dr = __Check.SqlDataReader("select * from System_Apps where App_Id=" + App_ID);
            while (dr.Read())
            {
                design = new Apps_Development()
                {
                    Antiinjection = dr["Antiinjection"].ToString(),
                    App_Category_Id = dr["App_Category_Id"].ToString(),
                    aid = dr["aid"].ToString(),
                    App_Id = dr["App_Id"].ToString(),
                    EditAccess = dr["EditAccess"].ToString().ToLower() == "true" ? true : false,
                    CategoryName = dr["CategoryName"].ToString(),
                    SEO = dr["SEO"].ToString().ToLower() == "true" ? true : false,
                    SpeedOptimization = dr["SpeedOptimization"].ToString().ToLower() == "true" ? true : false,
                    DatabaseOwn = dr["DatabaseOwn"].ToString(),
                    Support = dr["Support"].ToString().ToLower() == "true" ? true : false,
                    imgaePath = dr["imgaePath"].ToString(),
                    imageSize = Convert.ToDouble(dr["imageSize"].ToString()),
                    DB_ID = dr["DB_ID"].ToString(),
                    Discription = dr["Discription"].ToString(),
                    EncryptionEnable = dr["EncryptionEnable"].ToString().ToLower() == "true" ? true : false,
                    EncryptionKey = dr["EncryptionKey"].ToString(),
                    //Offset = dr["Offset"].ToString(),
                    OpenDate = dr["OpenDate"].ToString(),
                    Price = Convert.ToDouble(dr["Price"].ToString()),
                    PublicMode = dr["PublicMode"].ToString().ToLower() == "true" ? true : false,
                    PublishDate = dr["PublishDate"].ToString(),
                    Published = dr["Published"].ToString().ToLower() == "true" ? true : false,
                    RegID = dr["RegID"].ToString(),
                    Tag = dr["Tag"].ToString(),
                    Template_Id = dr["Template_Id"].ToString(),
                    Testing = dr["Testing"].ToString().ToLower() == "true" ? true : false,
                    Title = dr["Title"].ToString(),
                    version = dr["version"].ToString(),
                    versionDetails = dr["versionDetails"].ToString(),
                    VersionUpgrade = dr["VersionUpgrade"].ToString().ToLower() == "true" ? true : false,
                    YoutubeVideoEnable = dr["YoutubeVideoEnable"].ToString().ToLower() == "true" ? true : false,
                    YoutubeVideoLink = dr["YoutubeVideoLink"].ToString()
                };
                break;
            }

            return design;
        }
        public bool UpdateTemplate(Apps_Development Design)
        {
            //SqlParameter[] Parameter = new SqlParameter[] {
            //    new SqlParameter("@Title",Design.Title),
            //    new SqlParameter("@Discription",Design.Discription),
            //    new SqlParameter("@App_Category_Id",Design.App_Category_Id),
            //    new SqlParameter("@Template_Id",design.Template_ID),
            //    new SqlParameter("@CategoryName",Design.CategoryName),
            //    new SqlParameter("@Tag",Design.Tag),
            //    new SqlParameter("@Price",Design.Price),
            //    new SqlParameter("@YoutubeVideoEnable",Design.YoutubeVideoEnable.ToString().ToLower()),
            //    new SqlParameter("@YoutubeVideoLink",Design.YoutubeVideoLink),
            //    new SqlParameter("@SEO",Design.SEO.ToString().ToLower()),
            //    new SqlParameter("@VersionUpgrade",Design.VersionUpgrade.ToString().ToLower()),
            //    new SqlParameter("@SpeedOptimization",Design.SpeedOptimization.ToString().ToLower()),
            //    new SqlParameter("@Testing",Design.Testing.ToString().ToLower()),
            //    new SqlParameter("@Support",Design.Support.ToString().ToLower()),
            //    new SqlParameter("@imgaePath",Design.imgaePath),
            //    new SqlParameter("@imageSize",Design.imageSize),
            //    new SqlParameter("@PublicMode",Design.PublicMode.ToString().ToLower())
            //};
            bool ReturnVal = __Check.ExcutionNonQuery(string.Format(@"update System_Apps set 
Title='{0}',
Discription='{1}',
App_Category_Id='{2}',
CategoryName='{3}',
Tag='{4}',
Price={5},
YoutubeVideoEnable='{6}',
YoutubeVideoLink='{7}',
SEO='{8}',
VersionUpgrade='{9}',
SpeedOptimization='{10}',
Testing='{11}',
Support='{12}',
imgaePath='{13}',
imageSize='{14}',
PublicMode='{15}',Template_Id={16}
 where App_Id={17}", Design.Title, Design.Discription, Design.App_Category_Id, Design.CategoryName,
Design.Tag, Design.Price, Design.YoutubeVideoEnable.ToString().ToLower(), Design.YoutubeVideoLink, Design.SEO.ToString().ToLower(),
Design.VersionUpgrade.ToString().ToLower(), Design.SpeedOptimization.ToString().ToLower(), Design.Testing.ToString().ToLower(),
Design.Support.ToString().ToLower(), Design.imgaePath, Design.imageSize, Design.PublicMode.ToString().ToLower(), Design.Template_Id, Design.App_Id));
            ErrorMessege = __Check.Messege;
            ErrorServerMessege = __Check.ServerMessage;
            return ReturnVal;
        }


    }
    public class Apps_Development
    {
        public string App_Id { get; set; }
        public string RegID { get; set; }
        public string Template_Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string App_Category_Id { get; set; }
        public string CategoryName { get; set; }
        public string Tag { get; set; }
        public double Price { get; set; }
        public string DatabaseOwn { get; set; }
        public string DB_ID { get; set; }
        public bool YoutubeVideoEnable { get; set; }
        public string YoutubeVideoLink { get; set; }
        public string OpenDate { get; set; }
        public string PublishDate { get; set; }
        public bool EncryptionEnable { get; set; }
        public string EncryptionKey { get; set; }
        public string Antiinjection { get; set; }
        public bool SEO { get; set; }
        public bool VersionUpgrade { get; set; }
        public bool SpeedOptimization { get; set; }
        public bool Testing { get; set; }
        public bool Support { get; set; }
        public bool Published { get; set; }
        public bool EditAccess { get; set; }
        public string version { get; set; }
        public string versionDetails { get; set; }
        public string aid { get; set; }
        public string Offset { get; set; }
        public string imgaePath { get; set; }
        public double imageSize { get; set; }
        public bool PublicMode { get; set; }


    }
}
