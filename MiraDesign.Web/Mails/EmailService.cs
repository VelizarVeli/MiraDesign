using System;
using MimeKit;
using MiraDesign.Common.ViewModels;
using MiraDesign.Web.Mails.Contracts;

namespace MiraDesign.Web.Mails
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public void Send(IEmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.Name, _emailConfiguration.SmtpUsername));
            message.To.Add(new MailboxAddress("mira", "lmirakasabova@gmail.com"));
            message.Subject = $"{emailMessage.Subject}";
            message.Body = new TextPart("plain")
            {
                Text = $"Message: {emailMessage.Content}" + Environment.NewLine +
                       $"Contact email: {emailMessage.Email}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
                client.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
