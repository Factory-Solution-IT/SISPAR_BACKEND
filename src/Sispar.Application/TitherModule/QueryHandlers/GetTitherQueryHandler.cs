using AutoMapper;
using MediatR;
using Sispar.DataContract.TitherModule.Models;
using Sispar.Domain.TitherModule.Abstractions;
using Sispar.Domain.TitherModule.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.TitherModule.QueryHandlers
{
    public class GetTitherQueryHandler : IRequestHandler<GetTitherQuery, TitherModel>
    {
        private readonly IMapper _mapper;
        private readonly ITitherRepository _titherRepository;

        public GetTitherQueryHandler(IMapper mapper, ITitherRepository titherRepository)
        {
            _mapper = mapper;
            _titherRepository = titherRepository;
        }

        public async Task<TitherModel> Handle(GetTitherQuery request, CancellationToken cancellationToken)
        {
            var tither = await _titherRepository.GetByIdAsync(request.Id);

            var result = (tither != null && tither.Deleted == false) ? _mapper.Map<TitherModel>(tither) : null;

            return await Task.FromResult(result);
        }
    }
}