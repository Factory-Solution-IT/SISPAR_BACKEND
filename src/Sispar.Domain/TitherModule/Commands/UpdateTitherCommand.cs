using Sispar.DataContract.TitherModule.Parameters;
using Sispar.Domain.BaseModule.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitherModule.Commands
{
    public class UpdateTitherCommand : Command<TitherParameters, bool>
    {
        public Guid Id { get; set; }

        public UpdateTitherCommand(Guid id, TitherParameters parameters)
            : base(parameters)
        {
            Id = id;
        }
    }
}
