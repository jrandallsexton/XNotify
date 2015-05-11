
using System.Collections;
using System.Collections.Generic;

namespace XNotify.Contracts
{
    public interface INotificationService
    {
        string Name { get; set; }
        string Description { get; set; }
        INotificationPersistence<INotifiableEvent> Persistence { get; set; }
        INotificationQueue<INotifiableEvent> Queue { get; set; }
        IList<INotifiableEventProvider<INotifiableEvent>> EventProviders { get; set; }
        IList<INotificationProvider> NotificationProviders { get; set; }
        INotificationLogger Logger { get; set; }
        void Start();
        void Stop();
    }
}