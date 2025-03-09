using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer.Database;

namespace WelcomeExtended.Loggers
{
    internal class DatabaseLogger : ILogger
    {
        private readonly string _name;

        public DatabaseLogger(string name)
        {
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);

            Console.WriteLine($"[{logLevel}] {message}");

            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DataLayer.Model.DatabaseLogger>(new DataLayer.Model.DatabaseLogger()
                {
                    Message = message,
                    Date = DateTime.Now
                });
                context.SaveChanges();
            }
        }
    }
}
