﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNotify.Contracts;

namespace XNotify.Loggers
{
    public class NotificationLogger : INotificationLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(LogEntry exception)
        {
            throw new NotImplementedException();
        }
    }
}
