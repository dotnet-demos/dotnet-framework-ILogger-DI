using ConsoleFWKILoggerDIDemo.Modern;
using EasyConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFWKILoggerDIDemo
{
    class OptionsExecutor
    {
        internal void Execute()
        {
            Menu m = new Menu();
            m.Add("Find sum", () => { new SumOption().Execute(); });
            m.Add("Find area of circle", () => { new AreaOption().Execute(); });
            m.Add("Exit", () =>
            {
                Input.ReadString("Press any key to exit...");
                Environment.Exit(0);
            });
            while (true)
            {
                m.Display();
            }
        }
    }
}