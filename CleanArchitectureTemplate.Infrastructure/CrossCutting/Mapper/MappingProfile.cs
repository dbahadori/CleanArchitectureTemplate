using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Models;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Mapper
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
