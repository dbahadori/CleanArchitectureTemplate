using CleanArchitectureReferenceTemplate.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureReferenceTemplate.Presentation.Controllers.V1.Common
{
    // Specify the base (or current) API route to:
    // - Keep the existing route serving a default version (backward compatible).
    // - Support query string and HTTP header versioning.
    [Route("api")]

    // Specify the route to support URI Versioning
    //[Route("api/v{version:apiVersion}")]

    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRegisterUseCase _userRegisterUseCase;
        private readonly IUserLoginUseCase _userLoginUseCase;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRegisterUseCase userRegisterUseCase, IUserLoginUseCase userLoginUseCase, ILogger<UsersController> logger)
        {
            _userRegisterUseCase = userRegisterUseCase;
            _userLoginUseCase = userLoginUseCase;
            _logger = logger;
        }

    }
}
