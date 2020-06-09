using Sispar.DataContract.TitheModule.Parameters;
using Sispar.Domain.BaseModule.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Commands
{
    public class UpdateTitheCommand : Command<TitheParameters, bool>
    {
        public Guid Id { get; set; }

        public UpdateTitheCommand(Guid id, TitheParameters parameters) 
            : base(parameters)
        {
            Id = id;
        }
    }
}
