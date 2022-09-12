using NLog;
using Repository.Contracts;

namespace LoggerService
{
    /// <summary>
    /// Packages: NLog.Extensions.Logging version 5.0.4 
    /// Implements ILoggerMananger methods.
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager()
        {

        }
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
    }
}
