using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureReferenceTemplate.Application.DTO.V1;
using CleanArchitectureReferenceTemplate.Application.Extensions;
using CleanArchitectureReferenceTemplate.Application.Services.Implementations;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Application.UseCases.Implementations;
using CleanArchitectureReferenceTemplate.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureReferenceTemplate.Application
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
