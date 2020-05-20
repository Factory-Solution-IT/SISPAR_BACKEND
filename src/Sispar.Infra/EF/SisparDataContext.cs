using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sispar.Domain.Entities;

namespace Sispar.Infra.EF
{
    public class SisparDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public SisparDataContext(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tither> Tithers { get; set; }
        public DbSet<Tithe> Tithes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("MyConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.UserMap());
            modelBuilder.ApplyConfiguration(new Maps.TitherMap());
            modelBuilder.ApplyConfiguration(new Maps.TitheMap());

            modelBuilder.Seed();
        }
    }
}