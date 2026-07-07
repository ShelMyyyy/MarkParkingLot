
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingLot.Entity;
using System.IO;

namespace ParkingLot.ORM
{
    public class UserDbContext : DbContext
    {
        public DbSet<UsersEntity> Users { get; set; }

        public UserDbContext() { }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var basePath = Path.GetDirectoryName(typeof(UserDbContext).Assembly.Location)!;
                var config = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
