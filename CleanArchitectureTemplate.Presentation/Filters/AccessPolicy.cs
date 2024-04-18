using CleanArchitectureTemplate.Domain.Interfaces.Repositories;

using CleanArchitectureTemplate.Domain.ValueObejects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using CleanArchitectureTemplate.Presentation.Common.Exceptions;

namespace CleanArchitectureTemplate.Presentation.Filters
{
    public class AccessPolicy : TypeFilterAttribute
    {
        public AccessPolicy(params string[] roles) : base(typeof(CheckRole))
        {
            Arguments = new object[] { roles };
        }

        private class CheckRole : IAsyncActionFilter
        {
            private readonly string[] _roles;
            private readonly IUnitOfWork _unitOfWork;

            public CheckRole(string[] roles, IUnitOfWork unitOfWork)
            {
                _roles = roles;
                _unitOfWork = unitOfWork;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (_roles.Count() == 0)
                    throw new ArgumentNullException("Roles are not specified for accessing to this action.");

                string userId = context.HttpContext.User.FindFirst(ClaimTypes.Name)!.Value;
                if (string.IsNullOrWhiteSpace(userId))
                    throw new ForbiddenException()
                        .WithUserFriendlyMessage("User Don't Access to this Resourse")
                        .WithDeveloperDetail("User Don't Access to this Resourse");

                var user = await _unitOfWork.UserRepository.GetByIdAsync(new Guid(userId));
                if (user==null)
                    throw new ForbiddenException()
                        .WithUserFriendlyMessage("User Don't Access to this Resourse")
                        .WithDeveloperDetail("User Don't Access to this Resourse");
                var Access = false;
                foreach (var role in _roles)
                {
                    Access = user.Roles.Any(r => r.Name.ToLower() == role.ToString()!.ToLower());
                    if (Access)
                        break;
                }
                if (!Access)
                    throw new ForbiddenException()
                        .WithUserFriendlyMessage("User Don't Access to this Resourse")
                        .WithDeveloperDetail("User Don't Access to this Resourse");
                var result = await next();

            }
        }
    }
}
