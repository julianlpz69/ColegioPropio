using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
     {
        private readonly ColegioDBContext _context;
    
        public GenericRepository(ColegioDBContext context)
        {
            _context = context;
         }
    
         public virtual void Add(T entity)
         {
             _context.Set<T>().Add(entity);
         }
    
         public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
         {
             return _context.Set<T>().Where(expression);
         }
    
         public async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search, string Nombre)
        {
            var query = _context.Set<T>().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => EF.Property<string>(p, $"{Nombre}").ToLower().Contains(search.ToLower()));
            }
            query = query.OrderBy(p => EF.Property<int>(p, "Id"));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                    /* .Include(u =>u.Proveedor) */
                                    .Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return (totalRegistros, registros);
        }

    
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    
        public virtual Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    
        public virtual void Update(T entity)
        {
            _context.Set<T>()
                .Update(entity);
        }
    }
}