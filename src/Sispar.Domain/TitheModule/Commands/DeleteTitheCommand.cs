using Sispar.Domain.BaseModule.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Commands
{
    public class DeleteTitheCommand : Command<bool>
    {
        public Guid Id { get; set; }

        public DeleteTitheCommand(Guid id)
        {
            Id = id;
        }
    }
}
