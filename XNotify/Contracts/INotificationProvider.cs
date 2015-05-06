using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Contracts
{
    public interface INotificationProvider
    {
        INotificationProviderConfig Config { get; set; }
        void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message);
        void Send(IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string message, Action<string> callback);
    }
}