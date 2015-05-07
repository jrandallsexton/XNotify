
using System;

using XNotify.Common;

namespace XNotify.Loggers
{
    public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly string Source;
        public readonly Exception Exception;

        public LogEntry(LoggingEventType severity, string message, string source,
            Exception exception)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("message");
            if (severity < LoggingEventType.Debug || severity > LoggingEventType.Fatal)
                throw new ArgumentOutOfRangeException("severity");

            this.Severity = severity;
            this.Message = message;
            this.Source = source;
            this.Exception = exception;
        }
    }
}