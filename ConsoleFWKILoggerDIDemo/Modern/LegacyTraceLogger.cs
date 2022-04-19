using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class LegacyTraceLogger : ILogger
    {
        string category;
        readonly string newLine = Environment.NewLine;
        public LegacyTraceLogger(string categoryName)
        {
            this.category = categoryName;
        }
        private static object _lock = new object();
        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            return null;
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    string exc = "";
                    if (exception != null)
                    {
                        exc = $"{exception.GetType()}:{exception.Message}{newLine} {exception.StackTrace}";
                    }
                    MyTracer.WriteLine($"{logLevel}:{category}:{formatter(state, exception)} {newLine}  {exc}");
                }
            }
        }
    }
}