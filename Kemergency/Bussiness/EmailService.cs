using Kemergency.Models;
using MailKit.Net.Smtp;
using Microsoft.CodeAnalysis.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class EmailService : IEmailServices
    {

        EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public bool sendEmail(Message message)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                MailboxAddress emailFrom = new MailboxAddress("کندهار امرجنسي", "hakimsadat910@gmail.com");
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new MailboxAddress(message.EmailToName, message.EmailToId);
                emailMessage.To.Add(emailTo);
                emailMessage.Subject = message.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = message.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();
                SmtpClient emailClient = new SmtpClient();

                emailClient.Connect("smtp.gmail.com",465, true);

               // emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate("hakimsadat910@gmail.com", "Hakim0728280536");
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }

        }
    }
}
