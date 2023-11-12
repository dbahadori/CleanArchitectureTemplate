using CleanArchitectureReferenceTemplate.Application.DTO.V1.Admin;
using Microsoft.AspNetCore.Http;

namespace CleanArchitectureReferenceTemplate.Application.Common.Interfaces
{
    public interface IHttpFileParser
    {
        IEnumerable<FileContentOutput> Parse(IFormFile file);
    }
}
