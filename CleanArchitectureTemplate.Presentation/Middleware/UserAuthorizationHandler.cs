using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CleanArchitectureReferenceTemplate.Presentation.Middleware
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
                var userFromRepository = await _unitOfWork.UserRepository.FindByIdAsync(new Guid(userId));
                if (!userFromRepository.IsSuccessful)
                    context.Fail();

                else
                    context.Succeed(requirement);

            }
        }
    }
}
