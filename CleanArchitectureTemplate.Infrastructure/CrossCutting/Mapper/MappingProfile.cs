using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Models;

namespace CleanArchitectureReferenceTemplate.Infrastructure.CrossCutting.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<RecipeEntity, Recipe>();
            CreateMap<Recipe, RecipeEntity>();

            CreateMap<IngredientEntity, Ingredient>();
            CreateMap<Ingredient, IngredientEntity>();

            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();

            CreateMap<RoleEntity, Role>();
            CreateMap<Role, RoleEntity>();

            CreateMap<ActivityEntity, Activity>();
            CreateMap<Activity, ActivityEntity>();

            CreateMap<UserProfileEntity, UserProfile>();
            CreateMap<UserProfile, UserProfileEntity>();

            CreateMap<Session, SessionEntity>();
            CreateMap<SessionEntity, Session>();

        }

    }

}
