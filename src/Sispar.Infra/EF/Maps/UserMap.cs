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
            builder.ToTable("USER_");

            // pk
            builder.HasKey(pk => pk.Id);

            // columns
            builder.Property(c => c.Id)
                .HasColumnName("ID_USER");
            builder.Property(c => c.Username)
                .IsRequired()
                .HasColumnName("USERNAME")
                .HasColumnType("varchar(50)");
            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("varchar(50)");
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
