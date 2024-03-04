using EcomApp.DataAccessLayer.InfraStructure.IRepository;
using EcomApp.DataAccessLayer.InfraStructure.Reposatory;
using EcomApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcomApp.DataAccessLayer.InfraStructure.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private EshopDataContext _context;

        public ProductRepository(EshopDataContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Product product)
        {
            var ProductDb = _context.Products.FirstOrDefault(p=>p.Id==product.Id);
            if (ProductDb!=null)
            {
                ProductDb.Name = product.Name;
                ProductDb.Description = product.Description;
                ProductDb.Price = product.Price;
                ProductDb.CategoryId = product.CategoryId;
                if (ProductDb.ImageURL!=null)
                {
                    ProductDb.ImageURL = product.ImageURL;
                }
            }
         
        }

     
    }
}
