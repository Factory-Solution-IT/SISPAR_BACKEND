using Sispar.DataContract.TitheModule.Models;
using Sispar.DataContract.TitheModule.Parameters;
using Sispar.DataContract.TitherModule.Parameters;
using Sispar.Domain.BaseModule.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Commands
{
    public class CreateTitheCommand : Command<TitheParameters, TitheModel>
    {
        public CreateTitheCommand(TitheParameters parameters) : base(parameters) { }
    }
}
