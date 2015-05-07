using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    public interface IEventProviderElement
    {

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        string Name { get; set; }

        [ConfigurationProperty("assemblyName", IsRequired = true)]
        string AssemblyName { get; set; }

        [ConfigurationProperty("assemblyFolder", IsRequired = true)]
        string AssemblyFolder { get; set; }

        [ConfigurationProperty("class", IsRequired = true)]
        string Class { get; set; }

        [ConfigurationProperty("monitorInterval", IsRequired = true)]
        int MonitorInterval { get; set; }

        [ConfigurationProperty("enabled", IsRequired = true)]
        bool Enabled { get; set; }

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

    public class EventProviderElement : ConfigurationElement, IEventProviderElement
    {

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("assemblyName", IsRequired = true)]
        public string AssemblyName
        {
            get { return (string)this["assemblyName"]; }
            set { this["assemblyName"] = value; }
        }

        [ConfigurationProperty("assemblyFolder", IsRequired = true)]
        public string AssemblyFolder
        {
            get { return (string)this["assemblyFolder"]; }
            set { this["assemblyFolder"] = value; }
        }

        [ConfigurationProperty("class", IsRequired = true)]
        public string Class
        {
            get { return (string)this["class"]; }
            set { this["class"] = value; }
        }

        [ConfigurationProperty("monitorInterval", IsRequired = true)]
        public int MonitorInterval
        {
            get { return (int)this["monitorInterval"]; }
            set { this["monitorInterval"] = value; }
        }

        [ConfigurationProperty("enabled", IsRequired = true)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

    }
}