﻿namespace Repository.Contracts
{
    /// <summary>
    ///  ILoggerManager : Contains methods for different levels of logging.
    /// </summary>
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
