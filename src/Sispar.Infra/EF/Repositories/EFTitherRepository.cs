using Sispar.Domain.Contracts.Repositories;
using Sispar.Domain.Entities;

namespace Sispar.Infra.EF.Repositories
{
    public class EFTitherRepository : EFRepository<Tither>, ITitherRepository
    {
        public EFTitherRepository(SisparDataContext context)
            : base(context)
        {
        }
    }
}