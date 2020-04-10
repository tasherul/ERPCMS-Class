using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace ECMS
{
    class Mail
    {
        private string Host_ = "smtpout.secureserver.net";
        private int Port_ = 80;

        public string Host { set { Host_ = value; } }
        public int Port { set { Port_ = value; } }

        private bool _Mail_Send(string Email, string Subject, string Body)
        {
            try
            {
                MailMessage objeto_mail = new MailMessage();

                SmtpClient client = new SmtpClient();
                client.Port = Port_;
                client.Host = Host_;
                client.Timeout = 1000000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Credentials = new System.Net.NetworkCredential("support@bddoctorspoint.com", "Monir@1981");
                objeto_mail.From = new MailAddress("support@bddoctorspoint.com");
                objeto_mail.To.Add(new MailAddress(Email));
                objeto_mail.Subject = Subject;
                objeto_mail.Body = Body;
                client.Send(objeto_mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SendMail(string Email, string Subject, string Body)
        {
            return _Mail_Send(Email, Subject, Body);
        }
    }
}
