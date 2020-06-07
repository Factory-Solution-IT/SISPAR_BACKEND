using Sispar.DataContract.TitherModule.Models;
using Sispar.Domain.BaseModule.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.TitherModule.Queries
{
    public class GetTitherQuery : Query<TitherModel>
    {
        public Guid Id { get; set; }

        public GetTitherQuery(Guid id)
        {
            Id = id;
        }
    }
}
