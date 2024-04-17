using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Application.DTO.V1.Admin;
using Microsoft.AspNetCore.Http;

namespace CleanArchitectureTemplate.Infrastructure.Common.Components
{
    internal class PDFFileFromHttpRequestParser : IHttpFileParser
    {
        public IEnumerable<FileContentResponseDTO> Parse(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
