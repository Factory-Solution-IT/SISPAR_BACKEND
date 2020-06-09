using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.BaseModule.Command
{
    public class Command<TParameters, TResponse> : IRequest<TResponse>
    {
        public TParameters parameters;

        public Command(TParameters parameters)
        {
            this.parameters = parameters;
        }
    }

    public class Command<TResponse> : IRequest<TResponse>
    { 
    }
}
