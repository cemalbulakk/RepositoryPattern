using System.Linq.Expressions;

namespace Product.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    T? FindById(int id);
    int Create(T entity);
    T Update(T entity);
    bool Delete(T entity);
}