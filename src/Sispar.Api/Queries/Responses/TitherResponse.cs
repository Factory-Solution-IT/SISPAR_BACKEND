using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Queries.Responses
{
    public class TitherResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplent { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int MatiralStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public DateTime? MarriegeDate { get; set; }
        public string NameSpouse { get; set; }
        public DateTime? DateBirthSpouse { get; set; }
    }
}
