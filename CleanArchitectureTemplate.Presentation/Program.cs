using CleanArchitectureTemplate.Infrastructure;
using CleanArchitectureTemplate.Application;
using CleanArchitectureTemplate.Presentation;
using CleanArchitectureTemplate.Domain;
using CleanArchitectureTemplate.Presentation.Middleware;
using Serilog;
using Microsoft.Extensions.Configuration;
using CleanArchitectureTemplate.Infrastructure.Common;
using CleanArchitectureTemplate.Infrastructure.CrossCutting.Logging;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Determine the environment
var isDev = builder.Environment.IsDevelopment();
string? infrastructureDirectory;
if (isDev)
{
    infrastructureDirectory = InfrastructureHelper.GetInfrastructureDirectory();
}
else
{
    infrastructureDirectory = Directory.GetCurrentDirectory();
}

// create configuration object for configuration files of Infrastructure layer
var infrastructureConfiguration = builder.Configuration
    .SetBasePath(infrastructureDirectory!)
    .AddJsonFile("Infrastructure_settings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("serilog.config.json", optional: false, reloadOnChange: true)

    .Build();

// configuring Serilog as the logging provider for the application's host

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(infrastructureConfiguration));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition= JsonIgnoreCondition.WhenWritingNull;
}); 
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddPresentationServices(infrastructureConfiguration);
builder.Services.AddInfrastructureServices(infrastructureConfiguration);

var app = builder.Build();




// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CorsPolicy");
app.UseMiddleware<ApiExceptionMiddleware>();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();
public partial class Program { }