using System;
using System.Diagnostics;

namespace WebAPIFWKILoggerDIDemo
{
    class MyTracer
    {
        public static void WriteLine(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
            Trace.WriteLine(message);
        }
    }
}