using Core.Intarfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    class GenericRepo<T> : IGenericRepo<T> where T: class
    {
        private readonly DataContext _context;

        private DbSet<T> table = null;

        public GenericRepo( DataContext context )
        {
            _context = context;
            
            table = _context.Set<T>();
        }

        
        public void delete(T entity)
        {
            table.Remove(entity);
        }

        public IEnumerable<T> getAll()
        {
            return table.ToList();
        }

        public T GetBYId(object id)
        {
            return table.Find(id);
        }

        public void insert(T entity)
        {
            table.Add(entity);
        }

        public void update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified; 
        }
    }
}
