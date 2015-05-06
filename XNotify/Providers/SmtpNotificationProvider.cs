using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Providers
{
    public class SmtpNotificationProvider : INotificationProvider
    {
        public INotificationProviderConfig Config { get; set; }
        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message)
        {
            Console.WriteLine("SmtpNotificationProvider => {0}: {1}", subject, message);
            return;
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback)
        {
            callback("Sent via SMTP");
        }

        public SmtpNotificationProvider()
        {
            
        }
    }
}