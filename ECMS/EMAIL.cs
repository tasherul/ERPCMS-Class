
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace ECMS
{
    public class EMAIL
    {
        private string _Email= "info@bdbay.net";
        public string Email_UserName { set { _Email = value; } }
        private string _Password= "Pi@sh885989";
        public string Email_Password { set { _Password = value; } }
        public string Subject { get; set; }
        public string Messege { get; set; }
        public string Email { get; set; }
        public string ErrorMessage { get; set; }
        private bool _Mail()
        {
            try
            {
                MailMessage _msg = new MailMessage();
                _msg.From = new MailAddress(_Email);
                _msg.To.Add(Email);
                _msg.Subject = Subject;
                _msg.Body = Messege;
                _msg.IsBodyHtml = true;
                SmtpClient _smtp = new SmtpClient();
                _smtp.Credentials = new System.Net.NetworkCredential(_Email, _Password);
                _smtp.EnableSsl = false;
                _smtp.Send(_msg);
                _msg.Dispose();
                ErrorMessage = "OK";
                return true;
            }
            catch (Exception er)
            { ErrorMessage = er.Message; return false; }
        }
        public bool Mail()
        {
            return _Mail();
        }
       

    }
}
