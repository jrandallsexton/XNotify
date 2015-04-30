
using System;
using System.Collections.Generic;
using System.Linq;

using XNotify.Contracts;

namespace XNotify.Queues
{
    public sealed class NotificationQueue<T> : INotificationQueue<T> where T : INotifiableEvent
    {
        private Queue<T> _queue;
        private static readonly NotificationQueue<T> _instance = new NotificationQueue<T>();

        public static NotificationQueue<T> Instance
        {
            get { return _instance; }
        }

        public void Add(T item)
        {
            _queue.Enqueue(item);
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetList()
        {
            return _queue.ToList();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}