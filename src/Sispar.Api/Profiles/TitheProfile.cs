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
    public class TitheProfile : Profile
    {
        public TitheProfile()
        {
            //Source -> Target
            CreateMap<Tithe, TitheResponse>();
            CreateMap<Tithe, CreateTitheResponse>();
            CreateMap<CreateTitheRequest, Tithe>();
            // CreateMap<UpdateTitheRequest, Tithe>();
        }
    }
}
