using Sispar.Core.Contracts;
using Sispar.Core.Contracts.Services;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Business.Services
{
    public class TitherService : ITitherService
    {
        private readonly ITitherRepository _ctx;

        public TitherService(ITitherRepository titherRepository)
        {
            _ctx = titherRepository;
        }

        public IEnumerable<Tither> GetAll()
        {
            return _ctx.GetAll();
        }

        public Tither GetById(Guid id)
        {
            return _ctx.GetById(id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public Tither Register(string name, string address, DateTime birthdate, string cpf, string telephone, string cellphone, 
            DateTime marriegedate, string namespouse, DateTime datebirthSpouse)
        {
            var tither = new Tither() {
                Name = name, Address = address, BirthDate = birthdate, CPF = cpf, Telephone = telephone,
                Cellphone = cellphone, MarriegeDate = marriegedate, NameSpouse = namespouse, DateBirthSpouse = datebirthSpouse
            };

            _ctx.Add(tither);

            return tither;
        }

        public async Task<IEnumerable<Tither>> GetAllAsync()
        {
            return await _ctx.GetAllAsync();
        }

        public async Task<Tither> GetByIdAsync(Guid id)
        {
            return await _ctx.GetByIdAsync(id);
        }

        public Tither GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
