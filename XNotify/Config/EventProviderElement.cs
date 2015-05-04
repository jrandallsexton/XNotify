using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    public class EventProviderElement : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
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