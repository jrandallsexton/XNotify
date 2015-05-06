
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Timers;

using XNotify.Common;
using XNotify.Config;
using XNotify.Contracts;
using XNotify.Loggers;

namespace XNotify.Services
{
    public class NotificationService : INotificationService
    {

        private Timer _timer = null;
        private bool _enabled = true;
        private List<int> _processed = null; 

        public string Name { get; set; }

        public string Description { get; set; }

        private IXNotifyConfigSection Configuration { get; set; }

        public INotificationPersistence Persistence { get; set; }

        public INotificationProcessor Processor { get; set; }

        public INotificationQueue<INotifiableEvent> Queue { get; set; }

        public IList<INotifiableEventProvider<INotifiableEvent>> EventProviders { get; set; }

        public IList<INotificationProvider> NotificationProviders { get; set; }

        public INotificationMonitor Monitor { get; set; }

        public INotificationLogger Logger { get; set; }

        public IList NotificationSourceProviders { get; set; }

        public NotificationService(string name, string description)
        {
            this._processed = new List<int>();
            this._timer = new Timer();
            this.Logger= new NotificationLogger();
            this.Configuration = XNotifyConfigSection.GetSection();
            this.Name = name;
            this.Description = description;
        }

        public NotificationService(string name, string description, IList<INotificationProvider> notificationProviders)
        {
            this._timer = new Timer();
            this.Logger = new NotificationLogger();
            this.Configuration = XNotifyConfigSection.GetSection();
            this.Name = name;
            this.Description = description;
            this.NotificationProviders = notificationProviders;
        }

        public void Start()
        {
            this.Logger.Log(string.Format("XNotify started {0}", Configuration.Name));
            this.NotificationProviders = LoadNotificationProviders(Configuration.NotificationProvidersPath, Configuration.NotificationProviders);
            this.EventProviders = LoadEventProviders(Configuration.EventProvidersPath, Configuration.EventProviders);

            this._timer.Interval = 5000;
            this._timer.Elapsed += _timer_Elapsed;
            this._timer.Start();

            while (_enabled) { }
            
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MonitorEventProviders(this.EventProviders, this.NotificationProviders);
        }

        private void MonitorEventProviders(IEnumerable<INotifiableEventProvider<INotifiableEvent>> eventProviders,
            IEnumerable<INotificationProvider> notificationProviders)
        {
            eventProviders.ToList().ForEach(p =>
            {
                // Find all events that are due within the next 60 seconds
                var cutOffTime = DateTime.UtcNow.AddMinutes(-1);

                var items = p.GetAll().ToList().FindAll(notEvnt => notEvnt.UtcDue >= cutOffTime && !_processed.Contains(notEvnt.Id));

                items.ForEach(x =>
                {

                    Logger.Log(string.Format("Item due: {0}", x.Name));

                    notificationProviders.ToList().ForEach(z =>
                    {
                        if (x.Targets == null) { return; }

                        x.Targets.ToList().ForEach(t =>
                        {
                            switch (z.ProviderType)
                            {
                                case ENotificationProviderType.Email:
                                    if (t.SendEmail)
                                        z.Send(t.Email, x.Subject, x.Message);
                                    break;
                                case ENotificationProviderType.Sms:
                                    if (t.SendSms)
                                        z.Send(t.Sms, x.Message);
                                    break;
                            }
                        });

                    });

                    _processed.Add(x.Id);

                });

            });
        }

        public void Stop()
        {
            Logger.Log(string.Format("XNotify stopped {0}", Configuration.Name));
        }

        /// <summary>
        /// Using Reflection, XNotify will load all configured external event source providers
        /// </summary>
        /// <param name="assemblyPath">root path of all dll locations</param>
        /// <param name="eventProviders">collection of configuration entries</param>
        /// <returns></returns>
        private List<INotifiableEventProvider<INotifiableEvent>> LoadEventProviders(string assemblyPath,
            IEventProvidersConfigurationCollection eventProviders)
        {
            var providers = new List<INotifiableEventProvider<INotifiableEvent>>();

            foreach (IEventProviderElement element in eventProviders)
            {

                if (!element.Enabled)
                {
                    Logger.Log(string.Format("Skipped loading for disabled Event Provider: {0}", element.Class));
                    continue;
                }

                var assemblyLocation = Path.Combine(assemblyPath, element.AssemblyFolder);
                var eventProviderAssembly = Assembly.LoadFile(Path.Combine(assemblyLocation, element.AssemblyName));
                var eventProviderInstance = (INotifiableEventProvider<INotifiableEvent>)eventProviderAssembly.CreateInstance(element.Class);

                providers.Add(eventProviderInstance);
            }

            return providers;
        }

        private List<INotificationProvider> LoadNotificationProviders(string assemblyPath,
            INotificationProvidersConfigurationCollection notificationProviders)
        {
            var providers = new List<INotificationProvider>();

            foreach (INotificationProviderElement element in notificationProviders)
            {
                if (!element.Enabled)
                {
                    Logger.Log(string.Format("Skipped loading for disabled Notification Provider: {0}", element.Class));
                    continue; 
                }

                var assemblyLocation = Path.Combine(assemblyPath, element.AssemblyFolder);
                var notificationProviderAssembly = Assembly.LoadFile(Path.Combine(assemblyLocation, element.AssemblyName));

                //foreach (AssemblyName an in notificationProviderAssembly.GetReferencedAssemblies())
                //{
                //    var log = string.Format("Name={0}, Version={1}, Culture={2}, PublicKey token={3}", an.Name,
                //        an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
                //    Logger.Log(log);
                //}

                var notificationProviderInstance = (INotificationProvider)notificationProviderAssembly.CreateInstance(element.Class);

                if (notificationProviderInstance == null) continue;

                notificationProviderInstance.Config = new NotificationProviderConfig(element);

                providers.Add(notificationProviderInstance);
            }

            return providers;
        }

    }

}