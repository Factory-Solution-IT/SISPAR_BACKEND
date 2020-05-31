using Microsoft.EntityFrameworkCore;
using Sispar.Common.Helpers;
using Sispar.Domain.TitherModule;
using Sispar.Domain.UserModule;
using System;

namespace Sispar.Infra.EF
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = Guid.NewGuid(), Username = "milton", Password = "123456".Encrypt(), FirstName = "Felipe", LastName = "Santos" },
                new User() { Id = Guid.NewGuid(), Username = "felipe", Password = "123456".Encrypt(), FirstName = "Milton", LastName = "Honji" }
                );

            modelBuilder.Entity<Tither>().HasData(
                new Tither()
                {
                    Id = Guid.NewGuid(),
                    Name = "Jose",
                    Address = "rua sem saida",
                    BirthDate = DateTime.UtcNow,
                    CPF = "999.999.999-99",
                    Telephone = "11 9.9999-9999",
                    Cellphone = "11 9.9999-9999",
                    MarriegeDate = DateTime.UtcNow,
                    NameSpouse = "Maria",
                    DateBirthSpouse = DateTime.UtcNow,
                    Active = true
                }
                );
        }
    }
}