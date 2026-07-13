
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingLot.Models.DataBaseModels;
using System.IO;
using System.Reflection;

namespace ParkingLot.ORM
{
    public class ParkingLotDbContext : DbContext
    {
        public DbSet<SysUsers> Users { get; set; }
        public DbSet<SysMenu> Menus { get; set; }

        public ParkingLotDbContext() { }

        public ParkingLotDbContext(DbContextOptions<ParkingLotDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var basePath = Path.GetDirectoryName(typeof(ParkingLotDbContext).Assembly.Location)!;
                var config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SysMenu).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
