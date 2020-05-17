using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class DeleteTitherHandler : IRequestHandler<DeleteTitherRequest, NoContentResponse>
    {
        private readonly ITitherRepository _titherRepository;

        public DeleteTitherHandler(ITitherRepository titherRepository) => _titherRepository = titherRepository;

        public async Task<NoContentResponse> Handle(DeleteTitherRequest request, CancellationToken cancellationToken)
        {
            var tither = await _titherRepository.GetByIdAsync(request.Id);
            _titherRepository.Delete(tither);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}