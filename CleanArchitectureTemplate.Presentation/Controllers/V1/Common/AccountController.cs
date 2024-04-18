using CleanArchitectureTemplate.Application.DTO.V1.AdminControlPanel;
using CleanArchitectureTemplate.Application.DTO.V1.Users;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Admin;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Users;
using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Presentation.Controllers.V1.Common
{
    // Specify the base (or current) API route to:
    // - Keep the existing route serving a default version (backward compatible).
    // - Support query string and HTTP header versioning.
    [Route("api/[Controller]")]

    // Specify the route to support URI Versioning
    //[Route("api/v{version:apiVersion}/[Controller]")]

    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRegisterUseCase _userRegisterUseCase;
        private readonly IUserLoginUseCase _userLoginUseCase;
        private readonly ILogger<AccountController> _logger;
        private readonly IModelValidator _modelValidator;
             
        public AccountController(IUserRegisterUseCase userRegisterUseCase, IUserLoginUseCase userLoginUseCase, ILogger<AccountController> logger,IModelValidator modelValidator)
        {
            _userRegisterUseCase = userRegisterUseCase;
            _userLoginUseCase = userLoginUseCase;
            _logger = logger;
            _modelValidator = modelValidator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO request)
        {
            // Validation
            _modelValidator.ValidateAndThrow(request);

            try
            {
                // Login Process
                 var loginResult = await _userLoginUseCase.LoginAsync(request);
                if (!loginResult.IsSuccessful)
                    throw loginResult.Exception!;

                var result = loginResult as OperationResult<UserLoginResponseDTO>;
                return Ok(result!.Data!);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDTO request, CancellationToken cancellationToken)
        {
            // Validation
            _modelValidator.ValidateAndThrow(request);
            try
            {
                // Register Process
                var registerResult = await _userRegisterUseCase.RegisterAsync(request, cancellationToken);
                if (!registerResult.IsSuccessful)
                    throw registerResult.Exception!;

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
