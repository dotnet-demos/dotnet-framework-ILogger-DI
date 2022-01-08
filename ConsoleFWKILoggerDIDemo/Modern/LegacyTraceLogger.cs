using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class LegacyTraceLogger : ILogger
    {
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
                    var n = Environment.NewLine;
                    string exc = "";
                    if (exception != null) exc = exception.GetType() + ": " + exception.Message + n + exception.StackTrace + n;
                    MyTracer.WriteLine( logLevel.ToString() + ": " + DateTime.Now.ToString() + " " + formatter(state, exception) + n + exc);
                }
            }
        }
    }
}