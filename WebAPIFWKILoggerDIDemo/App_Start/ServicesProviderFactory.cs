using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebAPIFWKILoggerDIDemo
{
    public static class ServicesProviderFactory
    {
        public static ServiceProvider Get() {
            ServiceCollection services = new ServiceCollection();
            return ConfigureServices(services);
        }
        private static ServiceProvider ConfigureServices(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddControllersAsServices();
            serviceDescriptors.AddSingleton<IPiValueProvider, HardCodedPiValueProvider>();
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            serviceDescriptors.AddLogging((configure) =>
            {
                configure.AddConfiguration(config.GetSection("Logging"));
                configure.AddConsole();
                configure.AddEventLog();
                configure.AddLegacyTraceLogger();
            });
            return serviceDescriptors.BuildServiceProvider();
        }
    }
}
