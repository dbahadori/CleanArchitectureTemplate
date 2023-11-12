using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.File;
using CleanArchitectureReferenceTemplate.Infrastructure.Common;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureReferenceTemplate.Infrastructure.CrossCutting.Logging
{
    public class SerilogConfiguration : ILoggingConfiguration
    {
        public void Configure()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(InfrastructureHelper.GetInfrastructureDirectory()!)
                .AddJsonFile("serilog.config.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
