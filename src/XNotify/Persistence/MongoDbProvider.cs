
using System;
using System.Collections.Generic;

using XNotify.Contracts;

namespace XNotify.Persistence
{
    public class MongoDbProvider : INotificationPersistence<INotifiableEvent>
    {
        public void Add(INotifiableEvent item)
        {
            throw new NotImplementedException();
        }

        public void Remove(INotifiableEvent item)
        {
            throw new NotImplementedException();
        }

        public IList<INotifiableEvent> GetList()
        {
            throw new NotImplementedException();
        }

        public INotifiableEvent Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}