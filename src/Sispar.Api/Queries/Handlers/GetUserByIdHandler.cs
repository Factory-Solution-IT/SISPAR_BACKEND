using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using Sispar.Api.Queries.Requests;
using Sispar.Api.Queries.Responses;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
