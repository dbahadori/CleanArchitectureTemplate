using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Application.DTO.V2;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Application.Common.Exceptions;
using CleanArchitectureTemplate.Resources;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Recipies;

namespace CleanArchitectureTemplate.Application.UseCases.Implementations
{
    public class CreateRecipeInteractor : ICreateRecipeUseCase
    {
        private readonly IRecipeGeneratorFactoryProvider _recipeGeneratorFactoryProvider;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRecipeInteractor(IRecipeGeneratorFactoryProvider recipeGeneratorFactoryProvider, IUnitOfWork unitOfWork)
        {
            _recipeGeneratorFactoryProvider = recipeGeneratorFactoryProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> ExecuteAsync(CreateRecipeRequestDTO inputMessage)
        {
            try
            {
                var recipeCategory = (RecipeCategory)Enum.Parse(typeof(RecipeCategory), inputMessage.RecipeCategory);
                var recipeType = (RecipeType)Enum.Parse(typeof(RecipeType), inputMessage.RecipeType);

                var factory = _recipeGeneratorFactoryProvider.GetFactory(recipeCategory);
                var recipeGenerator = factory.CreateRecipeGenerator(recipeType);
                var recipe = recipeGenerator.Generate();

                await _unitOfWork.RecipeRepository.AddAsync(recipe);
                await _unitOfWork.CommitAsync();

                return OperationResult.Success();
            }
            catch (Exception exception)
            {
                _unitOfWork.Rollback();

                return OperationResult.Failure(exception);
            }



        }
    }
}
