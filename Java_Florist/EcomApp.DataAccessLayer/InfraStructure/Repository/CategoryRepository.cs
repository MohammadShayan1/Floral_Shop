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
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private EshopDataContext _context;

        public CategoryRepository(EshopDataContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Category category)
        {
            var CategoryDb = _context.Categories.FirstOrDefault(c => c.C_Id == category.C_Id);
            if (CategoryDb != null) 
            { 
                CategoryDb.C_Name = category.C_Name;
                CategoryDb.Display_Order   = category.Display_Order;
            }
           
        }

     
    }
}
