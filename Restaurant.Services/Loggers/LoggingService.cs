using Restaurant.Data;
using Restaurant.Data.Entities.Logs;
using Restaurant.Services.Settings;

namespace Restaurant.Services.Loggers
{
    public class LoggingService : ILoggingService
    {
        private readonly RestaurantDbContext _context;

        public LoggingService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task LogOnCreate(string tableName)
        {
            await LogMessage(tableName, LogOperationType.Create);
        }

        public async Task LogOnUpdate(string tableName)
        {
            await LogMessage(tableName, LogOperationType.Update);
        }

        private async Task LogMessage(string tableName, LogOperationType operationType)
        {
            Log log = new Log()
            {
                DateAndTimeOfOperation = DateTime.Now,
                TableName = tableName,
                TypeOfOperation = Enum.GetName(operationType)
            };

            await _context.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
