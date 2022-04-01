using Microsoft.Extensions.Logging;

namespace WebAPIFWKILoggerDIDemo
{
    public static class LegacyTraceLoggerExtensions
    {
        public static ILoggingBuilder AddLegacyTraceLogger(this ILoggingBuilder builder)
        {
            builder.AddProvider(new LegacyTraceLoggerProvider());
            return builder;
        }
    }
}