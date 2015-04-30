using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Contracts
{
    public interface INotifiableEventProvider<T> where T : INotifiableEvent
    {
        string Name { get; set; }
        string Description { get; set; }
        string Source { get; set; }
        int? ExternalId { get; set; }
        Guid? ExternalGuid { get; set; }
    }
}
