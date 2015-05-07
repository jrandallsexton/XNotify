using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Tests.Fakes
{
    public class FakeSmsNotificationProviderConfig : INotificationProviderConfig
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

        public FakeSmsNotificationProviderConfig()
        {
            this.Username = "jrandallsexton";
            this.Password = "food";
        }
    }
}