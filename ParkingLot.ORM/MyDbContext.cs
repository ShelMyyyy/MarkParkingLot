
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingLot.Entity;
using System.IO;

namespace ParkingLot.ORM
{
    public class MyDbContext : DbContext
    {
        public DbSet<UsersEntity> Users { get; set; }

        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var basePath = Path.GetDirectoryName(typeof(MyDbContext).Assembly.Location)!;
                var config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

    }
}
