using Sispar.Domain.TitherModule;
using Sispar.Domain.TitherModule.Abstractions;

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