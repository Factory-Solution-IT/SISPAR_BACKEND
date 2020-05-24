using AutoMapper;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.Entities;

namespace Sispar.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Source -> Target
            CreateMap<User, UserResponse>();
            CreateMap<User, CreateUserResponse>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, LoginResponse>();
        }
    }
}