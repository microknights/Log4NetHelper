using System;
using System.Linq;
using log4net;
using log4net.Core;
using log4net.Util;
using MicroKnights.Logging;

namespace MicroKnights.Log4NetHelper
{
    public static class InternalDebugHelper
    {
        private class ErrorHandler : IErrorHandler
        {
            private readonly LogReceivedEventHandler _eventHandler;

            public ErrorHandler(LogReceivedEventHandler eventHandler)
            {
                _eventHandler = eventHandler;
            }

            public void Error(string message, Exception e, ErrorCode errorCode)
            {
                _eventHandler.Invoke(this, new LogReceivedEventArgs(new LogLog(GetType(), "", $"{errorCode}: {message}", e)));
            }

            public void Error(string message, Exception e)
            {
                _eventHandler.Invoke(this, new LogReceivedEventArgs(new LogLog(GetType(), "", message, e)));
            }

            public void Error(string message)
            {
                _eventHandler.Invoke(this, new LogReceivedEventArgs(new LogLog(GetType(), "", message, null)));
            }
        }


        public static void EnableInternalDebug(LogReceivedEventHandler eventHandler)
        {
            LogLog.InternalDebugging = true;
            LogLog.LogReceived += eventHandler;

            var errorHandler = new ErrorHandler(eventHandler);
            var adoNetAppenders = LogManager.GetAllRepositories().SelectMany(e=>e.GetAppenders())
                .Where(a => a is AdoNetAppender).Cast<AdoNetAppender>();

            foreach (var appender in adoNetAppenders)
            {
                appender.ErrorHandler = errorHandler;
            }
        }

        public static void DisableInternalDebug(LogReceivedEventHandler eventHandler)
        {
            LogLog.InternalDebugging = false;
            LogLog.LogReceived -= eventHandler;

            var adoNetAppenders = LogManager.GetAllRepositories().SelectMany(e => e.GetAppenders())
                .Where(a => a is AdoNetAppender).Cast<AdoNetAppender>();

            foreach (var appender in adoNetAppenders)
            {
                appender.ErrorHandler = null;
            }
        }
    }
}