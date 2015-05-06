﻿
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
        T Get(int id);
        string GetMessage(int id);
        void Unsubscribe(int recipientId, int notificationProviderId);
        void MarkProcessed(int eventId, IEnumerable<int> recipientIds);
    }
}