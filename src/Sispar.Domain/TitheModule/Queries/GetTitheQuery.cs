using Sispar.DataContract.TitheModule.Models;
using Sispar.Domain.BaseModule.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitheModule.Queries
{
    public class GetTitheQuery : Query<TitheModel>
    {
        public Guid Id { get; set; }

        public GetTitheQuery(Guid id)
        {
            Id = id;
        }
    }
}
