using Restaurant.Services.Settings;

namespace Restaurant.Services.Loggers
{
    public interface ILoggingService
    {
        Task LogOnCreate(string tableName);

        Task LogOnUpdate(string tableName);
    }
}
