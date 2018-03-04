using log4net.Util;

namespace MicroKnights.Log4NetHelper
{
    public static class InternalDebugHelper
    {
        public static void EnableInternalDebug(LogReceivedEventHandler eventHandler)
        {
            LogLog.InternalDebugging = true;
            LogLog.LogReceived += eventHandler;
        }

        public static void DisableInternalDebug(LogReceivedEventHandler eventHandler)
        {
            LogLog.InternalDebugging = false;
            LogLog.LogReceived -= eventHandler;
        }
    }
}