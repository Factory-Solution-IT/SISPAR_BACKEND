using AutoMapper;
using MediatR;
using Sispar.DataContract.UserModule.Models;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.UserModule.QueryHandlers
{
    public class ListUserQueryHandler : IRequestHandler<ListUserQuery, IEnumerable<UserModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ListUserQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserModel>>(users.Where(_ => _.Deleted == false));

            return await Task.FromResult(result);
        }
    }
}
