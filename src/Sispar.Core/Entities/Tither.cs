using System;
using System.Collections.Generic;
using Sispar.Domain.Entities.Enums;

namespace Sispar.Domain.Entities
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

        public virtual ICollection<Tithe> Tithes { get; set; } = new List<Tithe>();
    }
}
