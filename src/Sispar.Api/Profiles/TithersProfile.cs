using AutoMapper;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.Entities;

namespace Sispar.Api.Profiles
{
    public class TithersProfile : Profile
    {
        public TithersProfile()
        {
            //Source -> Target
            CreateMap<Tither, TitherResponse>();
            CreateMap<Tither, CreateTitherResponse>();
            CreateMap<CreateTitherCommand, Tither>();
            CreateMap<UpdateTitherCommand, Tither>();

            //CreateMap<CommandUpdateDto, Command>();
            //CreateMap<Command, CommandUpdateDto>();
        }
    }
}