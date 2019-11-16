using Microsoft.Extensions.Logging;

namespace MicroKnights.Log4NetHelper.Provider
{
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            throw new System.NotImplementedException();
        }

        public void AddProvider(ILoggerProvider provider)
        {
            throw new System.NotImplementedException();
        }
    }
}