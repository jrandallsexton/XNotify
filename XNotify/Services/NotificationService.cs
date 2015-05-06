
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Timers;

using XNotify.Config;
using XNotify.Contracts;
using XNotify.Loggers;
using XNotify.Providers;

namespace XNotify.Services
{
    public class NotificationService : INotificationService
    {

        private Timer _timer = null;
        private bool _enabled = true;

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
            this.NotificationProviders = LoadNotificationProviders(Configuration.NotificationProviders);
            this.EventProviders = LoadEventProviders(Configuration.EventProvidersPath, Configuration.EventProviders);

            this._timer.Interval = 5000;
            this._timer.Elapsed += _timer_Elapsed;
            this._timer.Start();

            while (_enabled) { }
            
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MonitorEventProviders(this.EventProviders);
        }

        private void MonitorEventProviders(IEnumerable<INotifiableEventProvider<INotifiableEvent>> providers)
        {
            providers.ToList().ForEach(p =>
            {
                //p.GetAll().ToList().ForEach(x => Console.WriteLine("{0}: {1}\t{2}\t{3}", p.Name, x.UtcDue, x.Name, x.Description));
                // Find all events that are due within the next 60 seconds
                var cutOffTime = DateTime.UtcNow.AddMinutes(-1);
                var items = p.GetAll().ToList().FindAll(notifiableEvent => notifiableEvent.UtcDue >= cutOffTime);
                items.ForEach(x => NotificationProviders.ToList().ForEach(z =>
                {
                    Console.WriteLine("Item due: {0}", x.Name);
                    var tos = new List<string>();
                    var ccs = new List<string>();
                    var bccs = new List<string>();
                    z.Send(tos, ccs, bccs, "Test Subject", "Test Message");
                }));
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
        private List<INotifiableEventProvider<INotifiableEvent>> LoadEventProviders(string assemblyPath, IEventProvidersCollection eventProviders)
        {
            var providers = new List<INotifiableEventProvider<INotifiableEvent>>();

            foreach (IEventProviderElement element in eventProviders)
            {

                if (!element.Enabled)
                {
                    Logger.Log(string.Format("Skipped loading for disabled Event Provider: {0}", element.Class));
                    continue;
                }

                var eventProviderAssembly = Assembly.LoadFile(Path.Combine(assemblyPath, element.AssemblyName));
                var eventProviderInstance = (INotifiableEventProvider<INotifiableEvent>)eventProviderAssembly.CreateInstance(element.Class);

                providers.Add(eventProviderInstance);
            }

            return providers;
        }

        private List<INotificationProvider> LoadNotificationProviders(INotificationProvidersCollection notificationProviders)
        {
            var providers = new List<INotificationProvider>
            {
                new SmtpNotificationProvider(),
                new SmsNotificationProvider()
            };

            return providers;
        }

    }

}