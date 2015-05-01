
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using XNotify.Contracts;

namespace XNotify.Services
{
    public class NotificationService : INotificationService
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public INotificationPersistence Persistence { get; set; }

        public INotificationProcessor Processor { get; set; }

        public INotificationQueue<INotifiableEvent> Queue { get; set; }

        public IList<INotificationProvider> NotificationProviders { get; set; }

        public INotificationMonitor Monitor { get; set; }

        public INotificationLogger Logger { get; set; }

        public IList NotificationSourceProviders { get; set; }

        public NotificationService(string name, string description, IList<INotificationProvider> notificationProviders)
        {
            this.Name = name;
            this.Description = description;
            this.NotificationProviders = notificationProviders;
        }

    }
}