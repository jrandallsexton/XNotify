
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

        public INotificationPersistence<INotifiableEvent> Persistence { get; set; }

        public INotificationQueue<INotifiableEvent> Queue { get; set; }

        public IList<INotifiableEventProvider<INotifiableEvent>> EventProviders { get; set; }

        public IList<INotificationProvider> NotificationProviders { get; set; }

        public INotificationLogger Logger { get; set; }

        public NotificationService()
        {
            this._processed = new List<int>();
            this._timer = new Timer();
            this.Logger = new MongoDbLogger();
            this.Configuration = XNotifyConfigSection.GetSection();
            this.Name = Configuration.Name;
            this.Description = Configuration.Description;
        }

        public void Start()
        {
            this.Logger.Log(string.Format("XNotify started {0}", Configuration.Name));
            this.EventProviders = LoadEventProviders(Configuration.EventProvidersPath, Configuration.EventProviders);
            this.NotificationProviders = LoadNotificationProviders(Configuration.NotificationProvidersPath, Configuration.NotificationProviders);

            this._timer.Interval = 5000;
            this._timer.Elapsed += _timer_Elapsed;
            this._timer.Start();

            while (_enabled) { }
            
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MonitorEventProviders(this.EventProviders, this.NotificationProviders);
            MonitorNotificationProviderResponses(this.NotificationProviders);
        }

        private void MonitorNotificationProviderResponses(IEnumerable<INotificationProvider> notificationProviders)
        {
            notificationProviders.ToList().ForEach(p => {
                var responses = p.Receive();
                // if we have any responses ...
                responses.ToList().ForEach(r => {
                    if (r.Message == "REMOVE")
                    {
                        Logger.Log(r.ToString());
                    }
                });
                // ... we need to see if they were UNSUBSCRIBE requests (i.e. STOP, REMOVE, UNSUBSCRIBE)
                // if they were, we need to determine if they were of type "ALL"
                // STOP ALL != STOP
                // STOP -> no more notifications for this particular event
                // STOP ALL --> no more notification for this specific channel
            });
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
                                case NotificationProviderType.Email:
                                    if (t.SendEmail)
                                        z.Send(t.Email, x.Subject, x.Message);
                                    break;
                                case NotificationProviderType.Sms:
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
            _enabled = false;
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

                Logger.Log(string.Format("Dynamically loaded INotifiableEventProvider: {0}", element.AssemblyName));

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

                var notificationProviderInstance =
                    (INotificationProvider) notificationProviderAssembly.CreateInstance(element.Class);

                if (notificationProviderInstance == null) continue;

                notificationProviderInstance.Config = new NotificationProviderConfig(element);

                providers.Add(notificationProviderInstance);

                Logger.Log(string.Format("Dynamically loaded INotificationProvider: {0}", element.AssemblyName));
            }

            return providers;
        }

    }

}