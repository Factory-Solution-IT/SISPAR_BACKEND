using Sispar.DataContract.UserModule.Models;
using Sispar.Domain.BaseModule.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.UserModule.Queries
{
    public class GetUserQuery : Query<UserModel>
    {
        public Guid Id { get; set; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
}
