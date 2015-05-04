using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    [ConfigurationCollection(typeof(EventProviderElement))]
    public class EventProvidersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EventProviderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EventProviderElement)element).Name;
        }
    }
}