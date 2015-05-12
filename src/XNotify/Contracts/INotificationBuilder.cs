using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNotify.Contracts
{
    public interface INotificationBuilder
    {
        string Build(string raw);
    }
}