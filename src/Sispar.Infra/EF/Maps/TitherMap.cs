using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Maps
{
    public class TitherMap : IEntityTypeConfiguration<Tither>
    {
        public void Configure(EntityTypeBuilder<Tither> builder)
        {
            // table

            // pk
            builder.HasKey(pk => pk.Id);

            // columns
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.RegisterDate);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(200);
            builder.Property(c => c.BirthDate).HasColumnType("date");
            builder.Property(c => c.CPF).HasMaxLength(20);
            builder.Property(c => c.Telephone).HasMaxLength(20);
            builder.Property(c => c.Cellphone).HasMaxLength(20);
            builder.Property(c => c.MarriegeDate).HasColumnType("date");
            builder.Property(c => c.NameSpouse).HasMaxLength(100);
            builder.Property(c => c.DateBirthSpouse).HasColumnType("date");
            builder.Property(c => c.Active).HasColumnType("smallint");
            builder.Property(c => c.MatiralStatus).HasColumnType("smallint");
            builder.Property(c => c.AddressNumber).HasMaxLength(20);
            builder.Property(c => c.AddressComplent).HasMaxLength(100);
            builder.Property(c => c.ZipCode).HasMaxLength(9);
            builder.Property(c => c.Neighborhood).HasMaxLength(100);
            builder.Property(c => c.City).HasMaxLength(100);
            builder.Property(c => c.State).HasMaxLength(2);

            // relationships
        }
    }
}
