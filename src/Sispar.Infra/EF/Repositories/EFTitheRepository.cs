using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;

namespace Sispar.Infra.EF.Repositories
{
    public class EFTitheRepository : EFRepository<Tithe>, ITitheRepository
    {
        public EFTitheRepository(SisparDataContext context) : base(context)
        {
        }
    }
}