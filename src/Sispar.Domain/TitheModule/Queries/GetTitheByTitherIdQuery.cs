using Sispar.DataContract.TitheModule.Models;
using Sispar.Domain.BaseModule.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Queries
{
    public class GetTitheByTitherIdQuery : Query<IEnumerable<TitheModel>>
    {
        public Guid TitherId { get; set; }

        public GetTitheByTitherIdQuery(Guid titherId)
        {
            TitherId = titherId;
        }
    }
}
