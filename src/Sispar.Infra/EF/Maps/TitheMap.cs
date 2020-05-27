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

            // pk
            builder.HasKey(pk => pk.Id);

            // fields
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.RegisterDate).IsRequired();
            builder.Property(c => c.ValueContribution).IsRequired();
            builder.Property(c => c.DateContribution).IsRequired().HasColumnType("date");
            builder.Property(c => c.TitherId).IsRequired();

            // relationships
            builder.HasOne(c => c.Tither)
              .WithMany(c => c.Tithes)
              .HasForeignKey(c => c.TitherId);
        }
    }
}
