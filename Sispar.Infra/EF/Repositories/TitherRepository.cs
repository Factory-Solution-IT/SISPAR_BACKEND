using Sispar.Core.Contracts;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Repositories
{
    public class TitherRepository : Repository<Tither>, ITitherRepository
    {
        public TitherRepository(SisparDataContext context)
            :base(context)
        {

        }
    }
}
