using MediatR;

namespace Sispar.Domain.BaseModule.Query
{
    public class Query<TParameters, TResponse> : IRequest<TResponse>
    {
        public TParameters parameters;

        public Query(TParameters parameters)
        {
            this.parameters = parameters;
        }
    }

    public class Query<TResponse> : IRequest<TResponse>
    {
    }
}