using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    public interface INotificationProvidersConfigurationCollection
    {
        bool IsReadOnly();
        bool Equals(object compareTo);
        int GetHashCode();
        void CopyTo(ConfigurationElement[] array, int index);
        IEnumerator GetEnumerator();
        int Count { get; }
        bool EmitClear { get; set; }
        bool IsSynchronized { get; }
        object SyncRoot { get; }
        ConfigurationElementCollectionType CollectionType { get; }
        ConfigurationLockCollection LockAttributes { get; }
        ConfigurationLockCollection LockAllAttributesExcept { get; }
        ConfigurationLockCollection LockElements { get; }
        ConfigurationLockCollection LockAllElementsExcept { get; }
        bool LockItem { get; set; }
        ElementInformation ElementInformation { get; }
        Configuration CurrentConfiguration { get; }
    }

    [ConfigurationCollection(typeof(NotificationProviderElement))]
    public class NotificationProvidersCollection : ConfigurationElementCollection, INotificationProvidersConfigurationCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new NotificationProviderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NotificationProviderElement)element).Name;
        }
    }
}