
using System;

using XNotify.Common;
using XNotify.Contracts;

namespace XNotify.NotificationProviders
{
    public class NotificationProviderResponse : INotificationProviderResponse
    {
        public string SourceId { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Received { get; set; }
        public ENotificationProviderType Channel { get; set; }
        public new string ToString()
        {
            return string.Format("{0} via {1}: From: {2}\t{3}", Received, Channel, Sender, Message);
        }
    }
}