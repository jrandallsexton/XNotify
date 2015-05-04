
using System.Configuration;

namespace XNotify.Config
{
    public interface IXNotifyConfigSection
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        string Name { get; set; }

        [ConfigurationProperty("description", IsRequired = true, IsKey = false)]
        string Description { get; set; }

        [ConfigurationProperty("version", IsRequired = true, IsKey = false)]
        string Version { get; set; }

        [ConfigurationProperty("eventProvidersPath", IsRequired = true, IsKey = false)]
        string EventProvidersPath { get; set; }

        [ConfigurationProperty("notificationProvidersPath", IsRequired = true, IsKey = false)]
        string NotificationProvidersPath { get; set; }

        [ConfigurationProperty("EventProviders", IsRequired = true, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof (EventProvidersCollection), AddItemName = "EventProvider", ClearItemsName = "clear", RemoveItemName = "remove", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        EventProvidersCollection EventProviders { get; set; }

        [ConfigurationProperty("NotificationProviders", IsRequired = true, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof (NotificationProvidersCollection), AddItemName = "NotificationProvider", ClearItemsName = "clear", RemoveItemName = "remove", CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        NotificationProvidersCollection NotificationProviders { get; set; }

        SectionInformation SectionInformation { get; }
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
    }

    public class XNotifyConfigSection : ConfigurationSection, IXNotifyConfigSection
    {
        public static XNotifyConfigSection GetSection()
        {
            var section = ConfigurationManager.GetSection("XNotify") as XNotifyConfigSection;
            if (section == null)
                throw new ConfigurationErrorsException("The <XNotify> configuration section is not defined.");
            return section;
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("description", IsRequired = true, IsKey = false)]
        public string Description
        {
            get { return (string)this["description"]; }
            set { this["description"] = value; }
        }

        [ConfigurationProperty("version", IsRequired = true, IsKey = false)]
        public string Version
        {
            get { return (string)this["version"]; }
            set { this["version"] = value; }
        }

        [ConfigurationProperty("eventProvidersPath", IsRequired = true, IsKey = false)]
        public string EventProvidersPath
        {
            get { return (string)this["eventProvidersPath"]; }
            set { this["eventProvidersPath"] = value; }
        }

        [ConfigurationProperty("notificationProvidersPath", IsRequired = true, IsKey = false)]
        public string NotificationProvidersPath
        {
            get { return (string)this["notificationProvidersPath"]; }
            set { this["notificationProvidersPath"] = value; }
        }

        [ConfigurationProperty("EventProviders", IsRequired = true, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(EventProvidersCollection),
            AddItemName = "EventProvider",
            ClearItemsName = "clear",
            RemoveItemName = "remove",
            CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public EventProvidersCollection EventProviders
        {
            get { return (EventProvidersCollection)this["EventProviders"]; }
            set { this["EventProviders"] = value; }
        }

        [ConfigurationProperty("NotificationProviders", IsRequired = true, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(NotificationProvidersCollection),
            AddItemName = "NotificationProvider",
            ClearItemsName = "clear",
            RemoveItemName = "remove",
            CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public NotificationProvidersCollection NotificationProviders
        {
            get { return (NotificationProvidersCollection)this["NotificationProviders"]; }
            set { this["NotificationProviders"] = value; }
        }

    }
}