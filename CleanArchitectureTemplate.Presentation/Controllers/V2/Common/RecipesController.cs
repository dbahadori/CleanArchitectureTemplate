using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Presentation.Controllers.V1.Common;
using CleanArchitectureTemplate.Application.DTO.V2;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Recipies;

namespace CleanArchitectureTemplate.Presentation.Controllers.V2.Common
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class RecipesController : ControllerBase
    {
        private readonly ICreateRecipeUseCase _createRecipe;
        private readonly IModelValidator _modelValidator;
        private readonly ILogger<RecipesController> _logger;


        public RecipesController(ICreateRecipeUseCase createRecipe, IModelValidator modelValidator, ILogger<RecipesController> logger)
        {
            _createRecipe = createRecipe;
            _modelValidator = modelValidator;
            _logger = logger;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequestDTO recipeModel) { 
            
            _modelValidator.ValidateAndThrow(recipeModel);

            try
            {
                var result = await _createRecipe.ExecuteAsync(recipeModel);
                if (!result.IsSuccessful)
                    throw result.Exception;
                else
                    return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
