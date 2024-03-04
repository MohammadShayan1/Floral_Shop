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
        public DbSet<Reciver> reciver { get; set; }
    }
}
