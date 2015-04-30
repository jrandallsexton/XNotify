using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify
{
    public class NotifiableEvent : INotifiableEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime UtcDue { get; set; }
        public IList<INotificationTarget> Targets { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
