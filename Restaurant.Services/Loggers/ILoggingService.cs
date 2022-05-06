using Restaurant.Services.Settings;

namespace Restaurant.Services.Loggers
{
    public interface ILoggingService
    {
        Task LogMessage(string message, string tableName, LogOperationType operationType);
    }
}
