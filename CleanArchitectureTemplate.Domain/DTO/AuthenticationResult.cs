using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Entities;
using System.Security.Claims;

namespace CleanArchitectureTemplate.Domain.DTO
{
    public class AuthenticationResult : BaseServiceResult
    {
        public bool IsUserAuthenticated { get; set; } = false;
        public User? AuthenticatedUser { get; set; }
        public CustomException? Exception { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
