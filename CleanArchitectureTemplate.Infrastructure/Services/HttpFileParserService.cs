using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Application.DTO.V1.Admin;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Services
{
    public class HttpFileParserService : IFileParserService
    {
        private readonly IFileParserFactory _fileParserFactory;
        public HttpFileParserService(IFileParserFactory fileParserFactory)
        {
            _fileParserFactory = fileParserFactory;
        }
        public OperationResult Parse(IFormFile file)
        {
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!Enum.TryParse(fileExtension, out FileExtension extension))
                    return OperationResult.Failure(new FileExtentionException($"{extension} is not supported.", string.Format(Resources.ErrorMessages.ExtentionNotSupported, extension)));
                else
                {
                    var fileParser = _fileParserFactory.GetParserForHttpRequestFile(extension);
                    try
                    {
                        var result = fileParser.Parse(file);
                        return OperationResult<IEnumerable<FileContentOutput>>.Success(result);

                    }
                    catch (Exception e)
                    {
                        return OperationResult<IEnumerable<FileContentOutput>>.Failure(e);
                    }
                    
                }
            }
            else
                return OperationResult.Failure(new ArgumentNullException("No file is provided."));
        }
    }
}
