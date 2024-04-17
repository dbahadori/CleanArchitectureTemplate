using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureTemplate.Application.Common.Implementation.Factories;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Application.Services.Implementations;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Application.Common.Implementation.Builders;
using CleanArchitectureTemplate.Application.UseCases.Implementations;
using Microsoft.Extensions.Options;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.Beverage;
using CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.Breakfast;
using CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.Dessert;
using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.MainCourse;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Recipies;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Users;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Admin;

namespace CleanArchitectureTemplate.Application.Extensions
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
            services.AddKeyedScoped<IBeverageRecipeGenerator, CoffeeGenerator>(RecipeType.COFFEE);
            services.AddKeyedScoped<IBeverageRecipeGenerator, SmoothieGenerator>(RecipeType.SMOOTHIE);
            services.AddKeyedScoped<IBreakfastRecipeGenerator, OmeletteGenerator>(RecipeType.OMELETTE);
            services.AddKeyedScoped<IBreakfastRecipeGenerator, PancakeGenerator>(RecipeType.PANCAKE);
            services.AddKeyedScoped<IDessertRecipeGenerator, CakeGenerator>(RecipeType.CAKE);
            services.AddKeyedScoped<IDessertRecipeGenerator, IceCreamGenerator>(RecipeType.ICE_CREAM);
            services.AddKeyedScoped<IMainCourseRecipeGenerator, Pasta_DishGenerator>(RecipeType.PASTA_DISH);
            services.AddKeyedScoped<IMainCourseRecipeGenerator, RoastGenerator>(RecipeType.ROAST);



            return services;
        }
        public static IServiceCollection AddFactoryProviders(this IServiceCollection services)
        {
            services.AddScoped<IRecipeGeneratorFactoryProvider, RecipeGeneratorFactoryProvider>();

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
            services.AddScoped<ICreateRecipeUseCase, CreateRecipeInteractor>();

            return services;
        }



    }
}
