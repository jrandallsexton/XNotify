using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Tests.Fakes
{
    public class FakeNotificationTarget : INotificationTarget
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Sms { get; set; }
        public bool SendEmail { get; set; }
        public bool SendSms { get; set; }
    }
}