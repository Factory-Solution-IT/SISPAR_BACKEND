using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.BaseModule
{
    public abstract class DeleteableEntity : Entity
    {
        public bool Deleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
