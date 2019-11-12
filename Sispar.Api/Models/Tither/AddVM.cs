using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Models.Tither
{
    public class AddVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public DateTime Marriegedate { get; set; }
        public string NameSpouse { get; set; }
        public DateTime DatebirthSpouse { get; set; }
    }
}
