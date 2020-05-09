using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ECMS.Design
{
    public class Design
    {
        private Check __Check = new Check();
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
            le.Value = "Other";
            l.Add(le);
            ErrorMessege =__Check.Messege;
            return l;
        }
        public List<ListItem> AppsCategorys()
        {
            return _private_Category();
        }
    }
}
