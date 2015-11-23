
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

        private readonly INotificationService _service;

        public XNotifyServiceHost()
        {
            InitializeComponent();
            _service = new NotificationService();
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