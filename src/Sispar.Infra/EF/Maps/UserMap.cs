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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
    
            // table
            builder.ToTable("USER");

            // pk
            builder.HasKey(pk => pk.Id);

            // columns
            builder.Property(c => c.Id)
                .HasColumnName("USER_ID");
            builder.Property(c => c.Username)
                .IsRequired()
                .HasColumnName("USER_NAME")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar(100)");
            builder.Property(c => c.Active)
                .HasColumnName("ACTIVE")
                .HasColumnType("smallint");
            builder.Property(c => c.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("REGISTER_DATE");

            // relationships
        }
    }
}
