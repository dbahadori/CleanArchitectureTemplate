using CleanArchitectureTemplate.Application.Common.Interfaces;
using System.Security.Claims;

namespace CleanArchitectureTemplate.Presentation.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private string? _userId;

        public string? UserId
        {
            get
            {
                _userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
                return _userId;
            }
        }

    }
}