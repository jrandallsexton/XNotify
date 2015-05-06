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

        [ConfigurationProperty("assemblyName", IsRequired = true)]
        string AssemblyName { get; set; }

        [ConfigurationProperty("assemblyFolder", IsRequired = true)]
        string AssemblyFolder { get; set; }

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

        [ConfigurationProperty("token", IsRequired = false)]
        string Token { get; set; }

        [ConfigurationProperty("server", IsRequired = false)]
        string Server { get; set; }

        [ConfigurationProperty("port", IsRequired = false)]
        string Port { get; set; }

        [ConfigurationProperty("protocol", IsRequired = false)]
        string Protocol { get; set; }

        [ConfigurationProperty("ssl", IsRequired = true)]
        bool Ssl { get; set; }

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

        [ConfigurationProperty("token", IsRequired = false)]
        public string Token
        {
            get { return (string)this["token"]; }
            set { this["token"] = value; }
        }

        [ConfigurationProperty("server", IsRequired = false)]
        public string Server
        {
            get { return (string)this["server"]; }
            set { this["server"] = value; }
        }

        [ConfigurationProperty("port", IsRequired = false)]
        public string Port
        {
            get { return (string)this["port"]; }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("protocol", IsRequired = false)]
        public string Protocol
        {
            get { return (string)this["protocol"]; }
            set { this["protocol"] = value; }
        }

        [ConfigurationProperty("ssl", IsRequired = true)]
        public bool Ssl
        {
            get { return (bool)this["ssl"]; }
            set { this["ssl"] = value; }
        }

    }
}