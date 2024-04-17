using CleanArchitectureTemplate.Application.DTO.V1.Admin;
using Microsoft.AspNetCore.Http;

namespace CleanArchitectureTemplate.Application.Common.Interfaces
{
    public interface IHttpFileParser
    {
        IEnumerable<FileContentResponseDTO> Parse(IFormFile file);
    }
}
