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
    public class Design
    {
        
        public string Template_ID { get; private set; }
        public int AvaiableImageCount { get; private set; }
        private Check __Check = new Check();
        private Settings __Settings = new Settings();
        public string ErrorMessege { get; set; }
        private List<ListItem> _private_Category()
        {
            int i = 0;
            List<ListItem> l = new List<ListItem>();
            
            SqlDataReader dr = __Check.SqlDataReader("select * from Apps_Category order by CategoryName");
            while(dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["CategoryName"].ToString();
                li.Value= dr["App_Category_Id"].ToString();
                l.Add(li);
            }
            ListItem le = new ListItem();
            le.Text = "Other";
            le.Value = "0";
            l.Add(le);
            ErrorMessege =__Check.Messege;
            return l;
        }
        public List<ListItem> AppsCategorys()
        {
            return _private_Category();
        }
        private bool _Private_DesignUpload(DesignDetails Design)
        {
            if (AppsPermision(Design.RegID))
            {
                StringGenarator _Random = new StringGenarator();
                _Random.Number = true;
                _Random.ApperCase = true;
                _Random.TotalString = __Settings.Get_InValue_Settings(10002);//hou much number
                var tid = _Random.RandomStringNumber("tid");
                DateTimeZone __datetime = new DateTimeZone(Design.Offset);
                SqlParameter[] Parameter = new SqlParameter[] {
                new SqlParameter("@RegID",Design.RegID),
                new SqlParameter("@Title",Design.Title),
                new SqlParameter("@Discription",Design.Discription),
                new SqlParameter("@App_Category_Id",Design.CategoryID),
                new SqlParameter("@CategoryName",Design.CategoryName),
                new SqlParameter("@Tag",Design.Tag),
                new SqlParameter("@Price",Design.Price),
                new SqlParameter("@DatabaseOwn","true"),
                new SqlParameter("@DB_ID",__Settings.Get_InValue_Settings(3)),
                new SqlParameter("@YoutubeVideoEnable",Design.YoutubeEnable.ToString().ToLower()),
                new SqlParameter("@YoutubeVideoLink",Design.YoutubeLink),
                new SqlParameter("@OpenDate",__datetime.DateTimes()),
                new SqlParameter("@PublishDate",""),
                new SqlParameter("@SEO",Design.SEO.ToString().ToLower()),
                new SqlParameter("@VersionUpgrade",Design.Version.ToString().ToLower()),
                new SqlParameter("@SpeedOptimization",Design.SpeedOptimization.ToString().ToLower()),
                new SqlParameter("@Testing",Design.Testing.ToString().ToLower()),
                new SqlParameter("@Support",Design.Support.ToString().ToLower()),
                new SqlParameter("@Published","false"),
                new SqlParameter("@EditAccess","true"),
                new SqlParameter("@tid",tid),
                new SqlParameter("@imgaePath",Design.imgaePath),
                new SqlParameter("@imageSize",Design.imageSize),
                new SqlParameter("@PublicMode",Design.PublicMode.ToString().ToLower())
            };
                bool returnValue = __Check.ExcutionNonQuery(@"insert into System_Template (RegID,Title,Discription,App_Category_Id,CategoryName,Tag,Price,DatabaseOwn,DB_ID,YoutubeVideoEnable,YoutubeVideoLink,OpenDate,PublishDate,SEO,VersionUpgrade,SpeedOptimization,Testing,Support,Published,EditAccess,tid,imgaePath,imageSize,PublicMode) 
            values(@RegID,@Title,@Discription,@App_Category_Id,@CategoryName,@Tag,@Price,@DatabaseOwn,@DB_ID,@YoutubeVideoEnable,@YoutubeVideoLink,@OpenDate,@PublishDate,@SEO,@VersionUpgrade,@SpeedOptimization,@Testing,@Support,@Published,@EditAccess,@tid,@imgaePath,@imageSize,@PublicMode)", Parameter);
                Template_ID = __Check.stringCheck("select Template_Id from System_Template where tid='" + tid + "'");
                ErrorMessege = __Check.Messege;
                return returnValue;
            }
            else
            {
                ErrorMessege = "Your are create your maximam application now you can't create. please buy creadit!";
                return false;
            }
        }
        public bool InsertTemplate(DesignDetails Design)
        {
            return _Private_DesignUpload(Design);
        }
        public bool AvaiableTemplate(string TemplateID)
        {
            return __Check.int32Check("select count(*) from System_Template where Template_Id=" + TemplateID) == 1 ? true : false;
        }
        public bool AvaiableTemplate(string TemplateID, string RegID)
        {
            return __Check.int32Check("select count(*) from System_Template where Template_Id=" + TemplateID + " and RegID="+RegID) == 1 ? true : false;
        }
        public bool AppsPermision(string RegID)
        {
            int Apps_Develops = __Check.int32Check("select count(*) from System_Apps where RegID="+RegID);
            int Apps_Design = __Check.int32Check("select count(*) from System_Template where RegID=" + RegID);
            int Apps_Max = __Check.int32Check("select Max_Apps from DeveloperRegistation where Reg_ID="+RegID);
            return (Apps_Design + Apps_Develops) < Apps_Max ? true : false;
        }      
        
        public List<DesignDetails> GetTemplateData(string RegID)
        {
            List<DesignDetails> Details = new List<DesignDetails>();
            SqlDataReader dr = __Check.SqlDataReader("select * from System_Template where RegID="+RegID);
            while (dr.Read())
            {
                DesignDetails design = new DesignDetails() {
                    TemplateId = dr["Template_Id"].ToString(),
                    tid = dr["tid"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Title = dr["Title"].ToString(),
                    Discription = dr["Discription"].ToString(),
                    CategoryID = dr["App_Category_Id"].ToString(),
                    CategoryName = dr["CategoryName"].ToString(),
                    Tag = dr["Tag"].ToString(),
                    Price = Convert.ToDouble(dr["Price"].ToString()),
                    DatabaseOwn = dr["DatabaseOwn"].ToString().ToLower() == "true" ? true : false,
                    DB_ID =dr["DB_ID"].ToString(),
                    YoutubeEnable = dr["YoutubeVideoEnable"].ToString().ToLower()=="true"?true:false,
                    YoutubeLink=dr["YoutubeVideoLink"].ToString(),
                    OpenDate = dr["OpenDate"].ToString(),
                    PublishDate = dr["PublishDate"].ToString(),
                    SEO = dr["SEO"].ToString().ToLower()=="true"?true:false,
                    Version = dr["VersionUpgrade"].ToString().ToLower()=="true"?true:false,
                    SpeedOptimization =dr["SpeedOptimization"].ToString().ToLower() == "true" ? true : false,
                    Testing = dr["Testing"].ToString().ToLower() == "true" ? true : false,
                    Support = dr["Support"].ToString().ToLower() == "true" ? true : false,
                    Published = dr["Published"].ToString().ToLower() == "true" ? true : false,
                    EditAccess = dr["EditAccess"].ToString().ToLower() == "true" ? true : false,
                    ver =dr["version"].ToString(),
                    versionDetails = dr["versionDetails"].ToString(),
                    imgaePath = dr["imgaePath"].ToString(),
                    imageSize = Convert.ToDouble(dr["imageSize"].ToString()),                    
                    PublicMode = dr["PublicMode"].ToString().ToLower() == "true" ? true : false
                };
                Details.Add(design);
            }

            return Details;
        }
        public DesignDetails GetSingleTempletData(string TemplateID)
        {
            DesignDetails design = new DesignDetails();
            SqlDataReader dr = __Check.SqlDataReader("select * from System_Template where Template_Id=" + TemplateID);
            while (dr.Read())
            {
                design = new DesignDetails()
                {
                    TemplateId = dr["Template_Id"].ToString(),
                    tid = dr["tid"].ToString(),
                    RegID = dr["RegID"].ToString(),
                    Title = dr["Title"].ToString(),
                    Discription = dr["Discription"].ToString(),
                    CategoryID = dr["App_Category_Id"].ToString(),
                    CategoryName = dr["CategoryName"].ToString(),
                    Tag = dr["Tag"].ToString(),
                    Price = Convert.ToDouble(dr["Price"].ToString()),
                    DatabaseOwn = dr["DatabaseOwn"].ToString().ToLower() == "true" ? true : false,
                    DB_ID = dr["DB_ID"].ToString(),
                    YoutubeEnable = dr["YoutubeVideoEnable"].ToString().ToLower() == "true" ? true : false,
                    YoutubeLink = dr["YoutubeVideoLink"].ToString(),
                    OpenDate = dr["OpenDate"].ToString(),
                    PublishDate = dr["PublishDate"].ToString(),
                    SEO = dr["SEO"].ToString().ToLower() == "true" ? true : false,
                    Version = dr["VersionUpgrade"].ToString().ToLower() == "true" ? true : false,
                    SpeedOptimization = dr["SpeedOptimization"].ToString().ToLower() == "true" ? true : false,
                    Testing = dr["Testing"].ToString().ToLower() == "true" ? true : false,
                    Support = dr["Support"].ToString().ToLower() == "true" ? true : false,
                    Published = dr["Published"].ToString().ToLower() == "true" ? true : false,
                    EditAccess = dr["EditAccess"].ToString().ToLower() == "true" ? true : false,
                    ver = dr["version"].ToString(),
                    versionDetails = dr["versionDetails"].ToString(),
                    imgaePath = dr["imgaePath"].ToString(),
                    imageSize = Convert.ToDouble(dr["imageSize"].ToString()),
                    PublicMode = dr["PublicMode"].ToString().ToLower() == "true" ? true : false
                };                
            }
            return design;
        }
        public string ImagePath_forDelete { get; private set; }
        public bool DeleteTemplate(string TemplateID)
        {
            string Image = __Check.stringCheck("select imgaePath from System_Template where Template_Id="+TemplateID);
            ImagePath_forDelete = Image;
            bool returnVal = __Check.ExcutionNonQuery("delete from System_Template where Template_Id="+TemplateID);
            ErrorMessege = __Check.Messege;
            return returnVal;
        }
        public bool UpdateTemplate(DesignDetails Design)
        {
            SqlParameter[] Parameter = new SqlParameter[] {
                new SqlParameter("@Title",Design.Title),
                new SqlParameter("@Discription",Design.Discription),
                new SqlParameter("@App_Category_Id",Design.CategoryID),
                new SqlParameter("@CategoryName",Design.CategoryName),
                new SqlParameter("@Tag",Design.Tag),
                new SqlParameter("@Price",Design.Price),
                new SqlParameter("@YoutubeVideoEnable",Design.YoutubeEnable.ToString().ToLower()),
                new SqlParameter("@YoutubeVideoLink",Design.YoutubeLink),
                new SqlParameter("@SEO",Design.SEO.ToString().ToLower()),
                new SqlParameter("@VersionUpgrade",Design.Version.ToString().ToLower()),
                new SqlParameter("@SpeedOptimization",Design.SpeedOptimization.ToString().ToLower()),
                new SqlParameter("@Testing",Design.Testing.ToString().ToLower()),
                new SqlParameter("@Support",Design.Support.ToString().ToLower()),
                new SqlParameter("@imgaePath",Design.imgaePath),
                new SqlParameter("@imageSize",Design.imageSize),
                new SqlParameter("@PublicMode",Design.PublicMode.ToString().ToLower())
            };
            bool ReturnVal = __Check.ExcutionNonQuery(@"update System_Template set 
                Title=@Title,Discription=@Discription,App_Category_Id=@App_Category_Id,
CategoryName=@CategoryName,Tag=@Tag,Price=@Price,YoutubeVideoEnable=@YoutubeVideoEnable,
YoutubeVideoLink=@YoutubeVideoLink,SEO=@SEO,VersionUpgrade=@VersionUpgrade,SpeedOptimization=@SpeedOptimization,
Testing=@Testing,Support=@Support,imgaePath=@imgaePath,imageSize=@imageSize,PublicMode=@PublicMode where Template_Id="+Design.TemplateId, Parameter);
            ErrorMessege = __Check.Messege;
            return ReturnVal;
        }


    }
    public class DesignDetails
    {
        public string RegID { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string CategoryName { get; set; }
        public string CategoryID { get; set; }
        public bool YoutubeEnable { get; set; }
        public string YoutubeLink { get; set; }
        public bool SEO { get; set; }
        public bool Version { get; set; }
        public bool SpeedOptimization { get; set; }
        public bool Testing { get; set; }
        public bool Support { get; set; }
        public string Tag { get; set; }
        public string Offset { get; set; }
        public string imgaePath { get; set; }
        public double imageSize { get; set; }
        public bool PublicMode { get; set; }

        //----------------------------------------------------
        public string TemplateId { get; set; }
        public string tid { get; set; }
        public bool DatabaseOwn { get; set; }
        public string DB_ID { get; set; }
        public string OpenDate { get; set; }
        public string PublishDate { get; set; }
        public bool Published { get; set; }
        public bool EditAccess { get; set; }
        public string ver { get; set; }
        public string versionDetails { get; set; }
    }
}
