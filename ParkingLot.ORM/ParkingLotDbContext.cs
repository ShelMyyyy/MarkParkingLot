
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

           /* ValueConverter valueConverter = new ValueConverter<string, string>(
                p2d => string.IsNullOrEmpty(p2d) ? null : p2d.ToArray()[0].ToString(),
                d2p => d2p == null ? "" : ((char)int.Parse(d2p, System.Globalization.NumberStyles.HexNumber)).ToString());

            modelBuilder.Entity<SysMenu>().Property(x => x.MenuIcon).HasConversion(valueConverter);*/
            base.OnModelCreating(modelBuilder);
        }
    }
}
