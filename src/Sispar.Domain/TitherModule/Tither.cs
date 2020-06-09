using Sispar.Domain.BaseModule;
using Sispar.Domain.TitheModule;
using Sispar.Domain.TitherModule.Enums;
using System;
using System.Collections.Generic;

namespace Sispar.Domain.TitherModule
{
    public class Tither : DeleteableEntity
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
        public DateTime? DateBirthSpouse { get; set; }
        public bool Active { get; set; } = true;
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Tithe> Tithes { get; set; }// = new List<Tithe>();

        public Tither()
        {

        }

        public Tither(string name, string address, MatiralStatus matiralStatus, DateTime birthDate, 
            string cPF, string telephone, string cellphone, DateTime? marriegeDate, string nameSpouse, 
            DateTime? dateBirthSpouse, bool active, string addressNumber, string addressComplement, 
            string zipCode, string neighborhood, string city, string state)
        {
            Name = name;
            Address = address;
            MatiralStatus = matiralStatus;
            BirthDate = birthDate;
            CPF = cPF;
            Telephone = telephone;
            Cellphone = cellphone;
            MarriegeDate = marriegeDate;
            NameSpouse = nameSpouse;
            DateBirthSpouse = dateBirthSpouse;
            Active = active;
            AddressNumber = addressNumber;
            AddressComplement = addressComplement;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public void Delete()
        {
            Deleted = true;
            DeletedAt = DateTime.Now;
        }
    }
}