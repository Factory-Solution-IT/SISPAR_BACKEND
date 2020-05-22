using AutoMapper;
using MediatR;
using Sispar.Api.Commands.Requests;
using Sispar.Api.Commands.Responses;
using Sispar.Api.Queries.Responses;
using Sispar.Core.Notification;
using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IMapper mapper, 
            NotificationContext notificationContext, 
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.ConfirmPassword))
            {
                _notificationContext.AddNotification("Password", "Senha e Confirma Senha não conferem");
                return await Task.FromResult(new CreateUserResponse());
            }

            var user = _mapper.Map<User>(request);
            user.EncriptPassword();

            await _userRepository.AddAsync(user);

            var result = _mapper.Map<CreateUserResponse>(user);
            return await Task.FromResult(result);
        }
    }
}
