using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureReferenceTemplate.Presentation.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureReferenceTemplate.Presentation.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using CleanArchitectureReferenceTemplate.Presentation.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CleanArchitectureReferenceTemplate.Presentation.Middleware;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;

namespace CleanArchitectureReferenceTemplate.Presentation

{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
            services.AddControllers(options => options.Filters.Add<Modelstatefeaturefilter>());
            services.AddTransient<ICurrentRequest, CurrentRequest>();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddApiVersioningConfigured();
            services.AddCORSConfigured();

            return services;
        }
    }
}
