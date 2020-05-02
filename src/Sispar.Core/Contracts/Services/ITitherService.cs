using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Contracts.Services
{
    public interface ITitherService : IDisposable
    {
        Tither Register(string name, string address, DateTime birthdate, string cpf, string telephone, string cellphone, 
            DateTime marriegedate, string namespouse, DateTime datebirthSpouse);

        IEnumerable<Tither> GetAll();
        Tither GetById(Guid id);

        Task<IEnumerable<Tither>> GetAllAsync();
        Task<Tither> GetByIdAsync(Guid id);
    }
}
