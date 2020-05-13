using Sispar.Domain.Contracts;
using Sispar.Domain.Contracts.Services;
using Sispar.Domain.Entities;
using System;
using Sispar.Common.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _ctx;

        public UserService(IUserRepository userRepository) => _ctx = userRepository;

        public void ChangePassword(string username, string password, string newPassword, string confirmNewPassword)
        {
            var user = Login(username, password);

            user.SetPassword(newPassword, confirmNewPassword);
            _ctx.Edit(user);
        }


        public IEnumerable<User> GetAll()
        {
            return _ctx.GetAll();
        }

        public User GetById(Guid id)
        {
            return _ctx.GetById(id);
        }

        public User Login(string username, string password)
        {
            var user = _ctx.GetByUserName(username);

            if (user == null)
                throw new ArgumentException("Username not found");

            if (user.Password != password.Encrypt())
                throw new ArgumentException("Wrong password");

            if (!user.Active)
                throw new ArgumentException("User inactive");

            return user;
        }

        public User Register(string username, string password, string confirmPassword)
        {
            var hasUser = _ctx.GetByUserName(username);

            if (hasUser != null)
                throw new ArgumentException("Usuário já cadastrado");

            var user = new User() { Username = username, Active = true };
            user.SetPassword(password, confirmPassword);

            _ctx.Add(user);
            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _ctx.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _ctx.GetByIdAsync(id);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _ctx.GetByUserNameAsync(username);

            if (user == null)
                throw new ArgumentException("Username not found");

            if (user.Password != password.Encrypt())
                throw new ArgumentException("Wrong password");

            if (!user.Active)
                throw new ArgumentException("User inactive");

            return user;
        }
    }
}
