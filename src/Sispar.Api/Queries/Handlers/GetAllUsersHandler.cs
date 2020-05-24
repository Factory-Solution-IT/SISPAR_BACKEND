using AutoMapper;
using MediatR;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserResponse>>(users);

            return await Task.FromResult(result);
        }
    }
}