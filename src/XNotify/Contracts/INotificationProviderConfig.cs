using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Contracts
{
    public interface INotificationProviderConfig
    {
        string Username { get; set; }
        string Password { get; set; }
        string AccountName { get; set; }
        string AccountSid { get; set; }
        string AuthToken { get; set; }
        string Server { get; set; }
        string Port { get; set; }
        string Protocol { get; set; }
        bool Ssl { get; set; }
    }
}