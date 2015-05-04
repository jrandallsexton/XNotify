using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    public interface INotificationProviderElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        string Name { get; }

        [ConfigurationProperty("class", IsRequired = true)]
        string Class { get; set; }

        [ConfigurationProperty("type", IsRequired = true)]
        string Type { get; set; }

        [ConfigurationProperty("enabled", IsRequired = true)]
        bool Enabled { get; set; }

        [ConfigurationProperty("username", IsRequired = true)]
        string Username { get; set; }

        [ConfigurationProperty("password", IsRequired = true)]
        string Password { get; set; }

        [ConfigurationProperty("sid", IsRequired = false)]
        string Sid { get; set; }

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

    public class NotificationProviderElement : ConfigurationElement, INotificationProviderElement
    {

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }

        [ConfigurationProperty("class", IsRequired = true)]
        public string Class
        {
            get { return (string)this["class"]; }
            set { this["class"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("enabled", IsRequired = true)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("sid", IsRequired = false)]
        public string Sid
        {
            get { return (string)this["sid"]; }
            set { this["sid"] = value; }
        }
    }
}