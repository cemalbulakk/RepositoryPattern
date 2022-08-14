using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;

namespace Product.Infrastructure.Repositories.EfCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ProductDbContext _context;

    public GenericRepository(ProductDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> FindAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).AsNoTracking();
    }

    public T? FindById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public int Create(T entity)
    {
        _context.Add(entity);
        return _context.SaveChanges();
    }

    public T Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(T entity)
    {
        _context.Remove(entity);
        var result = _context.SaveChanges();
        return result > 0;
    }
}