using BanHang.Domain.Models;
using BanHang.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BanHang.Infrastructure
{
    public class BanHangDbContext : DbContext
    {
        public BanHangDbContext(DbContextOptions<BanHangDbContext> options) : base(options)
        {

        }

        public DbSet<List> List { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
