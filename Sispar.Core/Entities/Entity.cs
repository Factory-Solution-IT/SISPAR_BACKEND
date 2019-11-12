using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    }
}
