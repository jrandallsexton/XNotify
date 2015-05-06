using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    public interface IEventProvidersConfigurationCollection
    {
        EventProviderElement this[int index] { get; set; }
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
        bool IsReadOnly();
        bool Equals(object compareTo);
        int GetHashCode();
        void CopyTo(ConfigurationElement[] array, int index);
        IEnumerator GetEnumerator();
    }

    [ConfigurationCollection(typeof(EventProviderElement))]
    public class EventProvidersCollection : ConfigurationElementCollection, IEventProvidersConfigurationCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new EventProviderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EventProviderElement)element).Name;
        }

        public EventProviderElement this[int index]
        {
            get
            {
                return (EventProviderElement)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
    }
}