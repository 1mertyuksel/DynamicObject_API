using DataAccesLayer_DAL_.Concrete;
using EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer_DAL_.Abstract
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _entities;
        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
