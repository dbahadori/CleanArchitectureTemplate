using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Application.Extensions;
using CleanArchitectureTemplate.Application.Services.Implementations;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Application.UseCases.Implementations;
using CleanArchitectureTemplate.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            DependancyInjection.AddBuilders(services);
            DependancyInjection.AddApplicationServices(services);
            DependancyInjection.AddFactories(services);
            DependancyInjection.AddFactoryProviders(services);
            DependancyInjection.AddUseCases(services);

            return services;
        }
    }
}
