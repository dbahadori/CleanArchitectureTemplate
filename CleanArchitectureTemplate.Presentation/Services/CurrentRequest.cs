using Azure.Core;
using CleanArchitectureTemplate.Application.Common.Interfaces;

namespace CleanArchitectureTemplate.Presentation.Services
{
    public class CurrentRequest : ICurrentRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentRequest(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string AppUrl => $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext!.Request.Host}{_httpContextAccessor.HttpContext!.Request.PathBase}" + "/";
    }
}
