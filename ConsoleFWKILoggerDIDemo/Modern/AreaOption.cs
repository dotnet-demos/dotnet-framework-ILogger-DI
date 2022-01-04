using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

namespace ConsoleFWKILoggerDIDemo.Modern
{
    class AreaOption
    {
        internal void Execute()
        {
            ServiceCollection services = new ServiceCollection();
            var provider = ConfigureServices(services);
            var orchestrator = provider.GetRequiredService<IOrchestrator>();
            orchestrator.Run();
        }
        private ServiceProvider ConfigureServices(ServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<IOrchestrator, Orchestrator>();
            serviceDescriptors.AddSingleton<ICircleAreaCalculator, CircleAreaCalculator>();
            serviceDescriptors.AddSingleton<IPiValueProvider, HardCodedPiValueProvider>();
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            serviceDescriptors.AddLogging((configure) =>
            {
                configure.AddConfiguration(config.GetSection("Logging"));
                configure.AddConsole();
                configure.AddEventLog();
            });
            return serviceDescriptors.BuildServiceProvider();
        }
    }
}