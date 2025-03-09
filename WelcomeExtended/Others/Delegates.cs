using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Others
{
    internal class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("HashLogger");
        public static readonly ILogger loggerFile = LoggerHelper.GetLogger("FileLogger");
        public static readonly ILogger loggerDatabase = LoggerHelper.GetLogger("DatabaseLogger");

        public static void Log(string error)
        {
            logger.LogError(error);
        }

        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }

        public static void LogFile(string message)
        {
            loggerFile.LogInformation(message);
            loggerDatabase.LogInformation(message);
        }
    }

}
