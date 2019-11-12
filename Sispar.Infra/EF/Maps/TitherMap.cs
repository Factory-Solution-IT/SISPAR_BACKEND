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
            builder.ToTable("TITHER");

            // pk
            builder.HasKey(pk => pk.Id);

            // columns
            builder.Property(c => c.Id)
                .HasColumnName("ID_TITHER");
            builder.Property(c => c.RegisterDate)
               .HasColumnName("REGISTER_DATE")
               .HasColumnType("datetime");
            builder.Property(c => c.Name)
                .HasColumnName("NAME_TITHER")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.Address)
                .HasColumnName("ADDRESS_TITHER")
                .HasColumnType("varchar(200)");
            builder.Property(c => c.BirthDate)
                .HasColumnName("BIRTH_DATE")
                .HasColumnType("date");
            builder.Property(c => c.CPF)
                .HasColumnName("CPF_TITHER")
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Telephone)
                .HasColumnName("TELEPHONE")
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Cellphone)
                .HasColumnName("CELLPHONE")
                .HasColumnType("varchar(20)");
            builder.Property(c => c.MarriegeDate)
                .HasColumnName("MARRIAGE_DATE")
                .HasColumnType("date");
            builder.Property(c => c.NameSpouse)
                .HasColumnName("NAME_SPOUSE")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.DateBirthSpouse)
                .HasColumnName("DATE_BIRTH_SPOUSE")
                .HasColumnType("date");
            builder.Property(c => c.Active)
                .HasColumnName("ACTIVE")
                .HasColumnType("smallint");

            //[Column("MATIRAL_STATUS")]
            //public MatiralStatus MatiralStatus { get; set; }


        // relationships
    }
    }
}
