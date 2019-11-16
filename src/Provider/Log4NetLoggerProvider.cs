using System.Linq;
using log4net;
using log4net.Repository;
using Microsoft.Extensions.Logging;

namespace MicroKnights.Log4NetHelper.Provider
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly ILoggerRepository _loggerRepository;
        public Log4NetLoggerProvider()
        {
            _loggerRepository = LogManager.GetAllRepositories().FirstOrDefault();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Log4NetLogger(_loggerRepository.GetLogger(categoryName));
        }

        public void Dispose()
        {
        }
    }
}