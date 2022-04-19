using EasyConsole;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class AreaOptionOrchestrator : IOrchestrator
    {
        ICircleAreaCalculator circleAreaCalculator;
        ILogger<AreaOptionOrchestrator> logger;
        public AreaOptionOrchestrator(ICircleAreaCalculator circleAreaCalculator, ILogger<AreaOptionOrchestrator> logger)
        {
            this.circleAreaCalculator = circleAreaCalculator;
            this.logger = logger;
        }
        void IOrchestrator.Run()
        {
            try
            {
                string n1 = Input.ReadString("Radius :");
                Console.WriteLine($"Sum : {circleAreaCalculator.Area(int.Parse(n1))}");
            }
            catch (Exception ex) {
                logger.LogError( ex, "Error occurd.");
            }
        }
    }
}