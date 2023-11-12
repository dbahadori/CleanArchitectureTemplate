using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Factories;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Application.Services.Implementations;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Builders;
using CleanArchitectureReferenceTemplate.Application.UseCases.Implementations;
using CleanArchitectureReferenceTemplate.Application.UseCases.Interfaces;
using Microsoft.Extensions.Options;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Beverage;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Breakfast;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Dessert;
using AutoMapper;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.MainCourse;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Extensions
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRecipeGeneratorService, RecipeGeneratorService>();

            return services;
        }
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {

            // Add Recipe Generator Factories
            services.AddKeyedScoped<IRecipeGeneratorFactory, BreakfastTypesRecipeGeneratorFactory>(RecipeCategory.BREAKFAST);
            services.AddKeyedScoped<IRecipeGeneratorFactory, BeverageTypesRecipeGeneratorFactory>(RecipeCategory.BEVERAGE);
            services.AddKeyedScoped<IRecipeGeneratorFactory, MainCourseTypesRecipeGeneratorFactory>(RecipeCategory.MAIN_COURSE);
            services.AddKeyedScoped<IRecipeGeneratorFactory, DessertTypesRecipeGeneratorFactory>(RecipeCategory.DESSERT);

            // Add Recipe Generators
            services.AddKeyedScoped<IBeverageRecipeGenerator, CoffeeBeverageRecipeGenerator>(RecipeType.COFFEE);
            services.AddKeyedScoped<IBeverageRecipeGenerator, SmoothieBeverageRecipeGenerator>(RecipeType.SMOOTHIE);
            services.AddKeyedScoped<IBreakfastRecipeGenerator, OmeletteBreakfastRecipeGenerator>(RecipeType.OMELETTE);
            services.AddKeyedScoped<IBreakfastRecipeGenerator, PancakeBreakfastRecipeGenerator>(RecipeType.PANCAKE);
            services.AddKeyedScoped<IDessertRecipeGenerator, CakeDessertRecipeGenerator>(RecipeType.CAKE);
            services.AddKeyedScoped<IDessertRecipeGenerator, IceCreamDessertRecipeGenerator>(RecipeType.ICE_CREAM);
            services.AddKeyedScoped<IMainCourseRecipeGenerator, Pasta_DishMainCourseRecipeGenerator>(RecipeType.PASTA_DISH);
            services.AddKeyedScoped<IMainCourseRecipeGenerator, RoastMainCourseRecipeGenerator>(RecipeType.ROAST);



            return services;
        }
        public static IServiceCollection AddFactoryProviders(this IServiceCollection services)
        {
            services.AddSingleton<IRecipeGeneratorFactoryProvider, RecipeGeneratorFactoryProvider>();

            return services;
        }
        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            services.AddScoped<IRecipeBuilder, RecipeBuilder>();
            services.AddScoped<IIngredientBuilder, IngredientBuilder>();

            return services;
        }
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUserRegisterUseCase, UserRegisterInteractor>();
            services.AddScoped<IUserLoginUseCase, UserLoginInteractor>();

            return services;
        }



    }
}
