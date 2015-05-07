
using System.Collections.Generic;

namespace XNotify.Contracts
{
    public interface INotificationQueue<T> where T: INotifiableEvent
    {
        void Add(T item);
        void Remove(T item);
        IList<T> GetList();
        T Get(int id);
    }
}