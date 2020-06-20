using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InvoiceSystem.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //private readonly IApplicationDbContext context;
        private readonly InvoiceSystemDbContext context;
        private DbSet<T> entities;


        public Repository(InvoiceSystemDbContext _context)
        {
            context = _context;
            entities = _context.Set<T>();
        }


        public int Add(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            return Save();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            Save();
        }

        public IQueryable<T> GetAll()
        {
            return entities.ToList().AsQueryable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public int Save()
        {
            return this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Save();
        }
    }
}
