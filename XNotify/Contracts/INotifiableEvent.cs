
using System;
using System.Collections.Generic;

namespace XNotify.Contracts
{
    public interface INotifiableEvent
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Source { get; set; }
        DateTime Created { get; set; }
        DateTime? Modified { get; set; }
        DateTime UtcDue { get; set; }
        IList<INotificationTarget> Targets { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
    }
}