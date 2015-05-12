
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Markup;
using XNotify.Common;
using XNotify.Contracts;
using XNotify.Targets;

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
            //const int step = 5;
            //for (var i = 1; i < 100; i += step)
            //{
            //    var evnt = new NotifiableEvent
            //    {
            //        Created = DateTime.UtcNow,
            //        Description = "just a fake event coming from WorkOrderNotifiableEventProvider",
            //        Name = "Fake event " + i,
            //        Id = i,
            //        Message = "This is a fake event representing some event that XNotify will pull from an external data source",
            //        Source = "FakeSqlEventProvider",
            //        Subject = "Your Notification",
            //        UtcDue = DateTime.UtcNow.AddMinutes(i)
            //    };

            //    evnt.Targets = new List<INotificationTarget>
            //    {
            //        new NotificationTarget("Randall Sexton", "jrandallsexton@gmail.com", "8653865611", true, true)
            //    };

            //    events.Add(evnt);               
            //}

            var evnt = new NotifiableEvent
            {
                Created = DateTime.UtcNow,
                Description = "just a fake event coming from WorkOrderNotifiableEventProvider",
                Name = "Fake event ",
                Id = 0,
                Message = this.BuildMessageContent(),
                Source = "FakeSqlEventProvider",
                Subject = "Your Notification",
                UtcDue = DateTime.UtcNow.AddMinutes(1),
                Targets = new List<INotificationTarget>
                {
                    new NotificationTarget("Randall Sexton", "jrandallsexton@gmail.com", "+18653865611", true, true),
                    new NotificationTarget("Joe Blow", "joeblow@gmail.com", "+15005550001", false, true)
                }
            };

            events.Add(evnt);

        }

        public IEnumerable<INotifiableEvent> GetAll()
        {
            return events.AsEnumerable();
        }

        public INotifiableEvent Get(int id)
        {
            return events.Find(x => x.Id == id);
        }

        public string GetMessage(int id, NotificationProviderType notificationProviderType)
        {
            throw new NotImplementedException();
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

        private string BuildMessageContent()
        {
            var value = new StringBuilder();
            value.AppendLine("Subject: Something To Do");
            value.AppendLine("Task: Go meet with So-and-So");
            value.AppendLine("Ref #: Smith, John #12345");
            value.AppendLine("Start: " + DateTime.Now.AddMinutes(30));
            value.AppendLine("End: " + DateTime.Now.AddMinutes(90));
            value.AppendLine("Category, Subcategory");
            value.AppendLine("[Reply with REMOVE to discontinue notifications]");
            return value.ToString();
        }

    }
}