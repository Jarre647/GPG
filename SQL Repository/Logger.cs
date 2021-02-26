using System;
using NLog;

namespace SQL_Repository
{
    public static class Logger
    {
        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void ErrorHandling(Exception ex, string message = null)
        {
            _logger.Error(ex, message);
        }
    }
}