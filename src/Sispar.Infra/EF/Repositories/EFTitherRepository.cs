using Sispar.Core.Contracts.Repositories;
using Sispar.Core.Entities;

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