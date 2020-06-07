using AutoMapper;
using Sispar.DataContract.TitherModule.Models;
using Sispar.DataContract.TitherModule.Parameters;
using Sispar.Domain.TitherModule.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitherModule.Adapters
{
    public class TItherProfile : Profile
    {
        public TItherProfile()
        {
            //Source -> Target
            CreateMap<Tither, TitherModel>();
            CreateMap<TitherParameters, Tither>();
            // CreateMap<CreateTitherCommand, Tither>();
            //CreateMap<UpdateTitherCommand, Tither>();

            //CreateMap<CommandUpdateDto, Command>();
            //CreateMap<Command, CommandUpdateDto>();
        }
    }
}
