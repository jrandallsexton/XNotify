using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Providers
{
    public class SmsNotificationProvider : INotificationProvider
    {
        public INotificationProviderConfig Config { get; set; }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message)
        {
            Console.WriteLine("SmsNotificationProvider => {0}: {1}", subject, message);
            return;
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback)
        {
            callback("Sent via SMS");
        }

        public SmsNotificationProvider()
        {
            
        }
        public SmsNotificationProvider(INotificationProviderConfig config)
        {
            this.Config = config;
        }
    }
}