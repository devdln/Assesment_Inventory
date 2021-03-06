﻿using NLog;
using System;

namespace Assesment.Inventory.Common.Util.Helpers
{
    /// <summary>
    /// LogHelper class
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void LogInfo(string message)
        {
            Logger logger = LogManager.GetLogger("f");
            logger.Info(message);
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="message">The message.</param>
        public static void LogException(Exception ex, string message)
        {
            Logger logger = LogManager.GetLogger("ex");

            logger.Log(LogLevel.Fatal, message, ex);

            if (ex.InnerException != null)
            {
                LogException(ex.InnerException, ex.InnerException.Message);
            }
        }
    }
}
