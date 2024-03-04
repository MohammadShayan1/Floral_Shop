
using EcomApp.DataAccessLayer.InfraStructure.IRepository;
using EcomApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcomApp.DataAccessLayer.InfraStructure.Reposatory
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EshopDataContext _context;
        private DbSet<T> _dbSet;

        public Repository(EshopDataContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {

            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}
