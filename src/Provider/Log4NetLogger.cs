using System;
using log4net.Core;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MicroKnights.Log4NetHelper.Provider
{
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.Core.ILogger _log4NetLogger;

        public Log4NetLogger(log4net.Core.ILogger log4netLogger)
        {
            _log4NetLogger = log4netLogger;
        }

        private class Scope : IDisposable
        {
            public Scope(Log4NetLogger logger)
            {
            }

            public void Dispose()
            {
               
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _log4NetLogger.Log(null,TranslateLogLevel(logLevel),formatter(state,exception),exception);
        }

        protected virtual Level TranslateLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace: return Level.Trace;
                case LogLevel.Debug: return Level.Debug;
                case LogLevel.Information: return Level.Info;
                case LogLevel.Warning: return Level.Warn;
                case LogLevel.Error: return Level.Error;
                case LogLevel.Critical: return Level.Critical;
                case LogLevel.None: return Level.Off;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _log4NetLogger.IsEnabledFor(TranslateLogLevel(logLevel));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new Scope(this);
        }
    }
}