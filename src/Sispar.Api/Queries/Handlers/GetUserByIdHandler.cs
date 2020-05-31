using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.UserModule.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<UserResponse>(user);

            return await Task.FromResult(result);
        }
    }
}