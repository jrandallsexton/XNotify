
using System;
using System.Linq;
using System.ServiceProcess;

using XNotify.Config;
using XNotify.Contracts;
using XNotify.Services;

namespace XNotify.Service
{

    public partial class XNotifyServiceHost : ServiceBase
    {

        private INotificationService _service;

        public XNotifyServiceHost()
        {
            InitializeComponent();
            var config = XNotifyConfigSection.GetSection();
            _service = new NotificationService(config.Name, config.Description);
        }

        public void Startup()
        {
            _service.Start();
            Console.ReadKey();
            _service.Stop();
        }

        protected override void OnStart(string[] args)
        {
            _service.Start();
        }

        protected override void OnStop()
        {
            _service.Stop();
        }

    }

}