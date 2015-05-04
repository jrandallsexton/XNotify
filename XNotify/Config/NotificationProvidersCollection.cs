using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Config
{
    [ConfigurationCollection(typeof(NotificationProviderElement))]
    public class NotificationProvidersCollection : ConfigurationElementCollection
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