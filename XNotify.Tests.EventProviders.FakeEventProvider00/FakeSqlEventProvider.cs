
using System;
using System.Collections.Generic;
using System.Linq;
using XNotify.Contracts;

namespace XNotify.Tests.EventProviders.FakeEventProvider00
{
    public class FakeSqlEventProvider : INotifiableEventProvider<INotifiableEvent>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int? ExternalId { get; set; }
        public Guid? ExternalGuid { get; set; }

        private List<INotifiableEvent> events = null;

        public FakeSqlEventProvider()
        {
            events = new List<INotifiableEvent>();
            const int step = 5;
            for (var i = 1; i < 100; i += step)
            {
                var evnt = new NotifiableEvent
                {
                    Created = DateTime.UtcNow,
                    Description = "just a fake event coming from WorkOrderNotifiableEventProvider",
                    Name = "Fake event " + i,
                    Id = i,
                    Message = "This is a fake event representing some event that XNotify will pull from an external data source",
                    Source = "FakeSqlEventProvider",
                    Subject = "Your Notification",
                    UtcDue = DateTime.UtcNow.AddMinutes(i)
                };

                events.Add(evnt);               
            }

        }

        public IEnumerable<INotifiableEvent> GetAll()
        {
            return events.AsEnumerable();
        }

        public INotifiableEvent Get(int id)
        {
            return events.Find(x => x.Id == id);
        }

        public string GetMessage(int id)
        {
            return events.Find(x => x.Id == id).Message;
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