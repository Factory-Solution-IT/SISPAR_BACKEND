using AutoMapper;
using Sispar.Core.Dtos;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Profiles
{
    public class TithersProfile : Profile
    {
        public TithersProfile()
        {
            //Source -> Target
            CreateMap<Tither, TitherReadDto>();
            CreateMap<TitherCreateDto, Tither>();
            //CreateMap<CommandUpdateDto, Command>();
            //CreateMap<Command, CommandUpdateDto>();
        }
    }
}
