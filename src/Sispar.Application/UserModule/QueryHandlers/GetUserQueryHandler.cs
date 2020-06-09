using AutoMapper;
using MediatR;
using Sispar.DataContract.UserModule.Models;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Domain.UserModule.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Sispar.Application.UserModule.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            var result = (user != null && user.Deleted == false) ? _mapper.Map<UserModel>(user) : null;

            return await Task.FromResult(result);
        }
    }
}