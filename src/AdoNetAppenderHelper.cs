using System;
using System.Linq;
using System.Reflection;
using log4net;
using log4net.Repository;
using MicroKnights.Logging;

namespace MicroKnights.Log4NetHelper
{
    public static class AdoNetAppenderHelper
    {
        public static int SetConnectionString(Assembly repositoryAssembly, string connectionString)
        {
            var logRepository = LogManager.GetRepository(repositoryAssembly);
            return SetConnectionString(logRepository, connectionString);
        }

        public static int SetConnectionString(ILoggerRepository loggerRepository, string connectionString)
        {
            var adoNetAppenders = loggerRepository.GetAppenders()
                .Where(a => a is AdoNetAppender).Cast<AdoNetAppender>();

            int foundRepositories = 0;
            foreach (var appender in adoNetAppenders)
            {
                appender.ConnectionString = connectionString;
                appender.ActivateOptions();
                foundRepositories += 1;
            }

            return foundRepositories;
        }

        public static int SetConnectionString(string connectionString)
        {
            int foundRepositories = 0;
            foreach (var loggerRepository in LogManager.GetAllRepositories())
            {
                foundRepositories += SetConnectionString(loggerRepository, connectionString);
            }

            return foundRepositories;
        }
    }
}