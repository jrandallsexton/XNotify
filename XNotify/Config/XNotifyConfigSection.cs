
using System.Configuration;

namespace XNotify.Config
{
    public class XNotifyConfigSection : ConfigurationSection
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

        [ConfigurationProperty("description", IsRequired = true, IsKey = true)]
        public string Description
        {
            get { return (string)this["description"]; }
            set { this["description"] = value; }
        }

        [ConfigurationProperty("version", IsRequired = true, IsKey = true)]
        public string Version
        {
            get { return (string)this["version"]; }
            set { this["version"] = value; }
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