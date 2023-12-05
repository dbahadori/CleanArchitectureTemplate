using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Common.Components;
using CleanArchitectureTemplate.Infrastructure.CrossCutting.Logging;
using CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation;
using CleanArchitectureTemplate.Infrastructure.Factories;
using CleanArchitectureTemplate.Infrastructure.Interceptors;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureTemplate.Infrastructure.Persistence.Repositories;
using CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitectureTemplate.Infrastructure.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        public static IServiceCollection AddCrossCuttingConcerns(this IServiceCollection services)
        {
            services.AddSingleton<ILoggingConfiguration, SerilogConfiguration>();
            services.AddSingleton<IModelValidator, CustomModelValidator>();
            services.AddSingleton<ICustomValidatorFactory, FluentValidatorFactory>();

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddSingleton<ITokenService>(x => new TokenService(configuration, x.GetRequiredService<IDateTime>()));
            services.AddTransient<IFileParserService, HttpFileParserService>();

            return services;
        }
        public static IServiceCollection AddComponents(this IServiceCollection services)
        {
            services.AddKeyedTransient<IHttpFileParser, ExcelFileFromHttpRequestParser>(FileExtension.XLSX);
            services.AddKeyedTransient<IHttpFileParser, ExcelFileFromHttpRequestParser>(FileExtension.XLS);
            services.AddKeyedTransient<IHttpFileParser, PDFFileFromHttpRequestParser>(FileExtension.PDF);
            services.AddKeyedTransient<IHttpFileParser, WordFileFromHttpRequestParser>(FileExtension.DOC);
            services.AddKeyedTransient<IHttpFileParser, WordFileFromHttpRequestParser>(FileExtension.DOCX);


            return services;
        }
        public static IServiceCollection AddCustomInterceptors(this IServiceCollection services)
        {
            services.AddScoped<AuditingInterceptor>();

            return services;
        }
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddSingleton<IFileParserFactory, FileParserFactory>();

            return services;
        }
        public static IServiceCollection SetDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? databaseType = configuration.GetValue<string>("DatabaseType");
            string? connectionString = configuration.GetConnectionString(databaseType ?? "Undeclared");

            switch (databaseType)
            {
                case "SqlServerProduction":
                    services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
                    {
                        // Configure DbContext using IConfiguration
                        options.UseSqlServer(connectionString,
                            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                        // Create an instance of AuditingInterceptor
                        var auditingInterceptor = new AuditingInterceptor(
                            serviceProvider.GetRequiredService<ICurrentUserService>(),
                            serviceProvider.GetRequiredService<IDateTime>());

                        // Register AuditingInterceptor
                        options.AddInterceptors(auditingInterceptor);

                    });

                    break;
                case "SqlServerTest":
                    services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
                    {
                        options.UseSqlServer(connectionString,
                            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                        var auditingInterceptor = new AuditingInterceptor(
                            serviceProvider.GetRequiredService<ICurrentUserService>(),
                            serviceProvider.GetRequiredService<IDateTime>());

                        options.AddInterceptors(auditingInterceptor);
                    });

                    break;
                case "InMemory":
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseInMemoryDatabase("InMemoryDatabase"));
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported database type: {databaseType}");
            }



            return services;
        }
    }
}
