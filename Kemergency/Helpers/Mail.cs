using Kemergency.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Kemergency.Helpers
{
    public class Mail
    {
        private string NetworkEmail { get; set; }
        private string NetworkPassword { get; set; }
        private string FromEmail { get; set; }
        private string DisplayName { get; set; }
        private int Port { get; set; }
        private string Host { get; set; }
        private bool EnableSsl { get; set; }


        public Mail()
        {
            AccountEmail ObjClsEmail = new AccountEmail();
            var EmailSetting = ObjClsEmail.GetEmailSettings();
            if (EmailSetting != null)
            {
                NetworkEmail = EmailSetting.UserID;
                NetworkPassword = EmailSetting.Password;
                FromEmail = EmailSetting.UserID;
                DisplayName = "Kemergency";
                Port = Convert.ToInt16(EmailSetting.Port);
                Host = EmailSetting.Host;
                EnableSsl = EmailSetting.EnableSSL.Equals("true") ? true : false;
            }
        }

        public bool SendMail(string email, string subject, string body)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(NetworkEmail, NetworkPassword);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(FromEmail, DisplayName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = Host,
                    EnableSsl = true,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }



}
