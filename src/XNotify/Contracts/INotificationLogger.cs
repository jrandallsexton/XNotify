
using XNotify.Loggers;

namespace XNotify.Contracts
{
    public interface INotificationLogger
    {
        void Log(string message);
        void Log(LogEntry exception);
    }
}