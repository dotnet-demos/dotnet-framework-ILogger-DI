using Microsoft.Extensions.Logging;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class HardCodedPiValueProvider : IPiValueProvider
    {
        ILogger<HardCodedPiValueProvider> logger;
        public HardCodedPiValueProvider(ILogger<HardCodedPiValueProvider> logger)
        {
            this.logger = logger;   
        }
        double IPiValueProvider.Get()
        {
            logger.LogTrace($"{nameof(IPiValueProvider.Get)} - Returing value of pi = 3.14");
            return 3.14;
        }
    }
}