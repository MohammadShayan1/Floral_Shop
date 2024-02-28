
using Microsoft.EntityFrameworkCore;

namespace EcomApp.DataAccessLayer
{
    public class EshopDataContext : DbContext
    {
        public EshopDataContext(DbContextOptions<EshopDataContext> options) : base(options)
        {

        }

        public DbSet<Bouque> Bouques { get; set; }
        public DbSet<Customer> customers  { get; set; }

        public DbSet<Reiver> reivers { get; set; }



    }
}
