
using System;
using System.Collections.Generic;

using XNotify.Common;

namespace XNotify.Contracts
{
    public interface INotificationProvider
    {
        NotificationProviderType ProviderType { get; set; }
        INotificationProviderConfig Config { get; set; }
        void Send(string to, string message);
        void Send(string to, string subject, string message);
        void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message);
        void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback);
        IEnumerable<INotificationProviderResponse> Receive();
    }
}