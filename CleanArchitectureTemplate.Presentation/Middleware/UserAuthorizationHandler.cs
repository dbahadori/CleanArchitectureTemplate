using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CleanArchitectureTemplate.Presentation.Middleware
{
    public class UserAuthorizationRequirement : IAuthorizationRequirement { }
    public class UserAuthorizationHandler : AuthorizationHandler<UserAuthorizationRequirement>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserAuthorizationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizationRequirement requirement)
        {
            string userId = context.User.FindFirst(ClaimTypes.Name)!.Value;
            if (string.IsNullOrWhiteSpace(userId))
                context.Fail();

            else
            {
                var user = await _unitOfWork.UserRepository.FindByIdAsync(new Guid(userId));
                if (user != null)
                    context.Succeed(requirement);
                else
                    context.Fail();


            }
        }
    }
}
