using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    internal class LoggerProvider : ILoggerProvider
    {
        ILogger ILoggerProvider.CreateLogger(string categoryName)
        {
            switch(categoryName)
            {
                case "HashLogger":
                    return new HashLogger(categoryName);
                case "FileLogger":
                    return new FileLogger(categoryName);
                case "DatabaseLogger":
                    return new DatabaseLogger(categoryName);
                default:
                    return new HashLogger(categoryName);
            }
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
