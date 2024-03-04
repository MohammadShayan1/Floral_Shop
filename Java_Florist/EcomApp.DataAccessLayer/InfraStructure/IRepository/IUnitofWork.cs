using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomApp.DataAccessLayer.InfraStructure.IRepository
{
    public interface IUnitofWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository productRepository { get; }
        void Save();
    }
}
