
using System;
using System.Collections.Generic;
using System.Linq;
using XNotify.Common;
using XNotify.Contracts;

namespace XNotify.Tests.EventProviders.FakeEventProvider01
{
    public class FakeMongoDbEventProvider : INotifiableEventProvider<INotifiableEvent>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int? ExternalId { get; set; }
        public Guid? ExternalGuid { get; set; }
        public IEnumerable<INotifiableEvent> GetAll()
        {
            var events = new List<INotifiableEvent>();

            var evnt = new NotifiableEvent
            {
                Created = DateTime.UtcNow,
                Description = "just a fake event coming from AppointmentNotifiableEventProvider",
                Name = "Fake Appointment event",
                Id = 1,
                Message = "This is a fake event representing some event that XNotify will pull from an external data source",
                Source = "XNotify.Tests.EventProviders.FakeEventProvider00.FakeMongoDbEventProvider",
                Subject = "Your Notification",
                UtcDue = DateTime.UtcNow.AddMinutes(10)
            };

            events.Add(evnt);

            return events.AsEnumerable();
        }

        public INotifiableEvent Get(int id)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(int id, NotificationProviderType notificationProviderType)
        {
            throw new NotImplementedException();
        }

        public string GetMessage(int id)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(int recipientId, int notificationProviderId)
        {
            throw new NotImplementedException();
        }

        public void MarkProcessed(int eventId, IEnumerable<int> recipientIds)
        {
            throw new NotImplementedException();
        }
    }
}