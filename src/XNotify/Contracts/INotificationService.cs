
using System.Collections;
using System.Collections.Generic;

namespace XNotify.Contracts
{
    public interface INotificationService
    {
        string Name { get; set; }
        string Description { get; set; }
        INotificationPersistence Persistence { get; set; }
        INotificationQueue<INotifiableEvent> Queue { get; set; }
        IList<INotificationProvider> NotificationProviders { get; set; }
        INotificationLogger Logger { get; set; }
        IList NotificationSourceProviders { get; set; }
        void Start();
        void Stop();
    }
}