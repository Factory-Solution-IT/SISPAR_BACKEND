using MediatR;
using Microsoft.AspNetCore.Identity;
using Sispar.Api.Commands.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Api.Commands.Requests
{
    public class UpdateTitherRequest : IRequest<UpdateTitherResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
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
