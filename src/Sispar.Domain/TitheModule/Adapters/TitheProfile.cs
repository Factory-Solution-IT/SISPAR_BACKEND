using AutoMapper;
using Sispar.DataContract.TitheModule.Models;
using Sispar.DataContract.TitheModule.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Adapters
{
    public class TitheProfile : Profile
    {
        public TitheProfile()
        {
            //Source -> Target
            CreateMap<Tithe, TitheModel>();
            CreateMap<TitheParameters, Tithe>();
            //CreateMap<Tithe, CreateTitheResponse>();
            //CreateMap<UpdateTitheCommand, Tithe>();
        }
    }
}
