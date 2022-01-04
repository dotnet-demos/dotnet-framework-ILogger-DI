using Microsoft.Extensions.Logging;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class CircleAreaCalculator : ICircleAreaCalculator
    {
        IPiValueProvider piValueProvider;
        ILogger<CircleAreaCalculator> logger;
        public CircleAreaCalculator(ILogger<CircleAreaCalculator> logger, IPiValueProvider piValueProvider)
        {
            this.piValueProvider = piValueProvider;
            this.logger = logger;
        }
        double ICircleAreaCalculator.Area(double radius)
        {
            var area = piValueProvider.Get() * radius * radius;
            logger.LogInformation($"{nameof(ICircleAreaCalculator.Area)} - Returning area of circle with radius {radius} = {area}");
            return area;
        }
    }
}