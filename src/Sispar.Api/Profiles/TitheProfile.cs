using AutoMapper;
using Sispar.Api.Commands;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.Entities;

namespace Sispar.Api.Profiles
{
    public class TitheProfile : Profile
    {
        public TitheProfile()
        {
            //Source -> Target
            CreateMap<Tithe, TitheResponse>();
            CreateMap<Tithe, CreateTitheResponse>();
            CreateMap<CreateTitheCommand, Tithe>();
            CreateMap<UpdateTitheCommand, Tithe>();
        }
    }
}