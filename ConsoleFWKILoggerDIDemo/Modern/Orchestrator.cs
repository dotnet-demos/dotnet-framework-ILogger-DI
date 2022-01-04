using EasyConsole;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class Orchestrator : IOrchestrator
    {
        ICircleAreaCalculator circleAreaCalculator;
        ILogger<Orchestrator> logger;
        public Orchestrator(ICircleAreaCalculator circleAreaCalculator,ILogger<Orchestrator> logger)
        {
            this.circleAreaCalculator = circleAreaCalculator;
            this.logger = logger;
        }
        void IOrchestrator.Run()
        {
            int n1 = Input.ReadInt("Radius :", 0, 100);
            Console.WriteLine($"Sum : {circleAreaCalculator.Area(n1)}");
        }
    }
}