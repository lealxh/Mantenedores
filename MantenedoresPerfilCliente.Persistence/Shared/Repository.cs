
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MantenedoresPerfilCliente.Persistence.Shared
{
    public class Repository<T> : IRepository<T>  where T : class, IEntity

{
protected readonly IDatabaseContext _database;

public Repository(IDatabaseContext database)
{
_database = database;
}

public IEnumerable<T> GetAll()
{
return _database.Set<T>().AsEnumerable();
}
public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
{
return _database.Set<T>().Where(predicate).AsEnumerable();
}

public T Get(int id)
{
return _database.Set<T>().SingleOrDefault(x => x.Id == id);
}

public void Add(T entity)
{
_database.Set<T>().Add(entity);
}

public void Remove(T entity)
{
_database.Set<T>().Remove(entity);
}

public T SingleOrDefault(Expression<Func<T, bool>> predicate)
{
return _database.Set<T>().SingleOrDefault(predicate);
}

public long Count()
{
    return _database.Set<T>().Count();
}

public long Count(Expression<Func<T, bool>> predicate)
{
        return _database.Set<T>().Count(predicate);
}

}
}
