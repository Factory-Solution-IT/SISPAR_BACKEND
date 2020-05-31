using Microsoft.EntityFrameworkCore;
using Sispar.Domain.UserModule;
using Sispar.Domain.UserModule.Abstractions;
using Sispar.Infra.EF.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Sispar.Infra.EF
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(SisparDataContext context) : base(context)
        {
        }

        public User GetByUserName(string userName)
        {
            return _context.Users.Where(x => x.Username.Contains(userName)).FirstOrDefault();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
        }
    }
}