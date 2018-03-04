using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using log4net.Repository;
using log4net.Util;

namespace MicroKnights.Log4NetHelper
{
    public static class ConfigurationHelper
    {
        public static IEnumerable<LogLog> ListConfigurationMessages(Assembly repositoryAssembly)
        {
            return ListConfigurationMessages(LogManager.GetRepository(repositoryAssembly));
        }

        public static IEnumerable<LogLog> ListConfigurationMessages(ILoggerRepository repositoryAssembly)
        {
            return repositoryAssembly.ConfigurationMessages.Cast<LogLog>();
        }

        public static IEnumerable<LogLog> ListConfigurationMessages()
        {
            foreach (var loggerRepository in LogManager.GetAllRepositories())
            {
                foreach (var log in loggerRepository.ConfigurationMessages.OfType<LogLog>())
                {
                    yield return log;
                }
            }
        }
    }
}