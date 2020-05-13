using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sispar.Domain.Entities;
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

        // public DbSet<User> Users { get; set; }
        public DbSet<Tither> Tithers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_config.GetConnectionString("SisparDbConn"));
            optionsBuilder.UseSqlServer("Server=sql5059.site4now.net;Database=DB_A5E01E_sisparhomolog;User Id=DB_A5E01E_sisparhomolog_admin;Password=metal001;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.TitherMap());
            // modelBuilder.ApplyConfiguration(new Maps.UserMap());

            modelBuilder.Seed();
        }
    }
}
