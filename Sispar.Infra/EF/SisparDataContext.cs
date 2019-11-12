using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sispar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Infra.EF
{
    public class SisparDataContext: DbContext
    {
        private readonly IConfiguration _config;

        public SisparDataContext(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tither> Tithers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SisparDbConn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.TitherMap());
            modelBuilder.ApplyConfiguration(new Maps.UserMap());

            modelBuilder.Seed();
        }
    }
}
