using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Core.Entities
{
    public class Tither : Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public MatiralStatus MatiralStatus { get; set; }

        public DateTime BirthDate { get; set; }

        public string CPF { get; set; }

        public string Telephone { get; set; }

        public string Cellphone { get; set; }

        public DateTime? MarriegeDate { get; set; }

        public string NameSpouse { get; set; }

        public  DateTime? DateBirthSpouse { get; set; }

        public Boolean Active { get; set; } = true;
    }
}
