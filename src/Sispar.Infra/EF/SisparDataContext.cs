using Microsoft.EntityFrameworkCore;
using Sispar.Domain.TitheModule;
using Sispar.Domain.TitherModule;
using Sispar.Domain.UserModule;

namespace Sispar.Infra.EF
{
    public class SisparDataContext : DbContext
    {
        //        private readonly IConfiguration _config;

        public SisparDataContext()
        {
        }

        // public SisparDataContext(IConfiguration config)
        // {
        //     _config = config;
        //     Database.EnsureCreated();
        // }

        public DbSet<User> Users { get; set; }
        public DbSet<Tither> Tithers { get; set; }
        public DbSet<Tithe> Tithes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql5059.site4now.net;Database=DB_A5E01E_sisparhomolog;User Id=DB_A5E01E_sisparhomolog_admin;Password=metal001;");
            //optionsBuilder.UseSqlServer(_config.GetConnectionString("MyConnection"));
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