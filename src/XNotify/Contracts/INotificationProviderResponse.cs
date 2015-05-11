
using System;

using XNotify.Common;

namespace XNotify.Contracts
{
    public interface INotificationProviderResponse
    {
        string SourceId { get; set; }
        string Sender { get; set; }
        string Message { get; set; }
        DateTime Received { get; set; }
        NotificationProviderType Channel { get; set; }
        new string ToString();
    }
}