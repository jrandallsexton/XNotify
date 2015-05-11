
using System;
using System.Collections.Generic;

using XNotify.Common;
using XNotify.Contracts;

namespace XNotify.NotificationProviders
{

    public class SmsNotificationProvider : INotificationProvider
    {

        public NotificationProviderType ProviderType { get; set; }
        public INotificationProviderConfig Config { get; set; }

        public void Send(string to, string message)
        {
            throw new NotImplementedException();
        }

        public void Send(string to, string subject, string message)
        {
            throw new NotImplementedException();
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message)
        {
            Console.WriteLine("SmsNotificationProvider => {0}: {1}", subject, message);
            return;
        }

        public void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback)
        {
            callback("Sent via SMS");
        }

        public IEnumerable<INotificationProviderResponse> Receive()
        {
            throw new NotImplementedException();
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