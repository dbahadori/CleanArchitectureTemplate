using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Factories
{
    public class FileParserFactory : IFileParserFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FileParserFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IHttpFileParser GetParserForHttpRequestFile(FileExtension extension)
        {

            var parser = _serviceProvider.GetKeyedService<IHttpFileParser>(extension);
            if (parser != null)
                return parser;
            throw new NotSupportedException($"File type '{extension}' is not supported.");
        }
    }
}