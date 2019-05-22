using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MantenedoresPerfilCliente.Application.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();        

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Get(int id);

        void Add(T entity);

        void Remove(T entity);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        long Count();

        long Count(Expression<Func<T, bool>> predicate);
    }
}
