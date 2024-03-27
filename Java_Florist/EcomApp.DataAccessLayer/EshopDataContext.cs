using EcomApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomApp.DataAccessLayer
{
    public class EshopDataContext : DbContext
    {
        public EshopDataContext(DbContextOptions<EshopDataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model relationships, constraints, etc.
            // For example:
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Flower)
                .WithMany()
                .HasForeignKey(o => o.Id);
        }
    }
}
