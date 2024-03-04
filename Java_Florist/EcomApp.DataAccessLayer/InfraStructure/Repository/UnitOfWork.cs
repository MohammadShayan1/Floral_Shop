using EcomApp.DataAccessLayer.InfraStructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomApp.DataAccessLayer.InfraStructure.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private EshopDataContext _context;
        public ICategoryRepository Category { get; private set; }

        public ICategoryRepository CategoryRepository { get;private set; }

        public IProductRepository productRepository { get; private set; }

        public UnitOfWork(EshopDataContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(context);
            productRepository = new ProductRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
