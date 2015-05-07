using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Config
{
    public class NotificationProviderConfig : INotificationProviderConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set; }
        public bool Ssl { get; set; }

        public NotificationProviderConfig() { }

        public NotificationProviderConfig(INotificationProviderElement configElement)
        {
            this.AccountName = configElement.Username;
            this.Username = configElement.Username;
            this.Password = configElement.Password;
            this.AccountSid = configElement.Sid;
            this.AuthToken = configElement.Token;
            this.Password = configElement.Password;
            this.Server = configElement.Server;
            this.Port = configElement.Port;
            this.Protocol = configElement.Protocol;
            this.Ssl = configElement.Ssl;
        }
    }
}