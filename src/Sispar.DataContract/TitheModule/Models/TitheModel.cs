using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.DataContract.TitheModule.Models
{
    public class TitheModel
    {
        public Guid Id { get; set; }
        public decimal ValueContribution { get; set; }
        public DateTime DateContribution { get; set; }
        public Guid TitherId { get; set; }
    }
}
