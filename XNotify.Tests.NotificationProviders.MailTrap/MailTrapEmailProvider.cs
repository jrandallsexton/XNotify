
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

using XNotify.Common;
using XNotify.Contracts;

namespace XNotify.Tests.NotificationProviders.MailTrap
{

    public class MailTrapEmailProvider : INotificationProvider
    {

        public ENotificationProviderType ProviderType { get; set; }
        public INotificationProviderConfig Config { get; set; }

        public MailTrapEmailProvider()
        {
            this.ProviderType = ENotificationProviderType.Email;
        }

        public void Send(string to, string message)
        {
            this.Send(to, string.Empty, message);
        }

        public void Send(string to, string subject, string message)
        {
            var client = new SmtpClient(Config.Server, int.Parse(Config.Port))
            {
                Credentials = new NetworkCredential(Config.Username, Config.Password),
                EnableSsl = true
            };
            client.Send("from@email.com", to, subject, message);
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message)
        {
            return;
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback)
        {
            callback("sent");
            return;
        }

    }

}