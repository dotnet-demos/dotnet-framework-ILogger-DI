using EasyConsole;
using System;
using System.Diagnostics;
namespace ConsoleFWKILoggerDIDemo
{
    class SumOption
    {
        internal void Execute()
        {
            int n1 = Input.ReadInt("Number 1:", 0, 100);
            int n2 = Input.ReadInt("Number 2:", 0, 100);
            MyTracer.WriteLine($"Sum :{n1 + n2}");
        }
    }
}