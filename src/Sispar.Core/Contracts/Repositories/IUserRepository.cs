using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string userName);
        Task<User> GetByUserNameAsync(string userName);
    }
}
