using GrpcService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GrpcService.Data
{
    public class WaterWorksDbContext : DbContext
    {
        public WaterWorksDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Meter>().HasIndex(m => m.MeterNumber).IsUnique();
            builder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            builder.Entity<Meter>().HasData( GetMeters() );
            builder.Entity<User>().HasData( GetUsers() );
        }

        public DbSet<Meter> Meters { get; set; }
        public DbSet<User> Users { get; set; }

        private static List<Meter> GetMeters()
        {
            List<Meter> meters = new List<Meter>()
            {
                new Meter()
                {
                    MeterId = 1,
                    MeterNumber = "12345671"
                },
                new Meter()
                {
                    MeterId = 2,
                    MeterNumber = "12345672"
                },
                new Meter()
                {
                    MeterId = 3,
                    MeterNumber = "12345673"
                },
                new Meter()
                {
                    MeterId = 4,
                    MeterNumber = "12345674"
                },
                new Meter()
                {
                    MeterId = 5,
                    MeterNumber = "12345675"
                }
            };

            return meters;
        }

        private static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    UserName = "admin",
                    HashedPassword = "admin"
                },
                new User()
                {
                    UserId = 2,
                    UserName = "user",
                    HashedPassword = "user"
                }
            };

            return users;
        }
    }
}
