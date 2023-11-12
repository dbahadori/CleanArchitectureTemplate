using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;
using CleanArchitectureReferenceTemplate.Application.DTO.V1.Admin;
using Microsoft.AspNetCore.Http;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Common.Components
{
    internal class PDFFileFromHttpRequestParser : IHttpFileParser
    {
        public IEnumerable<FileContentOutput> Parse(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
