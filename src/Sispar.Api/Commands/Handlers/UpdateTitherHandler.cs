using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class UpdateTitherHandler : IRequestHandler<UpdateTitherRequest, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public UpdateTitherHandler(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<NoContentResponse> Handle(UpdateTitherRequest request, CancellationToken cancellationToken)
        {
            var titherFromRepo = await _titherRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, titherFromRepo);
            _titherRepository.Edit(titherFromRepo);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}