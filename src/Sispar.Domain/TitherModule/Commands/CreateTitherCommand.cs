using Sispar.DataContract.TitherModule.Models;
using Sispar.DataContract.TitherModule.Parameters;
using Sispar.Domain.BaseModule.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitherModule.Commands
{
    public class CreateTitherCommand : Command<TitherParameters, TitherModel>
    {
        public CreateTitherCommand(TitherParameters parameters) : base(parameters) { }
    }
}
