using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Contracts
{
    public interface INotificationTarget
    {
        string Name { get; set; }
        string Email { get; set; }
        string Sms { get; set; }
        bool SendEmail { get; set; }
        bool SendSms { get; set; }
    }
}