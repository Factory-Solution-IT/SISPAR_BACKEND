using Sispar.Domain.Contracts;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Repositories
{
    public class EFTitherRepository : EFRepository<Tither>, ITitherRepository
    {
        public EFTitherRepository(SisparDataContext context)
            :base(context)
        {

        }
    }
}
