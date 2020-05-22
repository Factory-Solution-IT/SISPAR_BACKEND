using AutoMapper;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Source -> Target
            CreateMap<User, UserResponse>();
            CreateMap<User, CreateUserResponse>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, LoginResponse>();
        }
    }
}
