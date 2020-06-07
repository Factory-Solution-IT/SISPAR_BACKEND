using Sispar.Domain.BaseModule.Command;
using System;

namespace Sispar.Domain.TitherModule.Commands
{
    public class DeleteTitherCommand : Command<bool>
    {
        public Guid Id { get; set; }

        public DeleteTitherCommand(Guid id)
        {
            Id = id;
        }
    }
}