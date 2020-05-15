using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sispar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF.Maps
{
    public class TitheMap : IEntityTypeConfiguration<Tithe>
    {
        public void Configure(EntityTypeBuilder<Tithe> builder)
        {
            // table
            builder.ToTable("TITHE");

            // pk
            builder.HasKey(pk => pk.Id);

            // fields
            builder.Property(c => c.Id)
                .HasColumnName("ID_TITHE")
                .HasColumnType("vachar(36)");
            builder.Property(c => c.RegisterDate)
                .HasColumnName("REGISTER_DATE")
                 .HasColumnType("datetime");
            builder.Property(c => c.ValueContribution)
              .HasColumnName("VALUE_CONTRIBUTION")
              .HasColumnType("float");
            builder.Property(c => c.DateContribution)
              .HasColumnName("DATE_CONTRIBUTION")
              .HasColumnType("datetime");
            builder.Property(c => c.TitherId)
              .HasColumnName("TITHER_ID")
              .HasColumnType("vachar(36)");
        }
    }
}
