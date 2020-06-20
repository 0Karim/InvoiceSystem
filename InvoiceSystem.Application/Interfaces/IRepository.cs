using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InvoiceSystem.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        int Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        int Save();
    }
}
