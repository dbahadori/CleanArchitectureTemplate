using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureReferenceTemplate.Presentation.Controllers.V2.Common
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]

    public class UserController : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
