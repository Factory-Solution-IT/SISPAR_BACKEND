using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Entities
{
    public enum MatiralStatus 
    {
        [Description("Solteiro")]
        Solteiro = 1,

        [Description("Casado")]
        Casado = 2,

        [Description("Viúvo")]
        Viuvo = 3,

        [Description("Divorciado")]
        Divorciado = 4
    }
}
