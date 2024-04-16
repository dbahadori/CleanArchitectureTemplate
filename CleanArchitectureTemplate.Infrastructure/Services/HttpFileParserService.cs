using CleanArchitectureTemplate.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Application.DTO.V1.Admin;
using CleanArchitectureTemplate.Resources;
using CleanArchitectureTemplate.Domain.DTO;

namespace CleanArchitectureTemplate.Infrastructure.Services
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
                {
                    var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ExtentionNotSupported, extension);
                    return OperationResult.Failure(
                        new FileExtentionException()
                        .WithDeveloperDetail(localizedMessage)
                        .WithDeveloperDetail(localizedMessage)                        
                        );
                }
                else
                {
                    var fileParser = _fileParserFactory.GetParserForHttpRequestFile(extension);
                    try
                    {
                        var result = fileParser.Parse(file);
                        return OperationResult<IEnumerable<FileContentOutputModel>>.Success(result);

                    }
                    catch (Exception exception)
                    {
                        return OperationResult<IEnumerable<FileContentOutputModel>>.Failure(exception);
                    }
                    
                }
            }
            else
                return OperationResult.Failure(new ArgumentNullException("No file is provided."));
        }
    }
}
