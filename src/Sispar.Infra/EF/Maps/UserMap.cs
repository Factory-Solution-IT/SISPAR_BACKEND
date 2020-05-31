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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
    
            // table

            // pk
            builder.HasKey(pk => pk.Id);

            // columns
            builder.Property(c => c.Id);
            builder.Property(c => c.Username).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(50);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Active).HasColumnType("smallint");
            builder.Property(c => c.RegisterDate);

            // relationships
        }
    }
}
