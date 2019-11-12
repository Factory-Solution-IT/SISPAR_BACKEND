﻿using Microsoft.EntityFrameworkCore;
using Sispar.Core.Contracts;
using Sispar.Core.Entities;
using Sispar.Infra.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(SisparDataContext context) : base(context) { }

        public User GetByUserName(string userName)
        {
            return _context.Users.Where(x => x.Username.Contains(userName)).FirstOrDefault();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users.Where(x => x.Username.Contains(userName)).FirstOrDefaultAsync();
        }
    }
}
