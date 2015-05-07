
using System;

using XNotify.Common;
using XNotify.Contracts;

namespace XNotify.Loggers
{

    /// <summary>
    /// Stolen from: http://stackoverflow.com/questions/5646820/logger-wrapper-best-practice
    /// </summary>
    public static class LoggerExtensions
    {
        public static void Log(this INotificationLogger logger, string message)
        {
            logger.Log(new LogEntry(LoggingEventType.Info, message, null, null));
        }

        public static void Log(this INotificationLogger logger, Exception exception)
        {
            logger.Log(new LogEntry(LoggingEventType.Error, exception.Message, null, exception));
        }

        // More methods here.
    }
}