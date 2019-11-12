using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Contracts.Services
{
    public interface IUserService: IDisposable
    {
        User Login(string username, string password);
        Task<User> LoginAsync(string username, string password);
        void ChangePassword(string username, string password, string newPassword, string confirmNewPassword);
        User Register(string username, string password, string confirmPassword);
        IEnumerable<User> GetAll();
        Task<IEnumerable<User>> GetAllAsync();
        User GetById(int id);
        Task<User> GetByIdAsync(int id);
    }
}
