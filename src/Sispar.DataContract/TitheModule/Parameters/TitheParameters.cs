using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.DataContract.TitheModule.Parameters
{
    public class TitheParameters
    {
        public decimal ValueContribution { get; set; }
        public DateTime DateContribution { get; set; }
        public Guid TitherId { get; set; }
    }
}
