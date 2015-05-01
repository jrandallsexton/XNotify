
using System;
using System.Collections.Generic;
using XNotify.Contracts;

namespace XNotify.Tests.Fakes
{
    public class FakeNotifiableEventProvider<T> : INotifiableEventProvider<T> where T : INotifiableEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int? ExternalId { get; set; }
        public Guid? ExternalGuid { get; set; }
        public IList<T> Get()
        {
            throw new NotImplementedException();
        }
    }
}