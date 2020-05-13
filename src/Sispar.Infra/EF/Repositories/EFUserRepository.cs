using Microsoft.EntityFrameworkCore;
using Sispar.Domain.Contracts;
using Sispar.Domain.Entities;
using Sispar.Infra.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {

        public EFUserRepository(SisparDataContext context) : base(context) { }

        public User GetByUserName(string userName)
        {
            return null;
            //return _context.Users.Where(x => x.Username.Contains(userName)).FirstOrDefault();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return null;
            //return await _context.Users.Where(x => x.Username.Contains(userName)).FirstOrDefaultAsync();
        }
    }
}
