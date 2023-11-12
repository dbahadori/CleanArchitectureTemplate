using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureReferenceTemplate.Infrastructure.Extentions;
using CleanArchitectureReferenceTemplate.Infrastructure.CrossCutting.Mapper;

namespace CleanArchitectureReferenceTemplate.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddCustomInterceptors();
            services.AddRepositories();
            services.AddCustomServices(configuration);
            services.AddComponents();
            services.AddCrossCuttingConcerns();
            services.AddFactories();
            services.SetDBContext(configuration);


            return services;
        }
    }

}