using AutoMapper;
using Sispar.DataContract.UserModule.Models;
using Sispar.DataContract.UserModule.Parameters;
using Sispar.Domain.UserModule.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.UserModule.Adapters
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Source -> Target
            CreateMap<User, UserModel>();
            CreateMap<UserParameters, User>();
            //CreateMap<User, CreateUserResponse>();
            //CreateMap<UpdateUserCommand, User>();
            CreateMap<User, LoginModel>();
        }
    }
}
