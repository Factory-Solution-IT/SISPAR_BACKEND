using AutoMapper;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.TitherModule;

namespace Sispar.Api.Profiles
{
    public class TitherProfile : Profile
    {
        public TitherProfile()
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