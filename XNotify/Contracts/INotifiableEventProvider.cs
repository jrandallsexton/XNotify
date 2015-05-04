
using System;
using System.Collections.Generic;

namespace XNotify.Contracts
{
    public interface INotifiableEventProvider<T> where T : INotifiableEvent
    {
        string Name { get; set; }
        string Description { get; set; }
        string Source { get; set; }
        int? ExternalId { get; set; }
        Guid? ExternalGuid { get; set; }
        IEnumerable<T> GetAll();
    }
}