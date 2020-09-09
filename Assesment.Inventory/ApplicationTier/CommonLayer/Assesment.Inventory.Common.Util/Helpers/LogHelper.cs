using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Common.Util.Helpers
{
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
