using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, NoContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<NoContentResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            _userRepository.Delete(user);

            return await Task.FromResult(new NoContentResponse());
        }
    }
}
