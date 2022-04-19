using System;
using System.Diagnostics;

namespace ConsoleFWKILoggerDIDemo
{
    class MyTracer
    {
        public static void WriteLine(string message)
        {
#if DEBUG
            Console.WriteLine($"{DateTime.Now}:{message}");
#endif
            Trace.WriteLine($"{DateTime.Now}:{message}");
        }
    }
}