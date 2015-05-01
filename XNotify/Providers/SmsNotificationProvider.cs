using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Providers
{
    public class SmsNotificationProvider : INotificationProvider
    {
        public INotificationProviderConfig Config { get; set; }

        public SmsNotificationProvider(INotificationProviderConfig config)
        {
            this.Config = config;
        }
    }
}