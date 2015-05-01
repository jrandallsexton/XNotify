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

        public FakeSmsNotificationProviderConfig()
        {
            this.Username = "jrandallsexton";
            this.Password = "food";
        }
    }
}