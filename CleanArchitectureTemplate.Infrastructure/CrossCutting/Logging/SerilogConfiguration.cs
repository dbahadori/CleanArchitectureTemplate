﻿using Serilog;
using CleanArchitectureTemplate.Infrastructure.Common;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Logging
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
